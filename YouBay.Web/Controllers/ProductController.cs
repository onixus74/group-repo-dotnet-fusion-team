
using System.Collections.Generic;
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
            var products = iProductService.getAllCategories();
            return View(products);
        }
        public ActionResult SellerIndex()
        {
            var products = iProductService.getAllCategories();
            return View(products);
        }
        [Route("Product/BySubcategory/{theSubcategoryId:long}")]
        public ActionResult BySubcategory(long theSubcategoryId)
        {
            var products = iProductService.GetMany(p => p.subcategory_subcategoryId == theSubcategoryId);
            return View(products);
        }

        [Route("Product/BySeller/{theSellerId:long}")]
        public ActionResult BySeller(long theSellerId)
        {
            var products = iProductService.GetMany(p => p.seller.youBayUserId == theSellerId);
            return View(products);
        }

        // GET: Product/Details/5
        public ActionResult Details(long id)
        {
            var product = iProductService.Get(c => c.productId == id);
            return View(product);
        }

        public ActionResult DetailsForUser(long id)
        {
            var product = iProductService.Get(c => c.productId == id);
            return View(product);
        }

        // GET: Product/Create
        public ActionResult Create()
        {
            /* _ _ _ _ _ _ _ _ _ _ _ _ _ _ _ _ _ _ _ _ _ _ _  */
            ISubcategoryService iSubcategoryService = new SubcategoryService();
            List<Subcategory> listSubcategory = iSubcategoryService.getAllCategories();
            ViewBag.listSubcategory = listSubcategory;

            ISellerService iSellerService = new SellerService();
            List<Seller> listSellers = iSellerService.getAllCategories();
            ViewBag.listSellers = listSellers;
            /* _ _ _ _ _ _ _ _ _ _ _ _ _ _ _ _ _ _ _ _ _ _ _  */

            return View();
        }

        public ActionResult SellerCreate()
        {
            /* _ _ _ _ _ _ _ _ _ _ _ _ _ _ _ _ _ _ _ _ _ _ _  */
            ISubcategoryService iSubcategoryService = new SubcategoryService();
            List<Subcategory> listSubcategory = iSubcategoryService.getAllCategories();
            ViewBag.listSubcategory = listSubcategory;

            ISellerService iSellerService = new SellerService();
            List<Seller> listSellers = iSellerService.getAllCategories();
            ViewBag.listSellers = listSellers;
            /* _ _ _ _ _ _ _ _ _ _ _ _ _ _ _ _ _ _ _ _ _ _ _  */

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

        // POST: Product/Create
        [HttpPost]
        public ActionResult SellerCreate(Product product)
        {
            try
            {

                if (ModelState.IsValid)
                {
                    iProductService.AddProduct(product);
                    return RedirectToAction("SellerIndex");
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
            /* _ _ _ _ _ _ _ _ _ _ _ _ _ _ _ _ _ _ _ _ _ _ _  */
            ISubcategoryService iSubcategoryService = new SubcategoryService();
            List<Subcategory> listSubcategory = iSubcategoryService.getAllCategories();
            ViewBag.listSubcategory = listSubcategory;

            ISellerService iSellerService = new SellerService();
            List<Seller> listSellers = iSellerService.getAllCategories();
            ViewBag.listSellers = listSellers;
            /* _ _ _ _ _ _ _ _ _ _ _ _ _ _ _ _ _ _ _ _ _ _ _  */

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
