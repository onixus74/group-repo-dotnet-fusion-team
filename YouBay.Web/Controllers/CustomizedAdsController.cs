using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace YouBay.Web.Controllers
{
    public class CustomizedAdsController : Controller
    {
        // GET: CustomizedAds
        public ActionResult Index()
        {
            return View();
        }

        // GET: CustomizedAds/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: CustomizedAds/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: CustomizedAds/Create
        [HttpPost]
        public ActionResult Create(FormCollection collection)
        {
            try
            {
                // TODO: Add insert logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: CustomizedAds/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: CustomizedAds/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: CustomizedAds/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: CustomizedAds/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
