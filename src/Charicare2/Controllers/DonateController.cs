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
using Charicare2.Configuration;
using Microsoft.Extensions.Options;

// "/**",
// " * Class: DonateController",
// " * Purpose: is a Donate constructor that enables the customer to create new Donates by grouping together variables of other types, methods and events. and lets you view Donates and Donatetypes.",
// " * Author: YONATAN MOLLA",
// " * Methods:",
// " *   Index() - When the page loads user be able to see list of all donatetypes options to choose from",
// " *   ClothesIndex() - When a user clicks on Clothes  donatetype link on the home page he will be able to see a customer form to fill out for Clothesdonation",
// " *   GoodsIndex() - When a user clicks on Goods donatetype link on the home page he will be able to see a customer form to fill out for Goodsdonation",
// " *   MedicalIndex() - When a user clicks on Medical  donatetype link on the home page he will be able to see a customer form to fill out for Medicaldonation",
// " *   MoneyIndex() - When a user clicks on Money  donatetype link on the home page he will be able to see a customer form to fill out for Moneydonation",
// " *   StripeForm(NewDonateCreateViewModel model, [FromRoute] int Id) - When User on MoneyDonation  page  choose to pay using stripe and clicks on button STRIPEPAY then page takes the customerId of clicking customer saves the detail from the previous form to the database then redirect them to strime card form",
// " *   Charge() - When User clicks on pay on stripe card form the detail will be submited to stripe.com",
// " */"



namespace Charicare2.Controllers
{
    public class DonateController : Controller
    {
        private ApplicationDbContext context;
        private PaymentSettings _paymentSettings;


        //Constructor functions that takes context 
        //and sets them to the private variables above

        public DonateController(ApplicationDbContext ctx, IOptions<PaymentSettings> paymentSettings)
        {
            context = ctx;
            _paymentSettings = paymentSettings.Value;
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
            //creates new Customer first then new clothes donation
            if (ActiveUser.Instance.Customer == null)
            {
                return RedirectToAction("CustomerIndex", "Customer");
            }

             DonateClothesIndexViewModel model = new DonateClothesIndexViewModel();
             model.DonateTypeId = ActiveUser.Instance.DonateTypeId;

            return View(model);
        }

        //Form MONEY Donation Form/Index
        public IActionResult MoneyIndex()
        {
            if (ActiveUser.Instance.Customer == null)
            {
                return RedirectToAction("CustomerIndex", "Customer");
            }

            DonateMoneyIndexViewModel model = new DonateMoneyIndexViewModel();
             model.DonateTypeId = ActiveUser.Instance.DonateTypeId;

            return View(model);
        }

        public IActionResult StripeForm(NewDonateCreateViewModel model, [FromRoute] int Id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            ViewBag.StripeKey = _paymentSettings.StripePublicKey;
            model.CustomerId = ActiveUser.Instance.Customer.CustomerId;
            Donate d = new Donate();
            d.DonateTypeId = ActiveUser.Instance.DonateTypeId;
            d.Name = model.Donate.Name;
            d.Note = model.Donate.Note;
            d.Value = model.Donate.Value;
            d.CustomerId = model.CustomerId;

            context.Donate.Add(d);
            try
            {
                context.SaveChanges();
                return RedirectToAction("StripeCheckout", "Donate");
            }

            catch (DbUpdateException)
            {
                return RedirectToAction("StripeForm", "Donate");
            }
        }

        // GET: /Donate/StripeCheckout
        public IActionResult StripeCheckout()
        {
            ViewBag.StripeKey = _paymentSettings.StripePublicKey;
            StripeFormViewModel model = new StripeFormViewModel();
            return View(model);
        }

        // POST: /Donate/Charge
        public IActionResult Charge()
        {
            ViewBag.StripeKey = _paymentSettings.StripePublicKey;
            return RedirectToAction("ThankYou", "Donate");
        }
        


        //Form MEDICAL Donation Form/Index
        public IActionResult MedicalIndex()
        {
            if (ActiveUser.Instance.Customer == null)
            {
                return RedirectToAction("CustomerIndex", "Customer");
            }

            DonateMedicalIndexViewModel model = new DonateMedicalIndexViewModel();
            model.DonateTypeId = ActiveUser.Instance.DonateTypeId;

            return View(model);
        }

        ////Form GOODS Donation Index
        public IActionResult GoodsIndex()
        {
            if (ActiveUser.Instance.Customer == null)
            {

                return RedirectToAction("CustomerIndex", "Customer");
            }

            DonateGoodsIndexViewModel model = new DonateGoodsIndexViewModel();
            model.DonateTypeId = ActiveUser.Instance.DonateTypeId;

            return View(model);
        }

        //Creates NEW DONATION for all types of donation
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult DonateCreate(NewDonateCreateViewModel model, [FromRoute] int Id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            model.CustomerId =  ActiveUser.Instance.Customer.CustomerId;
            Donate d = new Donate();
            d.DonateTypeId = ActiveUser.Instance.DonateTypeId;
            d.Name = model.Donate.Name;
            d.Note = model.Donate.Note;
            d.Value = model.Donate.Value;
            d.CustomerId = model.CustomerId;

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

       // Thankyou() a method that will be called after all the donations succedes 

        public IActionResult ThankYou(NewDonateCreateViewModel model)
        {
            model.DonatorFirstName = ActiveUser.Instance.Customer.FirstName;
            model.DonatorLastName = ActiveUser.Instance.Customer.LastName;
            return View(model);
        }


    }
}
