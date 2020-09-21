﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using totvs_test;

namespace totvs_test.Migrations
{
    [DbContext(typeof(TotvsDbContext))]
    [Migration("20200921150131_AddSeedDataToUser")]
    partial class AddSeedDataToUser
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.8");

            modelBuilder.Entity("totvs_test.Auction", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("TEXT");

                    b.Property<DateTime?>("ClosingDate")
                        .HasColumnType("TEXT");

                    b.Property<decimal>("InitialValue")
                        .HasColumnType("TEXT");

                    b.Property<bool>("IsUsed")
                        .HasColumnType("INTEGER");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<DateTime>("OpeningDate")
                        .HasColumnType("TEXT");

                    b.Property<Guid>("ResponsibleId")
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.HasIndex("ResponsibleId");

                    b.ToTable("Auctions");
                });

            modelBuilder.Entity("totvs_test.User", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("TEXT");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<bool>("Enabled")
                        .HasColumnType("INTEGER");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.ToTable("Users");

                    b.HasData(
                        new
                        {
                            Id = new Guid("97abbeca-c716-4eb0-b1da-d0e7287118b3"),
                            Email = "guilherme.neubaner@gmail.com",
                            Enabled = true,
                            Name = "Guilherme Neubaner",
                            Password = "$2a$11$IM6.AUVo9GujnYP8uV10F.VaDujBzBkCkO9JIINZ.9uMU7DIOguzK"
                        });
                });

            modelBuilder.Entity("totvs_test.Auction", b =>
                {
                    b.HasOne("totvs_test.User", "Responsible")
                        .WithMany()
                        .HasForeignKey("ResponsibleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}