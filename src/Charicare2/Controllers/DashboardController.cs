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
            var ClothDonationList = model.donates
                .Where(l => l.DonateTypeId == 1).ToList()
                .OrderBy(c => c.Name);
            model.TotalCountOfClothesDonates = ClothDonationList.Count();
            var MoneyDonationList = model.donates
                .Where(l => l.DonateTypeId == 2).ToList()
                .OrderBy(c => c.Name);
            model.TotalCountOfMoneyDonates = MoneyDonationList.Count();
            var GoodsDonationList = model.donates
                .Where(l => l.DonateTypeId == 3).ToList()
                .OrderBy(c => c.Name);
            model.TotalCountOfGoodsDonates = GoodsDonationList.Count();
            var MedicalDonationList = model.donates
                .Where(l => l.DonateTypeId == 4).ToList()
                .OrderBy(c => c.Name);
            model.TotalCountOfMedicalDonates = MedicalDonationList.Count();

            ////To get Total amount of money donated
            model.TotalAmontOfMoney = MoneyDonationList.Sum(x => x.Value);



            return View(model);
        }

    }
}