﻿// <auto-generated />
using System;
using ArgusEyesApi.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace ArgusEyesApi.Migrations
{
    [DbContext(typeof(KundenDBContext))]
    partial class KundenDBContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.6")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("ArgusEyesApi.Entities.KundenDaten", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<int?>("Alter")
                        .HasColumnType("int");

                    b.Property<DateTime?>("Geburtsdatum")
                        .HasColumnType("datetime2");

                    b.Property<int?>("Hausnummer")
                        .HasColumnType("int");

                    b.Property<string>("Nachname")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("Plz")
                        .HasColumnType("int");

                    b.Property<string>("Strasse")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Vorname")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("KundenDaten");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Alter = 25,
                            Geburtsdatum = new DateTime(1994, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Hausnummer = 15,
                            Nachname = "Tamr",
                            Plz = 12331,
                            Strasse = "hamburgerstr",
                            Vorname = "Omar"
                        },
                        new
                        {
                            Id = 2,
                            Alter = 25,
                            Geburtsdatum = new DateTime(1994, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Hausnummer = 15,
                            Nachname = "HH",
                            Plz = 12331,
                            Strasse = "hamburgerstr",
                            Vorname = "Rudi"
                        });
                });

            modelBuilder.Entity("ArgusEyesApi.Entities.KundenImagesDaten", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<byte[]>("Content")
                        .IsRequired()
                        .HasColumnType("varbinary(max)");

                    b.Property<int?>("MetadatenId")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("PunktKoordinatenId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("MetadatenId");

                    b.HasIndex("PunktKoordinatenId");

                    b.ToTable("KundenImagesDaten");
                });

            modelBuilder.Entity("ArgusEyesApi.Entities.Metadaten", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<int>("Helligkeit")
                        .HasColumnType("int");

                    b.Property<int>("Kontrast")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("Metadaten");
                });

            modelBuilder.Entity("ArgusEyesApi.Entities.PunktKoordinaten", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("Text")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("X")
                        .HasColumnType("int");

                    b.Property<int>("Y")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("PunktKoordinaten");
                });

            modelBuilder.Entity("ArgusEyesApi.Entities.KundenImagesDaten", b =>
                {
                    b.HasOne("ArgusEyesApi.Entities.Metadaten", "Metadaten")
                        .WithMany()
                        .HasForeignKey("MetadatenId");

                    b.HasOne("ArgusEyesApi.Entities.PunktKoordinaten", "PunktKoordinaten")
                        .WithMany()
                        .HasForeignKey("PunktKoordinatenId");

                    b.Navigation("Metadaten");

                    b.Navigation("PunktKoordinaten");
                });
#pragma warning restore 612, 618
        }
    }
}
