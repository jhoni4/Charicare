using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Charicare2.Data;
using Charicare2.Models.AppViewModels;
using Charicare2.Models;
using Microsoft.EntityFrameworkCore;

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
        public async Task<IActionResult> UserIndex()
        {
            var model = new UserFormViewModel();

            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> Create(UserFormViewModel model)
        {
            if (context.User.Where(e => e.FullName == model.User.FullName && e.Email == model.User.Email).SingleOrDefault() != null)
            {
                User u = new User();
                u = context.User.Where(e => e.FullName == model.User.FullName && e.Email == model.User.Email).SingleOrDefault();

                var LastPerson = u.FullName;

                ActiveUser.Instance.User = u;

                return RedirectToAction("ClothesIndex", "Donate");
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

                //var LastPerson = u.FullName;
                context.User.Add(u);
                context.SaveChanges();
               
            ActiveUser.Instance.User = u;
            };


            context.SaveChanges();
            return RedirectToAction("ClothesIndex", "Donate");
        }
    }

}
