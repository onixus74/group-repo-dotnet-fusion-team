
using System.Web.Mvc;
using YouBay.Domain.Entities;
using YouBay.Service.Services;

namespace YouBay.Web.Controllers
{
    public class ProductController : Controller
    {

        IProductService iProductService;
        public ProductController(IProductService iProductService)
        {
            this.iProductService = iProductService;
        }


        // GET: Product
        public ActionResult Index()
        {
            var categories = iProductService.getAllCategories();
            return View(categories);
        }

        // GET: Product/Details/5
        public ActionResult Details(long id)
        {
            var product = iProductService.Get(c => c.productId == id);
            return View(product);
        }

        // GET: Product/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Product/Create
        [HttpPost]
        public ActionResult Create(Product product)
        {
            try
            {
                
                if (ModelState.IsValid)
                {
                    iProductService.AddProduct(product);
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

        // GET: Product/Edit/5
        public ActionResult Edit(long id)
        {
            Product product = iProductService.Get(c => c.productId == id);
            return View(product);
        }

        // POST: Product/Edit/5
        [HttpPost]
        public ActionResult Edit(Product product)
        {
            try
            {

                if (ModelState.IsValid)
                {
                    iProductService.UpdateProduct(product);
                    return RedirectToAction("Index");
                }

            }
            catch
            {
                return View();
            }

            return View();
        }

        // GET: Product/Delete/5
        public ActionResult Delete(long id)
        {
            return View();
        }

        // POST: Product/Delete/5
        [HttpPost]
        public ActionResult Delete(long id, FormCollection collection)
        {
            try
            {
                iProductService.Delete(c => c.productId == id);
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
