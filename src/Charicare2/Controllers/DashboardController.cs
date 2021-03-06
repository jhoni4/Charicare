using System;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Charicare2.Models.AppViewModels;
using Charicare2.Data;
using System.Data;
using System.Collections;
using System.Configuration;
using FusionCharts.Charts;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Charicare2.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;
using System.Security.Claims;

// "/**",
// " * Class: DashboardController",
// " * Purpose: is a dashboard constructor that enables the Admin user to edit, view and delete donates by. And lets you view charts and tabular details of donats",
// " * Author: YONATAN MOLLA",
// " * Methods:",
// " *   Index() - When the page loads user be able to see list of all donates from the context in diffrent modes ",
// " *   Detail([FromRoute]int id) - When a Adminuser on Dashboard page clicks on any hyperlinked detail icons then page takes the donateId of clicked Donate and lists out detail of that Donate",
// " *   Edit([FromRoute]int? id) - When a Adminuser on Dashboard page clicks on any hyperlinked edit icons then page takes the donateId of clicked Donate and lists out edit form of that Donate",
// " *   Edit(int id, [Bind("DonateId,Name,Value,Note,DonateTypeId,DateCreated,CustomerId")] Donate donate) updates the context (bind used To protect from overposting attacks)
// " *   Delete([FromRoute]int? id) - When a Adminuser on Dashboard page clicks on any hyperlinked Delete icons then page takes the donateId of clicked Donate and lists out Delete form of that Donate",
// " */"

namespace Charicare2.Controllers
{
    public class DashboardController : Controller
    {
        private ApplicationDbContext context;

        //Constructor functions that takes context 
        //and sets them to the private variables above
        private readonly UserManager<ApplicationUser> _userManager;
        public DashboardController(ApplicationDbContext ctx, UserManager<ApplicationUser> userManager)
        {
            _userManager = userManager;
            context = ctx;
        }
        

        // This task retrieves the currently authenticated user
        private Task<ApplicationUser> GetCurrentUserAsync() => _userManager.GetUserAsync(HttpContext.User);

