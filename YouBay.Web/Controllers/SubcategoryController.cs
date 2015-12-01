using System.Collections.Generic;
using System.Web.Mvc;
using YouBay.Domain.Entities;
using YouBay.Service.Services;

namespace YouBay.Web.Controllers
{
    public class SubcategoryController : Controller
    {

        ISubcategoryService iSubcategoryService;


        public SubcategoryController(ISubcategoryService iSubcategoryService)
        {
            this.iSubcategoryService = iSubcategoryService;

        }


        // GET: Subcategory
        public ActionResult Index()
        {
            var categories = iSubcategoryService.getAllCategories();
            return View(categories);
        }

        // GET: Subcategory/Details/5
        public ActionResult Details(long id)
        {
            var subcategory = iSubcategoryService.Get(c => c.subcategoryId == id);
            return View(subcategory);
        }

        // GET: Subcategory/Create
        public ActionResult Create()
        {
            /* _ _ _ _ _ _ _ _ _ _ _ _ _ _ _ _ _ _ _ _ _ _ _  */
            ICategoryService iCategoryService = new CategoryService();
            List<Category> listCategory = iCategoryService.getAllCategories();
            ViewBag.listCategory = listCategory;
            /* _ _ _ _ _ _ _ _ _ _ _ _ _ _ _ _ _ _ _ _ _ _ _  */

            return View();
        }

        // POST: Subcategory/Create
        [HttpPost]
        public ActionResult Create(Subcategory subcategory)
        {
            try
            {

                if (ModelState.IsValid)
                {
                    iSubcategoryService.AddSubcategory(subcategory);
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

        // GET: Subcategory/Edit/5
        public ActionResult Edit(long id)
        {
            Subcategory subcategory = iSubcategoryService.Get(c => c.subcategoryId == id);

            /* _ _ _ _ _ _ _ _ _ _ _ _ _ _ _ _ _ _ _ _ _ _ _  */
            ICategoryService iCategoryService = new CategoryService();
            List<Category> listCategory = iCategoryService.getAllCategories();
            ViewBag.listCategory = listCategory;
            /* _ _ _ _ _ _ _ _ _ _ _ _ _ _ _ _ _ _ _ _ _ _ _  */

            return View(subcategory);
        }

        // POST: Subcategory/Edit/5
        [HttpPost]
        public ActionResult Edit(Subcategory subcategory)
        {
            try
            {

                if (ModelState.IsValid)
                {
                    iSubcategoryService.UpdateSubcategory(subcategory);
                    return RedirectToAction("Index");
                }

            }
            catch
            {
                return View();
            }

            return View();
        }

        // GET: Subcategory/Delete/5
        public ActionResult Delete(long id)
        {
            return View();
        }

        // POST: Subcategory/Delete/5
        [HttpPost]
        public ActionResult Delete(long id, FormCollection collection)
        {
            try
            {
                iSubcategoryService.Delete(c => c.subcategoryId == id);
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
