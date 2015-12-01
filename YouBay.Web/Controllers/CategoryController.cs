using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using YouBay.Domain.Entities;
using YouBay.Service.Services;

namespace YouBay.Web.Controllers
{
    public class CategoryController : Controller
    {

        ICategoryService iCategoryService;
        public CategoryController(ICategoryService iCategoryService)
        {
            this.iCategoryService = iCategoryService;
        }


        // GET: Category
        public ActionResult Index()
        {
            var categories = iCategoryService.getAllCategories();
            return View(categories);
        }

        // GET: Category/Details/5
        public ActionResult Details(long id)
        {
            var category = iCategoryService.Get(c => c.categoryId == id);
            return View(category);
        }

        // GET: Category/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Category/Create
        [HttpPost]
        public ActionResult Create(Category category)
        {
            try
            {
                
                if (ModelState.IsValid)
                {
                    iCategoryService.AddCategory(category);
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

        // GET: Category/Edit/5
        public ActionResult Edit(long id)
        {
            Category category = iCategoryService.Get(c => c.categoryId == id);
            return View(category);
        }

        // POST: Category/Edit/5
        [HttpPost]
        public ActionResult Edit(Category category)
        {
            try
            {

                if (ModelState.IsValid)
                {
                    iCategoryService.UpdateCategory(category);
                    return RedirectToAction("Index");
                }

            }
            catch
            {
                return View();
            }

            return View();
        }

        // GET: Category/Delete/5
        public ActionResult Delete(long id)
        {
            return View();
        }

        // POST: Category/Delete/5
        [HttpPost]
        public ActionResult Delete(long id, FormCollection collection)
        {
            try
            {
                iCategoryService.Delete(c => c.categoryId == id);
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
