﻿// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using board_service.DBContexts;

#nullable disable

namespace board_service.Migrations
{
    [DbContext(typeof(MyDbContext))]
    [Migration("20220508095230_test")]
    partial class test
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.3")
                .HasAnnotation("Relational:MaxIdentifierLength", 64);

            modelBuilder.Entity("board_service.Models.Board", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("board_id");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.HasKey("Id")
                        .HasName("pk_board");

                    b.HasIndex("Id")
                        .IsUnique()
                        .HasDatabaseName("idx_board_id");

                    b.ToTable("board", (string)null);
                });
#pragma warning restore 612, 618
        }
    }
}