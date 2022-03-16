﻿// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using ReversiRestApi.Data;

#nullable disable

namespace ReversiRestApi.Migrations
{
    [DbContext(typeof(ReversiContext))]
    [Migration("20220315180714_initialcreate")]
    partial class initialcreate
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.3")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("ReversiRestApi.Data.Bord", b =>
                {
                    b.Property<string>("Token")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("BespeeldBord")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("SpelToken")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("Token");

                    b.HasIndex("SpelToken");

                    b.ToTable("Bord");
                });

            modelBuilder.Entity("ReversiRestApi.Data.Spel", b =>
                {
                    b.Property<string>("Token")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Aandebeurd")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("NavigationProperty1Token")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("NavigationProperty2Token")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Omschrijving")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Speler1")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Speler2")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Token");

                    b.HasIndex("NavigationProperty1Token");

                    b.HasIndex("NavigationProperty2Token");

                    b.ToTable("Spellen");
                });

            modelBuilder.Entity("ReversiRestApi.Data.Speler", b =>
                {
                    b.Property<string>("Token")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Token");

                    b.ToTable("Spelers");
                });

            modelBuilder.Entity("ReversiRestApi.Data.Bord", b =>
                {
                    b.HasOne("ReversiRestApi.Data.Spel", "Spel")
                        .WithMany()
                        .HasForeignKey("SpelToken")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Spel");
                });

            modelBuilder.Entity("ReversiRestApi.Data.Spel", b =>
                {
                    b.HasOne("ReversiRestApi.Data.Speler", "NavigationProperty1")
                        .WithMany()
                        .HasForeignKey("NavigationProperty1Token");

                    b.HasOne("ReversiRestApi.Data.Speler", "NavigationProperty2")
                        .WithMany()
                        .HasForeignKey("NavigationProperty2Token");

                    b.Navigation("NavigationProperty1");

                    b.Navigation("NavigationProperty2");
                });
#pragma warning restore 612, 618
        }
    }
}
