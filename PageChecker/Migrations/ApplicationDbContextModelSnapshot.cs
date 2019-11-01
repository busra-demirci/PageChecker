﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using PageCheckerAPI.DataAccess;

namespace PageCheckerAPI.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    partial class ApplicationDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.2.0-rtm-35687")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("PageCheckerAPI.Models.Difference", b =>
                {
                    b.Property<Guid>("DifferenceId")
                        .ValueGeneratedOnAdd();

                    b.Property<DateTime>("Date");

                    b.Property<Guid>("PageId");

                    b.Property<string>("Text")
                        .IsRequired()
                        .HasColumnType("ntext");

                    b.HasKey("DifferenceId");

                    b.HasIndex("PageId");

                    b.ToTable("Differences");
                });

            modelBuilder.Entity("PageCheckerAPI.Models.Page", b =>
                {
                    b.Property<Guid>("PageId")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("CheckingType");

                    b.Property<string>("ElementXPath");

                    b.Property<bool>("HasChanged");

                    b.Property<string>("Name");

                    b.Property<Guid>("PrimaryTextId");

                    b.Property<int>("RefreshRate");

                    b.Property<bool>("Stopped");

                    b.Property<string>("Url")
                        .IsRequired();

                    b.Property<Guid>("UserId");

                    b.HasKey("PageId");

                    b.HasIndex("PrimaryTextId");

                    b.HasIndex("UserId");

                    b.ToTable("Pages");
                });

            modelBuilder.Entity("PageCheckerAPI.Models.User", b =>
                {
                    b.Property<Guid>("UserId")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Email")
                        .IsRequired();

                    b.Property<byte[]>("PasswordHash");

                    b.Property<byte[]>("PasswordSalt");

                    b.Property<string>("UserName")
                        .IsRequired();

                    b.Property<bool>("Verified");

                    b.HasKey("UserId");

                    b.ToTable("Users");
                });

            modelBuilder.Entity("PageCheckerAPI.Models.WebsiteText", b =>
                {
                    b.Property<Guid>("WebsiteTextId")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Text")
                        .IsRequired()
                        .HasColumnType("ntext");

                    b.HasKey("WebsiteTextId");

                    b.ToTable("WebsiteTexts");
                });

            modelBuilder.Entity("PageCheckerAPI.Models.Difference", b =>
                {
                    b.HasOne("PageCheckerAPI.Models.Page", "Page")
                        .WithMany()
                        .HasForeignKey("PageId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("PageCheckerAPI.Models.Page", b =>
                {
                    b.HasOne("PageCheckerAPI.Models.WebsiteText", "PrimaryText")
                        .WithMany()
                        .HasForeignKey("PrimaryTextId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("PageCheckerAPI.Models.User", "User")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });
#pragma warning restore 612, 618
        }
    }
}
