using Data.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using YouBay.Data.Models;

namespace YouBay.Data.Infrastructure
{
    public class UnitOfWork : IUnitOfWork
    {

        private fusiondbContext dataContext;
        protected fusiondbContext DataContext
        {
            get
            {
                return dataContext = dbFactory.DataContext;
            }
        }

        IDatabaseFactory dbFactory;
        public UnitOfWork(IDatabaseFactory dbFactory)
        {
            this.dbFactory = dbFactory;
        }
        public void Commit()
        {
            DataContext.SaveChanges();
        }

        public void Dispose()
        {
            DataContext.Dispose();
        }

        /* ---------------------------------------------------------------------- */
        private ICategoryRepository categoryRepository;
        public ICategoryRepository CategoryRepository
        {
            get { return categoryRepository = new CategoryRepository(dbFactory); ; }
        }


        private ISubcategoryRepository subcategoryRepository;
        public ISubcategoryRepository SubcategoryRepository
        {
            get { return subcategoryRepository = new SubcategoryRepository(dbFactory); ; }
        }


        private IAssistantItemsRepository assistantItemsRepository;
        public IAssistantItemsRepository AssistantItemsRepository
        {
            get { return assistantItemsRepository = new AssistantItemsRepository(dbFactory); ; }
        }


        private IAuctionRepository auctionRepository;
        public IAuctionRepository AuctionRepository
        {
            get { return auctionRepository = new AuctionRepository(dbFactory); ; }
        }



        private IBuyerRepository buyerRepository;
        public IBuyerRepository BuyerRepository
        {
            get { return buyerRepository = new BuyerRepository(dbFactory); ; }
        }

        private ICustomizedAdsRepository customizedAdsRepository;
        public ICustomizedAdsRepository CustomizedAdsRepository
        {
            get { return customizedAdsRepository = new CustomizedAdsRepository(dbFactory); ; }
        }


        private IHistoryOfViewsRepository historyOfViewsRepository;
        public IHistoryOfViewsRepository HistoryOfViewsRepository
        {
            get { return historyOfViewsRepository = new HistoryOfViewsRepository(dbFactory); ; }
        }


        private IManagerRepository managerRepository;
        public IManagerRepository ManagerRepository
        {
            get { return managerRepository = new ManagerRepository(dbFactory); ; }
        }


        private IOrderAndReviewRepository orderAndReviewRepository;
        public IOrderAndReviewRepository OrderAndReviewRepository
        {
            get { return orderAndReviewRepository = new OrderAndReviewRepository(dbFactory); ; }
        }


        private IProducthistoryRepository producthistoryRepository;
        public IProducthistoryRepository ProducthistoryRepository
        {
            get { return producthistoryRepository = new ProducthistoryRepository(dbFactory); ; }
        }

        private IProductRepository productRepository;
        public IProductRepository ProductRepository
        {
            get { return productRepository = new ProductRepository(dbFactory); ; }
        }


        private ISellerRepository sellerRepository;
        public ISellerRepository SellerRepository
        {
            get { return sellerRepository = new SellerRepository(dbFactory); ; }
        }


        private ISpecialPromotionRepository specialPromotionRepository;
        public ISpecialPromotionRepository SpecialPromotionRepository
        {
            get { return specialPromotionRepository = new SpecialPromotionRepository(dbFactory); ; }
        }





        private IYouBayUserRepository youBayUserRepository;
        public IYouBayUserRepository YouBayUserRepository
        {
            get { return youBayUserRepository = new YouBayUserRepository(dbFactory); ; }
        }

        /* ---------------------------------------------------------------------- */



    }
}
