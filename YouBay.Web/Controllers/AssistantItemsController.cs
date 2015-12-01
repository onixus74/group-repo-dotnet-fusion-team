
using System.Web.Mvc;
using YouBay.Domain.Entities;
using YouBay.Service.Services;

namespace YouBay.Web.Controllers
{
    public class AssistantItemsController : Controller
    {

        IAssistantItemsService iAssistantItemsService;
        public AssistantItemsController(IAssistantItemsService iAssistantItemsService)
        {
            this.iAssistantItemsService = iAssistantItemsService;
        }


        // GET: AssistantItems
        public ActionResult Index()
        {
            var categories = iAssistantItemsService.getAllCategories();
            return View(categories);
        }

        // GET: AssistantItems/Details/5
        public ActionResult Details(long id)
        {
            var assistantItems = iAssistantItemsService.Get(c => c.assistantItemsId == id);
            return View(assistantItems);
        }

        // GET: AssistantItems/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: AssistantItems/Create
        [HttpPost]
        public ActionResult Create(AssistantItems assistantItems)
        {
            try
            {
                
                if (ModelState.IsValid)
                {
                    iAssistantItemsService.AddAssistantItems(assistantItems);
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

        // GET: AssistantItems/Edit/5
        public ActionResult Edit(long id)
        {
            AssistantItems assistantItems = iAssistantItemsService.Get(c => c.assistantItemsId == id);
            return View(assistantItems);
        }

        // POST: AssistantItems/Edit/5
        [HttpPost]
        public ActionResult Edit(AssistantItems assistantItems)
        {
            try
            {

                if (ModelState.IsValid)
                {
                    iAssistantItemsService.UpdateAssistantItems(assistantItems);
                    return RedirectToAction("Index");
                }

            }
            catch
            {
                return View();
            }

            return View();
        }

        // GET: AssistantItems/Delete/5
        public ActionResult Delete(long id)
        {
            return View();
        }

        // POST: AssistantItems/Delete/5
        [HttpPost]
        public ActionResult Delete(long id, FormCollection collection)
        {
            try
            {
                iAssistantItemsService.Delete(c => c.assistantItemsId == id);
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}

