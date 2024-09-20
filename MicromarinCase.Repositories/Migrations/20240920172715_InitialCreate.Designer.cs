﻿// <auto-generated />
using System;
using MicromarinCase.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace MicromarinCase.Repositories.Migrations
{
    [DbContext(typeof(AppDbContex))]
    [Migration("20240920172715_InitialCreate")]
    partial class InitialCreate
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.8")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("MicromarinCase.Repositories.BaseTable", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<DateTime?>("CreatedDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("Discriminator")
                        .IsRequired()
                        .HasMaxLength(13)
                        .HasColumnType("nvarchar(13)");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("bit");

                    b.Property<DateTime?>("UpdatedDate")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.ToTable("BaseTables");

                    b.HasDiscriminator().HasValue("BaseTable");

                    b.UseTphMappingStrategy();
                });

            modelBuilder.Entity("MicromarinCase.Repositories.Customers.Customer", b =>
                {
                    b.HasBaseType("MicromarinCase.Repositories.BaseTable");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasDiscriminator().HasValue("Customer");
                });

            modelBuilder.Entity("MicromarinCase.Repositories.OrderDetails.OrderDetail", b =>
                {
                    b.HasBaseType("MicromarinCase.Repositories.BaseTable");

                    b.Property<int>("OrderId")
                        .HasColumnType("int");

                    b.Property<int>("ProductId")
                        .HasColumnType("int");

                    b.Property<int>("Quantity")
                        .HasColumnType("int");

                    b.HasIndex("OrderId");

                    b.HasIndex("ProductId");

                    b.HasDiscriminator().HasValue("OrderDetail");
                });

            modelBuilder.Entity("MicromarinCase.Repositories.Orders.Order", b =>
                {
                    b.HasBaseType("MicromarinCase.Repositories.BaseTable");

                    b.Property<int>("CustomerId")
                        .HasColumnType("int");

                    b.Property<DateTime>("OrderDate")
                        .HasColumnType("datetime2");

                    b.HasIndex("CustomerId");

                    b.HasDiscriminator().HasValue("Order");
                });

            modelBuilder.Entity("MicromarinCase.Repositories.Products.Product", b =>
                {
                    b.HasBaseType("MicromarinCase.Repositories.BaseTable");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(150)
                        .HasColumnType("nvarchar(150)");

                    b.Property<decimal>("Price")
                        .HasColumnType("decimal(18,2)");

                    b.ToTable("BaseTables", t =>
                        {
                            t.Property("Name")
                                .HasColumnName("Product_Name");
                        });

                    b.HasDiscriminator().HasValue("Product");
                });

            modelBuilder.Entity("MicromarinCase.Repositories.OrderDetails.OrderDetail", b =>
                {
                    b.HasOne("MicromarinCase.Repositories.Orders.Order", "Order")
                        .WithMany("OrderDetails")
                        .HasForeignKey("OrderId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.HasOne("MicromarinCase.Repositories.Products.Product", "Product")
                        .WithMany("OrderDetails")
                        .HasForeignKey("ProductId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("Order");

                    b.Navigation("Product");
                });

            modelBuilder.Entity("MicromarinCase.Repositories.Orders.Order", b =>
                {
                    b.HasOne("MicromarinCase.Repositories.Customers.Customer", "Customer")
                        .WithMany("Orders")
                        .HasForeignKey("CustomerId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("Customer");
                });

            modelBuilder.Entity("MicromarinCase.Repositories.Customers.Customer", b =>
                {
                    b.Navigation("Orders");
                });

            modelBuilder.Entity("MicromarinCase.Repositories.Orders.Order", b =>
                {
                    b.Navigation("OrderDetails");
                });

            modelBuilder.Entity("MicromarinCase.Repositories.Products.Product", b =>
                {
                    b.Navigation("OrderDetails");
                });
#pragma warning restore 612, 618
        }
    }
}
