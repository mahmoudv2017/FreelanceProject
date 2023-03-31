﻿// <auto-generated />
using System;
using FreelanceProject.DAL.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace FreelanceProject.DAL.Migrations
{
    [DbContext(typeof(MedicalContext))]
    [Migration("20230330053333_v4")]
    partial class v4
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.4")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("FreelanceProject.DAL.Models.Mahmoud.Cases", b =>
                {
                    b.Property<int>("CaseID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("CaseID"));

                    b.Property<bool>("HasConditions")
                        .HasColumnType("bit");

                    b.Property<string>("ImageUrl")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("QuestionQ_ID")
                        .HasColumnType("int");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("CaseID");

                    b.HasIndex("QuestionQ_ID");

                    b.ToTable("Cases");

                    b.HasData(
                        new
                        {
                            CaseID = 1,
                            HasConditions = false,
                            ImageUrl = "heart.jpg",
                            Title = "ازمة قلبية"
                        },
                        new
                        {
                            CaseID = 2,
                            HasConditions = false,
                            ImageUrl = "faints.png",
                            Title = "الاغماء"
                        },
                        new
                        {
                            CaseID = 3,
                            HasConditions = false,
                            ImageUrl = "bites.jpg",
                            Title = "العضات"
                        },
                        new
                        {
                            CaseID = 4,
                            HasConditions = false,
                            ImageUrl = "antsBite.png",
                            Title = "اللدغات"
                        });
                });

            modelBuilder.Entity("FreelanceProject.DAL.Models.Mahmoud.Conditions", b =>
                {
                    b.Property<int>("C_ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("C_ID"));

                    b.Property<string>("C_Body")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("SubCase_ID")
                        .HasColumnType("int");

                    b.HasKey("C_ID");

                    b.HasIndex("SubCase_ID");

                    b.ToTable("Conditions");

                    b.HasData(
                        new
                        {
                            C_ID = 1,
                            C_Body = "انزعاج أو شعور بالألم في منطقة الصدر",
                            SubCase_ID = 1
                        },
                        new
                        {
                            C_ID = 2,
                            C_Body = "الألم في الجزء العلوي من الجسم",
                            SubCase_ID = 1
                        },
                        new
                        {
                            C_ID = 3,
                            C_Body = "  ألم المعدة و ضيق تنفس ",
                            SubCase_ID = 1
                        });
                });

            modelBuilder.Entity("FreelanceProject.DAL.Models.Mahmoud.Instructions", b =>
                {
                    b.Property<int>("Ins_ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Ins_ID"));

                    b.Property<bool>("HasImage")
                        .HasColumnType("bit");

                    b.Property<string>("ImageURL")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Ins_Body")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Order")
                        .HasColumnType("int");

                    b.Property<int>("Severity")
                        .HasColumnType("int");

                    b.HasKey("Ins_ID");

                    b.ToTable("Instructions");
                });

            modelBuilder.Entity("FreelanceProject.DAL.Models.Mahmoud.SubCases", b =>
                {
                    b.Property<int>("SubCaseID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("SubCaseID"));

                    b.Property<int>("CaseID")
                        .HasColumnType("int");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("SubCaseID");

                    b.HasIndex("CaseID");

                    b.ToTable("SubCases");

                    b.HasData(
                        new
                        {
                            SubCaseID = 1,
                            CaseID = 1,
                            Title = " ST احتشاء عضلة القلب الناجم عن ارتفاع مقطع"
                        },
                        new
                        {
                            SubCaseID = 2,
                            CaseID = 1,
                            Title = "النوبات القلبية الصامتة"
                        },
                        new
                        {
                            SubCaseID = 3,
                            CaseID = 1,
                            Title = " ST احتشاء عضلة القلب غير المرتبطة بمقطع"
                        });
                });

            modelBuilder.Entity("FreelanceProject.DAL.Models.Mahmoud.SubCasesYoutubeLinks", b =>
                {
                    b.Property<int>("SubCaseID")
                        .HasColumnType("int");

                    b.Property<string>("Link")
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("SubCaseID", "Link");

                    b.ToTable("SubCasesYoutubeLinks");
                });

            modelBuilder.Entity("FreelanceProject.DAL.Models.Mahmoud.Subcase_Instructions", b =>
                {
                    b.Property<int>("Subcase_ID")
                        .HasColumnType("int");

                    b.Property<int>("Instructions_ID")
                        .HasColumnType("int");

                    b.HasKey("Subcase_ID", "Instructions_ID");

                    b.HasIndex("Instructions_ID");

                    b.ToTable("SubCases_Instructions");
                });

            modelBuilder.Entity("FreelanceProject.DAL.Models.Mona.Choice", b =>
                {
                    b.Property<int>("Ch_ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Ch_ID"));

                    b.Property<string>("Body")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<byte[]>("Image")
                        .IsRequired()
                        .HasColumnType("varbinary(max)");

                    b.Property<string>("ImageURL")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("IsImage")
                        .HasColumnType("bit");

                    b.Property<int>("Q_Id")
                        .HasColumnType("int");

                    b.HasKey("Ch_ID");

                    b.HasIndex("Q_Id");

                    b.ToTable("Choices");
                });

            modelBuilder.Entity("FreelanceProject.DAL.Models.Mona.Question", b =>
                {
                    b.Property<int>("Q_ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Q_ID"));

                    b.Property<string>("Body")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("CaseID")
                        .HasColumnType("int");

                    b.Property<int>("ChoiceID")
                        .HasColumnType("int");

                    b.Property<string>("Type")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Q_ID");

                    b.ToTable("Questions");
                });

            modelBuilder.Entity("FreelanceProject.DAL.Models.Mona.Question_Case", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("Case_ID")
                        .HasColumnType("int");

                    b.Property<int>("Q_ID")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("Question_Cases");
                });

            modelBuilder.Entity("FreelanceProject.DAL.Models.Mahmoud.Cases", b =>
                {
                    b.HasOne("FreelanceProject.DAL.Models.Mona.Question", null)
                        .WithMany("Cases")
                        .HasForeignKey("QuestionQ_ID");
                });

            modelBuilder.Entity("FreelanceProject.DAL.Models.Mahmoud.Conditions", b =>
                {
                    b.HasOne("FreelanceProject.DAL.Models.Mahmoud.SubCases", "SubCases")
                        .WithMany("Conditons")
                        .HasForeignKey("SubCase_ID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("SubCases");
                });

            modelBuilder.Entity("FreelanceProject.DAL.Models.Mahmoud.SubCases", b =>
                {
                    b.HasOne("FreelanceProject.DAL.Models.Mahmoud.Cases", "Case")
                        .WithMany()
                        .HasForeignKey("CaseID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Case");
                });

            modelBuilder.Entity("FreelanceProject.DAL.Models.Mahmoud.SubCasesYoutubeLinks", b =>
                {
                    b.HasOne("FreelanceProject.DAL.Models.Mahmoud.SubCases", "SubCases")
                        .WithMany("YoutubeLinks")
                        .HasForeignKey("SubCaseID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("SubCases");
                });

            modelBuilder.Entity("FreelanceProject.DAL.Models.Mahmoud.Subcase_Instructions", b =>
                {
                    b.HasOne("FreelanceProject.DAL.Models.Mahmoud.Instructions", "Instruction")
                        .WithMany("SubCases")
                        .HasForeignKey("Instructions_ID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("FreelanceProject.DAL.Models.Mahmoud.SubCases", "Subcase")
                        .WithMany("Instructions")
                        .HasForeignKey("Subcase_ID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Instruction");

                    b.Navigation("Subcase");
                });

            modelBuilder.Entity("FreelanceProject.DAL.Models.Mona.Choice", b =>
                {
                    b.HasOne("FreelanceProject.DAL.Models.Mona.Question", "Question")
                        .WithMany("Choices")
                        .HasForeignKey("Q_Id")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Question");
                });

            modelBuilder.Entity("FreelanceProject.DAL.Models.Mahmoud.Instructions", b =>
                {
                    b.Navigation("SubCases");
                });

            modelBuilder.Entity("FreelanceProject.DAL.Models.Mahmoud.SubCases", b =>
                {
                    b.Navigation("Conditons");

                    b.Navigation("Instructions");

                    b.Navigation("YoutubeLinks");
                });

            modelBuilder.Entity("FreelanceProject.DAL.Models.Mona.Question", b =>
                {
                    b.Navigation("Cases");

                    b.Navigation("Choices");
                });
#pragma warning restore 612, 618
        }
    }
}
