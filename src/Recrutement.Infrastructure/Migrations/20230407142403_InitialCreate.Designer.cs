﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Recrutement.Infrastructure.Repositories;

#nullable disable

namespace Recrutement.Infrastructure.Migrations
{
    [DbContext(typeof(DataContext))]
    [Migration("20230407142403_InitialCreate")]
    partial class InitialCreate
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.4")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("Recrutement.Infrastructure.Repositories.Entities.Appareil", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTimeOffset?>("DateDepose")
                        .HasColumnType("datetimeoffset");

                    b.Property<DateTimeOffset>("DatePose")
                        .HasColumnType("datetimeoffset");

                    b.Property<string>("NumeroSerie")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("Type")
                        .IsRequired()
                        .HasMaxLength(20)
                        .HasColumnType("nvarchar(20)");

                    b.HasKey("Id");

                    b.ToTable("Appareils");
                });

            modelBuilder.Entity("Recrutement.Infrastructure.Repositories.Entities.Releve", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<long>("Id"));

                    b.Property<Guid>("AppareilId")
                        .HasMaxLength(50)
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("DateMesure")
                        .HasColumnType("datetime2");

                    b.Property<string>("Type")
                        .IsRequired()
                        .HasMaxLength(10)
                        .HasColumnType("nvarchar(10)");

                    b.Property<decimal>("Valeur")
                        .HasPrecision(18, 6)
                        .HasColumnType("decimal(18,6)");

                    b.HasKey("Id");

                    b.HasIndex("AppareilId");

                    b.ToTable("Releves");
                });

            modelBuilder.Entity("Recrutement.Infrastructure.Repositories.Entities.Releve", b =>
                {
                    b.HasOne("Recrutement.Infrastructure.Repositories.Entities.Appareil", "Appareil")
                        .WithMany("Releves")
                        .HasForeignKey("AppareilId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Appareil");
                });

            modelBuilder.Entity("Recrutement.Infrastructure.Repositories.Entities.Appareil", b =>
                {
                    b.Navigation("Releves");
                });
#pragma warning restore 612, 618
        }
    }
}
