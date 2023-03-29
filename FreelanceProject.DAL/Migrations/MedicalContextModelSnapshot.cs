﻿// <auto-generated />
using System;
using FreelanceProject.DAL.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace FreelanceProject.DAL.Migrations
{
    [DbContext(typeof(MedicalContext))]
    partial class MedicalContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
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

                    b.ToTable("Cases", (string)null);
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

                    b.ToTable("Conditions", (string)null);
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

                    b.Property<int>("SubCase_ID")
                        .HasColumnType("int");

                    b.HasKey("Ins_ID");

                    b.ToTable("Instructions", (string)null);
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

                    b.ToTable("SubCases", (string)null);
                });

            modelBuilder.Entity("FreelanceProject.DAL.Models.Mahmoud.SubCasesYoutubeLinks", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Link")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("SubCaseID")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("SubCaseID");

                    b.ToTable("SubCasesYoutubeLinks", (string)null);
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

                    b.ToTable("Choices", (string)null);
                });

            modelBuilder.Entity("FreelanceProject.DAL.Models.Mona.Emergencys", b =>
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

                    b.ToTable("Emergencies", (string)null);
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

                    b.ToTable("Questions", (string)null);
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

                    b.ToTable("Question_Cases", (string)null);
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

                    b.ToTable("Users", (string)null);
                });

            modelBuilder.Entity("InstructionsSubCases", b =>
                {
                    b.Property<int>("InstructionsIns_ID")
                        .HasColumnType("int");

                    b.Property<int>("SubCasesSubCaseID")
                        .HasColumnType("int");

                    b.HasKey("InstructionsIns_ID", "SubCasesSubCaseID");

                    b.HasIndex("SubCasesSubCaseID");

                    b.ToTable("InstructionsSubCases", (string)null);
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
                        .WithMany()
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

            modelBuilder.Entity("FreelanceProject.DAL.Models.Mona.Choice", b =>
                {
                    b.HasOne("FreelanceProject.DAL.Models.Mona.Question", "Question")
                        .WithMany("Choices")
                        .HasForeignKey("Q_Id")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Question");
                });

            modelBuilder.Entity("FreelanceProject.DAL.Models.Mona.Emergencys", b =>
                {
                    b.HasOne("FreelanceProject.DAL.Models.Mona.User", "User")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("User");
                });

            modelBuilder.Entity("InstructionsSubCases", b =>
                {
                    b.HasOne("FreelanceProject.DAL.Models.Mahmoud.Instructions", null)
                        .WithMany()
                        .HasForeignKey("InstructionsIns_ID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("FreelanceProject.DAL.Models.Mahmoud.SubCases", null)
                        .WithMany()
                        .HasForeignKey("SubCasesSubCaseID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("FreelanceProject.DAL.Models.Mahmoud.SubCases", b =>
                {
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
