
using System.Web.Mvc;
using YouBay.Domain.Entities;
using YouBay.Service.Services;

namespace YouBay.Web.Controllers
{
    public class ProducthistoryController : Controller
    {

        IProductHistoryService iProductHistoryService;
        public ProducthistoryController(IProductHistoryService iProductHistoryService)
        {
            this.iProductHistoryService = iProductHistoryService;
        }


        // GET: Producthistory
        public ActionResult Index()
        {
            var categories = iProductHistoryService.getAllCategories();
            return View(categories);
        }

        // GET: Producthistory/Details/5
        public ActionResult Details(long id)
        {
            var Producthistory = iProductHistoryService.Get(c => c.productHistoryId == id);
            return View(Producthistory);
        }

        // GET: Producthistory/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Producthistory/Create
        [HttpPost]
        public ActionResult Create(ProductHistory productHistory)
        {
            try
            {

                if (ModelState.IsValid)
                {
                    iProductHistoryService.AddProductHistory(productHistory);
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

        // GET: Producthistory/Edit/5
        public ActionResult Edit(long id)
        {
            ProductHistory ProductHistory = iProductHistoryService.Get(c => c.productHistoryId == id);
            return View(ProductHistory);
        }

        // POST: Producthistory/Edit/5
        [HttpPost]
        public ActionResult Edit(ProductHistory ProductHistory)
        {
            try
            {

                if (ModelState.IsValid)
                {
                    iProductHistoryService.UpdateProductHistory(ProductHistory);
                    return RedirectToAction("Index");
                }

            }
            catch
            {
                return View();
            }

            return View();
        }

        // GET: Producthistory/Delete/5
        public ActionResult Delete(long id)
        {
            return View();
        }

        // POST: Producthistory/Delete/5
        [HttpPost]
        public ActionResult Delete(long id, FormCollection collection)
        {
            try
            {
                iProductHistoryService.Delete(c => c.productHistoryId == id);
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
