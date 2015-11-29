using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using YouBay.Data.Models.Mapping;

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

        public DbSet<t_assistantitems> t_assistantitems { get; set; }
        public DbSet<t_auction> t_auction { get; set; }
        public DbSet<t_category> t_category { get; set; }
        public DbSet<t_customizedads> t_customizedads { get; set; }
        public DbSet<t_historyofviews> t_historyofviews { get; set; }
        public DbSet<t_orderandreview> t_orderandreview { get; set; }
        public DbSet<t_product> t_product { get; set; }
        public DbSet<t_producthistory> t_producthistory { get; set; }
        public DbSet<t_specialpromotion> t_specialpromotion { get; set; }
        public DbSet<t_subcategory> t_subcategory { get; set; }
        public DbSet<t_user> t_user { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Configurations.Add(new t_assistantitemsMap());
            modelBuilder.Configurations.Add(new t_auctionMap());
            modelBuilder.Configurations.Add(new t_categoryMap());
            modelBuilder.Configurations.Add(new t_customizedadsMap());
            modelBuilder.Configurations.Add(new t_historyofviewsMap());
            modelBuilder.Configurations.Add(new t_orderandreviewMap());
            modelBuilder.Configurations.Add(new t_productMap());
            modelBuilder.Configurations.Add(new t_producthistoryMap());
            modelBuilder.Configurations.Add(new t_specialpromotionMap());
            modelBuilder.Configurations.Add(new t_subcategoryMap());
            modelBuilder.Configurations.Add(new t_userMap());
        }
    }
}
