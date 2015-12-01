using System;
using Microsoft.Practices.Unity;
using Microsoft.Practices.Unity.Configuration;
using Data.Repositories;
using YouBay.Data.Infrastructure;
using YouBay.Service.Services;

namespace YouBay.Web.App_Start
{
    /// <summary>
    /// Specifies the Unity configuration for the main container.
    /// </summary>
    public class UnityConfig
    {
        #region Unity Container
        private static Lazy<IUnityContainer> container = new Lazy<IUnityContainer>(() =>
        {
            var container = new UnityContainer();
            RegisterTypes(container);
            return container;
        });

        /// <summary>
        /// Gets the configured Unity container.
        /// </summary>
        public static IUnityContainer GetConfiguredContainer()
        {
            return container.Value;
        }
        #endregion

        /// <summary>Registers the type mappings with the Unity container.</summary>
        /// <param name="container">The unity container to configure.</param>
        /// <remarks>There is no need to register concrete types such as controllers or API controllers (unless you want to 
        /// change the defaults), as Unity allows resolving a concrete type even if it was not previously registered.</remarks>
        public static void RegisterTypes(IUnityContainer container)
        {
            // NOTE: To load from web.config uncomment the line below. Make sure to add a Microsoft.Practices.Unity.Configuration to the using statements.
            // container.LoadConfiguration();

            // TODO: Register your types here
            // container.RegisterType<IProductRepository, ProductRepository>();

            /* ------------------------------------------------------------------------------------------------------ */

            container.RegisterType<ICategoryService, CategoryService>(new PerRequestLifetimeManager());
            container.RegisterType<ICategoryRepository, CategoryRepository>(new PerRequestLifetimeManager() );
            container.RegisterType<ISubcategoryService, SubcategoryService>(new PerRequestLifetimeManager());
            container.RegisterType<ISubcategoryRepository, SubcategoryRepository>(new PerRequestLifetimeManager());
            container.RegisterType<IAssistantItemsService, AssistantItemsService>(new PerRequestLifetimeManager());
            container.RegisterType<IAssistantItemsRepository, AssistantItemsRepository>(new PerRequestLifetimeManager());


            container.RegisterType<IAuctionService, AuctionService>(new PerRequestLifetimeManager());
            container.RegisterType<IAuctionRepository, AuctionRepository>(new PerRequestLifetimeManager());


            container.RegisterType<IBuyerService, BuyerService>(new PerRequestLifetimeManager());
            container.RegisterType<IBuyerRepository, BuyerRepository>(new PerRequestLifetimeManager());


            container.RegisterType<ICustomizedAdsService, CustomizedAdsService>(new PerRequestLifetimeManager());
            container.RegisterType<ICustomizedAdsRepository, CustomizedAdsRepository>(new PerRequestLifetimeManager());



            container.RegisterType<IHistoryOfViewsService, HistoryOfViewsService>(new PerRequestLifetimeManager());
            container.RegisterType<IHistoryOfViewsRepository, HistoryOfViewsRepository>(new PerRequestLifetimeManager());


            container.RegisterType<IManagerService, ManagerService>(new PerRequestLifetimeManager());
            container.RegisterType<IManagerRepository, ManagerRepository>(new PerRequestLifetimeManager());


            container.RegisterType<IOrderAndReviewService, OrderAndReviewService>(new PerRequestLifetimeManager());
            container.RegisterType<IOrderAndReviewRepository, OrderAndReviewRepository>(new PerRequestLifetimeManager());


            container.RegisterType<IProductHistoryService, ProductHistoryService>(new PerRequestLifetimeManager());
            container.RegisterType<IProductHistoryRepository, ProductHistoryRepository>(new PerRequestLifetimeManager());


            container.RegisterType<IProductService, ProductService>(new PerRequestLifetimeManager());
            container.RegisterType<IProductRepository, ProductRepository>(new PerRequestLifetimeManager());


            container.RegisterType<ISellerService, SellerService>(new PerRequestLifetimeManager());
            container.RegisterType<ISellerRepository, SellerRepository>(new PerRequestLifetimeManager());


            container.RegisterType<ISpecialPromotionService, SpecialPromotionService>(new PerRequestLifetimeManager());
            container.RegisterType<ISpecialPromotionRepository, SpecialPromotionRepository>(new PerRequestLifetimeManager());



            container.RegisterType<IYouBayUserService, YouBayUserService>(new PerRequestLifetimeManager());
            container.RegisterType<IYouBayUserRepository, YouBayUserRepository>(new PerRequestLifetimeManager());
            /* ------------------------------------------------------------------------------------------------------ */


            container.RegisterType<IUnitOfWork, UnitOfWork>(new PerRequestLifetimeManager());
            container.RegisterType<IDatabaseFactory, DatabaseFactory>(new PerRequestLifetimeManager());

        }
    }
}
