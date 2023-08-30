﻿// <auto-generated />
using System;
using Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace Infrastructure.Data.Migrations
{
    [DbContext(typeof(TallerContext))]
    [Migration("20230828033719_InitialCreate")]
    partial class InitialCreate
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.10")
                .HasAnnotation("Relational:MaxIdentifierLength", 64);

            modelBuilder.Entity("Core.Entitites.TipoPersona", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("Apellido")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("varchar(50)");

                    b.Property<string>("Nombre")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("varchar(50)");

                    b.Property<int>("Numero")
                        .HasColumnType("long");

                    b.HasKey("Id");

                    b.ToTable("TipoPersonas");

                    b.UseTptMappingStrategy();
                });

            modelBuilder.Entity("Core.Entitites.Cliente", b =>
                {
                    b.HasBaseType("Core.Entitites.TipoPersona");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("varchar(50)");

                    b.Property<DateTime>("FechaRegistro")
                        .HasColumnType("Date");

                    b.Property<int>("IdTipoPersonaFk")
                        .HasColumnType("int");

                    b.HasIndex("IdTipoPersonaFk");

                    b.ToTable("cliente", (string)null);
                });

            modelBuilder.Entity("Core.Entitites.Empleado", b =>
                {
                    b.HasBaseType("Core.Entitites.TipoPersona");

                    b.Property<string>("Especialidad")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("varchar(50)");

                    b.Property<int>("IdTipoPersonFk")
                        .HasColumnType("int");

                    b.HasIndex("IdTipoPersonFk");

                    b.ToTable("empleado", (string)null);
                });

            modelBuilder.Entity("Core.Entitites.Cliente", b =>
                {
                    b.HasOne("Core.Entitites.TipoPersona", null)
                        .WithOne()
                        .HasForeignKey("Core.Entitites.Cliente", "Id")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Core.Entitites.TipoPersona", "TipoPersona")
                        .WithMany("Clientes")
                        .HasForeignKey("IdTipoPersonaFk")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("TipoPersona");
                });

            modelBuilder.Entity("Core.Entitites.Empleado", b =>
                {
                    b.HasOne("Core.Entitites.TipoPersona", null)
                        .WithOne()
                        .HasForeignKey("Core.Entitites.Empleado", "Id")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Core.Entitites.TipoPersona", "TipoPersona")
                        .WithMany("Empleados")
                        .HasForeignKey("IdTipoPersonFk")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("TipoPersona");
                });

            modelBuilder.Entity("Core.Entitites.TipoPersona", b =>
                {
                    b.Navigation("Clientes");

                    b.Navigation("Empleados");
                });
#pragma warning restore 612, 618
        }
    }
}
