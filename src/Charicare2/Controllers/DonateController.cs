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
        //Creates new Goods Donation
        public async Task<IActionResult> Index()
        {
            var model = new DonateTypeListViewModel(context);
            model.DonateTypes = await context.DonateType.ToListAsync();

            return View(model);
        }

        public async Task<IActionResult> ClothesIndex()
        {
            DonateClothesIndexViewModel model = new DonateClothesIndexViewModel(context);

            return View(model);
        }

        //Creates Clothes Donation Form/Index
        public async Task<IActionResult> ClothesCreate(ClothCreateViewModel model)
        {
            User u = new User();
            Donate d = new Donate();
            if (model.User.Equals(context.User.Where(e => e.FullName == model.User.FullName )))
            {

                u = context.User.Where(e => e.FullName == model.User.FullName && e.City == model.User.City && e.Email == model.User.Email && e.State == model.User.State && e.Telephone == model.User.Telephone && e.Street == model.User.Street).SingleOrDefault();
                d.DonateTypeId = 1;
                d.Name = model.Donate.Name;
                d.Note = model.Donate.Note;
                d.Value = model.Donate.Value;
                d.UserId = u.UserId;

            }
            else
            {
                u.FullName = model.User.FullName;
                u.Email = model.User.Email;
                u.Street = model.User.Street;
                u.City = model.User.City;
                u.State = model.User.State;
                u.Telephone = model.User.Telephone;

                context.User.Add(u);
                context.SaveChanges();

                d.DonateTypeId = 1;
                d.Name = model.Donate.Name;
                d.Note = model.Donate.Note;
                d.Value = model.Donate.Value;
                d.UserId = context.User.Where(e => e.FullName == model.User.FullName && e.City == model.User.City && e.Email == model.User.Email && e.State == model.User.State && e.Telephone == model.User.Telephone && e.Street == model.User.Street).SingleOrDefault().UserId;
                


            };

            context.Donate.Add(d);
            context.SaveChanges();


            if (!ModelState.IsValid)
            {
                return RedirectToAction("ClothesIndex", "Donate");
            }

            try
            {
                context.SaveChanges();
                return RedirectToAction("Index", "Home");
            }

            catch (DbUpdateException)
            {
                return RedirectToAction("ClothesIndex", "Donate");
            }
        }

        //Creates Goods Donation Form/Index
        public async Task<IActionResult> GoodsIndex()
        {
            DonateGoodsIndexViewModel model = new DonateGoodsIndexViewModel(context);

            return View(model);
        }

        //Creates new Goods Donation 
        public IActionResult GoodsCreate(Donate Donate, User User)
        {
            GoodsCreateViewModel model = new GoodsCreateViewModel(context);

            if (!ModelState.IsValid)
            {
                return RedirectToAction("GoodsIndex", "Donate");
            }

            context.Add(Donate);
            context.Add(User);

            try
            {
                context.SaveChanges();
                return RedirectToAction("Index", "Home");
            }

            catch (DbUpdateException)
            {
                return RedirectToAction("GoodsIndex", "Donate");
            }
        }
        public async Task<IActionResult> MedicalIndex()
        {
            var model = new DonateMedicalIndexViewModel(context);

            return View(model);
        }
        public async Task<IActionResult> MoneyIndex()
        {
            var model = new DonateMoneyIndexViewModel(context);

            return View(model);
        }
       

    }
}
