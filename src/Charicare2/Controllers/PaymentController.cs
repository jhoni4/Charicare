using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Charicare2.Data;
using Microsoft.AspNetCore.Identity;
using Charicare2.Models;
using Charicare2.ViewModels;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Stripe;
using System.Security.Claims;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc.Rendering;
using Charicare2.Models.AccountViewModels;
using Charicare2.Configuration;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace Charicare2.Controllers
{
    public class PaymentController : Controller
    {
        private ApplicationDbContext context;
        // Private variable for userManager helper function
        private PaymentSettings _PaymentSettings;
        private readonly UserManager<ApplicationUser> _userManager;
        private ILogger<PaymentController> _ILogger;

      

        //Constructor functions that takes both context AND the userManager object
        //and sets them to the private variables above
        public PaymentController(
            UserManager<ApplicationUser> userManager,
            ApplicationDbContext ctx,
            ILogger<PaymentController> ILogger,
            IOptions<PaymentSettings> PaymentSettings)
        {
             context = ctx;
            _userManager = userManager;
            _ILogger = ILogger;
            _PaymentSettings = PaymentSettings.Value;
        }

        // This task retrieves the currently authenticated user
        private Task<ApplicationUser> GetCurrentUserAsync() => _userManager.GetUserAsync(HttpContext.User);

        // GET: Subscribe
        public async Task<IActionResult> Index()
        {
            //var model = new PaymentFormViewModel(context);
            ApplicationUser user = await GetCurrentUserAsync();
            //var Id = user.Id;
            //var user = await GetCurrentUserAsync();
            //ApplicationUser user = await _userManager.FindByIdAsync(userId);
            //To check if the user is subscribed before
            if(! string.IsNullOrEmpty(user.CustomerIdentifier))
            {
                var SubscriptionService = new StripeSubscriptionService();
                IEnumerable<StripeSubscription> response = SubscriptionService.List(user.CustomerIdentifier);
                ViewBag.Subscriptions = response;
            }
            ViewBag.Stripekey = _PaymentSettings.StripePublicKey;
            return View();
        }

        [HttpPost]
        public async Task<ActionResult> Confirm([FromForm]string stripeToken)
        {
            ApplicationUser user = await GetCurrentUserAsync();
            var planId = "std-monthly";
            //model.stripeToken = stripeToken;

            if (string.IsNullOrEmpty(user.CustomerIdentifier)) // Customer is new and doesn't have an ID
            {

                var Customer = new StripeCustomerCreateOptions();
                Customer.Email = $"{user.Email}";
                Customer.Description = $"{user.Email} [{user.Id}]";
                Customer.PlanId = planId;


                //Customer.SourceToken = model.stripeToken;
                Customer.Source = new StripeSourceOptions()
                {
                    TokenId = stripeToken
                };


                var customerService = new StripeCustomerService();
                StripeCustomer stripeCustomer = customerService.Create(Customer);

                user.CustomerIdentifier = stripeCustomer.Id;

                stripeCustomer.StripeSubscriptionList.Data.ForEach(
                async s => await SaveSubscription(s, user));



                await _userManager.UpdateAsync(user);
            }
            else 
            {
                var subscriptionService = new StripeSubscriptionService();
                var stripeSubscription = subscriptionService.Create(user.CustomerIdentifier, planId);

                await SaveSubscription(stripeSubscription, user);
                await _userManager.UpdateAsync(user);
            }

            return RedirectToAction(nameof(Index));
        }

        private Task SaveSubscription(StripeSubscription s, ApplicationUser user)
        {
            throw new NotImplementedException();
        }
    }
}