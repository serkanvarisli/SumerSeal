using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SumerGidaSale.Models;
using System.Collections;
using System.Web.Helpers;

namespace SumerGidaSale.Controllers
{
    [Authorize(AuthenticationSchemes = "UserAuthentication")]

    public class HomeController : Controller
    {
        MyDbContext _context;
        public HomeController(MyDbContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            var sales = _context.Sales.ToList();
            return View(sales);
        }
        public IActionResult Graffic()
        {
            var veriler = _context.Sales.GroupBy(s => s.Province)
                .Select(g => new { Province = g.Key, SaleQuantity = g.Sum(s => s.SaleQuantity) })
                .ToList();

            var provinces = veriler.Select(v => v.Province).ToArray();
            var saleQuantities = veriler.Select(v => v.SaleQuantity).ToArray();

            ViewBag.Provinces = provinces;
            ViewBag.SaleQuantities = saleQuantities;

            return View();
        }



    }
}