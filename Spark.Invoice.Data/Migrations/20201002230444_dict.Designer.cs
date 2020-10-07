﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Spark.Invoice.Data.Context;

namespace Spark.Invoice.Data.Migrations
{
    [DbContext(typeof(InvoiceContext))]
    [Migration("20201002230444_dict")]
    partial class dict
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.8")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("Spark.Invoice.Data.Models.Address", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Address_City")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Address_Country")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Address_Full")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Address_Postal_Code")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("CompanyId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("CompanyId");

                    b.ToTable("Addresses");
                });

            modelBuilder.Entity("Spark.Invoice.Data.Models.BankAccount", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("AccountNumber")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("Active")
                        .HasColumnType("bit");

                    b.Property<string>("BankName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("CompanyId")
                        .HasColumnType("int");

                    b.Property<string>("SWIFT")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("VatAccountNumber")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("ID");

                    b.HasIndex("CompanyId");

                    b.ToTable("BankAccounts");
                });

            modelBuilder.Entity("Spark.Invoice.Data.Models.ClientType", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Client_Type")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("ClientTypes");
                });

            modelBuilder.Entity("Spark.Invoice.Data.Models.Company", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("City")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Client_Type")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Country")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Discount")
                        .HasColumnType("int");

                    b.Property<string>("Email")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Full_Address")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Mobile_Phone")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("NIP")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Payment_Method")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Phone_Number")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Postal_Code")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Short_Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("WWW")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Companies");
                });

            modelBuilder.Entity("Spark.Invoice.Data.Models.Country", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Country_Code")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Country_Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("IsEU")
                        .HasColumnType("bit");

                    b.HasKey("Id");

                    b.ToTable("Countries");
                });

            modelBuilder.Entity("Spark.Invoice.Data.Models.Currency", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("code")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("currency")
                        .HasColumnType("nvarchar(max)");

                    b.Property<float>("mid")
                        .HasColumnType("real");

                    b.HasKey("Id");

                    b.ToTable("Currencies");
                });

            modelBuilder.Entity("Spark.Invoice.Data.Models.IndividualRights", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int?>("IsLoggedId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("IsLoggedId");

                    b.ToTable("IndividualRights");
                });

            modelBuilder.Entity("Spark.Invoice.Data.Models.Invoice", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Currency")
                        .HasColumnType("nvarchar(max)");

                    b.Property<float>("Currency_Change_Rate")
                        .HasColumnType("real");

                    b.Property<float>("Gross_Value")
                        .HasColumnType("real");

                    b.Property<int>("ID_Client")
                        .HasColumnType("int");

                    b.Property<string>("Invoice_Number")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("Issue_Date")
                        .HasColumnType("datetime2");

                    b.Property<string>("Issuing_User")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Kwota_Slownie")
                        .HasColumnType("nvarchar(max)");

                    b.Property<float>("Net_Value")
                        .HasColumnType("real");

                    b.Property<string>("Note")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("Payment_AccountID")
                        .HasColumnType("int");

                    b.Property<DateTime>("Payment_Date")
                        .HasColumnType("datetime2");

                    b.Property<string>("Payment_Method")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("Sale_Date")
                        .HasColumnType("datetime2");

                    b.Property<int>("SplitPayment")
                        .HasColumnType("int");

                    b.Property<float>("VAT")
                        .HasColumnType("real");

                    b.Property<float>("VAT_Value")
                        .HasColumnType("real");

                    b.HasKey("Id");

                    b.HasIndex("Payment_AccountID");

                    b.ToTable("Invoices");
                });

            modelBuilder.Entity("Spark.Invoice.Data.Models.IsLogged", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("ComputerName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Role")
                        .HasColumnType("int");

                    b.Property<string>("Session")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UserName")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("IsLogged");
                });

            modelBuilder.Entity("Spark.Invoice.Data.Models.PaymentMethod", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Payment_Method_Name")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("PaymentMethods");
                });

            modelBuilder.Entity("Spark.Invoice.Data.Models.User", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Password")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UserName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("UserRole")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("Users");
                });

            modelBuilder.Entity("Spark.Invoice.Data.Models.Address", b =>
                {
                    b.HasOne("Spark.Invoice.Data.Models.Company", null)
                        .WithMany("Address")
                        .HasForeignKey("CompanyId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Spark.Invoice.Data.Models.BankAccount", b =>
                {
                    b.HasOne("Spark.Invoice.Data.Models.Company", null)
                        .WithMany("BankAccount")
                        .HasForeignKey("CompanyId");
                });

            modelBuilder.Entity("Spark.Invoice.Data.Models.IndividualRights", b =>
                {
                    b.HasOne("Spark.Invoice.Data.Models.IsLogged", null)
                        .WithMany("Rights")
                        .HasForeignKey("IsLoggedId");
                });

            modelBuilder.Entity("Spark.Invoice.Data.Models.Invoice", b =>
                {
                    b.HasOne("Spark.Invoice.Data.Models.BankAccount", "Payment_Account")
                        .WithMany()
                        .HasForeignKey("Payment_AccountID");
                });
#pragma warning restore 612, 618
        }
    }
}