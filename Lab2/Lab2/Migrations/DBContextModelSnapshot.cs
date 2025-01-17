﻿// <auto-generated />
using System;
using Lab2.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace Lab2.Migrations
{
    [DbContext(typeof(DBContext))]
    partial class DBContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "9.0.0")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("Lab2.Models.Device", b =>
                {
                    b.Property<int>("DeviceId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("DeviceId"));

                    b.Property<int>("CategoryId")
                        .HasColumnType("int");

                    b.Property<DateTime>("DateOfEntry")
                        .HasColumnType("datetime2");

                    b.Property<string>("DeviceCode")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<string>("DeviceName")
                        .IsRequired()
                        .HasMaxLength(200)
                        .HasColumnType("nvarchar(200)");

                    b.Property<int>("StatusId")
                        .HasColumnType("int");

                    b.HasKey("DeviceId");

                    b.HasIndex("CategoryId");

                    b.HasIndex("DeviceCode")
                        .IsUnique();

                    b.HasIndex("StatusId");

                    b.ToTable("Devices");
                });

            modelBuilder.Entity("Lab2.Models.DeviceAssignment", b =>
                {
                    b.Property<int>("AssignmentId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("AssignmentId"));

                    b.Property<DateTime>("AssignmentDate")
                        .HasColumnType("datetime2");

                    b.Property<int>("DeviceId")
                        .HasColumnType("int");

                    b.Property<DateTime?>("ReturnDate")
                        .HasColumnType("datetime2");

                    b.Property<int>("UserId")
                        .HasColumnType("int");

                    b.HasKey("AssignmentId");

                    b.HasIndex("DeviceId");

                    b.HasIndex("UserId");

                    b.ToTable("DeviceAssignments");
                });

            modelBuilder.Entity("Lab2.Models.DeviceCategory", b =>
                {
                    b.Property<int>("CategoryId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("CategoryId"));

                    b.Property<string>("CategoryName")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.HasKey("CategoryId");

                    b.HasIndex("CategoryName")
                        .IsUnique();

                    b.ToTable("DeviceCategories");
                });

            modelBuilder.Entity("Lab2.Models.DeviceStatus", b =>
                {
                    b.Property<int>("StatusId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("StatusId"));

                    b.Property<string>("StatusName")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.HasKey("StatusId");

                    b.ToTable("DeviceStatuses");

                    b.HasData(
                        new
                        {
                            StatusId = 1,
                            StatusName = "In use"
                        },
                        new
                        {
                            StatusId = 2,
                            StatusName = "Broken"
                        },
                        new
                        {
                            StatusId = 3,
                            StatusName = "Under maintenance"
                        });
                });

            modelBuilder.Entity("Lab2.Models.User", b =>
                {
                    b.Property<int>("UserId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("UserId"));

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasMaxLength(200)
                        .HasColumnType("nvarchar(200)");

                    b.Property<string>("FullName")
                        .IsRequired()
                        .HasMaxLength(200)
                        .HasColumnType("nvarchar(200)");

                    b.Property<string>("PhoneNumber")
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.HasKey("UserId");

                    b.HasIndex("Email")
                        .IsUnique();

                    b.ToTable("Users");
                });

            modelBuilder.Entity("Lab2.Models.Device", b =>
                {
                    b.HasOne("Lab2.Models.DeviceCategory", "Category")
                        .WithMany("Devices")
                        .HasForeignKey("CategoryId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Lab2.Models.DeviceStatus", "Status")
                        .WithMany("Devices")
                        .HasForeignKey("StatusId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Category");

                    b.Navigation("Status");
                });

            modelBuilder.Entity("Lab2.Models.DeviceAssignment", b =>
                {
                    b.HasOne("Lab2.Models.Device", "Device")
                        .WithMany("DeviceAssignments")
                        .HasForeignKey("DeviceId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Lab2.Models.User", "User")
                        .WithMany("DeviceAssignments")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Device");

                    b.Navigation("User");
                });

            modelBuilder.Entity("Lab2.Models.Device", b =>
                {
                    b.Navigation("DeviceAssignments");
                });

            modelBuilder.Entity("Lab2.Models.DeviceCategory", b =>
                {
                    b.Navigation("Devices");
                });

            modelBuilder.Entity("Lab2.Models.DeviceStatus", b =>
                {
                    b.Navigation("Devices");
                });

            modelBuilder.Entity("Lab2.Models.User", b =>
                {
                    b.Navigation("DeviceAssignments");
                });
#pragma warning restore 612, 618
        }
    }
}
