
using System.Web.Mvc;
using YouBay.Domain.Entities;
using YouBay.Service.Services;

namespace YouBay.Web.Controllers
{
    public class ProducthistoryController : Controller
    {

        IProducthistoryService iProducthistoryService;
        public ProducthistoryController(IProducthistoryService iProducthistoryService)
        {
            this.iProducthistoryService = iProducthistoryService;
        }


        // GET: Producthistory
        public ActionResult Index()
        {
            var categories = iProducthistoryService.getAllCategories();
            return View(categories);
        }

        // GET: Producthistory/Details/5
        public ActionResult Details(long id)
        {
            var Producthistory = iProducthistoryService.Get(c => c.ProducthistoryId == id);
            return View(Producthistory);
        }

        // GET: Producthistory/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Producthistory/Create
        [HttpPost]
        public ActionResult Create(Producthistory Producthistory)
        {
            try
            {
                
                if (ModelState.IsValid)
                {
                    iProducthistoryService.AddProducthistory(Producthistory);
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
            Producthistory Producthistory = iProducthistoryService.Get(c => c.ProducthistoryId == id);
            return View(Producthistory);
        }

        // POST: Producthistory/Edit/5
        [HttpPost]
        public ActionResult Edit(Producthistory Producthistory)
        {
            try
            {

                if (ModelState.IsValid)
                {
                    iProducthistoryService.UpdateProducthistory(Producthistory);
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
                iProducthistoryService.Delete(c => c.ProducthistoryId == id);
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
