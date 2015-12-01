
using System.Web.Mvc;
using YouBay.Domain.Entities;
using YouBay.Service.Services;

namespace YouBay.Web.Controllers
{
    public class HistoryOfViewsController : Controller
    {

        IHistoryOfViewsService iHistoryOfViewsService;
        public HistoryOfViewsController(IHistoryOfViewsService iHistoryOfViewsService)
        {
            this.iHistoryOfViewsService = iHistoryOfViewsService;
        }


        // GET: HistoryOfViews
        public ActionResult Index()
        {
            var categories = iHistoryOfViewsService.getAllCategories();
            return View(categories);
        }

        // GET: HistoryOfViews/Details/5
        public ActionResult Details(long id)
        {
            var historyOfViews = iHistoryOfViewsService.Get(c => c.historyOfViewsId == id);
            return View(historyOfViews);
        }

        // GET: HistoryOfViews/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: HistoryOfViews/Create
        [HttpPost]
        public ActionResult Create(HistoryOfViews historyOfViews)
        {
            try
            {
                
                if (ModelState.IsValid)
                {
                    iHistoryOfViewsService.AddHistoryOfViews(historyOfViews);
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

        // GET: HistoryOfViews/Edit/5
        public ActionResult Edit(long id)
        {
            HistoryOfViews historyOfViews = iHistoryOfViewsService.Get(c => c.historyOfViewsId == id);
            return View(historyOfViews);
        }

        // POST: HistoryOfViews/Edit/5
        [HttpPost]
        public ActionResult Edit(HistoryOfViews historyOfViews)
        {
            try
            {

                if (ModelState.IsValid)
                {
                    iHistoryOfViewsService.UpdateHistoryOfViews(historyOfViews);
                    return RedirectToAction("Index");
                }

            }
            catch
            {
                return View();
            }

            return View();
        }

        // GET: HistoryOfViews/Delete/5
        public ActionResult Delete(long id)
        {
            return View();
        }

        // POST: HistoryOfViews/Delete/5
        [HttpPost]
        public ActionResult Delete(long id, FormCollection collection)
        {
            try
            {
                iHistoryOfViewsService.Delete(c => c.historyOfViewsId == id);
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}

