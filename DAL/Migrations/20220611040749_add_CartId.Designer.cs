﻿// <auto-generated />
using System;
using DAL.DBcontext;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace DAL.Migrations
{
    [DbContext(typeof(Context))]
    [Migration("20220611040749_add_CartId")]
    partial class add_CartId
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.5")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("DAL.Entities.CartItem", b =>
                {
                    b.Property<Guid>("ProductId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("CartId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<float>("Price")
                        .HasColumnType("real");

                    b.Property<string>("ProductName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Quantity")
                        .HasColumnType("int");

                    b.Property<Guid>("VariantId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("ProductId");

                    b.HasIndex("ProductId");

                    b.ToTable("CartItem", (string)null);
                });

            modelBuilder.Entity("DAL.Entities.Options", b =>
                {
                    b.Property<Guid>("OptionID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<bool>("IsOptionEnabled")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bit")
                        .HasDefaultValue(true);

                    b.Property<string>("OptionName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("OptionID");

                    b.ToTable("options", (string)null);
                });

            modelBuilder.Entity("DAL.Entities.OptionValues", b =>
                {
                    b.Property<Guid>("ValuesID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<bool>("IsOptionValueEnabled")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bit")
                        .HasDefaultValue(true);

                    b.Property<Guid>("OptionID")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("OptionValue")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("ValuesID");

                    b.HasIndex("OptionID");

                    b.ToTable("optionValues", (string)null);
                });

            modelBuilder.Entity("DAL.Entities.Order", b =>
                {
                    b.Property<Guid>("CartID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<float>("AmountPlay")
                        .HasColumnType("real");

                    b.Property<bool>("IsOrderEnabled")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bit")
                        .HasDefaultValue(true);

                    b.Property<DateTime>("OrderTime")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("datetime2")
                        .HasDefaultValue(new DateTime(2022, 6, 11, 11, 7, 48, 0, DateTimeKind.Unspecified));

                    b.Property<float>("PayingCustomer")
                        .HasColumnType("real");

                    b.Property<float>("Payments")
                        .HasColumnType("real");

                    b.Property<float>("Refunds")
                        .HasColumnType("real");

                    b.Property<bool>("StatusDelete")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bit")
                        .HasDefaultValue(true);

                    b.Property<Guid>("UserID")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("CartID");

                    b.HasIndex("UserID");

                    b.ToTable("Order", (string)null);
                });

            modelBuilder.Entity("DAL.Entities.OrderDetails", b =>
                {
                    b.Property<Guid>("OrderID")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("VariantID")
                        .HasColumnType("uniqueidentifier");

                    b.Property<bool>("IsOrderDetailEnabled")
                        .HasColumnType("bit");

                    b.Property<int>("Quantity")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasDefaultValue(1);

                    b.Property<float>("UnitPrice")
                        .HasColumnType("real");

                    b.HasKey("OrderID", "VariantID");

                    b.HasIndex("VariantID");

                    b.ToTable("OrdertDetails", (string)null);
                });

            modelBuilder.Entity("DAL.Entities.ProductOptions", b =>
                {
                    b.Property<Guid>("OptionID")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("ProductID")
                        .HasColumnType("uniqueidentifier");

                    b.Property<bool>("IsProductOptionEnabled")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bit")
                        .HasDefaultValue(true);

                    b.HasKey("OptionID", "ProductID");

                    b.HasIndex("ProductID");

                    b.ToTable("productOptions");
                });

            modelBuilder.Entity("DAL.Entities.Products", b =>
                {
                    b.Property<Guid>("ProductID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<bool>("IsProductEnabled")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bit")
                        .HasDefaultValue(true);

                    b.Property<string>("ProductName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("ProductID");

                    b.ToTable("products", (string)null);
                });

            modelBuilder.Entity("DAL.Entities.ProductVariants", b =>
                {
                    b.Property<Guid>("VariantID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<float>("ImportPrice")
                        .HasColumnType("real");

                    b.Property<bool>("IsProductVariantEnabled")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bit")
                        .HasDefaultValue(true);

                    b.Property<float>("Price")
                        .HasColumnType("real");

                    b.Property<Guid>("ProductID")
                        .HasColumnType("uniqueidentifier");

                    b.Property<int>("Quantity")
                        .HasColumnType("int");

                    b.Property<Guid>("SkuID")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("VariantID");

                    b.HasIndex("ProductID");

                    b.ToTable("productVariants", (string)null);
                });

            modelBuilder.Entity("DAL.Entities.RolesUser", b =>
                {
                    b.Property<Guid>("RolesID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<bool>("IsRolesUserEnabled")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bit")
                        .HasDefaultValue(true);

                    b.Property<string>("RolesName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("RolesID");

                    b.ToTable("rolesUsers", (string)null);
                });

            modelBuilder.Entity("DAL.Entities.user", b =>
                {
                    b.Property<Guid>("UserID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Address")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("DOB")
                        .HasColumnType("datetime2");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Gender")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasDefaultValue(1);

                    b.Property<bool>("IsUserEnabled")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bit")
                        .HasDefaultValue(true);

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PhoneNumber")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<Guid>("RolesID")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("UserName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("UserID");

                    b.HasIndex("RolesID");

                    b.ToTable("users", (string)null);
                });

            modelBuilder.Entity("DAL.Entities.VariantValues", b =>
                {
                    b.Property<Guid>("ProductID")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("VariantID")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("OptionID")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("ValuesID")
                        .HasColumnType("uniqueidentifier");

                    b.Property<bool>("IsVariantValueEnabled")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bit")
                        .HasDefaultValue(true);

                    b.HasKey("ProductID", "VariantID", "OptionID", "ValuesID");

                    b.HasIndex("ValuesID");

                    b.HasIndex("VariantID");

                    b.ToTable("variantValues", (string)null);
                });

            modelBuilder.Entity("DAL.Entities.OptionValues", b =>
                {
                    b.HasOne("DAL.Entities.Options", "Options")
                        .WithMany("OptionValues")
                        .HasForeignKey("OptionID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Options");
                });

            modelBuilder.Entity("DAL.Entities.Order", b =>
                {
                    b.HasOne("DAL.Entities.user", "User")
                        .WithMany("Orders")
                        .HasForeignKey("UserID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("User");
                });

            modelBuilder.Entity("DAL.Entities.OrderDetails", b =>
                {
                    b.HasOne("DAL.Entities.Order", "Orderds")
                        .WithMany("OrderDetails")
                        .HasForeignKey("OrderID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("DAL.Entities.ProductVariants", "ProductVariants")
                        .WithMany("OrderDetails")
                        .HasForeignKey("VariantID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Orderds");

                    b.Navigation("ProductVariants");
                });

            modelBuilder.Entity("DAL.Entities.ProductOptions", b =>
                {
                    b.HasOne("DAL.Entities.Options", "Options")
                        .WithMany("ProductOptions")
                        .HasForeignKey("OptionID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("DAL.Entities.Products", "Products")
                        .WithMany("ProductOptions")
                        .HasForeignKey("ProductID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Options");

                    b.Navigation("Products");
                });

            modelBuilder.Entity("DAL.Entities.ProductVariants", b =>
                {
                    b.HasOne("DAL.Entities.Products", "Product")
                        .WithMany("ProductVariants")
                        .HasForeignKey("ProductID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Product");
                });

            modelBuilder.Entity("DAL.Entities.user", b =>
                {
                    b.HasOne("DAL.Entities.RolesUser", "RolesUsers")
                        .WithMany("Users")
                        .HasForeignKey("RolesID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("RolesUsers");
                });

            modelBuilder.Entity("DAL.Entities.VariantValues", b =>
                {
                    b.HasOne("DAL.Entities.OptionValues", "OptionValue")
                        .WithMany("VariantValues")
                        .HasForeignKey("ValuesID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("DAL.Entities.ProductVariants", "ProductVariant")
                        .WithMany("VariantValues")
                        .HasForeignKey("VariantID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("OptionValue");

                    b.Navigation("ProductVariant");
                });

            modelBuilder.Entity("DAL.Entities.Options", b =>
                {
                    b.Navigation("OptionValues");

                    b.Navigation("ProductOptions");
                });

            modelBuilder.Entity("DAL.Entities.OptionValues", b =>
                {
                    b.Navigation("VariantValues");
                });

            modelBuilder.Entity("DAL.Entities.Order", b =>
                {
                    b.Navigation("OrderDetails");
                });

            modelBuilder.Entity("DAL.Entities.Products", b =>
                {
                    b.Navigation("ProductOptions");

                    b.Navigation("ProductVariants");
                });

            modelBuilder.Entity("DAL.Entities.ProductVariants", b =>
                {
                    b.Navigation("OrderDetails");

                    b.Navigation("VariantValues");
                });

            modelBuilder.Entity("DAL.Entities.RolesUser", b =>
                {
                    b.Navigation("Users");
                });

            modelBuilder.Entity("DAL.Entities.user", b =>
                {
                    b.Navigation("Orders");
                });
#pragma warning restore 612, 618
        }
    }
}
