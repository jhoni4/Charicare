using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Charicare2.Models.AppViewModels;
using Charicare2.Data;
using Microsoft.EntityFrameworkCore;

namespace Charicare2.Controllers
{
    public class DashboardController : Controller
    {
        private ApplicationDbContext context;

        //Constructor functions that takes context 
        //and sets them to the private variables above

        public DashboardController(ApplicationDbContext ctx)
        {
            context = ctx;
        }

        public async Task<IActionResult> Index()
        {
            DashboardListViewModel model = new DashboardListViewModel(context);
            model.DonateTypes = await context.DonateType.ToListAsync();
            model.donates = await context.Donate.ToListAsync();
            model.donners = await context.User.ToListAsync();

            return View(model);
        }

        //public async Task<IActionResult> Detail(int Id1, int Id2)
        //{
        //    var model = new DashboardListViewModel(context);
        //    model.DonateTypes = await context.DonateType.ToListAsync();
        //    var donates = context.Donate
        //                    .Where(s => s.DonateTypeId == Id1);
        //    var donners = context.User
        //                    .Where(s => s.UserId == Id2);
        //    return View(model);
        //}
    }
}