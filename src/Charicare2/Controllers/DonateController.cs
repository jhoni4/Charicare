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

        //Form CLOTHES Donation form/Index 
        public IActionResult ClothesIndex()
        {
            //creates new user first then new clothes donation
            if (ActiveUser.Instance.User == null)
            {
                return RedirectToAction("UserIndex", "User");
            }

             DonateClothesIndexViewModel model = new DonateClothesIndexViewModel();
             model.DonateTypeId = ActiveUser.Instance.DonateTypeId;

            return View(model);
        }

        //Form MONEY Donation Form/Index
        public IActionResult MoneyIndex()
        {
            if (ActiveUser.Instance.User == null)
            {
                return RedirectToAction("UserIndex", "User");
            }

            DonateMoneyIndexViewModel model = new DonateMoneyIndexViewModel();
             model.DonateTypeId = ActiveUser.Instance.DonateTypeId;

            return View(model);
        }

        //Form MEDICAL Donation Form/Index
        public IActionResult MedicalIndex()
        {
            if (ActiveUser.Instance.User == null)
            {
                return RedirectToAction("UserIndex", "User");
            }

            DonateMedicalIndexViewModel model = new DonateMedicalIndexViewModel();
            model.DonateTypeId = ActiveUser.Instance.DonateTypeId;

            return View(model);
        }

        ////Form GOODS Donation Index
        public IActionResult GoodsIndex()
        {
            if (ActiveUser.Instance.User == null)
            {

                return RedirectToAction("UserIndex", "User");
            }

            DonateGoodsIndexViewModel model = new DonateGoodsIndexViewModel();
            model.DonateTypeId = ActiveUser.Instance.DonateTypeId;

            return View(model);
        }

        //Creates NEW DONATION for all types of donation
        public async Task<IActionResult> DonateCreate(NewDonateCreateViewModel model, [FromRoute] int Id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            model.UserId = ActiveUser.Instance.User.UserId;
            Donate d = new Donate();
            d.DonateTypeId = ActiveUser.Instance.DonateTypeId;
            d.Name = model.Donate.Name;
            d.Note = model.Donate.Note;
            d.Value = model.Donate.Value;
            d.UserId = model.UserId;

            context.Donate.Add(d);
            try
            {
                context.SaveChanges();
                return RedirectToAction("ThankYou", "Donate");
            }

            catch (DbUpdateException)
            {
                return RedirectToAction("DonateCreate", "Donate");
            }

        }


        public IActionResult ThankYou(NewDonateCreateViewModel model)
        {
            model.Donator = ActiveUser.Instance.User.FullName;
            return View(model);
        }


    }
}
