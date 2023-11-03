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
            var veriler = _context.Sales.GroupBy(s => s.Province)
               .Select(g => new { Province = g.Key, TotalSaleQuantity = g.Sum(s => s.SaleQuentity) })
               .ToList();

            var provinces = veriler.Select(v => v.Province).ToArray();
            var totalSaleQuantities = veriler.Select(v => v.TotalSaleQuantity).ToArray();

            ViewBag.Provinces = provinces;
            ViewBag.TotalSaleQuantities = totalSaleQuantities;
            var sales = _context.Sales.ToList();

            return View(sales);
        }
    }
}