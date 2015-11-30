using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using YouBay.Data.Models.Mapping;
using YouBay.Domain.Entities;

namespace YouBay.Data.Models
{
    public partial class fusiondbContext : DbContext
    {
        static fusiondbContext()
        {
            Database.SetInitializer<fusiondbContext>(null);
        }

        public fusiondbContext()
            : base("Name=fusiondbContext")
        {
        }

        public DbSet<AssistantItems> t_assistantitems { get; set; }
        public DbSet<Auction> t_auction { get; set; }
        public DbSet<Category> t_category { get; set; }
        public DbSet<CustomizedAds> t_customizedads { get; set; }
        public DbSet<HistoryOfViews> t_historyofviews { get; set; }
        public DbSet<OrderAndReview> t_orderandreview { get; set; }
        public DbSet<Product> t_product { get; set; }
        public DbSet<ProductHistory> t_producthistory { get; set; }
        public DbSet<SpecialPromotion> t_specialpromotion { get; set; }
        public DbSet<Subcategory> t_subcategory { get; set; }
        public DbSet<YouBayUser> t_user { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Configurations.Add(new AssistantitemsMap());
            modelBuilder.Configurations.Add(new AuctionMap());
            modelBuilder.Configurations.Add(new CategoryMap());
            modelBuilder.Configurations.Add(new CustomizedAdsMap());
            modelBuilder.Configurations.Add(new HistoryOfViewsMap());
            modelBuilder.Configurations.Add(new OrderAndReviewMap());
            modelBuilder.Configurations.Add(new ProductMap());
            modelBuilder.Configurations.Add(new ProductHistoryMap());
            modelBuilder.Configurations.Add(new SpecialPromotionMap());
            modelBuilder.Configurations.Add(new SubcategoryMap());
            modelBuilder.Configurations.Add(new YouBayUserMap());
        }
    }
}
