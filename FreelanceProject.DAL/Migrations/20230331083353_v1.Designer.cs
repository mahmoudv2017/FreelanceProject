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
    [Migration("20230331083353_v1")]
    partial class v1
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

                    b.HasData(
                        new
                        {
                            Ins_ID = 1,
                            HasImage = false,
                            Ins_Body = "اتصل على  رقم الطوارئ في بلدك",
                            Order = 1,
                            Severity = 2
                        },
                        new
                        {
                            Ins_ID = 2,
                            HasImage = false,
                            Ins_Body = "امضغ الأسبرين ثم ابلعه أثناء انتظارك المساعدة الطارئة.",
                            Order = 2,
                            Severity = 0
                        },
                        new
                        {
                            Ins_ID = 3,
                            HasImage = false,
                            Ins_Body = "تناول نيتروغلسرين، إذا وُصف لك",
                            Order = 3,
                            Severity = 2
                        },
                        new
                        {
                            Ins_ID = 4,
                            HasImage = false,
                            Ins_Body = " ابدأ الإنعاش القلبي الرئوي إذا كان الشخص فاقدًا للوعي.",
                            Order = 4,
                            Severity = 2
                        });
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
                            Title = "ST احتشاء عضلة القلب الناجم عن ارتفاع مقطع"
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
                            Title = "ST احتشاء عضلة القلب غير المرتبطة بمقطع"
                        },
                        new
                        {
                            SubCaseID = 4,
                            CaseID = 2,
                            Title = "(إغماء وعائي مبهمي (إغماء قلبي وعصبي"
                        },
                        new
                        {
                            SubCaseID = 5,
                            CaseID = 2,
                            Title = "إغماء الظرفية"
                        },
                        new
                        {
                            SubCaseID = 6,
                            CaseID = 2,
                            Title = "(الإغماء الوضعي (انخفاض ضغط الدم الوضعي"
                        },
                        new
                        {
                            SubCaseID = 7,
                            CaseID = 2,
                            Title = "إغماء عصبي"
                        },
                        new
                        {
                            SubCaseID = 8,
                            CaseID = 2,
                            Title = "(POTS) متلازمة تسرع القلب الانتصابي الوضعي "
                        },
                        new
                        {
                            SubCaseID = 9,
                            CaseID = 3,
                            Title = "عضات سامة"
                        },
                        new
                        {
                            SubCaseID = 10,
                            CaseID = 3,
                            Title = "عضات غير سامة"
                        },
                        new
                        {
                            SubCaseID = 11,
                            CaseID = 4,
                            Title = "قرصة القراد"
                        },
                        new
                        {
                            SubCaseID = 12,
                            CaseID = 4,
                            Title = "قرصة العنكبوت"
                        },
                        new
                        {
                            SubCaseID = 13,
                            CaseID = 4,
                            Title = "قرصة البعوض"
                        },
                        new
                        {
                            SubCaseID = 14,
                            CaseID = 4,
                            Title = "قرصات بق الفراش"
                        },
                        new
                        {
                            SubCaseID = 15,
                            CaseID = 4,
                            Title = "قرصات قمل الرأس"
                        },
                        new
                        {
                            SubCaseID = 16,
                            CaseID = 4,
                            Title = "لدغات البراغيث"
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

                    b.HasData(
                        new
                        {
                            Subcase_ID = 1,
                            Instructions_ID = 1
                        },
                        new
                        {
                            Subcase_ID = 1,
                            Instructions_ID = 2
                        },
                        new
                        {
                            Subcase_ID = 1,
                            Instructions_ID = 3
                        });
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

            modelBuilder.Entity("FreelanceProject.DAL.Models.Mona.Emergency", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Address")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("CH_Body")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("CH_Id")
                        .HasColumnType("int");

                    b.Property<int>("CaseID")
                        .HasColumnType("int");

                    b.Property<string>("Q_Body")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Q_Id")
                        .HasColumnType("int");

                    b.Property<string>("SubCaseBody")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("SubCaseID")
                        .HasColumnType("int");

                    b.Property<int>("UserId")
                        .HasColumnType("int");

                    b.Property<string>("UserName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("Emergencies");
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

            modelBuilder.Entity("FreelanceProject.DAL.Models.Mona.User", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Users");
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

            modelBuilder.Entity("FreelanceProject.DAL.Models.Mona.Emergency", b =>
                {
                    b.HasOne("FreelanceProject.DAL.Models.Mona.User", "User")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("User");
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
