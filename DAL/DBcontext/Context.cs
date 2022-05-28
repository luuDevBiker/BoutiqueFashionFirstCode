using DAL.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.DBcontext
{
    public class Context : DbContext
    {
        public Context(DbContextOptions<Context> options) : base(options)
        {

        }

        public DbSet<user>? users { get; set; }
        public DbSet<RolesUser>? rolesUsers { get; set; }
        public DbSet<cart>? carts { get; set; }
        public DbSet<cartDetails>? cartDetails { get; set; }
        public DbSet<ProductVariants>? productVariants { get; set; }
        public DbSet<VariantValues>? variantValues { get; set; }
        public DbSet<OptionValues>? optionValues { get; set; }
        public DbSet<Options>? options { get; set; }
        public DbSet<ProductOptions>? productOptions { get; set; }
        public DbSet<Products>? products { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<RolesUser>(rolesUser =>
            {
                rolesUser.HasKey(p => p.rolesID);
                rolesUser.ToTable("rolesUsers");
                rolesUser.Property(p => p.rolesID).IsRequired();
                rolesUser.Property(p => p.isRolesUserEnabled).HasDefaultValue(true);

            });
            modelBuilder.Entity<user>(user =>
            {
                user.ToTable("users");
                user.HasKey(p => p.userID);
                user.Property(p => p.rolesID).IsRequired();
                user.Property(p => p.userName).IsRequired();
                user.Property(p => p.Gender).HasDefaultValue(1);
                user.Property(p => p.isUserEnabled).HasDefaultValue(true);
                user.HasOne<RolesUser>(p => p.rolesUsers).WithMany(p => p.users).HasForeignKey(p => p.rolesID);
            });
            modelBuilder.Entity<cart>(cart =>
            {
                cart.ToTable("carts");
                cart.HasKey(p => p.cartID);
                cart.Property(p => p.userID).IsRequired();
                cart.Property(p => p.orderTime).HasDefaultValue(DateTime.Now.ToString("HH:mm:ss tt"));
                cart.Property(p => p.payingCustomer).IsRequired();
                cart.Property(p => p.payments).IsRequired();
                cart.Property(p => p.statusDelete).HasDefaultValue(true);
                cart.Property(p => p.isOrderEnabled).HasDefaultValue(true);
                cart.HasOne<user>(p => p.user).WithMany(p => p.carts).HasForeignKey(p => p.userID);
            });
            modelBuilder.Entity<ProductVariants>(productVariants =>
            {
                productVariants.ToTable("productVariants");
                productVariants.HasKey(p => p.variantID);
                productVariants.Property(p => p.importPrice).IsRequired();
                productVariants.Property(p => p.price).IsRequired();
                productVariants.Property(p => p.qunatity).IsRequired();
                productVariants.Property(p => p.isProductVariantEnabled).HasDefaultValue(true);
                productVariants.HasOne<Products>(p => p.product).WithMany(p => p.productVariants).HasForeignKey(p => p.productID);
            });
            modelBuilder.Entity<Products>(products =>
            {
                products.ToTable("products");
                products.HasKey(p => p.productID);
                products.Property(p => p.productName).IsRequired();
                products.Property(p => p.isProductEnabled).HasDefaultValue(true);

            });
            modelBuilder.Entity<Options>(options =>
            {
                options.ToTable("options");
                options.HasKey(p => p.optionID);
                options.Property(p => p.optionName).IsRequired();
                options.Property(p => p.isOptionEnabled).HasDefaultValue(true);

            });
            modelBuilder.Entity<ProductOptions>(productOptions =>
            {
                productOptions.HasKey(p => new { p.optionID, p.productID });
                productOptions.Property(p => p.isProductOptionEnabled).HasDefaultValue(true);
                productOptions.HasOne<Products>(p => p.products).WithMany(p => p.productOptions).HasForeignKey(p => p.productID);
                productOptions.HasOne<Options>(p => p.options).WithMany(p => p.productOptions).HasForeignKey(p => p.optionID);

            });
            modelBuilder.Entity<OptionValues>(optionValues =>
            {
                optionValues.ToTable("optionValues");
                optionValues.HasKey(p => p.valuesID);
                optionValues.Property(p => p.optionValues).IsRequired();
                optionValues.Property(p => p.isOptionValueEnabled).HasDefaultValue(true);
                optionValues.HasOne<Options>(p => p.options).WithMany(p => p.optionValues).HasForeignKey(p => p.optionID);
            });
            modelBuilder.Entity<VariantValues>(variantValues =>
            {
                variantValues.ToTable("variantValues");
                variantValues.HasKey(p => new { p.productID, p.variantID, p.optionID, p.valuesID });
                variantValues.Property(p => p.isVariantValueEnabled).HasDefaultValue(true);
                variantValues.HasOne<ProductVariants>(p => p.productVariant).WithMany(p => p.variantValues).HasForeignKey(p => p.variantID);
                variantValues.HasOne<OptionValues>(p => p.optionValue).WithMany(p => p.variantValues).HasForeignKey(p => p.valuesID);

            });
            modelBuilder.Entity<cartDetails>(cartDetails =>
            {
                cartDetails.ToTable("cartDetails");
                cartDetails.HasKey(p => new { p.orderID, p.variantID });
                cartDetails.Property(p => p.quantity).HasDefaultValue(1);
                cartDetails.Property(p => p.unitPrice).IsRequired();
                cartDetails.HasOne<cart>(p => p.carts).WithMany(p => p.cartDetails).HasForeignKey(p => p.orderID);
                cartDetails.HasOne<ProductVariants>(p => p.productVariants).WithMany(p => p.CartDetails).HasForeignKey(p => p.variantID);
            });
        }
    }
}
