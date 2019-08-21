﻿// <auto-generated />
using System;
using InfotechVision.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace InfotechVision.Data.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    partial class ApplicationDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.2.6-servicing-10079")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("InfotechVision.Models.Address", b =>
                {
                    b.Property<int>("AddressID")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("City")
                        .HasMaxLength(1000);

                    b.Property<int?>("Contact");

                    b.Property<int?>("Contact1ContactID");

                    b.Property<string>("Country")
                        .HasMaxLength(1000);

                    b.Property<string>("DetailAddress")
                        .HasMaxLength(1000);

                    b.Property<string>("State")
                        .HasMaxLength(1000);

                    b.Property<string>("ZipCode")
                        .HasMaxLength(10);

                    b.HasKey("AddressID");

                    b.HasIndex("Contact1ContactID");

                    b.ToTable("Addresses");
                });

            modelBuilder.Entity("InfotechVision.Models.Company", b =>
                {
                    b.Property<int>("CompanyID")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int?>("AddressID");

                    b.Property<string>("CompanyName")
                        .HasMaxLength(1000);

                    b.Property<string>("CreatedById");

                    b.Property<DateTime?>("CreatedDate");

                    b.Property<string>("Description");

                    b.Property<bool>("HideOnSite");

                    b.Property<string>("LogoImage")
                        .HasMaxLength(1000);

                    b.Property<string>("UpdatedById");

                    b.Property<DateTime?>("UpdatedDate");

                    b.Property<string>("WebsiteURL")
                        .HasMaxLength(1000);

                    b.HasKey("CompanyID");

                    b.HasIndex("AddressID");

                    b.HasIndex("CreatedById");

                    b.HasIndex("UpdatedById");

                    b.ToTable("Companies");
                });

            modelBuilder.Entity("InfotechVision.Models.Contact", b =>
                {
                    b.Property<int>("ContactID")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Email")
                        .HasMaxLength(1000);

                    b.Property<string>("Phone")
                        .HasMaxLength(20);

                    b.HasKey("ContactID");

                    b.ToTable("Contacts");
                });

            modelBuilder.Entity("InfotechVision.Models.ContentDetail", b =>
                {
                    b.Property<int>("ContentID")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Author")
                        .HasMaxLength(1000);

                    b.Property<string>("CompanyName");

                    b.Property<string>("CreatedById");

                    b.Property<DateTime?>("CreatedDate");

                    b.Property<string>("Description");

                    b.Property<bool>("HideOnSite");

                    b.Property<string>("Image")
                        .HasMaxLength(1000);

                    b.Property<string>("Keywords");

                    b.Property<string>("Title")
                        .HasMaxLength(1000);

                    b.Property<string>("URL")
                        .HasMaxLength(1000);

                    b.Property<string>("UpdatedById");

                    b.Property<DateTime?>("UpdatedDate");

                    b.HasKey("ContentID");

                    b.HasIndex("CreatedById");

                    b.HasIndex("UpdatedById");

                    b.ToTable("ContentDetails");
                });

            modelBuilder.Entity("InfotechVision.Models.EmailCampaignLandingPageTrack", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Address");

                    b.Property<string>("AssetName");

                    b.Property<string>("Browser");

                    b.Property<string>("CampaignName");

                    b.Property<string>("City");

                    b.Property<string>("Company");

                    b.Property<string>("Country");

                    b.Property<string>("CustomQuestion1");

                    b.Property<string>("CustomQuestion2");

                    b.Property<string>("CustomQuestion3");

                    b.Property<string>("CustomQuestion4");

                    b.Property<string>("CustomQuestion5");

                    b.Property<DateTime>("DateTime");

                    b.Property<string>("Device");

                    b.Property<string>("Email");

                    b.Property<string>("EmployeeSize");

                    b.Property<string>("FirstName");

                    b.Property<string>("IP");

                    b.Property<string>("Industry");

                    b.Property<string>("JobTitle");

                    b.Property<string>("LastName");

                    b.Property<bool?>("OptIn");

                    b.Property<string>("Phone");

                    b.Property<string>("Revenue");

                    b.Property<string>("State");

                    b.Property<string>("Track");

                    b.Property<string>("Zip");

                    b.HasKey("Id");

                    b.ToTable("EmailCampaignLandingPageTracks");
                });

            modelBuilder.Entity("InfotechVision.Models.Event", b =>
                {
                    b.Property<int>("EventID")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int?>("AddressID");

                    b.Property<int?>("ContentID");

                    b.Property<DateTime?>("EndDate");

                    b.Property<string>("EventType");

                    b.Property<DateTime?>("StartDate");

                    b.HasKey("EventID");

                    b.HasIndex("AddressID");

                    b.HasIndex("ContentID");

                    b.ToTable("Events");
                });

            modelBuilder.Entity("InfotechVision.Models.News", b =>
                {
                    b.Property<int>("NewsID")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int?>("ContentID");

                    b.Property<DateTime?>("NewsDate");

                    b.Property<string>("NewsType");

                    b.HasKey("NewsID");

                    b.HasIndex("ContentID");

                    b.ToTable("News");
                });

            modelBuilder.Entity("InfotechVision.Models.Resource", b =>
                {
                    b.Property<int>("ResourcesID")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int?>("ContentID");

                    b.Property<DateTime>("DateTime");

                    b.Property<string>("ResourceFile")
                        .HasMaxLength(1000);

                    b.Property<string>("ResourceType");

                    b.HasKey("ResourcesID");

                    b.HasIndex("ContentID");

                    b.ToTable("Resources");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRole", b =>
                {
                    b.Property<string>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken();

                    b.Property<string>("Name")
                        .HasMaxLength(256);

                    b.Property<string>("NormalizedName")
                        .HasMaxLength(256);

                    b.HasKey("Id");

                    b.HasIndex("NormalizedName")
                        .IsUnique()
                        .HasName("RoleNameIndex")
                        .HasFilter("[NormalizedName] IS NOT NULL");

                    b.ToTable("AspNetRoles");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("ClaimType");

                    b.Property<string>("ClaimValue");

                    b.Property<string>("RoleId")
                        .IsRequired();

                    b.HasKey("Id");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetRoleClaims");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUser", b =>
                {
                    b.Property<string>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("AccessFailedCount");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken();

                    b.Property<string>("Email")
                        .HasMaxLength(256);

                    b.Property<bool>("EmailConfirmed");

                    b.Property<bool>("LockoutEnabled");

                    b.Property<DateTimeOffset?>("LockoutEnd");

                    b.Property<string>("NormalizedEmail")
                        .HasMaxLength(256);

                    b.Property<string>("NormalizedUserName")
                        .HasMaxLength(256);

                    b.Property<string>("PasswordHash");

                    b.Property<string>("PhoneNumber");

                    b.Property<bool>("PhoneNumberConfirmed");

                    b.Property<string>("SecurityStamp");

                    b.Property<bool>("TwoFactorEnabled");

                    b.Property<string>("UserName")
                        .HasMaxLength(256);

                    b.HasKey("Id");

                    b.HasIndex("NormalizedEmail")
                        .HasName("EmailIndex");

                    b.HasIndex("NormalizedUserName")
                        .IsUnique()
                        .HasName("UserNameIndex")
                        .HasFilter("[NormalizedUserName] IS NOT NULL");

                    b.ToTable("AspNetUsers");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("ClaimType");

                    b.Property<string>("ClaimValue");

                    b.Property<string>("UserId")
                        .IsRequired();

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserClaims");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.Property<string>("LoginProvider")
                        .HasMaxLength(128);

                    b.Property<string>("ProviderKey")
                        .HasMaxLength(128);

                    b.Property<string>("ProviderDisplayName");

                    b.Property<string>("UserId")
                        .IsRequired();

                    b.HasKey("LoginProvider", "ProviderKey");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserLogins");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<string>", b =>
                {
                    b.Property<string>("UserId");

                    b.Property<string>("RoleId");

                    b.HasKey("UserId", "RoleId");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetUserRoles");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.Property<string>("UserId");

                    b.Property<string>("LoginProvider")
                        .HasMaxLength(128);

                    b.Property<string>("Name")
                        .HasMaxLength(128);

                    b.Property<string>("Value");

                    b.HasKey("UserId", "LoginProvider", "Name");

                    b.ToTable("AspNetUserTokens");
                });

            modelBuilder.Entity("InfotechVision.Models.Address", b =>
                {
                    b.HasOne("InfotechVision.Models.Contact", "Contact1")
                        .WithMany("Addresses")
                        .HasForeignKey("Contact1ContactID");
                });

            modelBuilder.Entity("InfotechVision.Models.Company", b =>
                {
                    b.HasOne("InfotechVision.Models.Address", "Address")
                        .WithMany("Company")
                        .HasForeignKey("AddressID");

                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityUser", "CreatedBy")
                        .WithMany()
                        .HasForeignKey("CreatedById");

                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityUser", "UpdatedBy")
                        .WithMany()
                        .HasForeignKey("UpdatedById");
                });

            modelBuilder.Entity("InfotechVision.Models.ContentDetail", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityUser", "CreatedBy")
                        .WithMany()
                        .HasForeignKey("CreatedById");

                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityUser", "UpdatedBy")
                        .WithMany()
                        .HasForeignKey("UpdatedById");
                });

            modelBuilder.Entity("InfotechVision.Models.Event", b =>
                {
                    b.HasOne("InfotechVision.Models.Address", "Address")
                        .WithMany("Events")
                        .HasForeignKey("AddressID");

                    b.HasOne("InfotechVision.Models.ContentDetail", "ContentDetail")
                        .WithMany("Events")
                        .HasForeignKey("ContentID");
                });

            modelBuilder.Entity("InfotechVision.Models.News", b =>
                {
                    b.HasOne("InfotechVision.Models.ContentDetail", "ContentDetail")
                        .WithMany("News")
                        .HasForeignKey("ContentID");
                });

            modelBuilder.Entity("InfotechVision.Models.Resource", b =>
                {
                    b.HasOne("InfotechVision.Models.ContentDetail", "ContentDetail")
                        .WithMany("Resources")
                        .HasForeignKey("ContentID");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityRole")
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityUser")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityUser")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityRole")
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityUser")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityUser")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });
#pragma warning restore 612, 618
        }
    }
}
