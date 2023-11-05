﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using SanaAPI;

namespace SanaAPI.Migrations
{
    [DbContext(typeof(CurrencyContext))]
    partial class CurrencyContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "6.0.0-preview.3.21201.2")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("SanaAPI.Currency", b =>
                {
                    b.Property<int>("CurrencyId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("CurrencyCode")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("CurrencyName")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("CurrencyId");

                    b.ToTable("Currencies");

                    b.HasData(
                        new
                        {
                            CurrencyId = 1,
                            CurrencyCode = "EUR",
                            CurrencyName = "یورو"
                        },
                        new
                        {
                            CurrencyId = 2,
                            CurrencyCode = "AED",
                            CurrencyName = "درهم امارات متحده عربی"
                        },
                        new
                        {
                            CurrencyId = 3,
                            CurrencyCode = "CNY",
                            CurrencyName = "یوان  چین"
                        },
                        new
                        {
                            CurrencyId = 4,
                            CurrencyCode = "INR",
                            CurrencyName = "روپیه  هند"
                        },
                        new
                        {
                            CurrencyId = 5,
                            CurrencyCode = "USD",
                            CurrencyName = "دلار آمریکا"
                        },
                        new
                        {
                            CurrencyId = 6,
                            CurrencyCode = "RUB",
                            CurrencyName = "روبل روسيه"
                        });
                });

            modelBuilder.Entity("SanaAPI.CurrencyRate", b =>
                {
                    b.Property<int>("CurrencyId")
                        .HasColumnType("int");

                    b.Property<int>("TypeId")
                        .HasColumnType("int");

                    b.Property<DateTime>("SiteDate")
                        .HasColumnType("datetime2(0)");

                    b.Property<DateTime>("DateSubmitted")
                        .HasColumnType("datetime2(0)");

                    b.Property<decimal>("Price")
                        .HasColumnType("decimal(18,2)");

                    b.HasKey("CurrencyId", "TypeId", "SiteDate");

                    b.HasIndex("TypeId");

                    b.ToTable("CurrencyRates");
                });

            modelBuilder.Entity("SanaAPI.CurrencyType", b =>
                {
                    b.Property<int>("TypeId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("PriceType")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("TypeCurrency")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("TypeId");

                    b.ToTable("CurrencyTypes");

                    b.HasData(
                        new
                        {
                            TypeId = 1,
                            PriceType = "خرید",
                            TypeCurrency = "اسکناس"
                        },
                        new
                        {
                            TypeId = 2,
                            PriceType = "فروش",
                            TypeCurrency = "اسکناس"
                        },
                        new
                        {
                            TypeId = 3,
                            PriceType = "خرید",
                            TypeCurrency = "حواله ارزی"
                        },
                        new
                        {
                            TypeId = 4,
                            PriceType = "فروش",
                            TypeCurrency = "حواله ارزی"
                        },
                        new
                        {
                            TypeId = 5,
                            PriceType = "نرخ دولتی",
                            TypeCurrency = "ارز دولتی"
                        });
                });

            modelBuilder.Entity("SanaAPI.CurrencyRate", b =>
                {
                    b.HasOne("SanaAPI.Currency", "Currency")
                        .WithMany()
                        .HasForeignKey("CurrencyId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("SanaAPI.CurrencyType", "CurrencyType")
                        .WithMany()
                        .HasForeignKey("TypeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Currency");

                    b.Navigation("CurrencyType");
                });
#pragma warning restore 612, 618
        }
    }
}
