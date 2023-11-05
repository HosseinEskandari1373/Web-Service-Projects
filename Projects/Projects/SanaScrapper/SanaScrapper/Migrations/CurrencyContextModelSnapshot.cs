﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using WebScrappingHtmlPage;

namespace SanaRate_Scrapper.Migrations
{
    [DbContext(typeof(CurrencyContext))]
    partial class CurrencyContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.0-preview.2.21154.2");

            modelBuilder.Entity("WebScrappingHtmlPage.Currency", b =>
                {
                    b.Property<int>("CurrencyId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("CurrencyCode")
                        .HasColumnType("TEXT");

                    b.Property<string>("CurrencyName")
                        .HasColumnType("TEXT");

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

            modelBuilder.Entity("WebScrappingHtmlPage.CurrencyRate", b =>
                {
                    b.Property<int>("CurrencyId")
                        .HasColumnType("INTEGER");

                    b.Property<int>("TypeId")
                        .HasColumnType("INTEGER");

                    b.Property<DateTime>("SiteDate")
                        .HasColumnType("TEXT");

                    b.Property<DateTime>("DateSubmitted")
                        .HasColumnType("TEXT");

                    b.Property<decimal>("Price")
                        .HasColumnType("TEXT");

                    b.HasKey("CurrencyId", "TypeId", "SiteDate");

                    b.HasIndex("TypeId");

                    b.ToTable("CurrencyRates");
                });

            modelBuilder.Entity("WebScrappingHtmlPage.CurrencyType", b =>
                {
                    b.Property<int>("TypeId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("PriceType")
                        .HasColumnType("TEXT");

                    b.Property<string>("TypeCurrency")
                        .HasColumnType("TEXT");

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
                        });
                });

            modelBuilder.Entity("WebScrappingHtmlPage.CurrencyRate", b =>
                {
                    b.HasOne("WebScrappingHtmlPage.Currency", "Currency")
                        .WithMany()
                        .HasForeignKey("CurrencyId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("WebScrappingHtmlPage.CurrencyType", "CurrencyType")
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
