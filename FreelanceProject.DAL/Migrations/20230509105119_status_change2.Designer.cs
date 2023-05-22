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
    [Migration("20230509105119_status_change2")]
    partial class status_change2
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.4")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("EmergencyV2Questions_Answers", b =>
                {
                    b.Property<int>("EmergenciesID")
                        .HasColumnType("int");

                    b.Property<int>("Questions_AnswersId")
                        .HasColumnType("int");

                    b.HasKey("EmergenciesID", "Questions_AnswersId");

                    b.HasIndex("Questions_AnswersId");

                    b.ToTable("EmergencyV2Questions_Answers");
                });

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
                });

            modelBuilder.Entity("FreelanceProject.DAL.Models.Mahmoud.EmergencyV2", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ID"));

                    b.Property<string>("CaseTitle")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("SubCaseTitle")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("User_EmergencyId")
                        .HasColumnType("int");

                    b.HasKey("ID");

                    b.HasIndex("User_EmergencyId");

                    b.ToTable("EmergencyV2");
                });

            modelBuilder.Entity("FreelanceProject.DAL.Models.Mahmoud.Emergency_Status_Change", b =>
                {
                    b.Property<string>("UserID")
                        .HasColumnType("nvarchar(450)");

                    b.Property<int>("User_EmergencyID")
                        .HasColumnType("int");

                    b.Property<int>("StatusPart")
                        .HasColumnType("int");

                    b.HasKey("UserID", "User_EmergencyID", "StatusPart");

                    b.HasIndex("User_EmergencyID");

                    b.ToTable("Emergency_Status_Change");
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
                });

            modelBuilder.Entity("FreelanceProject.DAL.Models.Mahmoud.Questions_Answers", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Answer")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("CastTitle")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Question")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Questions_Answers");
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

            modelBuilder.Entity("FreelanceProject.DAL.Models.Mahmoud.User_Emergency", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("ApplicationUserID")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("CreatedAt")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<decimal>("Latitude")
                        .HasColumnType("decimal(8,6)");

                    b.Property<decimal>("Logntitue")
                        .HasColumnType("decimal(9,6)");

                    b.Property<int>("Status")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("ApplicationUserID");

                    b.ToTable("User_Emergency");
                });

            modelBuilder.Entity("FreelanceProject.DAL.Models.Mona.ApplicationUser", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<int>("AccessFailedCount")
                        .HasColumnType("int");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Email")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<bool>("EmailConfirmed")
                        .HasColumnType("bit");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("LockoutEnabled")
                        .HasColumnType("bit");

                    b.Property<DateTimeOffset?>("LockoutEnd")
                        .HasColumnType("datetimeoffset");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("NormalizedEmail")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<string>("NormalizedUserName")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<string>("PasswordHash")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PhoneNumber")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("PhoneNumberConfirmed")
                        .HasColumnType("bit");

                    b.Property<string>("SecurityStamp")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("TwoFactorEnabled")
                        .HasColumnType("bit");

                    b.Property<string>("UserName")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.HasKey("Id");

                    b.HasIndex("NormalizedEmail")
                        .HasDatabaseName("EmailIndex");

                    b.HasIndex("NormalizedUserName")
                        .IsUnique()
                        .HasDatabaseName("UserNameIndex")
                        .HasFilter("[NormalizedUserName] IS NOT NULL");

                    b.ToTable("AspNetUsers", (string)null);
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

                    b.ToTable("User");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRole", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<string>("NormalizedName")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.HasKey("Id");

                    b.HasIndex("NormalizedName")
                        .IsUnique()
                        .HasDatabaseName("RoleNameIndex")
                        .HasFilter("[NormalizedName] IS NOT NULL");

                    b.ToTable("AspNetRoles", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("ClaimType")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("RoleId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("Id");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetRoleClaims", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("ClaimType")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserClaims", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.Property<string>("LoginProvider")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("ProviderKey")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("ProviderDisplayName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("LoginProvider", "ProviderKey");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserLogins", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<string>", b =>
                {
                    b.Property<string>("UserId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("RoleId")
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("UserId", "RoleId");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetUserRoles", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.Property<string>("UserId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("LoginProvider")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Value")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("UserId", "LoginProvider", "Name");

                    b.ToTable("AspNetUserTokens", (string)null);
                });

            modelBuilder.Entity("EmergencyV2Questions_Answers", b =>
                {
                    b.HasOne("FreelanceProject.DAL.Models.Mahmoud.EmergencyV2", null)
                        .WithMany()
                        .HasForeignKey("EmergenciesID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("FreelanceProject.DAL.Models.Mahmoud.Questions_Answers", null)
                        .WithMany()
                        .HasForeignKey("Questions_AnswersId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
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

            modelBuilder.Entity("FreelanceProject.DAL.Models.Mahmoud.EmergencyV2", b =>
                {
                    b.HasOne("FreelanceProject.DAL.Models.Mahmoud.User_Emergency", null)
                        .WithMany("User_Emergencies")
                        .HasForeignKey("User_EmergencyId");
                });

            modelBuilder.Entity("FreelanceProject.DAL.Models.Mahmoud.Emergency_Status_Change", b =>
                {
                    b.HasOne("FreelanceProject.DAL.Models.Mona.ApplicationUser", "UserPart")
                        .WithMany("Status_Changes")
                        .HasForeignKey("UserID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("FreelanceProject.DAL.Models.Mahmoud.User_Emergency", "Emergency_Part")
                        .WithMany("Status_Changes")
                        .HasForeignKey("User_EmergencyID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Emergency_Part");

                    b.Navigation("UserPart");
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

            modelBuilder.Entity("FreelanceProject.DAL.Models.Mahmoud.User_Emergency", b =>
                {
                    b.HasOne("FreelanceProject.DAL.Models.Mona.ApplicationUser", "User")
                        .WithMany()
                        .HasForeignKey("ApplicationUserID");

                    b.Navigation("User");
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

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityRole", null)
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.HasOne("FreelanceProject.DAL.Models.Mona.ApplicationUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.HasOne("FreelanceProject.DAL.Models.Mona.ApplicationUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityRole", null)
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("FreelanceProject.DAL.Models.Mona.ApplicationUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.HasOne("FreelanceProject.DAL.Models.Mona.ApplicationUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
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

            modelBuilder.Entity("FreelanceProject.DAL.Models.Mahmoud.User_Emergency", b =>
                {
                    b.Navigation("Status_Changes");

                    b.Navigation("User_Emergencies");
                });

            modelBuilder.Entity("FreelanceProject.DAL.Models.Mona.ApplicationUser", b =>
                {
                    b.Navigation("Status_Changes");
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