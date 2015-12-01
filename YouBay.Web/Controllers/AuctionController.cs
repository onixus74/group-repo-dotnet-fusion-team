
using System.Web.Mvc;
using YouBay.Domain.Entities;
using YouBay.Service.Services;

namespace YouBay.Web.Controllers
{
    public class AuctionController : Controller
    {

        IAuctionService iAuctionService;
        public AuctionController(IAuctionService iAuctionService)
        {
            this.iAuctionService = iAuctionService;
        }


        // GET: Auction
        public ActionResult Index()
        {
            var categories = iAuctionService.getAllCategories();
            return View(categories);
        }

        // GET: Auction/Details/5
        public ActionResult Details(long id)
        {
            var auction = iAuctionService.Get(c => c.auctionId == id);
            return View(auction);
        }

        // GET: Auction/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Auction/Create
        [HttpPost]
        public ActionResult Create(Auction auction)
        {
            try
            {
                
                if (ModelState.IsValid)
                {
                    iAuctionService.AddAuction(auction);
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

        // GET: Auction/Edit/5
        public ActionResult Edit(long id)
        {
            Auction auction = iAuctionService.Get(c => c.auctionId == id);
            return View(auction);
        }

        // POST: Auction/Edit/5
        [HttpPost]
        public ActionResult Edit(Auction auction)
        {
            try
            {

                if (ModelState.IsValid)
                {
                    iAuctionService.UpdateAuction(auction);
                    return RedirectToAction("Index");
                }

            }
            catch
            {
                return View();
            }

            return View();
        }

        // GET: Auction/Delete/5
        public ActionResult Delete(long id)
        {
            return View();
        }

        // POST: Auction/Delete/5
        [HttpPost]
        public ActionResult Delete(long id, FormCollection collection)
        {
            try
            {
                iAuctionService.Delete(c => c.auctionId == id);
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
