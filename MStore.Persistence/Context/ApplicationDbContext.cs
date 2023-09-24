using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage;
using MStore.Domain.Entities;
using MStore.Domain.Entities.Catalog.Common;
using MStore.Domain.Entities.Catalog.Products;
using MStore.Domain.Entities.CMS.Commons;
using MStore.Domain.Entities.Identities;
using MStore.Domain.Entities.Subscriptions;
using System.Data;
using MStore.Persistence.EntityConfig;
using MStore.Domain.Financials;
using MStore.Domain.Entities.Financials;
using MStore.Domain.Entities.Customers;

namespace MStore.Persistence.Context
{
    public class ApplicationDbContext : IdentityDbContext<AppUsers>
    {
        private IDbContextTransaction _currentTransaction;
       
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> dbContextOptions) : base(dbContextOptions)
        {
            //try
            //{
            //    var databaseCreator = Database.GetService<IDatabaseCreator>() as RelationalDatabaseCreator;
            //    if (databaseCreator != null)
            //    {
            //        if (!databaseCreator.CanConnect()) databaseCreator.Create();
            //        if (!databaseCreator.HasTables()) databaseCreator.CreateTables();
            //    }
            //}
            //catch (Exception ex)
            //{
            //    Console.WriteLine(ex.Message);
            //}
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.EnableDetailedErrors();
        }
            

        public override Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
        {
            AddAuditInfo();
            return base.SaveChangesAsync(cancellationToken);
        }
        private void AddAuditInfo()
        {
            var timestamp = DateTime.UtcNow;


            foreach (var entry in ChangeTracker.Entries().Where(x => x.Entity is BaseEntity && (x.State == EntityState.Added || x.State == EntityState.Modified)))
            {

                if (entry.State == EntityState.Added)
                {

                    ((BaseEntity)entry.Entity).CreatedDate = timestamp;
                }
                else
                {
                    ((BaseEntity)entry.Entity).UpdatedDate = timestamp;
                    ((BaseEntity)entry.Entity).CreatedDate = (DateTime?)entry.Property("CreatedDate").OriginalValue;
                }

            }
        }

        public DbSet<Category> Categories { get; set; }
        public DbSet<Brand> Brands { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<ProductTags> ProductTags { get; set; }
        public DbSet<ProductAttribute> ProductAttributes { get; set; }
        public DbSet<ProductAttributeValue> ProductAttributeValues { get; set; }
        public DbSet<ProductAttributeCombination> ProductAttributeCombinations { get; set; }
        public DbSet<Navigation> Navigations { get; set; }
        public DbSet<Plans> Plans { get; set; }
        public DbSet<Subscription> Subscriptions { get; set; }
        public DbSet<TaxCategory> TaxCategories { get; set; }
        public DbSet<Slider> Sliders { get; set; }
        public DbSet<Offers> Offers { get; set; }
        public DbSet<GiftCard> GiftCards { get; set; }
        public DbSet<Shipping> Shippings { get; set; }
        public DbSet<Currency> Currencies { get; set; }
        public DbSet<Customer> Customers { get; set; }
        public DbSet<Address> Adresses { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.ApplyConfiguration(new ProductEntityConfiguration());
            modelBuilder.ApplyConfiguration(new ProductTagsEntityConfiguration());
            modelBuilder.ApplyConfiguration(new SubscriptionEntityConfiguration());
            modelBuilder.ApplyConfiguration(new ProductAttributeValueEntityConfiguration());
            modelBuilder.ApplyConfiguration(new ProductArributeCombinationEntityConfiguration());

        }
        public async Task<IDbContextTransaction> BeginTransactionAsync()
        {
            if (_currentTransaction != null) return null;

            _currentTransaction = await Database.BeginTransactionAsync(IsolationLevel.ReadCommitted);

            return _currentTransaction;
        }
        public async Task CommitTransactionAsync(IDbContextTransaction transaction)
        {
            if (transaction == null) throw new ArgumentNullException(nameof(transaction));
            if (transaction != _currentTransaction) throw new InvalidOperationException($"Transaction {transaction.TransactionId} is not current");

            try
            {
                await SaveChangesAsync();
                await transaction.CommitAsync();
            }
            catch
            {
                RollbackTransaction();
                throw;
            }
            finally
            {
                if (_currentTransaction != null)
                {
                    _currentTransaction.Dispose();
                    _currentTransaction = null;
                }
            }
        }
        public void RollbackTransaction()
        {
            try
            {
                _currentTransaction?.Rollback();
            }
            finally
            {
                if (_currentTransaction != null)
                {
                    _currentTransaction.Dispose();
                    _currentTransaction = null;
                }
            }
        }
    }
}