        public async Task<IActionResult> Index(string sortOrder)
        {
            var user = await GetCurrentUserAsync();
            var roles = ((ClaimsIdentity)User.Identity).Claims
                .Where(c => c.Type == ClaimTypes.Role)
                .Select(c => c.Value);

            Console.WriteLine("roles");
            

                //ViewData["Title"] = "Dashboard";
                Chart sales = new Chart();
            //// Setting chart 
            sales.SetChartParameter(Chart.ChartParameter.chartId, "myChart");
            sales.SetChartParameter(Chart.ChartParameter.chartType, "column3d");
            sales.SetChartParameter(Chart.ChartParameter.chartWidth, "600");
            sales.SetChartParameter(Chart.ChartParameter.chartHeight, "350");
            sales.SetData("{\"chart\":{\"caption\":\"Monthly\",\"xaxisname\":\"Month\",\"yaxisname\":\"Revenue\",\"numberprefix\":\"$\",\"showvalues\":\"1\",\"animation\":\"0\"},\"data\":[{\"label\":\"Jan\",\"value\":\"420000\"},{\"label\":\"Feb\",\"value\":\"910000\"},{\"label\":\"Mar\",\"value\":\"720000\"},{\"label\":\"Apr\",\"value\":\"550000\"},{\"label\":\"May\",\"value\":\"810000\"},{\"label\":\"Jun\",\"value\":\"510000\"},{\"label\":\"Jul\",\"value\":\"680000\"},{\"label\":\"Aug\",\"value\":\"620000\"},{\"label\":\"Sep\",\"value\":\"610000\"},{\"label\":\"Oct\",\"value\":\"490000\"},{\"label\":\"Nov\",\"value\":\"530000\"},{\"label\":\"Dec\",\"value\":\"330000\"}],\"trendlines\":[{\"line\":[{\"startvalue\":\"700000\",\"istrendzone\":\"1\",\"valueonright\":\"1\",\"tooltext\":\"AYAN\",\"endvalue\":\"900000\",\"color\":\"009933\",\"displayvalue\":\"Target\",\"showontop\":\"1\",\"thickness\":\"5\"}]}],\"styles\":{\"definition\":[{\"name\":\"CanvasAnim\",\"type\":\"animation\",\"param\":\"_xScale\",\"start\":\"0\",\"duration\":\"1\"}],\"application\":[{\"toobject\":\"Canvas\",\"styles\":\"CanvasAnim\"}]}}", Chart.DataFormat.json);

            DashboardListViewModel model = new DashboardListViewModel(context);
            foreach (var role in roles)
            {
                model.UserRole = role.ToString();
            }
                model.DonateTypes = context.DonateType.ToList();
            model.donates = context.Donate.ToList();
            model.donners = context.Customer.ToList();

            ////To get count of donners for each donate 
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
            ///To get sum of each donate type values
            var ClothTotalValue = model.donates
                .Where(l => l.DonateTypeId == 1).Sum(d => d.Value);
            model.ClothTotalValue = ClothTotalValue;
            var GoodsTotalValue = model.donates
                .Where(l => l.DonateTypeId == 3).Sum(d => d.Value);
            model.GoodsTotalValue = GoodsTotalValue;
            var MoneyTotalValue = model.donates
                .Where(l => l.DonateTypeId == 2).Sum(d => d.Value);
            model.MoneyTotalValue = MoneyTotalValue;
            var MedicalTotalValue = model.donates
                .Where(l => l.DonateTypeId == 4).Sum(d => d.Value);
            model.MedicalTotalValue = MedicalTotalValue;

            
            ViewBag.NameSortParm = String.IsNullOrEmpty(sortOrder) ? "name_desc" : "";
            ViewBag.ValueSortParm = sortOrder == "Value" ? "value_desc" : "Value";
            ViewBag.DateSortParm = sortOrder == "Date" ? "date_desc" : "Date";
            var donatess = from d in context.Donate
                           select d;
            switch (sortOrder)
            {
                case "name_desc":
                    donatess = donatess.OrderByDescending(s => s.Name);
                    break;
                case "Value":
                    donatess = donatess.OrderBy(s => s.Value);
                    break;
                case "value_desc":
                    donatess = donatess.OrderByDescending(s => s.Value);
                    break;
                case "Date":
                    donatess = donatess.OrderBy(s => s.DateCreated);
                    break;
                case "date_desc":
                    donatess = donatess.OrderByDescending(s => s.DateCreated);
                    break;
                default:
                    donatess = donatess.OrderBy(s => s.Name);
                    break;
            }
            model.donatesss = donatess.ToList();

            return View(model);
        }

        public ActionResult ModalAction(int Id)
        {
            ViewBag.Id = Id;
            return PartialView("ModalContent");
        }

        // GET: Donate/Details/5
        [Authorize]
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            var donate = await context.Donate.SingleOrDefaultAsync(m => m.DonateId == id);
            donate.danatedBy = await context.Customer.Where(m => m.CustomerId == donate.CustomerId).SingleOrDefaultAsync();
            donate.donatType = await context.DonateType.Where(m => m.DonateTypeId == donate.DonateTypeId).SingleOrDefaultAsync();
            if (donate == null)
            {
                return NotFound();
            }

            return PartialView(donate);
        }

        [Authorize]
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var donate = await context.Donate.SingleOrDefaultAsync(m => m.DonateId == id);
            if (donate == null)
            {
                return NotFound();
            }
            return PartialView(donate);
        }

        // POST: Donate/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [Authorize]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("DonateId,Name,Value,Note,DonateTypeId,DateCreated,CustomerId")] Donate donate)
        {
            if (id != donate.DonateId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    context.Update(donate);
                    await context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!DonateExists(donate.DonateId))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction("Index");
            }
            return PartialView(donate);
        }

        // GET: Donate/Delete/5
        [Authorize]
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var donate = await context.Donate.SingleOrDefaultAsync(m => m.DonateId == id);
            if (donate == null)
            {
                return NotFound();
            }

            return PartialView(donate);
        }

        // POST: Donate/Delete/5
        [HttpPost, ActionName("Delete")]
        [Authorize]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var donate = await context.Donate.SingleOrDefaultAsync(m => m.DonateId == id);
            context.Donate.Remove(donate);
            await context.SaveChangesAsync();
            return RedirectToAction("Index");
        }

        private bool DonateExists(int id)
        {
            return context.Donate.Any(e => e.DonateId == id);
        }


    }
}