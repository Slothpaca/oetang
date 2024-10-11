﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Oetang.API.Database;

#nullable disable

namespace Oetang.API.Database.Migrations
{
    [DbContext(typeof(OetangDbContext))]
    [Migration("20241008084956_RemoveAllTimesheetActionTypeClutter")]
    partial class RemoveAllTimesheetActionTypeClutter
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.8")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("ConsultantProject", b =>
                {
                    b.Property<long>("ConsultantsId")
                        .HasColumnType("bigint");

                    b.Property<long>("ProjectId")
                        .HasColumnType("bigint");

                    b.HasKey("ConsultantsId", "ProjectId");

                    b.HasIndex("ProjectId");

                    b.ToTable("ConsultantProject");
                });

            modelBuilder.Entity("Oetang.API.Domain.Consultant", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<long>("Id"));

                    b.Property<long>("DepartmentId")
                        .HasColumnType("bigint");

                    b.Property<string>("Function")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<int>("Status")
                        .HasColumnType("int");

                    b.Property<long>("UserId")
                        .HasColumnType("bigint");

                    b.HasKey("Id");

                    b.HasIndex("DepartmentId");

                    b.HasIndex("UserId");

                    b.ToTable("Consultants");
                });

            modelBuilder.Entity("Oetang.API.Domain.Customer", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<long>("Id"));

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.HasKey("Id");

                    b.HasIndex("Name")
                        .IsUnique();

                    b.ToTable("Customers");
                });

            modelBuilder.Entity("Oetang.API.Domain.Department", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<long>("Id"));

                    b.Property<long>("ManagerId")
                        .HasColumnType("bigint");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.HasKey("Id");

                    b.HasIndex("ManagerId");

                    b.ToTable("Departments");
                });

            modelBuilder.Entity("Oetang.API.Domain.Project", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<long>("Id"));

                    b.Property<long?>("CustomerId")
                        .HasColumnType("bigint");

                    b.Property<DateOnly?>("End")
                        .HasColumnType("date");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<DateOnly>("Start")
                        .HasColumnType("date");

                    b.HasKey("Id");

                    b.HasIndex("CustomerId");

                    b.ToTable("Projects");
                });

            modelBuilder.Entity("Oetang.API.Domain.TimeEntry", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<long>("Id"));

                    b.Property<string>("Comment")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<DateOnly>("Date")
                        .HasColumnType("date");

                    b.Property<long>("ProjectId")
                        .HasColumnType("bigint");

                    b.Property<TimeSpan>("TimeSpan")
                        .HasColumnType("time");

                    b.Property<long?>("TimesheetId")
                        .HasColumnType("bigint");

                    b.HasKey("Id");

                    b.HasIndex("ProjectId");

                    b.HasIndex("TimesheetId");

                    b.ToTable("TimeEntry");
                });

            modelBuilder.Entity("Oetang.API.Domain.Timesheet", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<long>("Id"));

                    b.Property<long>("ConsultantId")
                        .HasColumnType("bigint");

                    b.Property<DateOnly>("End")
                        .HasColumnType("date");

                    b.Property<DateOnly>("Start")
                        .HasColumnType("date");

                    b.Property<int>("Status")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("ConsultantId");

                    b.ToTable("Timesheets");
                });

            modelBuilder.Entity("Oetang.API.Domain.TimesheetAction", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<long>("Id"));

                    b.Property<string>("Comment")
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<long?>("TimesheetId")
                        .HasColumnType("bigint");

                    b.Property<DateTime>("Timestamp")
                        .HasColumnType("datetime2");

                    b.Property<int>("Type")
                        .HasColumnType("int");

                    b.Property<long>("UserId")
                        .HasColumnType("bigint");

                    b.HasKey("Id");

                    b.HasIndex("TimesheetId");

                    b.HasIndex("UserId");

                    b.ToTable("TimesheetAction");
                });

            modelBuilder.Entity("Oetang.API.Domain.User", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<long>("Id"));

                    b.Property<string>("EmailAddress")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<string>("Roles")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Surname")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.HasKey("Id");

                    b.ToTable("User");
                });

            modelBuilder.Entity("ConsultantProject", b =>
                {
                    b.HasOne("Oetang.API.Domain.Consultant", null)
                        .WithMany()
                        .HasForeignKey("ConsultantsId")
                        .IsRequired();

                    b.HasOne("Oetang.API.Domain.Project", null)
                        .WithMany()
                        .HasForeignKey("ProjectId")
                        .IsRequired();
                });

            modelBuilder.Entity("Oetang.API.Domain.Consultant", b =>
                {
                    b.HasOne("Oetang.API.Domain.Department", "Department")
                        .WithMany()
                        .HasForeignKey("DepartmentId")
                        .IsRequired();

                    b.HasOne("Oetang.API.Domain.User", "User")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .IsRequired();

                    b.Navigation("Department");

                    b.Navigation("User");
                });

            modelBuilder.Entity("Oetang.API.Domain.Department", b =>
                {
                    b.HasOne("Oetang.API.Domain.User", "Manager")
                        .WithMany()
                        .HasForeignKey("ManagerId")
                        .IsRequired();

                    b.Navigation("Manager");
                });

            modelBuilder.Entity("Oetang.API.Domain.Project", b =>
                {
                    b.HasOne("Oetang.API.Domain.Customer", "Customer")
                        .WithMany()
                        .HasForeignKey("CustomerId");

                    b.Navigation("Customer");
                });

            modelBuilder.Entity("Oetang.API.Domain.TimeEntry", b =>
                {
                    b.HasOne("Oetang.API.Domain.Project", "Project")
                        .WithMany()
                        .HasForeignKey("ProjectId")
                        .IsRequired();

                    b.HasOne("Oetang.API.Domain.Timesheet", null)
                        .WithMany("Entries")
                        .HasForeignKey("TimesheetId");

                    b.Navigation("Project");
                });

            modelBuilder.Entity("Oetang.API.Domain.Timesheet", b =>
                {
                    b.HasOne("Oetang.API.Domain.Consultant", "Consultant")
                        .WithMany()
                        .HasForeignKey("ConsultantId")
                        .IsRequired();

                    b.Navigation("Consultant");
                });

            modelBuilder.Entity("Oetang.API.Domain.TimesheetAction", b =>
                {
                    b.HasOne("Oetang.API.Domain.Timesheet", null)
                        .WithMany("Actions")
                        .HasForeignKey("TimesheetId");

                    b.HasOne("Oetang.API.Domain.User", "User")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .IsRequired();

                    b.Navigation("User");
                });

            modelBuilder.Entity("Oetang.API.Domain.Timesheet", b =>
                {
                    b.Navigation("Actions");

                    b.Navigation("Entries");
                });
#pragma warning restore 612, 618
        }
    }
}
