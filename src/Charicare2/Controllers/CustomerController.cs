using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Charicare2.Data;
using Charicare2.Models.AppViewModels;
using Charicare2.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace Charicare2.Controllers
{
    public class CustomerController : Controller
    {

        private ApplicationDbContext context;

        //Constructor functions that takes context 
        //and sets them to the private variables above

        public CustomerController(ApplicationDbContext ctx)
        {
            context = ctx;
        }

        //// GET: Donate
        public IActionResult CustomerIndex([FromRoute]int Id)
        {
            ActiveUser.Instance.Customer = null;
            ActiveUser.Instance.DonateTypeId = 0;
            CustomerFormViewModel model = new CustomerFormViewModel();

            if (ActiveUser.Instance.Customer == null)
            {
                model.DonateTypeId = Id;
                return View(model);
            }

            model.CustomerId =  ActiveUser.Instance.Customer.CustomerId;
            return RedirectToAction("Index", "Donate");
        }

        [HttpPost]
        public async Task<IActionResult> CustomerCreate(CustomerFormViewModel model, [FromRoute]int Id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (context.Customer.Where(e => e.FirstName == model.Customer.FirstName && e.Email == model.Customer.Email).SingleOrDefault() != null)
            {
                Customer u = new Customer();
                u = await context.Customer.Where(e => e.FirstName == model.Customer.FirstName && e.Email == model.Customer.Email).SingleOrDefaultAsync();
                model.DonateTypeId = Id;

                //var LastPerson = u.FirstName;
                ActiveUser.Instance.Customer = u;
                ActiveUser.Instance.DonateTypeId = Id;

                switch (ActiveUser.Instance.DonateTypeId)
                {
                    case 1:
                        return RedirectToAction("ClothesIndex", "Donate");
                    case 2:
                        return RedirectToAction("MoneyIndex", "Donate");
                    case 3:
                        return RedirectToAction("GoodsIndex", "Donate");
                    case 4:
                        return RedirectToAction("MedicalIndex", "Donate");
                    default:
                        Console.WriteLine("Default case");
                        break;
                }
            }
            else
            {
                Customer u = new Customer();
                u.FirstName = model.Customer.FirstName;
                u.LastName = model.Customer.LastName;
                u.Email = model.Customer.Email;
                u.Street = model.Customer.Street;
                u.City = model.Customer.City;
                u.State = model.Customer.State;
                u.Telephone = model.Customer.Telephone;
                model.DonateTypeId = Id;

                context.Customer.Add(u);
                context.SaveChanges();
               
                ActiveUser.Instance.Customer = u;
                ActiveUser.Instance.DonateTypeId = Id;

                switch (ActiveUser.Instance.DonateTypeId)
                {
                    case 1:
                        return RedirectToAction("ClothesIndex", "Donate");
                    case 2:
                        return RedirectToAction("MoneyIndex", "Donate");
                    case 3:
                        return RedirectToAction("GoodsIndex", "Donate");
                    case 4:
                        return RedirectToAction("MedicalIndex", "Donate");
                    default:
                        Console.WriteLine("Default case");
                        break;
                }
            }

            try
            {
                context.SaveChanges();
                return RedirectToAction("CustomerIndex", "Customer");
            }

            catch (DbUpdateException)
            {
                return RedirectToAction("CustomerIndex", "Customer");
            }
        }

    }

}
