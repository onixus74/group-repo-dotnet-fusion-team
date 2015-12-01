
using System.Web.Mvc;
using YouBay.Domain.Entities;
using YouBay.Service.Services;

namespace YouBay.Web.Controllers
{
    public class ManagerController : Controller
    {

        IManagerService iManagerService;
        public ManagerController(IManagerService iManagerService)
        {
            this.iManagerService = iManagerService;
        }


        // GET: Manager
        public ActionResult Index()
        {
            var categories = iManagerService.getAllCategories();
            return View(categories);
        }

        // GET: Manager/Details/5
        public ActionResult Details(long id)
        {
            var manager = iManagerService.Get(c => c.managerId == id);
            return View(manager);
        }

        // GET: Manager/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Manager/Create
        [HttpPost]
        public ActionResult Create(Manager manager)
        {
            try
            {
                
                if (ModelState.IsValid)
                {
                    iManagerService.AddManager(manager);
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

        // GET: Manager/Edit/5
        public ActionResult Edit(long id)
        {
            Manager manager = iManagerService.Get(c => c.managerId == id);
            return View(manager);
        }

        // POST: Manager/Edit/5
        [HttpPost]
        public ActionResult Edit(Manager manager)
        {
            try
            {

                if (ModelState.IsValid)
                {
                    iManagerService.UpdateManager(manager);
                    return RedirectToAction("Index");
                }

            }
            catch
            {
                return View();
            }

            return View();
        }

        // GET: Manager/Delete/5
        public ActionResult Delete(long id)
        {
            return View();
        }

        // POST: Manager/Delete/5
        [HttpPost]
        public ActionResult Delete(long id, FormCollection collection)
        {
            try
            {
                iManagerService.Delete(c => c.managerId == id);
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
