using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SumerGidaSale.Models;

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

        [HttpPost]
        public IActionResult Add(Sale sale)
        {
            _context.Sales.Add(sale);
            _context.SaveChanges();
            return RedirectToAction("Index", "Home");
        }
        [HttpPost]
        public IActionResult Update(int value, int Id)
        {
            var quentityToUpdate = _context.Sales.FirstOrDefault(s => s.Id == Id);
            if(value > 0)
            {
            quentityToUpdate.SaleQuentity += value;
            }
            else
            {
                TempData["Hata"] = "Guncelleme Basarisiz. Satis sayisi sifir veya negatif sayi olamaz";
            }
            _context.SaveChanges();

            return RedirectToAction("Index", "Home");
        }
    }
}