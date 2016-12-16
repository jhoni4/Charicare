using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Charicare2.Models.AppViewModels;
using Charicare2.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc.Rendering;
using Charicare2.Models;
using Newtonsoft.Json.Linq;

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

        public IActionResult Index()
        {
            DashboardListViewModel model = new DashboardListViewModel(context);
            model.DonateTypes = context.DonateType.ToList();
            model.donates = context.Donate.ToList();
            model.donners = context.User.ToList();

            ////To get count of donners for earch donate type
            var ClothDonationList = model.donates.Where(l => l.DonateTypeId == 1).ToList();
            model.TotalCountOfClothesDonners = ClothDonationList.Count();
            var MoneyDonationList = model.donates.Where(l => l.DonateTypeId == 2).ToList();
            model.TotalCountOfMoneyDonners = MoneyDonationList.Count();
            var GoodsDonationList = model.donates.Where(l => l.DonateTypeId == 3).ToList();
            model.TotalCountOfGoodsDonners = GoodsDonationList.Count();
            var MedicalDonationList = model.donates.Where(l => l.DonateTypeId == 4).ToList();
            model.TotalCountOfMedicalDonners = MedicalDonationList.Count();

            ////To get Total amount of money donated
            model.TotalAmontOfMoney = MoneyDonationList.Sum(x => x.Value);



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