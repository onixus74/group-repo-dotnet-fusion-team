
using System.Web.Mvc;
using YouBay.Domain.Entities;
using YouBay.Service.Services;

namespace YouBay.Web.Controllers
{
    public class BuyerController : Controller
    {

        IBuyerService iBuyerService;
        public BuyerController(IBuyerService iBuyerService)
        {
            this.iBuyerService = iBuyerService;
        }


        // GET: Buyer
        public ActionResult Index()
        {
            var categories = iBuyerService.getAllCategories();
            return View(categories);
        }

        // GET: Buyer/Details/5
        public ActionResult Details(long id)
        {
            var buyer = iBuyerService.Get(c => c.youBayUserId == id);
            return View(buyer);
        }

        // GET: Buyer/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Buyer/Create
        [HttpPost]
        public ActionResult Create(Buyer buyer)
        {
            try
            {

                if (ModelState.IsValid)
                {
                    iBuyerService.AddBuyer(buyer);
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

        // GET: Buyer/Edit/5
        public ActionResult Edit(long id)
        {
            Buyer buyer = iBuyerService.Get(c => c.youBayUserId == id);
            return View(buyer);
        }

        // POST: Buyer/Edit/5
        [HttpPost]
        public ActionResult Edit(Buyer buyer)
        {
            try
            {

                if (ModelState.IsValid)
                {
                    iBuyerService.UpdateBuyer(buyer);
                    return RedirectToAction("Index");
                }

            }
            catch
            {
                return View();
            }

            return View();
        }

        // GET: Buyer/Delete/5
        public ActionResult Delete(long id)
        {
            return View();
        }

        // POST: Buyer/Delete/5
        [HttpPost]
        public ActionResult Delete(long id, FormCollection collection)
        {
            try
            {
                iBuyerService.Delete(c => c.youBayUserId == id);
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}

