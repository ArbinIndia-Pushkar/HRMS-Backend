﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;
using hrms.Data;

#nullable disable

namespace hrms.Migrations
{
    [DbContext(typeof(hrmsDbContext))]
    [Migration("20240910081130_AddedAttendaceTable2")]
    partial class AddedAttendaceTable2
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.18")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            NpgsqlModelBuilderExtensions.UseIdentityByDefaultColumns(modelBuilder);

            modelBuilder.Entity("hrms.Models.Employees", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("text");

                    b.Property<string>("AttendanceRecords")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<DateOnly>("JoiningDate")
                        .HasColumnType("date");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Phone")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Username")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<int>("compOffs")
                        .HasColumnType("integer");

                    b.Property<int>("halfDays")
                        .HasColumnType("integer");

                    b.Property<int>("personalLeaves")
                        .HasColumnType("integer");

                    b.Property<int>("sickLeaves")
                        .HasColumnType("integer");

                    b.HasKey("Id");

                    b.ToTable("Employees");
                });
#pragma warning restore 612, 618
        }
    }
}
