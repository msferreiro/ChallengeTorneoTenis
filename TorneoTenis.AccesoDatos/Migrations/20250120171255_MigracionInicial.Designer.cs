﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using TorneoTenis.AccesoDatos;

#nullable disable

namespace TorneoTenis.AccesoDatos.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    [Migration("20250120171255_MigracionInicial")]
    partial class MigracionInicial
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.12")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("TorneoTenis.Dominio.Jugador", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("Habilidad")
                        .HasColumnType("int");

                    b.Property<string>("Nombre")
                        .IsRequired()
                        .HasColumnType("varchar(200)");

                    b.Property<int>("Sexo")
                        .HasColumnType("int");

                    b.Property<int>("TorneoId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("TorneoId");

                    b.ToTable("Jugador", (string)null);

                    b.HasDiscriminator<int>("Sexo").HasValue(2);

                    b.UseTphMappingStrategy();
                });

            modelBuilder.Entity("TorneoTenis.Dominio.Torneo", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("CantidadJugadores")
                        .HasColumnType("int");

                    b.Property<DateTime>("Fecha")
                        .HasColumnType("datetime");

                    b.Property<int?>("GanadorId")
                        .HasColumnType("int");

                    b.Property<string>("Nombre")
                        .IsRequired()
                        .HasColumnType("varchar(200)");

                    b.Property<int>("Sexo")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("GanadorId");

                    b.ToTable("Torneo", (string)null);
                });

            modelBuilder.Entity("TorneoTenis.Dominio.JugadorFemenino", b =>
                {
                    b.HasBaseType("TorneoTenis.Dominio.Jugador");

                    b.Property<int>("TiempoReaccion")
                        .HasColumnType("int");

                    b.HasDiscriminator().HasValue(0);
                });

            modelBuilder.Entity("TorneoTenis.Dominio.JugadorMasculino", b =>
                {
                    b.HasBaseType("TorneoTenis.Dominio.Jugador");

                    b.Property<int>("Fuerza")
                        .HasColumnType("int");

                    b.Property<int>("VelocidadDesplazamiento")
                        .HasColumnType("int");

                    b.HasDiscriminator().HasValue(1);
                });

            modelBuilder.Entity("TorneoTenis.Dominio.Jugador", b =>
                {
                    b.HasOne("TorneoTenis.Dominio.Torneo", "Torneo")
                        .WithMany("Jugadores")
                        .HasForeignKey("TorneoId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Torneo");
                });

            modelBuilder.Entity("TorneoTenis.Dominio.Torneo", b =>
                {
                    b.HasOne("TorneoTenis.Dominio.Jugador", "Ganador")
                        .WithMany("Torneos")
                        .HasForeignKey("GanadorId");

                    b.Navigation("Ganador");
                });

            modelBuilder.Entity("TorneoTenis.Dominio.Jugador", b =>
                {
                    b.Navigation("Torneos");
                });

            modelBuilder.Entity("TorneoTenis.Dominio.Torneo", b =>
                {
                    b.Navigation("Jugadores");
                });
#pragma warning restore 612, 618
        }
    }
}
