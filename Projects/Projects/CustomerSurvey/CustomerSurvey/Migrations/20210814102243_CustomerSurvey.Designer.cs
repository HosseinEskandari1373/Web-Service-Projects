﻿// <auto-generated />
using System;
using CustomerSurvey.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace CustomerSurvey.Migrations
{
    [DbContext(typeof(CustomeSurveyContext))]
    [Migration("20210814102243_CustomerSurvey")]
    partial class CustomerSurvey
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "6.0.0-preview.5.21301.9")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("CustomerSurvey.Models.Database.Answer", b =>
                {
                    b.Property<int>("AnswerID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Answers")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("OuestionID")
                        .HasColumnType("int");

                    b.HasKey("AnswerID");

                    b.HasIndex("OuestionID");

                    b.ToTable("Answers");
                });

            modelBuilder.Entity("CustomerSurvey.Models.Database.Customer", b =>
                {
                    b.Property<int>("CustomerID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("NationalCode")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("CustomerID");

                    b.ToTable("Customers");
                });

            modelBuilder.Entity("CustomerSurvey.Models.Database.CustomerAnswer", b =>
                {
                    b.Property<int>("AnswerID")
                        .HasColumnType("int");

                    b.Property<int>("CustomerID")
                        .HasColumnType("int");

                    b.Property<int>("CustomerAnswers")
                        .HasColumnType("int");

                    b.Property<string>("Response")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("AnswerID", "CustomerID", "CustomerAnswers");

                    b.HasIndex("CustomerID");

                    b.ToTable("CustomerAnswers");
                });

            modelBuilder.Entity("CustomerSurvey.Models.Database.CustomerSurveys", b =>
                {
                    b.Property<int>("CustomerID")
                        .HasColumnType("int");

                    b.Property<int>("SurveyID")
                        .HasColumnType("int");

                    b.Property<bool>("IsSurveyCompleted")
                        .HasColumnType("bit");

                    b.Property<bool>("SurveyNotificationDelivered")
                        .HasColumnType("bit");

                    b.Property<string>("UniqueURL")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("CustomerID", "SurveyID");

                    b.HasIndex("SurveyID");

                    b.ToTable("CustomerSurveys");
                });

            modelBuilder.Entity("CustomerSurvey.Models.Database.Question", b =>
                {
                    b.Property<int>("QuestionID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("QuestionCategory")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("QuestionText")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("QuestionType")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("SurveyID")
                        .HasColumnType("int");

                    b.HasKey("QuestionID");

                    b.HasIndex("SurveyID");

                    b.ToTable("Questions");
                });

            modelBuilder.Entity("CustomerSurvey.Models.Database.Survey", b =>
                {
                    b.Property<int>("SurveyID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("DateSubmitted")
                        .HasColumnType("datetime2");

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("EndDate")
                        .HasColumnType("datetime2");

                    b.Property<bool>("IsActive")
                        .HasColumnType("bit");

                    b.Property<string>("Organization")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("StartDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("Title")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("SurveyID");

                    b.ToTable("Surveys");
                });

            modelBuilder.Entity("CustomerSurvey.Models.Database.Answer", b =>
                {
                    b.HasOne("CustomerSurvey.Models.Database.Question", "Question")
                        .WithMany()
                        .HasForeignKey("OuestionID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Question");
                });

            modelBuilder.Entity("CustomerSurvey.Models.Database.CustomerAnswer", b =>
                {
                    b.HasOne("CustomerSurvey.Models.Database.Answer", "Answer")
                        .WithMany()
                        .HasForeignKey("AnswerID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("CustomerSurvey.Models.Database.Customer", "Customer")
                        .WithMany()
                        .HasForeignKey("CustomerID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Answer");

                    b.Navigation("Customer");
                });

            modelBuilder.Entity("CustomerSurvey.Models.Database.CustomerSurveys", b =>
                {
                    b.HasOne("CustomerSurvey.Models.Database.Customer", "Customer")
                        .WithMany()
                        .HasForeignKey("CustomerID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("CustomerSurvey.Models.Database.Survey", "Survey")
                        .WithMany()
                        .HasForeignKey("SurveyID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Customer");

                    b.Navigation("Survey");
                });

            modelBuilder.Entity("CustomerSurvey.Models.Database.Question", b =>
                {
                    b.HasOne("CustomerSurvey.Models.Database.Survey", "Survey")
                        .WithMany()
                        .HasForeignKey("SurveyID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Survey");
                });
#pragma warning restore 612, 618
        }
    }
}
