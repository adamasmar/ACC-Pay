﻿// <auto-generated />
using System;
using ACC_Pay.Server.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace ACC_Pay.Server.Migrations
{
    [DbContext(typeof(AccPayDbContext))]
    [Migration("20220821204650_Initial")]
    partial class Initial
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.8")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("ACC_Pay.Blazor.Models.Employee", b =>
                {
                    b.Property<Guid>("EmployeeId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("DateOfBirth")
                        .HasColumnType("date");

                    b.Property<string>("FirstName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("LastName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("MiddleName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("SocialSecurity")
                        .HasColumnType("int");

                    b.Property<DateTime>("StartDate")
                        .HasColumnType("date");

                    b.HasKey("EmployeeId");

                    b.ToTable("Employee");
                });

            modelBuilder.Entity("ACC_Pay.Blazor.Models.EmployeeContactInformation", b =>
                {
                    b.Property<Guid>("EmployeeContactInformationId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("City")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("DateTimeAdded")
                        .HasColumnType("datetime2");

                    b.Property<Guid>("EmployeeId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<bool>("IsCurrent")
                        .HasColumnType("bit");

                    b.Property<int?>("PrimaryPhoneNumber")
                        .HasColumnType("int");

                    b.Property<int?>("SecondaryPhoneNumber")
                        .HasColumnType("int");

                    b.Property<string>("State")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("StreetAddress")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ZipCode")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("EmployeeContactInformationId");

                    b.HasIndex("EmployeeId");

                    b.ToTable("EmployeeContactInformation");
                });

            modelBuilder.Entity("ACC_Pay.Blazor.Models.EmployeeW4Configuration", b =>
                {
                    b.Property<Guid>("EmployeeW4ConfigurationId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("DateSigned")
                        .HasColumnType("date");

                    b.Property<Guid>("EmployeeContactInformationId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<bool>("Value2c")
                        .HasColumnType("bit");

                    b.Property<decimal>("Value3")
                        .HasPrecision(18, 2)
                        .HasColumnType("decimal(18,2)");

                    b.Property<decimal>("Value4a")
                        .HasPrecision(18, 2)
                        .HasColumnType("decimal(18,2)");

                    b.Property<decimal>("Value4b")
                        .HasPrecision(18, 2)
                        .HasColumnType("decimal(18,2)");

                    b.Property<decimal>("Value4c")
                        .HasPrecision(18, 2)
                        .HasColumnType("decimal(18,2)");

                    b.Property<Guid>("W4YearsId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("EmployeeW4ConfigurationId");

                    b.HasIndex("EmployeeContactInformationId");

                    b.HasIndex("W4YearsId");

                    b.ToTable("EmployeeW4Configuration");
                });

            modelBuilder.Entity("ACC_Pay.Blazor.Models.W4Years", b =>
                {
                    b.Property<Guid>("W4YearsId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<int>("Year")
                        .HasColumnType("int");

                    b.HasKey("W4YearsId");

                    b.ToTable("W4Years");
                });

            modelBuilder.Entity("ACC_Pay.Blazor.Models.EmployeeContactInformation", b =>
                {
                    b.HasOne("ACC_Pay.Blazor.Models.Employee", "Employee")
                        .WithMany("ContactInformation")
                        .HasForeignKey("EmployeeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Employee");
                });

            modelBuilder.Entity("ACC_Pay.Blazor.Models.EmployeeW4Configuration", b =>
                {
                    b.HasOne("ACC_Pay.Blazor.Models.EmployeeContactInformation", "EmployeeContactInformation")
                        .WithMany()
                        .HasForeignKey("EmployeeContactInformationId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("ACC_Pay.Blazor.Models.W4Years", "W4year")
                        .WithMany()
                        .HasForeignKey("W4YearsId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("EmployeeContactInformation");

                    b.Navigation("W4year");
                });

            modelBuilder.Entity("ACC_Pay.Blazor.Models.Employee", b =>
                {
                    b.Navigation("ContactInformation");
                });
#pragma warning restore 612, 618
        }
    }
}