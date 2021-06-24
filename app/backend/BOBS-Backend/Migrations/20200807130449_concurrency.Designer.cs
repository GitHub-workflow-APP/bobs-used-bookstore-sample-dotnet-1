﻿// <auto-generated />
using System;
using BookstoreBackend.Database;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace BookstoreBackend.Migrations
{
    [DbContext(typeof(DatabaseContext))]
    [Migration("20200807130449_concurrency")]
    partial class concurrency
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.6")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("BookstoreBackend.Models.Book.Book", b =>
                {
                    b.Property<long>("Book_Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("AudioBook_Url")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Author")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Back_Url")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Front_Url")
                        .HasColumnType("nvarchar(max)");

                    b.Property<long?>("Genre_Id")
                        .HasColumnType("bigint");

                    b.Property<long>("ISBN")
                        .HasColumnType("bigint");

                    b.Property<string>("Left_Url")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<long?>("Publisher_Id")
                        .HasColumnType("bigint");

                    b.Property<string>("Right_Url")
                        .HasColumnType("nvarchar(max)");

                    b.Property<byte[]>("RowVersion")
                        .IsConcurrencyToken()
                        .ValueGeneratedOnAddOrUpdate()
                        .HasColumnType("rowversion");

                    b.Property<string>("Summary")
                        .HasColumnType("nvarchar(max)");

                    b.Property<long?>("Type_Id")
                        .HasColumnType("bigint");

                    b.HasKey("Book_Id");

                    b.HasIndex("Genre_Id");

                    b.HasIndex("Publisher_Id");

                    b.HasIndex("Type_Id");

                    b.ToTable("Book");
                });

            modelBuilder.Entity("BookstoreBackend.Models.Book.Condition", b =>
                {
                    b.Property<long>("Condition_Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("ConditionName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<byte[]>("RowVersion")
                        .IsConcurrencyToken()
                        .ValueGeneratedOnAddOrUpdate()
                        .HasColumnType("rowversion");

                    b.HasKey("Condition_Id");

                    b.ToTable("Condition");
                });

            modelBuilder.Entity("BookstoreBackend.Models.Book.Genre", b =>
                {
                    b.Property<long>("Genre_Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<byte[]>("RowVersion")
                        .IsConcurrencyToken()
                        .ValueGeneratedOnAddOrUpdate()
                        .HasColumnType("rowversion");

                    b.HasKey("Genre_Id");

                    b.ToTable("Genre");
                });

            modelBuilder.Entity("BookstoreBackend.Models.Book.Price", b =>
                {
                    b.Property<long>("Price_Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<bool>("Active")
                        .HasColumnType("bit");

                    b.Property<long?>("Book_Id")
                        .HasColumnType("bigint");

                    b.Property<long?>("Condition_Id")
                        .HasColumnType("bigint");

                    b.Property<double>("ItemPrice")
                        .HasColumnType("float");

                    b.Property<int>("Quantity")
                        .HasColumnType("int");

                    b.Property<byte[]>("RowVersion")
                        .IsConcurrencyToken()
                        .ValueGeneratedOnAddOrUpdate()
                        .HasColumnType("rowversion");

                    b.Property<string>("UpdatedBy")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("UpdatedOn")
                        .HasColumnType("datetime2");

                    b.HasKey("Price_Id");

                    b.HasIndex("Book_Id");

                    b.HasIndex("Condition_Id");

                    b.ToTable("Price");
                });

            modelBuilder.Entity("BookstoreBackend.Models.Book.Publisher", b =>
                {
                    b.Property<long>("Publisher_Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<byte[]>("RowVersion")
                        .IsConcurrencyToken()
                        .ValueGeneratedOnAddOrUpdate()
                        .HasColumnType("rowversion");

                    b.HasKey("Publisher_Id");

                    b.ToTable("Publisher");
                });

            modelBuilder.Entity("BookstoreBackend.Models.Book.Type", b =>
                {
                    b.Property<long>("Type_Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<byte[]>("RowVersion")
                        .IsConcurrencyToken()
                        .ValueGeneratedOnAddOrUpdate()
                        .HasColumnType("rowversion");

                    b.Property<string>("TypeName")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Type_Id");

                    b.ToTable("Type");
                });

            modelBuilder.Entity("BookstoreBackend.Models.Customer.Address", b =>
                {
                    b.Property<long>("Address_Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("AddressLine1")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("AddressLine2")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("City")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Country")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Customer_Id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<bool>("IsPrimary")
                        .HasColumnType("bit");

                    b.Property<string>("State")
                        .HasColumnType("nvarchar(max)");

                    b.Property<long>("ZipCode")
                        .HasColumnType("bigint");

                    b.HasKey("Address_Id");

                    b.HasIndex("Customer_Id");

                    b.ToTable("Address");
                });

            modelBuilder.Entity("BookstoreBackend.Models.Customer.Customer", b =>
                {
                    b.Property<string>("Customer_Id")
                        .HasColumnType("nvarchar(450)")
                        .HasMaxLength(450);

                    b.Property<DateTime>("DateOfBirth")
                        .HasColumnType("datetime2");

                    b.Property<string>("Email")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("FirstName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("LastName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Phone")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Username")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Customer_Id");

                    b.ToTable("Customer");
                });

            modelBuilder.Entity("BookstoreBackend.Models.Order.Order", b =>
                {
                    b.Property<long>("Order_Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<long?>("Address_Id")
                        .HasColumnType("bigint");

                    b.Property<string>("Customer_Id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("DeliveryDate")
                        .HasColumnType("nvarchar(max)");

                    b.Property<long?>("OrderStatus_Id")
                        .HasColumnType("bigint");

                    b.Property<byte[]>("RowVersion")
                        .IsConcurrencyToken()
                        .ValueGeneratedOnAddOrUpdate()
                        .HasColumnType("rowversion");

                    b.Property<double>("Subtotal")
                        .HasColumnType("float");

                    b.Property<double>("Tax")
                        .HasColumnType("float");

                    b.HasKey("Order_Id");

                    b.HasIndex("Address_Id");

                    b.HasIndex("Customer_Id");

                    b.HasIndex("OrderStatus_Id");

                    b.ToTable("Order");
                });

            modelBuilder.Entity("BookstoreBackend.Models.Order.OrderDetail", b =>
                {
                    b.Property<long>("OrderDetail_Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<long?>("Book_Id")
                        .HasColumnType("bigint");

                    b.Property<bool>("IsRemoved")
                        .HasColumnType("bit");

                    b.Property<long?>("Order_Id")
                        .HasColumnType("bigint");

                    b.Property<long?>("Price_Id")
                        .HasColumnType("bigint");

                    b.Property<byte[]>("RowVersion")
                        .IsConcurrencyToken()
                        .ValueGeneratedOnAddOrUpdate()
                        .HasColumnType("rowversion");

                    b.Property<double>("price")
                        .HasColumnType("float");

                    b.Property<int>("quantity")
                        .HasColumnType("int");

                    b.HasKey("OrderDetail_Id");

                    b.HasIndex("Book_Id");

                    b.HasIndex("Order_Id");

                    b.HasIndex("Price_Id");

                    b.ToTable("OrderDetail");
                });

            modelBuilder.Entity("BookstoreBackend.Models.Order.OrderStatus", b =>
                {
                    b.Property<long>("OrderStatus_Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Status")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("position")
                        .HasColumnType("int");

                    b.HasKey("OrderStatus_Id");

                    b.ToTable("OrderStatus");
                });

            modelBuilder.Entity("BookstoreBackend.Models.Book.Book", b =>
                {
                    b.HasOne("BookstoreBackend.Models.Book.Genre", "Genre")
                        .WithMany()
                        .HasForeignKey("Genre_Id");

                    b.HasOne("BookstoreBackend.Models.Book.Publisher", "Publisher")
                        .WithMany()
                        .HasForeignKey("Publisher_Id");

                    b.HasOne("BookstoreBackend.Models.Book.Type", "Type")
                        .WithMany()
                        .HasForeignKey("Type_Id");
                });

            modelBuilder.Entity("BookstoreBackend.Models.Book.Price", b =>
                {
                    b.HasOne("BookstoreBackend.Models.Book.Book", "Book")
                        .WithMany()
                        .HasForeignKey("Book_Id");

                    b.HasOne("BookstoreBackend.Models.Book.Condition", "Condition")
                        .WithMany()
                        .HasForeignKey("Condition_Id");
                });

            modelBuilder.Entity("BookstoreBackend.Models.Customer.Address", b =>
                {
                    b.HasOne("BookstoreBackend.Models.Customer.Customer", "Customer")
                        .WithMany()
                        .HasForeignKey("Customer_Id");
                });

            modelBuilder.Entity("BookstoreBackend.Models.Order.Order", b =>
                {
                    b.HasOne("BookstoreBackend.Models.Customer.Address", "Address")
                        .WithMany()
                        .HasForeignKey("Address_Id");

                    b.HasOne("BookstoreBackend.Models.Customer.Customer", "Customer")
                        .WithMany()
                        .HasForeignKey("Customer_Id");

                    b.HasOne("BookstoreBackend.Models.Order.OrderStatus", "OrderStatus")
                        .WithMany()
                        .HasForeignKey("OrderStatus_Id");
                });

            modelBuilder.Entity("BookstoreBackend.Models.Order.OrderDetail", b =>
                {
                    b.HasOne("BookstoreBackend.Models.Book.Book", "Book")
                        .WithMany()
                        .HasForeignKey("Book_Id");

                    b.HasOne("BookstoreBackend.Models.Order.Order", "Order")
                        .WithMany()
                        .HasForeignKey("Order_Id");

                    b.HasOne("BookstoreBackend.Models.Book.Price", "Price")
                        .WithMany()
                        .HasForeignKey("Price_Id");
                });
#pragma warning restore 612, 618
        }
    }
}
