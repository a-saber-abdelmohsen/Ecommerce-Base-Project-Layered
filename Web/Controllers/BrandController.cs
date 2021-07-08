using BL.AppServices;
using BL.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Web.Controllers
{
    public class BrandController : Controller
    {
        // GET: Brand
        BrandAppService Brands = new BrandAppService();

        public ActionResult Index()
        {
            List<BrandViewModel> brands = Brands.GetAllBrand();
            return View(brands);
        }

        [HttpGet]
        public ActionResult Create() => View();

        [HttpPost]
        public ActionResult Create(BrandViewModel brand)
        {
            if (!ModelState.IsValid)
            {
                return View(brand);
            }
            Brands.SaveNewBrand(brand);
            return RedirectToAction("Index");
        }
    }
}