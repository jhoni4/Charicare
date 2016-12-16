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
            Donate d = new Donate();
              if (context.User.Where(e => e.FullName == model.User.FullName && e.Email == model.User.Email).SingleOrDefault() != null)
                {
                    User u = new User();
                     u = context.User.Where(e => e.FullName == model.User.FullName && e.Email == model.User.Email).SingleOrDefault();
                d.DonateTypeId = 1;
                d.Name = model.Donate.Name;
                d.Note = model.Donate.Note;
                d.Value = model.Donate.Value;
                d.UserId = u.UserId;

                var LastPerson = u.FullName;


                context.Donate.Add(d);
                context.SaveChanges();
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

                var LastPerson = u.FullName;
                context.User.Add(u);
                context.SaveChanges();

                d.DonateTypeId = 1;
                d.Name = model.Donate.Name;
                d.Note = model.Donate.Note;
                d.Value = model.Donate.Value;
                d.UserId = context.User.Where(e => e.FullName == model.User.FullName && e.Email == model.User.Email).SingleOrDefault().UserId;

                context.Donate.Add(d);
                context.SaveChanges();

            };

            context.SaveChanges();
            return RedirectToAction("ThankYou", "Donate");


            //if (!ModelState.IsValid)
            //{
            //    return RedirectToAction("ClothesIndex", "Donate");
            //}

            //try
            //{
            //    context.SaveChanges();
            //    return RedirectToAction("Index", "Home");
            //}

            //catch (DbUpdateException)
            //{
            //    return RedirectToAction("ClothesIndex", "Donate");
            //}
        }

        //Form Goods Donation Index
        public async Task<IActionResult> GoodsIndex()
        {
            DonateGoodsIndexViewModel model = new DonateGoodsIndexViewModel(context);

            return View(model);
        }

        //Creates new Goods Donation 
        public async Task<IActionResult> GoodsCreate(GoodsCreateViewModel model)
        {
            Donate d = new Donate();
            if (context.User.Where(e => e.FullName == model.User.FullName && e.Email == model.User.Email).SingleOrDefault() != null)
            {
                User u = new User();
                u = context.User.Where(e => e.FullName == model.User.FullName && e.Email == model.User.Email).SingleOrDefault();
                d.DonateTypeId = 3;
                d.Name = model.Donate.Name;
                d.Note = model.Donate.Note;
                d.Value = model.Donate.Value;
                d.UserId = u.UserId;

                context.Donate.Add(d);
                context.SaveChanges();
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

                context.User.Add(u);
                context.SaveChanges();

                d.DonateTypeId = 3;
                d.Name = model.Donate.Name;
                d.Note = model.Donate.Note;
                d.Value = model.Donate.Value;
                d.UserId = context.User.Where(e => e.FullName == model.User.FullName && e.Email == model.User.Email).SingleOrDefault().UserId;

                context.Donate.Add(d);
                context.SaveChanges();

            };

            context.SaveChanges();
            return RedirectToAction("Index", "Home");


            //if (!ModelState.IsValid)
            //{
            //    return RedirectToAction("ClothesIndex", "Donate");
            //}

            //try
            //{
            //    context.SaveChanges();
            //    return RedirectToAction("Index", "Home");
            //}

            //catch (DbUpdateException)
            //{
            //    return RedirectToAction("ClothesIndex", "Donate");
            //}
        }
        public async Task<IActionResult> MedicalIndex()
        {
            var model = new DonateMedicalIndexViewModel(context);

            return View(model);
        }
        //Creates Medical Donation Form/Index
        public async Task<IActionResult> MedicalCreate(MedicalCreateViewModel model)
        {
            Donate d = new Donate();
            if (context.User.Where(e => e.FullName == model.User.FullName && e.Email == model.User.Email).SingleOrDefault() != null)
            {
                User u = new User();
                u = context.User.Where(e => e.FullName == model.User.FullName && e.Email == model.User.Email).SingleOrDefault();
                d.DonateTypeId = 4;
                d.Name = model.Donate.Name;
                d.Note = model.Donate.Note;
                d.Value = model.Donate.Value;
                d.UserId = u.UserId;

                context.Donate.Add(d);
                context.SaveChanges();
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

                context.User.Add(u);
                context.SaveChanges();

                d.DonateTypeId = 4;
                d.Name = model.Donate.Name;
                d.Note = model.Donate.Note;
                d.Value = model.Donate.Value;
                d.UserId = context.User.Where(e => e.FullName == model.User.FullName && e.Email == model.User.Email).SingleOrDefault().UserId;

                context.Donate.Add(d);
                context.SaveChanges();

            };

            context.SaveChanges();
            return RedirectToAction("Index", "Home");


            //if (!ModelState.IsValid)
            //{
            //    return RedirectToAction("ClothesIndex", "Donate");
            //}

            //try
            //{
            //    context.SaveChanges();
            //    return RedirectToAction("Index", "Home");
            //}

            //catch (DbUpdateException)
            //{
            //    return RedirectToAction("ClothesIndex", "Donate");
            //}
        }
        public async Task<IActionResult> MoneyIndex()
        {
            var model = new DonateMoneyIndexViewModel(context);

            return View(model);
        }
        //Creates Money Donation Form/Index
        public async Task<IActionResult> MoneyCreate(MoneyCreateViewModel model)
        {
            Donate d = new Donate();
            if (context.User.Where(e => e.FullName == model.User.FullName && e.Email == model.User.Email).SingleOrDefault() != null)
            {
                User u = new User();
                u = context.User.Where(e => e.FullName == model.User.FullName && e.Email == model.User.Email).SingleOrDefault();
                d.DonateTypeId = 2;
                d.Name = model.Donate.Name;
                d.Note = model.Donate.Note;
                d.Value = model.Donate.Value;
                d.UserId = u.UserId;

                context.Donate.Add(d);
                context.SaveChanges();
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

                context.User.Add(u);
                context.SaveChanges();

                d.DonateTypeId = 2;
                d.Name = model.Donate.Name;
                d.Note = model.Donate.Note;
                d.Value = model.Donate.Value;
                d.UserId = context.User.Where(e => e.FullName == model.User.FullName && e.Email == model.User.Email).SingleOrDefault().UserId;

                context.Donate.Add(d);
                context.SaveChanges();

            };

            context.SaveChanges();
            return RedirectToAction("Index", "Home");


            if (!ModelState.IsValid)
            {
                return RedirectToAction("MoneyIndex", "Donate");
            }

            try
            {
                context.SaveChanges();
                return RedirectToAction("Index", "Home");
            }

            catch (DbUpdateException)
            {
                return RedirectToAction("MoneyIndex", "Donate");
            }
        }

        public IActionResult ThankYou(ClothCreateViewModel model)
        {
            var Donator = model.LastPerson.SingleOrDefault();

            return View(model);
        }


    }
}
