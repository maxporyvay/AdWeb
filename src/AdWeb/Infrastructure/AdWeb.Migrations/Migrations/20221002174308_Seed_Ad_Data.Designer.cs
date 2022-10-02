﻿// <auto-generated />
using System;
using AdWeb.Migrations;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace AdWeb.Migrations.Migrations
{
    [DbContext(typeof(MigrationsDbContext))]
    [Migration("20221002174308_Seed_Ad_Data")]
    partial class Seed_Ad_Data
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.9")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            NpgsqlModelBuilderExtensions.UseIdentityByDefaultColumns(modelBuilder);

            modelBuilder.Entity("AdWeb.Domain.Ad", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<string>("AdDescription")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("AdTitle")
                        .IsRequired()
                        .HasMaxLength(800)
                        .HasColumnType("character varying(800)");

                    b.Property<DateTime>("PublishTime")
                        .HasColumnType("timestamp with time zone");

                    b.HasKey("Id");

                    b.ToTable("Ads", (string)null);
                });

            modelBuilder.Entity("AdWeb.Domain.AdBoard", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<Guid>("AdId")
                        .HasColumnType("uuid");

                    b.HasKey("Id");

                    b.HasIndex("AdId");

                    b.ToTable("AdBoards", (string)null);
                });

            modelBuilder.Entity("AdWeb.Domain.AdBoard", b =>
                {
                    b.HasOne("AdWeb.Domain.Ad", "Ad")
                        .WithMany("AdBoards")
                        .HasForeignKey("AdId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Ad");
                });

            modelBuilder.Entity("AdWeb.Domain.Ad", b =>
                {
                    b.Navigation("AdBoards");
                });
#pragma warning restore 612, 618
        }
    }
}