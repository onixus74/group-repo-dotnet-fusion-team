using System.Web.Mvc;
using YouBay.Domain.Entities;
using YouBay.Service.Services;

namespace YouBay.Web.Controllers
{
    public class YouBayUserController : Controller
    {

        IYouBayUserService iYouBayUserService;
        public YouBayUserController(IYouBayUserService iYouBayUserService)
        {
            this.iYouBayUserService = iYouBayUserService;
        }


        // GET: YouBayUser
        public ActionResult Index()
        {
            var categories = iYouBayUserService.getAllCategories();
            return View(categories);
        }

        // GET: YouBayUser/Details/5
        public ActionResult Details(long id)
        {
            var youBayUser = iYouBayUserService.Get(c => c.youBayUserId == id);
            return View(youBayUser);
        }

        // GET: YouBayUser/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: YouBayUser/Create
        [HttpPost]
        public ActionResult Create(YouBayUser youBayUser)
        {
            try
            {

                if (ModelState.IsValid)
                {
                    iYouBayUserService.AddYouBayUser(youBayUser);
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

        // GET: YouBayUser/Edit/5
        public ActionResult Edit(long id)
        {
            YouBayUser youBayUser = iYouBayUserService.Get(c => c.youBayUserId == id);
            return View(youBayUser);
        }

        // POST: YouBayUser/Edit/5
        [HttpPost]
        public ActionResult Edit(YouBayUser youBayUser)
        {
            try
            {

                if (ModelState.IsValid)
                {
                    iYouBayUserService.UpdateYouBayUser(youBayUser);
                    return RedirectToAction("Index");
                }

            }
            catch
            {
                return View();
            }

            return View();
        }

        // GET: YouBayUser/Delete/5
        public ActionResult Delete(long id)
        {
            return View();
        }

        // POST: YouBayUser/Delete/5
        [HttpPost]
        public ActionResult Delete(long id, FormCollection collection)
        {
            try
            {
                iYouBayUserService.Delete(c => c.youBayUserId == id);
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
