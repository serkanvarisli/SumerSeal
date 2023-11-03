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
            var veriler = _context.Sales.ToList();

            var labels = veriler.Select(s => s.Province).ToArray();
            var data = veriler.Select(s => s.SaleQuentity).ToArray();

            ViewBag.Labels = labels;
            ViewBag.Data = data;

            return View(veriler);
        }



    }
}