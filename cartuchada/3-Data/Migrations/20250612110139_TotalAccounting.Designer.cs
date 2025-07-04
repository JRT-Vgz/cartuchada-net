﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using _3_Data;

#nullable disable

namespace _3_Data.Migrations
{
    [DbContext(typeof(AppDbContext))]
    [Migration("20250612110139_TotalAccounting")]
    partial class TotalAccounting
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.14")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("_3_Data.Models.CartdrigeModel", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("IdCondition")
                        .HasColumnType("int");

                    b.Property<int>("IdGame")
                        .HasColumnType("int");

                    b.Property<int>("IdProductType")
                        .HasColumnType("int");

                    b.Property<int>("IdReference")
                        .HasColumnType("int");

                    b.Property<int>("IdRegion")
                        .HasColumnType("int");

                    b.Property<DateTime>("PurchaseDate")
                        .HasColumnType("DATE");

                    b.Property<decimal>("PurchasePrice")
                        .HasColumnType("decimal(18,2)");

                    b.HasKey("Id");

                    b.HasIndex("IdCondition");

                    b.HasIndex("IdGame");

                    b.HasIndex("IdProductType");

                    b.HasIndex("IdReference");

                    b.HasIndex("IdRegion");

                    b.ToTable("Cartdrige", (string)null);
                });

            modelBuilder.Entity("_3_Data.Models.ConditionModel", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Condition", (string)null);
                });

            modelBuilder.Entity("_3_Data.Models.ConsoleModel", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("IdProductType")
                        .HasColumnType("int");

                    b.Property<int>("IdReference")
                        .HasColumnType("int");

                    b.Property<DateTime>("PurchaseDate")
                        .HasColumnType("DATE");

                    b.Property<decimal>("PurchasePrice")
                        .HasColumnType("decimal(18,2)");

                    b.Property<decimal>("SparePartsPrice")
                        .HasColumnType("decimal(18,2)");

                    b.Property<decimal>("TotalPrice")
                        .HasColumnType("decimal(18,2)");

                    b.HasKey("Id");

                    b.HasIndex("IdProductType");

                    b.HasIndex("IdReference");

                    b.ToTable("Console", (string)null);
                });

            modelBuilder.Entity("_3_Data.Models.GameCatalogueModel", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("IdProductType")
                        .HasColumnType("int");

                    b.Property<bool>("JAP")
                        .HasColumnType("bit");

                    b.Property<bool>("NA")
                        .HasColumnType("bit");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("PAL")
                        .HasColumnType("bit");

                    b.HasKey("Id");

                    b.HasIndex("IdProductType");

                    b.ToTable("GameCatalogue", (string)null);
                });

            modelBuilder.Entity("_3_Data.Models.Management_Models.AccountingModel", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<DateTime>("Date")
                        .HasColumnType("DATE");

                    b.Property<decimal>("Expenses")
                        .HasColumnType("decimal(18,2)");

                    b.Property<decimal>("Income")
                        .HasColumnType("decimal(18,2)");

                    b.Property<decimal>("Total")
                        .HasColumnType("decimal(18,2)");

                    b.HasKey("Id");

                    b.ToTable("Accounting");
                });

            modelBuilder.Entity("_3_Data.Models.Management_Models.LogModel", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<DateTime>("Date")
                        .HasColumnType("datetime2");

                    b.Property<string>("Entry")
                        .IsRequired()
                        .HasMaxLength(255)
                        .HasColumnType("nvarchar(255)");

                    b.HasKey("Id");

                    b.ToTable("Logs");
                });

            modelBuilder.Entity("_3_Data.Models.Management_Models.WarningModel", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<DateTime>("Date")
                        .HasColumnType("datetime2");

                    b.Property<string>("Entry")
                        .IsRequired()
                        .HasMaxLength(255)
                        .HasColumnType("nvarchar(255)");

                    b.HasKey("Id");

                    b.ToTable("Warnings");
                });

            modelBuilder.Entity("_3_Data.Models.ProductTypeModel", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ReferencePrefix")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("ProductType", (string)null);
                });

            modelBuilder.Entity("_3_Data.Models.Product_Models.SpotModel", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("IdCondition")
                        .HasColumnType("int");

                    b.Property<int>("IdGame")
                        .HasColumnType("int");

                    b.Property<int>("IdProductType")
                        .HasColumnType("int");

                    b.Property<int>("IdRegion")
                        .HasColumnType("int");

                    b.Property<DateTime>("SpotDate")
                        .HasColumnType("DATE");

                    b.Property<decimal>("SpotPrice")
                        .HasColumnType("decimal(18,2)");

                    b.HasKey("Id");

                    b.HasIndex("IdCondition");

                    b.HasIndex("IdGame");

                    b.HasIndex("IdProductType");

                    b.HasIndex("IdRegion");

                    b.ToTable("Spot", (string)null);
                });

            modelBuilder.Entity("_3_Data.Models.ReferenceModel", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<bool>("Assigned")
                        .HasColumnType("bit");

                    b.Property<int>("IdProductType")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("IdProductType");

                    b.ToTable("Reference", (string)null);
                });

            modelBuilder.Entity("_3_Data.Models.RegionModel", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Region", (string)null);
                });

            modelBuilder.Entity("_3_Data.Models.SaleModels.SoldCartdrigeModel", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<decimal>("Benefit")
                        .HasColumnType("decimal(18,2)");

                    b.Property<int>("IdCondition")
                        .HasColumnType("int");

                    b.Property<int>("IdGame")
                        .HasColumnType("int");

                    b.Property<int>("IdProductType")
                        .HasColumnType("int");

                    b.Property<int>("IdRegion")
                        .HasColumnType("int");

                    b.Property<DateTime>("PurchaseDate")
                        .HasColumnType("DATE");

                    b.Property<decimal>("PurchasePrice")
                        .HasColumnType("decimal(18,2)");

                    b.Property<DateTime>("SaleDate")
                        .HasColumnType("DATE");

                    b.Property<decimal>("SalePrice")
                        .HasColumnType("decimal(18,2)");

                    b.HasKey("Id");

                    b.HasIndex("IdCondition");

                    b.HasIndex("IdGame");

                    b.HasIndex("IdProductType");

                    b.HasIndex("IdRegion");

                    b.ToTable("SoldCartdrige", (string)null);
                });

            modelBuilder.Entity("_3_Data.Models.SaleModels.SoldConsoleModel", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<decimal>("Benefit")
                        .HasColumnType("decimal(18,2)");

                    b.Property<int>("IdProductType")
                        .HasColumnType("int");

                    b.Property<DateTime>("PurchaseDate")
                        .HasColumnType("DATE");

                    b.Property<decimal>("PurchasePrice")
                        .HasColumnType("decimal(18,2)");

                    b.Property<DateTime>("SaleDate")
                        .HasColumnType("DATE");

                    b.Property<decimal>("SalePrice")
                        .HasColumnType("decimal(18,2)");

                    b.Property<decimal>("SparePartsPrice")
                        .HasColumnType("decimal(18,2)");

                    b.Property<decimal>("TotalPrice")
                        .HasColumnType("decimal(18,2)");

                    b.HasKey("Id");

                    b.HasIndex("IdProductType");

                    b.ToTable("SoldConsole", (string)null);
                });

            modelBuilder.Entity("_3_Data.Models.SaleModels.SoldSleeveModel", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("IdSparePartType")
                        .HasColumnType("int");

                    b.Property<int>("Quantity")
                        .HasColumnType("int");

                    b.Property<DateTime>("SaleDate")
                        .HasColumnType("DATE");

                    b.Property<decimal>("SalePrice")
                        .HasColumnType("decimal(18,2)");

                    b.HasKey("Id");

                    b.HasIndex("IdSparePartType");

                    b.ToTable("SoldSleeve", (string)null);
                });

            modelBuilder.Entity("_3_Data.Models.ShopStatModel", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Quantity")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("ShopStat", (string)null);
                });

            modelBuilder.Entity("_3_Data.Models.Spare_Parts_Models.SparePartTypeModel", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("SparePartType", (string)null);
                });

            modelBuilder.Entity("_3_Data.Models.Spare_Parts_Models.SparePartsPurchaseModel", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Concept")
                        .IsRequired()
                        .HasMaxLength(255)
                        .HasColumnType("nvarchar(255)");

                    b.Property<int>("IdSparePartType")
                        .HasColumnType("int");

                    b.Property<DateTime>("PurchaseDate")
                        .HasColumnType("DATE");

                    b.Property<decimal>("PurchasePrice")
                        .HasColumnType("decimal(18,2)");

                    b.HasKey("Id");

                    b.HasIndex("IdSparePartType");

                    b.ToTable("SparePartsPurchase", (string)null);
                });

            modelBuilder.Entity("_3_Data.Models.CartdrigeModel", b =>
                {
                    b.HasOne("_3_Data.Models.ConditionModel", "Condition")
                        .WithMany()
                        .HasForeignKey("IdCondition")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.HasOne("_3_Data.Models.GameCatalogueModel", "Game")
                        .WithMany()
                        .HasForeignKey("IdGame")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.HasOne("_3_Data.Models.ProductTypeModel", "ProductType")
                        .WithMany()
                        .HasForeignKey("IdProductType")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.HasOne("_3_Data.Models.ReferenceModel", "Reference")
                        .WithMany()
                        .HasForeignKey("IdReference")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.HasOne("_3_Data.Models.RegionModel", "Region")
                        .WithMany()
                        .HasForeignKey("IdRegion")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("Condition");

                    b.Navigation("Game");

                    b.Navigation("ProductType");

                    b.Navigation("Reference");

                    b.Navigation("Region");
                });

            modelBuilder.Entity("_3_Data.Models.ConsoleModel", b =>
                {
                    b.HasOne("_3_Data.Models.ProductTypeModel", "ProductType")
                        .WithMany()
                        .HasForeignKey("IdProductType")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.HasOne("_3_Data.Models.ReferenceModel", "Reference")
                        .WithMany()
                        .HasForeignKey("IdReference")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("ProductType");

                    b.Navigation("Reference");
                });

            modelBuilder.Entity("_3_Data.Models.GameCatalogueModel", b =>
                {
                    b.HasOne("_3_Data.Models.ProductTypeModel", "ProductType")
                        .WithMany()
                        .HasForeignKey("IdProductType")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("ProductType");
                });

            modelBuilder.Entity("_3_Data.Models.Product_Models.SpotModel", b =>
                {
                    b.HasOne("_3_Data.Models.ConditionModel", "Condition")
                        .WithMany()
                        .HasForeignKey("IdCondition")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.HasOne("_3_Data.Models.GameCatalogueModel", "Game")
                        .WithMany()
                        .HasForeignKey("IdGame")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.HasOne("_3_Data.Models.ProductTypeModel", "ProductType")
                        .WithMany()
                        .HasForeignKey("IdProductType")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.HasOne("_3_Data.Models.RegionModel", "Region")
                        .WithMany()
                        .HasForeignKey("IdRegion")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("Condition");

                    b.Navigation("Game");

                    b.Navigation("ProductType");

                    b.Navigation("Region");
                });

            modelBuilder.Entity("_3_Data.Models.ReferenceModel", b =>
                {
                    b.HasOne("_3_Data.Models.ProductTypeModel", "ProductType")
                        .WithMany()
                        .HasForeignKey("IdProductType")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("ProductType");
                });

            modelBuilder.Entity("_3_Data.Models.SaleModels.SoldCartdrigeModel", b =>
                {
                    b.HasOne("_3_Data.Models.ConditionModel", "Condition")
                        .WithMany()
                        .HasForeignKey("IdCondition")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.HasOne("_3_Data.Models.GameCatalogueModel", "Game")
                        .WithMany()
                        .HasForeignKey("IdGame")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.HasOne("_3_Data.Models.ProductTypeModel", "ProductType")
                        .WithMany()
                        .HasForeignKey("IdProductType")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.HasOne("_3_Data.Models.RegionModel", "Region")
                        .WithMany()
                        .HasForeignKey("IdRegion")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("Condition");

                    b.Navigation("Game");

                    b.Navigation("ProductType");

                    b.Navigation("Region");
                });

            modelBuilder.Entity("_3_Data.Models.SaleModels.SoldConsoleModel", b =>
                {
                    b.HasOne("_3_Data.Models.ProductTypeModel", "ProductType")
                        .WithMany()
                        .HasForeignKey("IdProductType")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("ProductType");
                });

            modelBuilder.Entity("_3_Data.Models.SaleModels.SoldSleeveModel", b =>
                {
                    b.HasOne("_3_Data.Models.Spare_Parts_Models.SparePartTypeModel", "SparePartType")
                        .WithMany()
                        .HasForeignKey("IdSparePartType")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("SparePartType");
                });

            modelBuilder.Entity("_3_Data.Models.Spare_Parts_Models.SparePartsPurchaseModel", b =>
                {
                    b.HasOne("_3_Data.Models.Spare_Parts_Models.SparePartTypeModel", "SparePartType")
                        .WithMany()
                        .HasForeignKey("IdSparePartType")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("SparePartType");
                });
#pragma warning restore 612, 618
        }
    }
}
