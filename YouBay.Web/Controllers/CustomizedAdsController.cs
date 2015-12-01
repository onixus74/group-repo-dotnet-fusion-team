
using System.Web.Mvc;
using YouBay.Domain.Entities;
using YouBay.Service.Services;

namespace YouBay.Web.Controllers
{
    public class CustomizedAdsController : Controller
    {

        ICustomizedAdsService iCustomizedAdsService;
        public CustomizedAdsController(ICustomizedAdsService iCustomizedAdsService)
        {
            this.iCustomizedAdsService = iCustomizedAdsService;
        }


        // GET: CustomizedAds
        public ActionResult Index()
        {
            var categories = iCustomizedAdsService.getAllCategories();
            return View(categories);
        }

        // GET: CustomizedAds/Details/5
        public ActionResult Details(long id)
        {
            var customizedAds = iCustomizedAdsService.Get(c => c.customizedAdsId == id);
            return View(customizedAds);
        }

        // GET: CustomizedAds/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: CustomizedAds/Create
        [HttpPost]
        public ActionResult Create(CustomizedAds customizedAds)
        {
            try
            {
                
                if (ModelState.IsValid)
                {
                    iCustomizedAdsService.AddCustomizedAds(customizedAds);
                    return RedirectToAction("Index");
                }

                else
                {
                    return View();
                }

            }
            catch
            {
                return View();
            }
        }

        // GET: CustomizedAds/Edit/5
        public ActionResult Edit(long id)
        {
            CustomizedAds customizedAds = iCustomizedAdsService.Get(c => c.customizedAdsId == id);
            return View(customizedAds);
        }

        // POST: CustomizedAds/Edit/5
        [HttpPost]
        public ActionResult Edit(CustomizedAds customizedAds)
        {
            try
            {

                if (ModelState.IsValid)
                {
                    iCustomizedAdsService.UpdateCustomizedAds(customizedAds);
                    return RedirectToAction("Index");
                }

            }
            catch
            {
                return View();
            }

            return View();
        }

        // GET: CustomizedAds/Delete/5
        public ActionResult Delete(long id)
        {
            return View();
        }

        // POST: CustomizedAds/Delete/5
        [HttpPost]
        public ActionResult Delete(long id, FormCollection collection)
        {
            try
            {
                iCustomizedAdsService.Delete(c => c.customizedAdsId == id);
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
