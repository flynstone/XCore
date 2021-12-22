﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using XCore.Entities;

namespace XCore.Api.Migrations
{
    [DbContext(typeof(XCoreDbContext))]
    partial class XCoreDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.13")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("XCore.Entities.Models.Overtime.Backup", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<bool>("IsSelected")
                        .HasColumnType("bit");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.HasKey("Id");

                    b.ToTable("Backups");
                });

            modelBuilder.Entity("XCore.Entities.Models.Overtime.Crew", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(5)
                        .HasColumnType("nvarchar(5)");

                    b.HasKey("Id");

                    b.ToTable("Crews");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Name = "A"
                        },
                        new
                        {
                            Id = 2,
                            Name = "B"
                        },
                        new
                        {
                            Id = 3,
                            Name = "C"
                        },
                        new
                        {
                            Id = 4,
                            Name = "D"
                        },
                        new
                        {
                            Id = 5,
                            Name = "Days"
                        });
                });

            modelBuilder.Entity("XCore.Entities.Models.Overtime.Employee", b =>
                {
                    b.Property<int>("EmployeeId")
                        .HasColumnType("int");

                    b.Property<string>("CellPhone")
                        .HasMaxLength(20)
                        .HasColumnType("nvarchar(20)");

                    b.Property<int>("CrewId")
                        .HasColumnType("int");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("HomePhone")
                        .HasMaxLength(20)
                        .HasColumnType("nvarchar(20)");

                    b.Property<int>("JobTitleId")
                        .HasColumnType("int");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<int>("RuleTypeId")
                        .HasColumnType("int");

                    b.HasKey("EmployeeId");

                    b.HasIndex("CrewId");

                    b.HasIndex("JobTitleId");

                    b.HasIndex("RuleTypeId");

                    b.ToTable("Employees");
                });

            modelBuilder.Entity("XCore.Entities.Models.Overtime.EmployeeBackup", b =>
                {
                    b.Property<int>("EmployeeId")
                        .HasColumnType("int");

                    b.Property<int>("BackupId")
                        .HasColumnType("int");

                    b.HasKey("EmployeeId", "BackupId");

                    b.HasIndex("BackupId");

                    b.ToTable("EmployeeBackups");
                });

            modelBuilder.Entity("XCore.Entities.Models.Overtime.JobTitle", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.HasKey("Id");

                    b.ToTable("JobTitles");
                });

            modelBuilder.Entity("XCore.Entities.Models.Overtime.RuleType", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.HasKey("Id");

                    b.ToTable("RuleTypes");
                });

            modelBuilder.Entity("XCore.Entities.Models.Overtime.WeeklyOvertime", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Crew")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("EmployeeId")
                        .HasColumnType("int");

                    b.Property<string>("JobTitle")
                        .HasColumnType("nvarchar(max)");

                    b.Property<decimal>("RefusedOvertime")
                        .HasColumnType("decimal(5,2)");

                    b.Property<string>("RuleType")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("WeekEnding")
                        .HasColumnType("datetime2");

                    b.Property<decimal>("WorkedOvertime")
                        .HasColumnType("decimal(5,2)");

                    b.HasKey("Id");

                    b.ToTable("WeeklyOvertimes");
                });

            modelBuilder.Entity("XCore.Entities.Models.Rentals.Category", b =>
                {
                    b.Property<int>("CategoryId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Description")
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.HasKey("CategoryId");

                    b.ToTable("Categories");
                });

            modelBuilder.Entity("XCore.Entities.Models.Rentals.Customer", b =>
                {
                    b.Property<int>("CustomerId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Address")
                        .HasMaxLength(125)
                        .HasColumnType("nvarchar(125)");

                    b.Property<string>("FirstName")
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<string>("LastName")
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.HasKey("CustomerId");

                    b.ToTable("Customers");
                });

            modelBuilder.Entity("XCore.Entities.Models.Rentals.Media", b =>
                {
                    b.Property<int>("MediaId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("CategoryId")
                        .HasColumnType("int");

                    b.Property<string>("ItemTitle")
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.HasKey("MediaId");

                    b.HasIndex("CategoryId");

                    b.ToTable("Medias");
                });

            modelBuilder.Entity("XCore.Entities.Models.Rentals.Rental", b =>
                {
                    b.Property<int>("RentalId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("CustomerId")
                        .HasColumnType("int");

                    b.Property<DateTime>("DateOfRental")
                        .HasColumnType("Date");

                    b.Property<DateTime>("DueDate")
                        .HasColumnType("Date");

                    b.Property<bool>("IsReturned")
                        .HasColumnType("bit");

                    b.Property<int>("MediaId")
                        .HasColumnType("int");

                    b.HasKey("RentalId");

                    b.HasIndex("CustomerId");

                    b.HasIndex("MediaId");

                    b.ToTable("Rentals");
                });

            modelBuilder.Entity("XCore.Entities.Models.Overtime.Employee", b =>
                {
                    b.HasOne("XCore.Entities.Models.Overtime.Crew", "Crew")
                        .WithMany()
                        .HasForeignKey("CrewId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("XCore.Entities.Models.Overtime.JobTitle", "JobTitle")
                        .WithMany()
                        .HasForeignKey("JobTitleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("XCore.Entities.Models.Overtime.RuleType", "RuleType")
                        .WithMany()
                        .HasForeignKey("RuleTypeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Crew");

                    b.Navigation("JobTitle");

                    b.Navigation("RuleType");
                });

            modelBuilder.Entity("XCore.Entities.Models.Overtime.EmployeeBackup", b =>
                {
                    b.HasOne("XCore.Entities.Models.Overtime.Backup", "Backup")
                        .WithMany("EmployeeBackups")
                        .HasForeignKey("BackupId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("XCore.Entities.Models.Overtime.Employee", "Employee")
                        .WithMany("EmployeeBackups")
                        .HasForeignKey("EmployeeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Backup");

                    b.Navigation("Employee");
                });

            modelBuilder.Entity("XCore.Entities.Models.Rentals.Media", b =>
                {
                    b.HasOne("XCore.Entities.Models.Rentals.Category", "ItemCategory")
                        .WithMany()
                        .HasForeignKey("CategoryId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("ItemCategory");
                });

            modelBuilder.Entity("XCore.Entities.Models.Rentals.Rental", b =>
                {
                    b.HasOne("XCore.Entities.Models.Rentals.Customer", "Customer")
                        .WithMany()
                        .HasForeignKey("CustomerId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("XCore.Entities.Models.Rentals.Media", "Media")
                        .WithMany()
                        .HasForeignKey("MediaId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Customer");

                    b.Navigation("Media");
                });

            modelBuilder.Entity("XCore.Entities.Models.Overtime.Backup", b =>
                {
                    b.Navigation("EmployeeBackups");
                });

            modelBuilder.Entity("XCore.Entities.Models.Overtime.Employee", b =>
                {
                    b.Navigation("EmployeeBackups");
                });
#pragma warning restore 612, 618
        }
    }
}
