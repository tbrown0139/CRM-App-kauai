using Microsoft.Azure.Mobile.Server.Tables;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Linq;

using XamarinCRMv2CatalogDataService.DataObjects;

namespace XamarinCRMv2CatalogDataService.Models
{

    public class MobileServiceContext : DbContext
    {
        // You can add custom code to this file. Changes will not be overwritten.
        // 
        // If you want Entity Framework to alter your database
        // automatically whenever you change your model schema, please use data migrations.
        // For more information refer to the documentation:
        // http://msdn.microsoft.com/en-us/data/jj591621.aspx
        //
        // To enable Entity Framework migrations in the cloud, please ensure that the 
        // service name, set by the 'MS_MobileServiceName' AppSettings in the local 
        // Web.config, is the same as the service name when hosted in Azure.

        private const string connectionStringName = "Name=MS_TableConnectionString";

        public MobileServiceContext() : base(connectionStringName) { }

        public DbSet<Category> Categories { get; set; }
        public DbSet<Product> Products { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Category>().HasKey(c => c.Id);

            modelBuilder.Entity<Product>().HasKey(p => p.Id);

            modelBuilder.Entity<Category>()
                .HasOptional(c => c.ParentCategory)
                .WithMany(c => c.SubCategories)
                .HasForeignKey(c => c.ParentCategoryId);

            modelBuilder.Entity<Product>()
                .HasRequired<Category>(p => p.Category)
                .WithMany(c => c.Products)
                .HasForeignKey(p => p.CategoryId);

            string schema = System.Configuration.ConfigurationManager.AppSettings.Get("MS_MobileServiceName");
            if (!string.IsNullOrEmpty(schema))
            {
                modelBuilder.HasDefaultSchema(schema);
            }

            modelBuilder.Conventions.Add(
                new AttributeToColumnAnnotationConvention<TableColumnAttribute, string>(
                    "ServiceTableColumn", (property, attributes) => attributes.Single().ColumnType.ToString()));
            modelBuilder.Types<Account>().Configure(x => x.Ignore(prop => prop.CreatedAt));
            modelBuilder.Types<Account>().Configure(x => x.Ignore(prop => prop.UpdatedAt));

            modelBuilder.Types<Order>().Configure(x => x.Ignore(prop => prop.CreatedAt));
            modelBuilder.Types<Order>().Configure(x => x.Ignore(prop => prop.UpdatedAt));

            modelBuilder.Types<Category>().Configure(x => x.Ignore(prop => prop.CreatedAt));
            modelBuilder.Types<Category>().Configure(x => x.Ignore(prop => prop.UpdatedAt));

            modelBuilder.Types<Product>().Configure(x => x.Ignore(prop => prop.CreatedAt));
            modelBuilder.Types<Product>().Configure(x => x.Ignore(prop => prop.UpdatedAt));

            //Database.SetInitializer<Context>(new JobDbContextInitializer());
        }

        public System.Data.Entity.DbSet<XamarinCRMv2CatalogDataService.DataObjects.Account> Accounts { get; set; }

        public System.Data.Entity.DbSet<XamarinCRMv2CatalogDataService.DataObjects.Order> Orders { get; set; }
    }
}
