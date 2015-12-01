
using System.Web.Mvc;
using YouBay.Domain.Entities;
using YouBay.Service.Services;

namespace YouBay.Web.Controllers
{
    public class OrderAndReviewController : Controller
    {

        IOrderAndReviewService iOrderAndReviewService;
        public OrderAndReviewController(IOrderAndReviewService iOrderAndReviewService)
        {
            this.iOrderAndReviewService = iOrderAndReviewService;
        }


        // GET: OrderAndReview
        public ActionResult Index()
        {
            var categories = iOrderAndReviewService.getAllCategories();
            return View(categories);
        }

        // GET: OrderAndReview/Details/5
        public ActionResult Details(long id)
        {
            var orderAndReview = iOrderAndReviewService.Get(c => c.orderAndReviewId == id);
            return View(orderAndReview);
        }

        // GET: OrderAndReview/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: OrderAndReview/Create
        [HttpPost]
        public ActionResult Create(OrderAndReview orderAndReview)
        {
            try
            {
                
                if (ModelState.IsValid)
                {
                    iOrderAndReviewService.AddOrderAndReview(orderAndReview);
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

        // GET: OrderAndReview/Edit/5
        public ActionResult Edit(long id)
        {
            OrderAndReview orderAndReview = iOrderAndReviewService.Get(c => c.orderAndReviewId == id);
            return View(orderAndReview);
        }

        // POST: OrderAndReview/Edit/5
        [HttpPost]
        public ActionResult Edit(OrderAndReview orderAndReview)
        {
            try
            {

                if (ModelState.IsValid)
                {
                    iOrderAndReviewService.UpdateOrderAndReview(orderAndReview);
                    return RedirectToAction("Index");
                }

            }
            catch
            {
                return View();
            }

            return View();
        }

        // GET: OrderAndReview/Delete/5
        public ActionResult Delete(long id)
        {
            return View();
        }

        // POST: OrderAndReview/Delete/5
        [HttpPost]
        public ActionResult Delete(long id, FormCollection collection)
        {
            try
            {
                iOrderAndReviewService.Delete(c => c.orderAndReviewId == id);
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
