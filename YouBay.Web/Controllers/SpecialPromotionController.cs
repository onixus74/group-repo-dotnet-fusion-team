
using System.Web.Mvc;
using YouBay.Domain.Entities;
using YouBay.Service.Services;

namespace YouBay.Web.Controllers
{
    public class SpecialPromotionController : Controller
    {

        ISpecialPromotionService iSpecialPromotionService;
        public SpecialPromotionController(ISpecialPromotionService iSpecialPromotionService)
        {
            this.iSpecialPromotionService = iSpecialPromotionService;
        }


        // GET: SpecialPromotion
        public ActionResult Index()
        {
            var categories = iSpecialPromotionService.getAllCategories();
            return View(categories);
        }

        // GET: SpecialPromotion/Details/5
        public ActionResult Details(long id)
        {
            var specialPromotion = iSpecialPromotionService.Get(c => c.specialPromotionId == id);
            return View(specialPromotion);
        }

        // GET: SpecialPromotion/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: SpecialPromotion/Create
        [HttpPost]
        public ActionResult Create(SpecialPromotion specialPromotion)
        {
            try
            {
                
                if (ModelState.IsValid)
                {
                    iSpecialPromotionService.AddSpecialPromotion(specialPromotion);
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

        // GET: SpecialPromotion/Edit/5
        public ActionResult Edit(long id)
        {
            SpecialPromotion specialPromotion = iSpecialPromotionService.Get(c => c.specialPromotionId == id);
            return View(specialPromotion);
        }

        // POST: SpecialPromotion/Edit/5
        [HttpPost]
        public ActionResult Edit(SpecialPromotion specialPromotion)
        {
            try
            {

                if (ModelState.IsValid)
                {
                    iSpecialPromotionService.UpdateSpecialPromotion(specialPromotion);
                    return RedirectToAction("Index");
                }

            }
            catch
            {
                return View();
            }

            return View();
        }

        // GET: SpecialPromotion/Delete/5
        public ActionResult Delete(long id)
        {
            return View();
        }

        // POST: SpecialPromotion/Delete/5
        [HttpPost]
        public ActionResult Delete(long id, FormCollection collection)
        {
            try
            {
                iSpecialPromotionService.Delete(c => c.specialPromotionId == id);
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
