﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Persistence.Contexts;

namespace Persistence.Migrations
{
    [DbContext(typeof(ApplicationDataBaseContext))]
    partial class ApplicationDataBaseContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.9")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("Domain.Entities.LocationsAgg.CityOrVilage", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int?>("AreaExpertId")
                        .HasColumnType("int");

                    b.Property<int>("CityOrVilageType")
                        .HasColumnType("int");

                    b.Property<string>("InsertByUserId")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime?>("InsertTime")
                        .HasColumnType("datetime2");

                    b.Property<bool?>("IsRemoved")
                        .HasColumnType("bit");

                    b.Property<int>("PartId")
                        .HasColumnType("int");

                    b.Property<string>("RemoveByUserId")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime?>("RemoveTime")
                        .HasColumnType("datetime2");

                    b.Property<int>("RuralId")
                        .HasColumnType("int");

                    b.Property<int?>("ServiceCenterId")
                        .HasColumnType("int");

                    b.Property<int>("Status")
                        .HasColumnType("int");

                    b.Property<string>("Title")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UpdateByUserId")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime?>("UpdateTime")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.HasIndex("PartId");

                    b.ToTable("CityOrVilage");
                });

            modelBuilder.Entity("Domain.Entities.LocationsAgg.County", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("InsertByUserId")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime?>("InsertTime")
                        .HasColumnType("datetime2");

                    b.Property<bool?>("IsRemoved")
                        .HasColumnType("bit");

                    b.Property<int>("ProvinceId")
                        .HasColumnType("int");

                    b.Property<string>("RemoveByUserId")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime?>("RemoveTime")
                        .HasColumnType("datetime2");

                    b.Property<int>("Status")
                        .HasColumnType("int");

                    b.Property<string>("Title")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UpdateByUserId")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime?>("UpdateTime")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.HasIndex("ProvinceId");

                    b.ToTable("County");
                });

            modelBuilder.Entity("Domain.Entities.LocationsAgg.MainLocation", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("InsertByUserId")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime?>("InsertTime")
                        .HasColumnType("datetime2");

                    b.Property<bool?>("IsRemoved")
                        .HasColumnType("bit");

                    b.Property<string>("RemoveByUserId")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime?>("RemoveTime")
                        .HasColumnType("datetime2");

                    b.Property<int>("Status")
                        .HasColumnType("int");

                    b.Property<string>("Title")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UpdateByUserId")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime?>("UpdateTime")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.ToTable("MainLocation");
                });

            modelBuilder.Entity("Domain.Entities.LocationsAgg.Part", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("CountyId")
                        .HasColumnType("int");

                    b.Property<string>("InsertByUserId")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime?>("InsertTime")
                        .HasColumnType("datetime2");

                    b.Property<bool?>("IsRemoved")
                        .HasColumnType("bit");

                    b.Property<string>("RemoveByUserId")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime?>("RemoveTime")
                        .HasColumnType("datetime2");

                    b.Property<string>("Title")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UpdateByUserId")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime?>("UpdateTime")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.HasIndex("CountyId");

                    b.ToTable("Part");
                });

            modelBuilder.Entity("Domain.Entities.LocationsAgg.Province", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("InsertByUserId")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime?>("InsertTime")
                        .HasColumnType("datetime2");

                    b.Property<bool?>("IsRemoved")
                        .HasColumnType("bit");

                    b.Property<int>("MainLocationId")
                        .HasColumnType("int");

                    b.Property<string>("RemoveByUserId")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime?>("RemoveTime")
                        .HasColumnType("datetime2");

                    b.Property<int>("Status")
                        .HasColumnType("int");

                    b.Property<string>("Title")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UpdateByUserId")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime?>("UpdateTime")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.HasIndex("MainLocationId");

                    b.ToTable("Province");
                });

            modelBuilder.Entity("Domain.Entities.UserAgg.ApplicationRole", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("InsertByUserId")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime?>("InsertTime")
                        .HasColumnType("datetime2");

                    b.Property<bool?>("IsRemoved")
                        .HasColumnType("bit");

                    b.Property<string>("Name")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<string>("NormalizedName")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<string>("RemoveByUserId")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime?>("RemoveTime")
                        .HasColumnType("datetime2");

                    b.Property<string>("UpdateByUserId")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime?>("UpdateTime")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.HasIndex("NormalizedName")
                        .IsUnique()
                        .HasDatabaseName("RoleNameIndex")
                        .HasFilter("[NormalizedName] IS NOT NULL");

                    b.ToTable("AspNetRoles");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            ConcurrencyStamp = "94f4fb94-6cb5-4631-94d7-5a330ee81791",
                            Description = "کاربر حقیقی",
                            Name = "UserReal",
                            NormalizedName = "USERREAL"
                        },
                        new
                        {
                            Id = 2,
                            ConcurrencyStamp = "8a437644-b6af-45c2-8692-1d94dcbaadf4",
                            Description = "کاربر حقوقی",
                            Name = "UserLegal",
                            NormalizedName = "USERLEGAL"
                        },
                        new
                        {
                            Id = 3,
                            ConcurrencyStamp = "06defbc5-a5f9-4eae-9b9d-14d605c0a353",
                            Description = "ادمین کل سیستم",
                            Name = "AdminSystem",
                            NormalizedName = "ADMINSYSTEM"
                        },
                        new
                        {
                            Id = 4,
                            ConcurrencyStamp = "a63bd148-f692-473a-b6b2-a9d9035d36bc",
                            Description = "ادمین کل سازمان",
                            Name = "AdminGeneralOrganization",
                            NormalizedName = "ADMINGENERALORGANIZATION"
                        },
                        new
                        {
                            Id = 5,
                            ConcurrencyStamp = "3ae47dac-8158-4a51-90bf-60a249757cdd",
                            Description = "ادمین سازمان",
                            Name = "AdminOrganization",
                            NormalizedName = "ADMINORGANIZATION"
                        });
                });

            modelBuilder.Entity("Domain.Entities.UserAgg.ApplicationUser", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("AccessFailedCount")
                        .HasColumnType("int");

                    b.Property<string>("Address")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("CityOrVilageId")
                        .HasColumnType("int");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Discriminator")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Email")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<bool>("EmailConfirmed")
                        .HasColumnType("bit");

                    b.Property<int?>("IdentityUserId")
                        .HasColumnType("int");

                    b.Property<DateTime?>("InsertTime")
                        .HasColumnType("datetime2");

                    b.Property<string>("Instagram")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("IsAuthorizedUser")
                        .HasColumnType("bit");

                    b.Property<double?>("Lat")
                        .HasColumnType("float");

                    b.Property<string>("LinkIn")
                        .HasColumnType("nvarchar(max)");

                    b.Property<double?>("Lng")
                        .HasColumnType("float");

                    b.Property<bool>("LockoutEnabled")
                        .HasColumnType("bit");

                    b.Property<DateTimeOffset?>("LockoutEnd")
                        .HasColumnType("datetimeoffset");

                    b.Property<string>("MobileNumber")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("NatureTypeUser")
                        .HasColumnType("int");

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

                    b.Property<string>("PicProfile")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PostalCode")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("SecurityStamp")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("Status")
                        .HasColumnType("int");

                    b.Property<string>("Telegram")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("TellNumber")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("TwoFactorEnabled")
                        .HasColumnType("bit");

                    b.Property<DateTime?>("UpdateTime")
                        .HasColumnType("datetime2");

                    b.Property<string>("UserName")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<string>("WebSite")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("CityOrVilageId");

                    b.HasIndex("NormalizedEmail")
                        .HasDatabaseName("EmailIndex");

                    b.HasIndex("NormalizedUserName")
                        .IsUnique()
                        .HasDatabaseName("UserNameIndex")
                        .HasFilter("[NormalizedUserName] IS NOT NULL");

                    b.ToTable("AspNetUsers");

                    b.HasDiscriminator<string>("Discriminator").HasValue("ApplicationUser");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<int>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("ClaimType")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("RoleId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetRoleClaims");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<int>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("ClaimType")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("UserId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserClaims");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<int>", b =>
                {
                    b.Property<string>("LoginProvider")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("ProviderKey")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("ProviderDisplayName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("UserId")
                        .HasColumnType("int");

                    b.HasKey("LoginProvider", "ProviderKey");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserLogins");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<int>", b =>
                {
                    b.Property<int>("UserId")
                        .HasColumnType("int");

                    b.Property<int>("RoleId")
                        .HasColumnType("int");

                    b.HasKey("UserId", "RoleId");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetUserRoles");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<int>", b =>
                {
                    b.Property<int>("UserId")
                        .HasColumnType("int");

                    b.Property<string>("LoginProvider")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Value")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("UserId", "LoginProvider", "Name");

                    b.ToTable("AspNetUserTokens");
                });

            modelBuilder.Entity("Domain.Entities.UserAgg.UserLegal", b =>
                {
                    b.HasBaseType("Domain.Entities.UserAgg.ApplicationUser");

                    b.Property<DateTime>("CompanyRegistrationDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("CompanyRegistrationPlace")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("EconomicCode")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("EstablishedYear")
                        .HasColumnType("int");

                    b.Property<string>("NationalId")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("RegistrationNumber")
                        .HasColumnType("nvarchar(max)");

                    b.HasDiscriminator().HasValue("UserLegal");
                });

            modelBuilder.Entity("Domain.Entities.UserAgg.UserReal", b =>
                {
                    b.HasBaseType("Domain.Entities.UserAgg.ApplicationUser");

                    b.Property<int?>("BirthCertificatId")
                        .HasColumnType("int");

                    b.Property<string>("FatherName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("LastName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("NationalCode")
                        .HasColumnType("nvarchar(max)");

                    b.HasDiscriminator().HasValue("UserReal");
                });

            modelBuilder.Entity("Domain.Entities.LocationsAgg.CityOrVilage", b =>
                {
                    b.HasOne("Domain.Entities.LocationsAgg.Part", "Part")
                        .WithMany("CityOrVilages")
                        .HasForeignKey("PartId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Part");
                });

            modelBuilder.Entity("Domain.Entities.LocationsAgg.County", b =>
                {
                    b.HasOne("Domain.Entities.LocationsAgg.Province", "Province")
                        .WithMany("Counties")
                        .HasForeignKey("ProvinceId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Province");
                });

            modelBuilder.Entity("Domain.Entities.LocationsAgg.Part", b =>
                {
                    b.HasOne("Domain.Entities.LocationsAgg.County", "County")
                        .WithMany("Parts")
                        .HasForeignKey("CountyId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("County");
                });

            modelBuilder.Entity("Domain.Entities.LocationsAgg.Province", b =>
                {
                    b.HasOne("Domain.Entities.LocationsAgg.MainLocation", "MainLocation")
                        .WithMany("Provinces")
                        .HasForeignKey("MainLocationId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("MainLocation");
                });

            modelBuilder.Entity("Domain.Entities.UserAgg.ApplicationUser", b =>
                {
                    b.HasOne("Domain.Entities.LocationsAgg.CityOrVilage", "CityOrVilage")
                        .WithMany()
                        .HasForeignKey("CityOrVilageId");

                    b.Navigation("CityOrVilage");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<int>", b =>
                {
                    b.HasOne("Domain.Entities.UserAgg.ApplicationRole", null)
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<int>", b =>
                {
                    b.HasOne("Domain.Entities.UserAgg.ApplicationUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<int>", b =>
                {
                    b.HasOne("Domain.Entities.UserAgg.ApplicationUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<int>", b =>
                {
                    b.HasOne("Domain.Entities.UserAgg.ApplicationRole", null)
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Domain.Entities.UserAgg.ApplicationUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<int>", b =>
                {
                    b.HasOne("Domain.Entities.UserAgg.ApplicationUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Domain.Entities.LocationsAgg.County", b =>
                {
                    b.Navigation("Parts");
                });

            modelBuilder.Entity("Domain.Entities.LocationsAgg.MainLocation", b =>
                {
                    b.Navigation("Provinces");
                });

            modelBuilder.Entity("Domain.Entities.LocationsAgg.Part", b =>
                {
                    b.Navigation("CityOrVilages");
                });

            modelBuilder.Entity("Domain.Entities.LocationsAgg.Province", b =>
                {
                    b.Navigation("Counties");
                });
#pragma warning restore 612, 618
        }
    }
}
