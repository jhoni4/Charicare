using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Charicare2.Data;
using Charicare2.Models.AppViewModels;
using Microsoft.EntityFrameworkCore;

namespace Charicare2.Controllers
{
    public class HomeController : Controller
    {
        private ApplicationDbContext context;

        //Constructor functions that takes context 
        //and sets them to the private variables above

        public HomeController(ApplicationDbContext ctx)
        {
            context = ctx;
        }

        // GET: Donate
        public async Task<IActionResult> Index()
        {
            var model = new DonateTypeListViewModel(context);
            model.DonateTypes = await context.DonateType.ToListAsync();

            return View(model);
        }
   

        public IActionResult About()
        {
            ViewData["Message"] = "Your application description page.";

            return View();
        }

        public IActionResult Contact()
        {
            ViewData["Message"] = "Your contact page.";

            return View();
        }

        public IActionResult Error()
        {
            return View();
        }
    }
}
