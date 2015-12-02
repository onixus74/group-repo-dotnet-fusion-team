using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using System.Net;
using System.Web;
using System.Web.Mvc;
using MVCYoubay2.Helpers;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.Owin;
using YouBay.Web.Models;
using YouBay.Service.Services;
using YouBay.Domain.Entities;

namespace YouBay.Web.Controllers
{
    public class CartsController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();
        private ApplicationSignInManager _signInManager;
        private ApplicationUserManager _userManager;

        public CartsController(ApplicationUserManager userManager, ApplicationSignInManager signInManager)
        {
            UserManager = userManager;
            SignInManager = signInManager;
        }

        public CartsController()
        {

        }

        IProductService iProductService;
        public CartsController(IProductService iProductService)
        {
            this.iProductService = iProductService;
        }

        public ApplicationSignInManager SignInManager
        {
            get
            {
                return _signInManager ?? HttpContext.GetOwinContext().Get<ApplicationSignInManager>();
            }
            private set
            {
                _signInManager = value;
            }
        }

        public ApplicationUserManager UserManager
        {
            get
            {
                return _userManager ?? HttpContext.GetOwinContext().GetUserManager<ApplicationUserManager>();
            }
            private set
            {
                _userManager = value;
            }
        }

        //[AllowAnonymous]
        //public ActionResult Index()
        //{
        //    ViewBag.Liste = ListCart.Instance.Items;
        //    ViewBag.total = ListCart.Instance.GetSubTotal();
        //    return View();

        //}


        [AllowAnonymous]
        public ActionResult AddProduct(int? id)
        {

            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            Product pp = iProductService.Get(p => p.productId == id);


            ListCart.Instance.AddItem(pp);
            ViewBag.List = ListCart.Instance.Items;
            ViewBag.total =ListCart.Instance.GetSubTotal();
            return View();

        }


        [HttpPost]
        [AllowAnonymous]
        public ActionResult PlusProduct(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            Product pp = iProductService.Get(p => p.productId == id);
            ListCart.Instance.AddItem(pp);
            Item foundItem = null;

            foreach (Item a in ListCart.Instance.Items)
            {
                if (a.Prod.productId == pp.productId)
                    foundItem = a;
            }

            var results = new
            {
                ct = 1,
                Total = ListCart.Instance.GetSubTotal(),
                Quatite = foundItem.Quantity,
                TotalRow = foundItem.TotalPrice
            };
            return Json(results);
        }

        [HttpPost]
        [AllowAnonymous]
        public ActionResult LessProduct(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            Product pp = iProductService.Get(p => p.productId == id);
            ListCart.Instance.SetLessOneItem(pp);
            Item trouve = null;

            foreach (Item a in ListCart.Instance.Items)
            {
                if (a.Prod.productId == pp.productId)
                    trouve = a;
            }



            if (trouve != null)
            {
                var results = new
                {

                    Total = ListCart.Instance.GetSubTotal(),
                    Quatite = trouve.Quantity,
                    TotalRow = trouve.TotalPrice,
                    ct = 1
                };

                return Json(results);

            }
            else
            {
                var results = new
                {
                    ct = 0
                };

                return Json(results);
            }
            return null;


        }

        public ActionResult CheckOut()
        {

            return View();
        }

        [HttpPost]
        public ActionResult CheckOut(FormCollection collection)
        {
            ListCart.Instance.Items.Clear();

            ViewBag.Message = "Purchase Success";

            return View();

        }

        // GET: Carts
        public async Task<ActionResult> Index()
        {
            return View(await db.Carts.ToListAsync());
        }

        // GET: Carts/Details/5
        public async Task<ActionResult> Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Cart cart = await db.Carts.FindAsync(id);
            if (cart == null)
            {
                return HttpNotFound();
            }
            return View(cart);
        }



        [HttpPost]
        [AllowAnonymous]
        public ActionResult DeleteProduct(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            Product pp = iProductService.Get(p => p.productId == id);
            ListCart.Instance.RemoveItem(pp);
            var results = new
            {
                Total = ListCart.Instance.GetSubTotal(),
            };

            return Json(results);
        }

        // GET: Carts/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Carts/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "CartId")] Cart cart)
        {
            if (ModelState.IsValid)
            {
                db.Carts.Add(cart);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            return View(cart);
        }

        // GET: Carts/Edit/5
        public async Task<ActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Cart cart = await db.Carts.FindAsync(id);
            if (cart == null)
            {
                return HttpNotFound();
            }
            return View(cart);
        }

        // POST: Carts/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "CartId")] Cart cart)
        {
            if (ModelState.IsValid)
            {
                db.Entry(cart).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return View(cart);
        }

        // GET: Carts/Delete/5
        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Cart cart = await db.Carts.FindAsync(id);
            if (cart == null)
            {
                return HttpNotFound();
            }
            return View(cart);
        }

        // POST: Carts/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            Cart cart = await db.Carts.FindAsync(id);
            db.Carts.Remove(cart);
            await db.SaveChangesAsync();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
