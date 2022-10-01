﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Termo.Data;

#nullable disable

namespace Termo.Data.Migrations
{
    [DbContext(typeof(TermoDbContext))]
    [Migration("20221001204108_Initial")]
    partial class Initial
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder.HasAnnotation("ProductVersion", "6.0.9");

            modelBuilder.Entity("Termo.Data.Models.ChairLampTest", b =>
                {
                    b.Property<string>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("TEXT");

                    b.Property<DateTime>("CreatedTime")
                        .HasColumnType("TEXT");

                    b.Property<DateTime>("EndTime")
                        .HasColumnType("TEXT");

                    b.Property<DateTime>("StartTime")
                        .HasColumnType("TEXT");

                    b.Property<string>("TestId")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.HasIndex("TestId");

                    b.ToTable("ChairLampTests");
                });

            modelBuilder.Entity("Termo.Data.Models.ChairLampTestPart", b =>
                {
                    b.Property<string>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("TEXT");

                    b.Property<string>("ChairLampTestId")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<int>("CorrectlyIgnored")
                        .HasColumnType("INTEGER");

                    b.Property<int>("CorrectlyMarked")
                        .HasColumnType("INTEGER");

                    b.Property<DateTime>("CreatedTime")
                        .HasColumnType("TEXT");

                    b.Property<int>("IncorrectlyIgnored")
                        .HasColumnType("INTEGER");

                    b.Property<int>("IncorrectlyMarked")
                        .HasColumnType("INTEGER");

                    b.Property<int>("PicturesRevised")
                        .HasColumnType("INTEGER");

                    b.HasKey("Id");

                    b.HasIndex("ChairLampTestId");

                    b.ToTable("ChairLampTestParts");
                });

            modelBuilder.Entity("Termo.Data.Models.Test", b =>
                {
                    b.Property<string>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("TEXT");

                    b.Property<DateTime>("CreatedTime")
                        .HasColumnType("TEXT");

                    b.Property<string>("Link")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("Tests");
                });

            modelBuilder.Entity("Termo.Data.Models.ToulousePieronTest", b =>
                {
                    b.Property<string>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("TEXT");

                    b.Property<int>("ColumnCount")
                        .HasColumnType("INTEGER");

                    b.Property<int>("CorrectlyIgnored")
                        .HasColumnType("INTEGER");

                    b.Property<int>("CorrectlyMarked")
                        .HasColumnType("INTEGER");

                    b.Property<DateTime>("CreatedTime")
                        .HasColumnType("TEXT");

                    b.Property<DateTime>("EndTime")
                        .HasColumnType("TEXT");

                    b.Property<int>("IncorrectlyIgnored")
                        .HasColumnType("INTEGER");

                    b.Property<int>("IncorrectlyMarked")
                        .HasColumnType("INTEGER");

                    b.Property<int>("RowCount")
                        .HasColumnType("INTEGER");

                    b.Property<DateTime>("StartTime")
                        .HasColumnType("TEXT");

                    b.Property<string>("TestId")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.HasIndex("TestId");

                    b.ToTable("ToulousePieronTests");
                });

            modelBuilder.Entity("Termo.Data.Models.User", b =>
                {
                    b.Property<string>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("TEXT");

                    b.Property<DateTime>("CreatedTime")
                        .HasColumnType("TEXT");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.ToTable("Users");
                });

            modelBuilder.Entity("Termo.Data.Models.ChairLampTest", b =>
                {
                    b.HasOne("Termo.Data.Models.Test", "Test")
                        .WithMany()
                        .HasForeignKey("TestId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Test");
                });

            modelBuilder.Entity("Termo.Data.Models.ChairLampTestPart", b =>
                {
                    b.HasOne("Termo.Data.Models.ChairLampTest", "ChairLampTest")
                        .WithMany("ChairLampTestParts")
                        .HasForeignKey("ChairLampTestId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("ChairLampTest");
                });

            modelBuilder.Entity("Termo.Data.Models.Test", b =>
                {
                    b.HasOne("Termo.Data.Models.User", "User")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("User");
                });

            modelBuilder.Entity("Termo.Data.Models.ToulousePieronTest", b =>
                {
                    b.HasOne("Termo.Data.Models.Test", "Test")
                        .WithMany()
                        .HasForeignKey("TestId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Test");
                });

            modelBuilder.Entity("Termo.Data.Models.ChairLampTest", b =>
                {
                    b.Navigation("ChairLampTestParts");
                });
#pragma warning restore 612, 618
        }
    }
}
