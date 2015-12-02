
using System.Web.Mvc;
using YouBay.Domain.Entities;
using YouBay.Service.Services;

namespace YouBay.Web.Controllers
{
    public class SellerController : Controller
    {

        ISellerService iSellerService;
        public SellerController(ISellerService iSellerService)
        {
            this.iSellerService = iSellerService;
        }


        // GET: Seller
        public ActionResult Index()
        {
            var categories = iSellerService.getAllCategories();
            return View(categories);
        }

        // GET: Seller/Details/5
        public ActionResult Details(long id)
        {
            var seller = iSellerService.Get(c => c.youBayUserId == id);
            return View(seller);
        }

        // GET: Seller/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Seller/Create
        [HttpPost]
        public ActionResult Create(Seller seller)
        {
            try
            {

                if (ModelState.IsValid)
                {
                    iSellerService.AddSeller(seller);
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

        // GET: Seller/Edit/5
        public ActionResult Edit(long id)
        {
            Seller seller = iSellerService.Get(c => c.youBayUserId == id);
            return View(seller);
        }

        // POST: Seller/Edit/5
        [HttpPost]
        public ActionResult Edit(Seller seller)
        {
            try
            {

                if (ModelState.IsValid)
                {
                    iSellerService.UpdateSeller(seller);
                    return RedirectToAction("Index");
                }

            }
            catch
            {
                return View();
            }

            return View();
        }

        // GET: Seller/Delete/5
        public ActionResult Delete(long id)
        {
            return View();
        }

        // POST: Seller/Delete/5
        [HttpPost]
        public ActionResult Delete(long id, FormCollection collection)
        {
            try
            {
                iSellerService.Delete(c => c.youBayUserId == id);
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
