using DGS.BusinessObjects.Common;
using DGS.BusinessObjects.Entities;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;

namespace DGS.BusinessObjects
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public ApplicationDbContext(DbContextOptions options) : base(options)
        {
            
        }

        public ApplicationDbContext()
        {
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            builder.Entity<ApplicationUser>(entity =>
            {
                entity.Property(x => x.Id).HasMaxLength(50).IsRequired(true);
            });

            builder.Entity<ApplicationRole>(entity =>
            {
                entity.Property(x => x.Id).HasMaxLength(50).IsRequired(true);
            });

            builder.Entity<ApplicationRole>()
                .HasData(
                new ApplicationRole { Id = Guid.NewGuid().ToString() , Name="Admin",Description = "Admin", NormalizedName ="ADMIN"},
                new ApplicationRole { Id = Guid.NewGuid().ToString() , Name="Staff", Description = "Staff", NormalizedName ="STAFF"},
                new ApplicationRole { Id = Guid.NewGuid().ToString() , Name="Customer", Description = "Customer", NormalizedName ="CUSTOMER"}
                );

            builder.Entity<Size>().HasData(
                new Size { Id = 5, SizeName = "S"},
                new Size { Id = 6, SizeName = "M"},
                new Size { Id = 7, SizeName = "L"},
                new Size { Id = 8, SizeName = "XL"},
                new Size { Id = 9, SizeName = "2XL"},
                new Size { Id = 10, SizeName = "3XL"},
                new Size { Id = 11, SizeName = "4XL"}
            ); ;
        }


        public virtual DbSet<ApplicationUser> ApplicationUsers { get; set; }    
        public virtual DbSet<Product> Products { get; set; }
        public virtual DbSet<Category> Categories { get; set; }
        public virtual DbSet<Order> Orders { get; set; }
        public virtual DbSet<OrderDetail> OrderDetails { get; set; }
        public virtual DbSet<Size> Sizes { get; set; }
        public virtual DbSet<ProductSize> ProductSizes { get; set; }
        public virtual DbSet<RefreshToken> RefreshTokens { get; set; }

        public override int SaveChanges()
        {
            TrackingEntities();
            return base.SaveChanges();
        }

        public override async Task<int> SaveChangesAsync(bool acceptAllChangesOnSuccess, CancellationToken cancellationToken = default)
        {
            TrackingEntities();
            return await base.SaveChangesAsync(acceptAllChangesOnSuccess, cancellationToken);
        }
        private void TrackingEntities()
        {
            var modified = ChangeTracker.Entries().Where(e => e.State == EntityState.Modified || e.State == EntityState.Added);

            foreach (EntityEntry item in modified)
            {
                var changedOrAddedItem = item.Entity as BaseEntity<int>;
                if (changedOrAddedItem != null)
                {
                    if (item.State == EntityState.Added)
                    {
                        changedOrAddedItem.CreatedAt = DateTime.Now;
                    }
                    changedOrAddedItem.UpdatedAt = DateTime.Now;
                    changedOrAddedItem.IsDeleted = false;
                }
            }
        }

    }
}
