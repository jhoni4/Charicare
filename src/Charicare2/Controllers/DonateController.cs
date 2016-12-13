using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Charicare2.Data;
using Charicare2.Models;
using Microsoft.AspNetCore.Identity;
using Charicare2.Models.AppViewModels;

namespace Charicare2.Controllers
{
    public class DonateController : Controller
    {
        private ApplicationDbContext context;

        //Constructor functions that takes context 
        //and sets them to the private variables above
        
        public DonateController(ApplicationDbContext ctx)
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

        public async Task<IActionResult> Clothes()
        {
            var model = new DonateClothesIndexViewModel(context);

            return View(model);
        }
        public async Task<IActionResult> Goods()
        {
            var model = new DonateGoodsIndexViewModel(context);

            return View(model);
        }
        public async Task<IActionResult> Medical()
        {
            var model = new DonateMedicalIndexViewModel(context);

            return View(model);
        }
        public async Task<IActionResult> Money()
        {
            var model = new DonateMoneyIndexViewModel(context);

            return View(model);
        }
        //public async Task<IActionResult> Create(User User)
        //{
        //    var model = new ClothCreateViewModel(context);

        //    return View(model);
        //}
        public async Task<IActionResult> Create(ClothesDonate ClothesDonate, User User)
        {


            if (!ModelState.IsValid)
            {
                return RedirectToAction("Create", "Donate");
            }

            context.Add(ClothesDonate);
            context.Add(User);

            try
            {
                context.SaveChanges();

                return RedirectToAction("Index", "Donate");
            }

            catch (DbUpdateException)
            {
                return RedirectToAction("Create", "Donate");
            }
        }

    }
}
