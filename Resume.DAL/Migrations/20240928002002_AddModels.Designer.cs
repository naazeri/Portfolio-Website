﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Resume.DAL.Context;

#nullable disable

namespace Resume.DAL.Migrations
{
    [DbContext(typeof(AppDbContext))]
    [Migration("20240928002002_AddModels")]
    partial class AddModels
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.8")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("Resume.DAL.Models.Config.SiteConfig", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<DateTime>("CreateDate")
                        .HasColumnType("datetime2");

                    b.Property<bool>("ShowAboutSection")
                        .HasColumnType("bit");

                    b.Property<bool>("ShowContactSection")
                        .HasColumnType("bit");

                    b.Property<bool>("ShowFooter1Section")
                        .HasColumnType("bit");

                    b.Property<bool>("ShowFooter2Section")
                        .HasColumnType("bit");

                    b.Property<bool>("ShowPortfolioSection")
                        .HasColumnType("bit");

                    b.Property<bool>("ShowResumeSection")
                        .HasColumnType("bit");

                    b.Property<bool>("ShowServicesSection")
                        .HasColumnType("bit");

                    b.Property<bool>("ShowSkillsSection")
                        .HasColumnType("bit");

                    b.Property<bool>("ShowStatsSection")
                        .HasColumnType("bit");

                    b.Property<bool>("ShowTestimonialsSection")
                        .HasColumnType("bit");

