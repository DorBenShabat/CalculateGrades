﻿// <auto-generated />
using CalculateGrades.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace CalculateGrades.Migrations
{
    [DbContext(typeof(ApplicationDB))]
    [Migration("20230416185510_AddToDB")]
    partial class AddToDB
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.13")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("CalculateGrades.Models.Courses", b =>
                {
                    b.Property<int>("CourseNum")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("CourseNum"), 1L, 1);

                    b.Property<string>("CourseName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("YearNum")
                        .HasColumnType("int");

                    b.HasKey("CourseNum");

                    b.HasIndex("YearNum");

                    b.ToTable("courses");
                });

            modelBuilder.Entity("CalculateGrades.Models.Years", b =>
                {
                    b.Property<int>("YearNum")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("YearNum"), 1L, 1);

                    b.Property<string>("Year")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("YearNum");

                    b.ToTable("years");
                });

            modelBuilder.Entity("CalculateGrades.Models.Courses", b =>
                {
                    b.HasOne("CalculateGrades.Models.Years", "Year")
                        .WithMany()
                        .HasForeignKey("YearNum")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Year");
                });
#pragma warning restore 612, 618
        }
    }
}
