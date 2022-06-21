using DAL.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using DAL.ValueObject;

namespace DAL.DBcontext
{
    public class Context : DbContext
    {
        public Context(DbContextOptions<Context> options) : base(options)
        {

        }

        public DbSet<user> users { get; set; }
        public DbSet<RolesUser> rolesUsers { get; set; }
        public DbSet<Order> orders { get; set; }
        public DbSet<OrderDetails> orderDetails { get; set; }
        public DbSet<ProductVariants> productVariants { get; set; }
        public DbSet<VariantValues> variantValues { get; set; }
        public DbSet<OptionValues> optionValues { get; set; }
        public DbSet<Options> options { get; set; }
        public DbSet<ProductOptions> productOptions { get; set; }
        public DbSet<Products> products { get; set; }
        public DbSet<CartItem> cartItems { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<RolesUser>(rolesUser =>
            {
                rolesUser.HasKey(p => p.RolesID);
                rolesUser.ToTable("rolesUsers");
                rolesUser.Property(p => p.RolesID).IsRequired();
                rolesUser.Property(p => p.IsRolesUserEnabled).HasDefaultValue(true);

            });
            modelBuilder.Entity<user>(user =>
            {
                user.ToTable("users");
                user.HasKey(p => p.UserID);
                user.Property(p => p.RolesID).IsRequired();
                user.Property(p => p.UserName).IsRequired();
                user.Property(p => p.Gender).HasDefaultValue(1);
                user.Property(p => p.IsUserEnabled).HasDefaultValue(true);
                user.HasOne<RolesUser>(p => p.RolesUsers).WithMany(p => p.Users).HasForeignKey(p => p.RolesID);
                user.Property(p => p.Avatar).HasConversion(
                  v => JsonConvert.SerializeObject(v, new JsonSerializerSettings { NullValueHandling = NullValueHandling.Ignore }),
                  v => JsonConvert.DeserializeObject<ImageValueObject>(v, new JsonSerializerSettings { NullValueHandling = NullValueHandling.Ignore })
                  );
                user.Property(p => p.Profile).HasConversion(
                  v => JsonConvert.SerializeObject(v, new JsonSerializerSettings { NullValueHandling = NullValueHandling.Ignore }),
                  v => JsonConvert.DeserializeObject<List<ProfilesUser>>(v, new JsonSerializerSettings { NullValueHandling = NullValueHandling.Ignore })
                  );
            });
            modelBuilder.Entity<Order>(cart =>
            {
                cart.ToTable("Orders");
                cart.HasKey(p => p.OrderID);
                cart.Property(p => p.UserID).IsRequired();
                cart.Property(p => p.OrderTime).HasDefaultValue(DateTime.Now.ToString("HH:mm:ss tt"));
                cart.Property(p => p.PayingCustomer).IsRequired();
                cart.Property(p => p.Payments).IsRequired();
               
                cart.Property(p => p.IsOrderEnabled).HasDefaultValue(true);
                cart.HasOne<user>(p => p.User).WithMany(p => p.Orders).HasForeignKey(p => p.UserID);
                cart.Property(p => p.StatusOrder).HasDefaultValue(1);
            });
            modelBuilder.Entity<ProductVariants>(productVariants =>
            {
                productVariants.ToTable("productVariants");
                productVariants.HasKey(p => p.VariantID);
                productVariants.Property(p => p.ImportPrice).IsRequired();
                productVariants.Property(p => p.Price).IsRequired();
                productVariants.Property(p => p.Quantity).IsRequired();
                productVariants.Property(p => p.Images).HasConversion(
                    v => JsonConvert.SerializeObject(v, new JsonSerializerSettings { NullValueHandling = NullValueHandling.Ignore }),
                    v => JsonConvert.DeserializeObject<ICollection<ImageValueObject>>(v, new JsonSerializerSettings { NullValueHandling = NullValueHandling.Ignore })
                    );
                productVariants.Property(p => p.IsProductVariantEnabled).HasDefaultValue(true);
                productVariants.HasOne<Products>(p => p.Product).WithMany(p => p.ProductVariants).HasForeignKey(p => p.ProductID);

            });
            modelBuilder.Entity<Products>(products =>
            {
                products.ToTable("products");
                products.HasKey(p => p.ProductID);
                products.Property(p => p.ProductName).IsRequired();
                products.Property(p => p.IsProductEnabled).HasDefaultValue(true);

            });
            modelBuilder.Entity<Options>(options =>
            {
                options.ToTable("options");
                options.HasKey(p => p.OptionID);
                options.Property(p => p.OptionName).IsRequired();
                options.Property(p => p.IsOptionEnabled).HasDefaultValue(true);

            });
            modelBuilder.Entity<ProductOptions>(productOptions =>
            {
                productOptions.HasKey(p => new { p.OptionID, p.ProductID });
                productOptions.Property(p => p.IsProductOptionEnabled).HasDefaultValue(true);
                productOptions.HasOne<Products>(p => p.Products).WithMany(p => p.ProductOptions).HasForeignKey(p => p.ProductID);
                productOptions.HasOne<Options>(p => p.Options).WithMany(p => p.ProductOptions).HasForeignKey(p => p.OptionID);

            });
            modelBuilder.Entity<OptionValues>(optionValues =>
            {
                optionValues.ToTable("optionValues");
                optionValues.HasKey(p => p.ValuesID);
                optionValues.Property(p => p.OptionValue).IsRequired();
                optionValues.Property(p => p.IsOptionValueEnabled).HasDefaultValue(true);
                optionValues.HasOne<Options>(p => p.Options).WithMany(p => p.OptionValues).HasForeignKey(p => p.OptionID);
            });
            modelBuilder.Entity<VariantValues>(variantValues =>
            {
                variantValues.ToTable("variantValues");
                variantValues.HasKey(p => new { p.ProductID, p.VariantID, p.OptionID, p.ValuesID });
                variantValues.Property(p => p.IsVariantValueEnabled).HasDefaultValue(true);
                variantValues.HasOne<ProductVariants>(p => p.ProductVariant).WithMany(p => p.VariantValues).HasForeignKey(p => p.VariantID);
                variantValues.HasOne<OptionValues>(p => p.OptionValue).WithMany(p => p.VariantValues).HasForeignKey(p => p.ValuesID);

            });
            modelBuilder.Entity<OrderDetails>(cartDetails =>
            {
                cartDetails.ToTable("OrdertDetails");
                cartDetails.HasKey(p => new { p.OrderID, p.VariantID });
                cartDetails.Property(p => p.Quantity).HasDefaultValue(1);
                cartDetails.Property(p => p.UnitPrice).IsRequired();
                cartDetails.HasOne<Order>(p => p.Orderds).WithMany(p => p.OrderDetails).HasForeignKey(p => p.OrderID);
                cartDetails.HasOne<ProductVariants>(p => p.ProductVariants).WithMany(p => p.OrderDetails).HasForeignKey(p => p.VariantID);
            });
            modelBuilder.Entity<CartItem>(cartItems =>
            {
                cartItems.ToTable("CartItem");
                cartItems.HasKey(p => p.CartId);
                cartItems.HasIndex(p => p.ProductId);
                cartItems.Property(p => p.Images).HasConversion(
                 v => JsonConvert.SerializeObject(v, new JsonSerializerSettings { NullValueHandling = NullValueHandling.Ignore }),
                 v => JsonConvert.DeserializeObject<ICollection<ImageValueObject>>(v, new JsonSerializerSettings { NullValueHandling = NullValueHandling.Ignore })
                 );
            });
         

        }
    }
}
