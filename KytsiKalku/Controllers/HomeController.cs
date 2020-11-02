using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Microsoft.EntityFrameworkCore;
using KytsiKalku.Models;
using KytsiKalku.Data;

namespace KytsiKalku.Controllers
{
    public class HomeController : Controller
    {
        public readonly KytsiKalkuFuelContext _context;

        public HomeController(KytsiKalkuFuelContext context)
        {
            _context = context;
        }

        // GET: FuelDatas

        public async Task<IActionResult> Index(string searchString)
        {
            DateTime today = DateTime.Today;
            DateTime twoWeeksBefore = today.AddDays(-14);

            var tripnames = from m in _context.FuelData
                            where m.DriveDate  >= twoWeeksBefore
                            select m;


            return View(await tripnames.ToListAsync());
        }

        public IActionResult About()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
