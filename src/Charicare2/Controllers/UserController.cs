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
        public async Task<IActionResult> Index()
        {
            var model = new UserFormViewModel();

            return View(model);
        }

        //public async Task<IActionResult> Create()
        //{
        //    var model = new UserFormViewModel();

        //    return View(model);
        //}

        public async Task<IActionResult> Create(User User)
        {
            UserCreateViewModel model = new UserCreateViewModel(context);

            if (!ModelState.IsValid)
            {
                return RedirectToAction("Create", "User");
            }

            context.Add(User);

            try
            {
                context.SaveChanges();

                return RedirectToAction("Index", "Donate");
            }

            catch (DbUpdateException)
            {
                return RedirectToAction("Create", "User");
            }
        }

    }
}
