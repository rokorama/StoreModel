// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using StoreModel.Contexts;

namespace StoreModel.Migrations
{
    [DbContext(typeof(StoreItemContext))]
    [Migration("20220325194437_InitialMigration")]
    partial class InitialMigration
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.15")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("StoreModel.Models.Beverage", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Container")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<decimal>("Price")
                        .HasColumnType("decimal(18,2)");

                    b.Property<int>("SKU")
                        .HasColumnType("int");

                    b.Property<int>("WeightGrams")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("BeverageItems");
                });

            modelBuilder.Entity("StoreModel.Models.Candy", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<decimal>("Price")
                        .HasColumnType("decimal(18,2)");

                    b.Property<int>("SKU")
                        .HasColumnType("int");

                    b.Property<int>("SugarPer100G")
                        .HasColumnType("int");

                    b.Property<int>("WeightGrams")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("CandyItems");
                });

            modelBuilder.Entity("StoreModel.Models.Meat", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<decimal>("Price")
                        .HasColumnType("decimal(18,2)");

                    b.Property<int>("ProteinPer100G")
                        .HasColumnType("int");

                    b.Property<int>("SKU")
                        .HasColumnType("int");

                    b.Property<int>("WeightGrams")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("MeatItems");
                });

            modelBuilder.Entity("StoreModel.Models.Vegetable", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<int>("FibrePer100G")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<decimal>("Price")
                        .HasColumnType("decimal(18,2)");

                    b.Property<int>("SKU")
                        .HasColumnType("int");

                    b.Property<int>("WeightGrams")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("VegetableItems");
                });
#pragma warning restore 612, 618
        }
    }
}
