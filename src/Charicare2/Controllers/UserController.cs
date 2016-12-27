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
    public class UserController : Controller
    {

        private ApplicationDbContext context;

        //Constructor functions that takes context 
        //and sets them to the private variables above

        public UserController(ApplicationDbContext ctx)
        {
            context = ctx;
        }

        //// GET: Donate
        public IActionResult UserIndex([FromRoute]int Id)
        {
            ActiveUser.Instance.User = null;
            ActiveUser.Instance.DonateTypeId = 0;
            UserFormViewModel model = new UserFormViewModel();

            if (ActiveUser.Instance.User == null)
            {
                model.DonateTypeId = Id;
                return View(model);
            }

            model.UserId =  ActiveUser.Instance.User.UserId;
            return RedirectToAction("Index", "Donate");
        }

        [HttpPost]
        public async Task<IActionResult> UserCreate(UserFormViewModel model, [FromRoute]int Id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (context.User.Where(e => e.FullName == model.User.FullName && e.Email == model.User.Email).SingleOrDefault() != null)
            {
                User u = new User();
                u = await context.User.Where(e => e.FullName == model.User.FullName && e.Email == model.User.Email).SingleOrDefaultAsync();
                model.DonateTypeId = Id;

                var LastPerson = u.FullName;
                ActiveUser.Instance.User = u;
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
                User u = new User();
                u.FullName = model.User.FullName;
                u.Email = model.User.Email;
                u.Street = model.User.Street;
                u.City = model.User.City;
                u.State = model.User.State;
                u.Telephone = model.User.Telephone;
                model.DonateTypeId = Id;

                context.User.Add(u);
                context.SaveChanges();
               
                ActiveUser.Instance.User = u;
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
                return RedirectToAction("UserIndex", "User");
            }

            catch (DbUpdateException)
            {
                return RedirectToAction("UserIndex", "User");
            }
        }

    }

}