                    b.Property<string>("SiteIcon")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("SiteTitle")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Tagline")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("UpdateDate")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.ToTable("SiteConfigs");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            CreateDate = new DateTime(2024, 9, 28, 3, 50, 2, 479, DateTimeKind.Local).AddTicks(8051),
                            ShowAboutSection = true,
                            ShowContactSection = true,
                            ShowFooter1Section = true,
                            ShowFooter2Section = true,
                            ShowPortfolioSection = true,
                            ShowResumeSection = true,
                            ShowServicesSection = true,
                            ShowSkillsSection = false,
                            ShowStatsSection = true,
                            ShowTestimonialsSection = false,
                            SiteIcon = "/Site/assets/img/favicon.png",
                            SiteTitle = "John Doe Resume",
                            Tagline = "My Portfolio",
                            UpdateDate = new DateTime(2024, 9, 28, 3, 50, 2, 479, DateTimeKind.Local).AddTicks(8051)
                        });
                });

            modelBuilder.Entity("Resume.DAL.Models.ContactUs", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Answer")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("CreateDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("FullName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Message")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("UpdateDate")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.ToTable("ContactUs");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            CreateDate = new DateTime(2024, 9, 28, 3, 50, 2, 479, DateTimeKind.Local).AddTicks(8144),
                            Email = "reza.armani75@gmail.com",
                            FullName = "Reza Nazeri",
                            Message = "hi\nhow are you doin?",
                            Title = "Test 1",
                            UpdateDate = new DateTime(2024, 9, 28, 3, 50, 2, 479, DateTimeKind.Local).AddTicks(8144)
                        });
                });

            modelBuilder.Entity("Resume.DAL.Models.File.ImageFile", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Alt")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("CreateDate")
                        .HasColumnType("datetime2");

                    b.Property<bool>("IsInTrash")
                        .HasColumnType("bit");

                    b.Property<string>("LargeImage")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("MaxImage")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("MediumImage")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ThumbnailImage")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("UpdateDate")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.ToTable("ImageFiles");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Alt = "profile image",
                            CreateDate = new DateTime(2024, 9, 28, 3, 50, 2, 479, DateTimeKind.Local).AddTicks(8069),
                            IsInTrash = false,
                            LargeImage = "/Site/assets/img/profile-img.jpg",
                            MaxImage = "/Site/assets/img/profile-img.jpg",
                            MediumImage = "/Site/assets/img/profile-img.jpg",
                            ThumbnailImage = "/Site/assets/img/profile-img.jpg",
                            UpdateDate = new DateTime(2024, 9, 28, 3, 50, 2, 479, DateTimeKind.Local).AddTicks(8069)
                        });
                });

            modelBuilder.Entity("Resume.DAL.Models.User.About", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<DateOnly?>("BirthDate")
                        .HasColumnType("date");

                    b.Property<DateTime>("CreateDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("CurrentJobTitle")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("CurrentJobTitleDescriptionBottom")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("CurrentJobTitleDescriptionTop")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Email")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("FirstName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("ImageFileId")
                        .HasColumnType("int");

                    b.Property<string>("LastName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Location")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Mobile")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("MyTitles")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Summary")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("UpdateDate")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.HasIndex("ImageFileId");

                    b.ToTable("About");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            BirthDate = new DateOnly(1996, 4, 10),
                            CreateDate = new DateTime(2024, 9, 28, 3, 50, 2, 479, DateTimeKind.Local).AddTicks(8100),
                            CurrentJobTitle = "Software Engineer at <a href=\"https://dotin.ir\" target=\"_blank\" style=\"color:green;\">Dotin</a>",
                            CurrentJobTitleDescriptionBottom = "Therefore, choosing the services of labor and pains is the choice of the services. Anyone can get everything and that. There are no complaints from the prosecutors about their services at the time. And all his Because of desire, as said, most offices indeed. But those who are not to be repulsed will therefore be pursued.",
                            CurrentJobTitleDescriptionTop = "It is important to take care of the patient, to be followed by the doctor, but it is a time of great pain and suffering.",
                            Email = "reza.armani75@gmail.com",
                            FirstName = "Reza",
                            ImageFileId = 1,
                            LastName = "Nazeri",
                            Location = "Mashhad, Iran",
                            Mobile = "+989123456789",
                            MyTitles = "Developer, Teacher",
                            Summary = "It takes great pains to benefit. His needs result from something that actually drives him away. Let them be what they want. Anyone whom anyone desires. And no one who hinders receives the others. Because he should flee in this office of convenience, which is here.",
                            UpdateDate = new DateTime(2024, 9, 28, 3, 50, 2, 479, DateTimeKind.Local).AddTicks(8100)
                        });
                });

            modelBuilder.Entity("Resume.DAL.Models.User.AppUser", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<DateTime>("CreateDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("IsActive")
                        .HasColumnType("bit");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Mobile")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("UpdateDate")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.ToTable("Users");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            CreateDate = new DateTime(2024, 9, 28, 3, 50, 2, 479, DateTimeKind.Local).AddTicks(7865),
                            Email = "admin@gmail.com",
                            FirstName = "Admin",
                            IsActive = true,
                            LastName = "Admin",
                            Mobile = "+989123456789",
                            Password = "E1-0A-DC-39-49-BA-59-AB-BE-56-E0-57-F2-0F-88-3E",
                            UpdateDate = new DateTime(2024, 9, 28, 3, 50, 2, 479, DateTimeKind.Local).AddTicks(7874)
                        });
                });

            modelBuilder.Entity("Resume.DAL.Models.User.SocialLink", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("AboutId")
                        .HasColumnType("int");

                    b.Property<DateTime>("CreateDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("IconName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("IsActive")
                        .HasColumnType("bit");

                    b.Property<string>("LinkAddress")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Title")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("UpdateDate")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.HasIndex("AboutId");

                    b.ToTable("SocialLinks");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            AboutId = 1,
                            CreateDate = new DateTime(2024, 9, 28, 3, 50, 2, 479, DateTimeKind.Local).AddTicks(8116),
                            IconName = "bi-linkedin",
                            IsActive = true,
                            LinkAddress = "https://linkedin.com/in/rezanazeri",
                            Title = "Linkedin",
                            UpdateDate = new DateTime(2024, 9, 28, 3, 50, 2, 479, DateTimeKind.Local).AddTicks(8116)
                        },
                        new
                        {
                            Id = 2,
                            AboutId = 1,
                            CreateDate = new DateTime(2024, 9, 28, 3, 50, 2, 479, DateTimeKind.Local).AddTicks(8117),
                            IconName = "bi-youtube",
                            IsActive = true,
                            LinkAddress = "https://youtube.com/@naazeri",
                            Title = "Youtube",
                            UpdateDate = new DateTime(2024, 9, 28, 3, 50, 2, 479, DateTimeKind.Local).AddTicks(8118)
                        },
                        new
                        {
                            Id = 3,
                            AboutId = 1,
                            CreateDate = new DateTime(2024, 9, 28, 3, 50, 2, 479, DateTimeKind.Local).AddTicks(8119),
                            IconName = "bi-github",
                            IsActive = true,
                            LinkAddress = "https://github.com/naazeri",
                            Title = "Github",
                            UpdateDate = new DateTime(2024, 9, 28, 3, 50, 2, 479, DateTimeKind.Local).AddTicks(8120)
                        },
                        new
                        {
                            Id = 4,
                            AboutId = 1,
                            CreateDate = new DateTime(2024, 9, 28, 3, 50, 2, 479, DateTimeKind.Local).AddTicks(8121),
                            IconName = "bi-twitter-x",
                            IsActive = true,
                            LinkAddress = "https://x.com/r_nazeri",
                            Title = "X",
                            UpdateDate = new DateTime(2024, 9, 28, 3, 50, 2, 479, DateTimeKind.Local).AddTicks(8121)
                        },
                        new
                        {
                            Id = 5,
                            AboutId = 1,
                            CreateDate = new DateTime(2024, 9, 28, 3, 50, 2, 479, DateTimeKind.Local).AddTicks(8124),
                            IconName = "bi-instagram",
                            IsActive = true,
                            LinkAddress = "https://instagram.com/re_nazeri",
                            Title = "Instagram",
                            UpdateDate = new DateTime(2024, 9, 28, 3, 50, 2, 479, DateTimeKind.Local).AddTicks(8125)
                        });
                });

            modelBuilder.Entity("Resume.DAL.Models.User.About", b =>
                {
                    b.HasOne("Resume.DAL.Models.File.ImageFile", "AboutImage")
                        .WithMany()
                        .HasForeignKey("ImageFileId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("AboutImage");
                });

            modelBuilder.Entity("Resume.DAL.Models.User.SocialLink", b =>
                {
                    b.HasOne("Resume.DAL.Models.User.About", "About")
                        .WithMany("SocialLinks")
                        .HasForeignKey("AboutId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("About");
                });

            modelBuilder.Entity("Resume.DAL.Models.User.About", b =>
                {
                    b.Navigation("SocialLinks");
                });
#pragma warning restore 612, 618
        }
    }
}
