using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using YouBay.Service.Services;

namespace YouBay.Web.Controllers
{
    public class HomeController : Controller
    {
        IProductService iProductService;
        public HomeController(IProductService iProductService)
        {
            this.iProductService = iProductService;
        }
        public ActionResult Index()
        {
            var products = iProductService.getAllCategories();
            return View(products);
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}