﻿// <auto-generated />
using System;
using DAL.DBcontext;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace DAL.Migrations
{
    [DbContext(typeof(Context))]
    partial class ContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.5")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("DAL.Entities.cart", b =>
                {
                    b.Property<Guid>("cartID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<float>("amountPlay")
                        .HasColumnType("real");

                    b.Property<bool>("isOrderEnabled")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bit")
                        .HasDefaultValue(true);

                    b.Property<DateTime>("orderTime")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("datetime2")
                        .HasDefaultValue(new DateTime(2022, 5, 21, 22, 19, 29, 0, DateTimeKind.Unspecified));

                    b.Property<float>("payingCustomer")
                        .HasColumnType("real");

                    b.Property<float>("payments")
                        .HasColumnType("real");

                    b.Property<float>("refunds")
                        .HasColumnType("real");

                    b.Property<bool>("statusDelete")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bit")
                        .HasDefaultValue(true);

                    b.Property<Guid>("userID")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("cartID");

                    b.HasIndex("payingCustomer")
                        .IsUnique();

                    b.HasIndex("payments")
                        .IsUnique();

                    b.HasIndex("userID")
                        .IsUnique();

                    b.ToTable("carts", (string)null);
                });

            modelBuilder.Entity("DAL.Entities.cartDetails", b =>
                {
                    b.Property<Guid>("orderID")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("variantID")
                        .HasColumnType("uniqueidentifier");

                    b.Property<bool>("isOrderDetailEnabled")
                        .HasColumnType("bit");

                    b.Property<int>("quantity")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasDefaultValue(1);

                    b.Property<float>("unitPrice")
                        .HasColumnType("real");

                    b.HasKey("orderID", "variantID");

                    b.HasIndex("unitPrice")
                        .IsUnique();

                    b.HasIndex("variantID");

                    b.ToTable("cartDetails", (string)null);
                });

            modelBuilder.Entity("DAL.Entities.Options", b =>
                {
                    b.Property<Guid>("optionID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<bool>("isOptionEnabled")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bit")
                        .HasDefaultValue(true);

                    b.Property<string>("optionName")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("optionID");

                    b.HasIndex("optionName")
                        .IsUnique();

                    b.ToTable("options", (string)null);
                });

            modelBuilder.Entity("DAL.Entities.OptionValues", b =>
                {
                    b.Property<Guid>("valuesID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<bool>("isOptionValueEnabled")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bit")
                        .HasDefaultValue(true);

                    b.Property<Guid>("optionID")
                        .HasColumnType("uniqueidentifier");

                    b.Property<int>("optionValues")
                        .HasColumnType("int");

                    b.HasKey("valuesID");

                    b.HasIndex("optionID");

                    b.HasIndex("optionValues")
                        .IsUnique();

                    b.ToTable("optionValues", (string)null);
                });

            modelBuilder.Entity("DAL.Entities.ProductOptions", b =>
                {
                    b.Property<Guid>("optionID")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("productID")
                        .HasColumnType("uniqueidentifier");

                    b.Property<bool>("isProductOptionEnabled")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bit")
                        .HasDefaultValue(true);

                    b.HasKey("optionID", "productID");

                    b.HasIndex("productID");

                    b.ToTable("productOptions");
                });

            modelBuilder.Entity("DAL.Entities.Products", b =>
                {
                    b.Property<Guid>("productID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<bool>("isProductEnabled")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bit")
                        .HasDefaultValue(true);

                    b.Property<string>("productName")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("productID");

                    b.HasIndex("productName")
                        .IsUnique();

                    b.ToTable("products", (string)null);
                });

            modelBuilder.Entity("DAL.Entities.ProductVariants", b =>
                {
                    b.Property<Guid>("variantID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<float>("importPrice")
                        .HasColumnType("real");

                    b.Property<bool>("isProductVariantEnabled")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bit")
                        .HasDefaultValue(true);

                    b.Property<float>("price")
                        .HasColumnType("real");

                    b.Property<Guid>("productID")
                        .HasColumnType("uniqueidentifier");

                    b.Property<int>("qunatity")
                        .HasColumnType("int");

                    b.Property<Guid>("skuID")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("variantID");

                    b.HasIndex("importPrice")
                        .IsUnique();

                    b.HasIndex("price")
                        .IsUnique();

                    b.HasIndex("productID");

                    b.HasIndex("qunatity")
                        .IsUnique();

                    b.ToTable("productVariants", (string)null);
                });

            modelBuilder.Entity("DAL.Entities.RolesUser", b =>
                {
                    b.Property<Guid>("rolesID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<bool>("isRolesUserEnabled")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bit")
                        .HasDefaultValue(true);

                    b.Property<string>("rolesName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("rolesID");

                    b.ToTable("rolesUsers", (string)null);
                });

            modelBuilder.Entity("DAL.Entities.user", b =>
                {
                    b.Property<Guid>("userID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<int>("Gender")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasDefaultValue(1);

                    b.Property<int>("address")
                        .HasColumnType("int");

                    b.Property<int>("birdDate")
                        .HasColumnType("int");

                    b.Property<int>("email")
                        .HasColumnType("int");

                    b.Property<int>("isUserEnabled")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasDefaultValue(1);

                    b.Property<int>("numberPhone")
                        .HasColumnType("int");

                    b.Property<Guid>("rolesID")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("userName")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("userID");

                    b.HasIndex("rolesID")
                        .IsUnique();

                    b.HasIndex("userName")
                        .IsUnique();

                    b.ToTable("users", (string)null);
                });

            modelBuilder.Entity("DAL.Entities.VariantValues", b =>
                {
                    b.Property<Guid>("productID")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("variantID")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("optionID")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("valuesID")
                        .HasColumnType("uniqueidentifier");

                    b.Property<bool>("isVariantValueEnabled")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bit")
                        .HasDefaultValue(true);

                    b.HasKey("productID", "variantID", "optionID", "valuesID");

                    b.HasIndex("valuesID");

                    b.HasIndex("variantID");

                    b.ToTable("variantValues", (string)null);
                });

            modelBuilder.Entity("DAL.Entities.cart", b =>
                {
                    b.HasOne("DAL.Entities.user", "user")
                        .WithMany("carts")
                        .HasForeignKey("userID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("user");
                });

            modelBuilder.Entity("DAL.Entities.cartDetails", b =>
                {
                    b.HasOne("DAL.Entities.cart", "carts")
                        .WithMany("cartDetails")
                        .HasForeignKey("orderID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("DAL.Entities.ProductVariants", "productVariants")
                        .WithMany("CartDetails")
                        .HasForeignKey("variantID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("carts");

                    b.Navigation("productVariants");
                });

            modelBuilder.Entity("DAL.Entities.OptionValues", b =>
                {
                    b.HasOne("DAL.Entities.Options", "options")
                        .WithMany("optionValues")
                        .HasForeignKey("optionID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("options");
                });

            modelBuilder.Entity("DAL.Entities.ProductOptions", b =>
                {
                    b.HasOne("DAL.Entities.Options", "options")
                        .WithMany("productOptions")
                        .HasForeignKey("optionID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("DAL.Entities.Products", "products")
                        .WithMany("productOptions")
                        .HasForeignKey("productID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("options");

                    b.Navigation("products");
                });

            modelBuilder.Entity("DAL.Entities.ProductVariants", b =>
                {
                    b.HasOne("DAL.Entities.Products", "product")
                        .WithMany("productVariants")
                        .HasForeignKey("productID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("product");
                });

            modelBuilder.Entity("DAL.Entities.user", b =>
                {
                    b.HasOne("DAL.Entities.RolesUser", "rolesUsers")
                        .WithMany("users")
                        .HasForeignKey("rolesID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("rolesUsers");
                });

            modelBuilder.Entity("DAL.Entities.VariantValues", b =>
                {
                    b.HasOne("DAL.Entities.OptionValues", "optionValue")
                        .WithMany("variantValues")
                        .HasForeignKey("valuesID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("DAL.Entities.ProductVariants", "productVariant")
                        .WithMany("variantValues")
                        .HasForeignKey("variantID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("optionValue");

                    b.Navigation("productVariant");
                });

            modelBuilder.Entity("DAL.Entities.cart", b =>
                {
                    b.Navigation("cartDetails");
                });

            modelBuilder.Entity("DAL.Entities.Options", b =>
                {
                    b.Navigation("optionValues");

                    b.Navigation("productOptions");
                });

            modelBuilder.Entity("DAL.Entities.OptionValues", b =>
                {
                    b.Navigation("variantValues");
                });

            modelBuilder.Entity("DAL.Entities.Products", b =>
                {
                    b.Navigation("productOptions");

                    b.Navigation("productVariants");
                });

            modelBuilder.Entity("DAL.Entities.ProductVariants", b =>
                {
                    b.Navigation("CartDetails");

                    b.Navigation("variantValues");
                });

            modelBuilder.Entity("DAL.Entities.RolesUser", b =>
                {
                    b.Navigation("users");
                });

            modelBuilder.Entity("DAL.Entities.user", b =>
                {
                    b.Navigation("carts");
                });
#pragma warning restore 612, 618
        }
    }
}
