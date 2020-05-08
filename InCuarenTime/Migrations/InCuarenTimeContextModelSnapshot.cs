﻿// <auto-generated />
using System;
using InCuarenTime.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace InCuarenTime.Migrations
{
    [DbContext(typeof(InCuarenTimeContext))]
    partial class InCuarenTimeContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.3")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("InCuarenTime.Models.Apartamento", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Bloque")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("Estado")
                        .HasColumnType("bit");

                    b.Property<int>("Numero")
                        .HasColumnType("int");

                    b.Property<int>("Piso")
                        .HasColumnType("int");

                    b.Property<int>("Unidad_ResidencialID")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("Unidad_ResidencialID");

                    b.ToTable("Apartamento");
                });

            modelBuilder.Entity("InCuarenTime.Models.Ciudad", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("DepartamentoID")
                        .HasColumnType("int");

                    b.Property<bool>("Estado")
                        .HasColumnType("bit");

                    b.Property<string>("Nombre")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("DepartamentoID");

                    b.ToTable("Ciudad");
                });

            modelBuilder.Entity("InCuarenTime.Models.Compra", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("Cantidad")
                        .HasColumnType("int");

                    b.Property<bool>("Estado")
                        .HasColumnType("bit");

                    b.Property<int>("MercadoID")
                        .HasColumnType("int");

                    b.Property<int>("ProductoID")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("MercadoID")
                        .IsUnique();

                    b.HasIndex("ProductoID");

                    b.ToTable("Compra");
                });

            modelBuilder.Entity("InCuarenTime.Models.Departamento", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<bool>("Estado")
                        .HasColumnType("bit");

                    b.Property<string>("Nombre")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("PaisID")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("PaisID");

                    b.ToTable("Departamento");
                });

            modelBuilder.Entity("InCuarenTime.Models.Mercado", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<bool>("Estado")
                        .HasColumnType("bit");

                    b.Property<DateTime>("FechaCreacion")
                        .HasColumnType("datetime2");

                    b.Property<int>("PropietarioID")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("PropietarioID");

                    b.ToTable("Mercado");
                });

            modelBuilder.Entity("InCuarenTime.Models.Pais", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<bool>("Estado")
                        .HasColumnType("bit");

                    b.Property<string>("Nombre")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Pais");
                });

            modelBuilder.Entity("InCuarenTime.Models.Producto", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<bool>("Estado")
                        .HasColumnType("bit");

                    b.Property<string>("Nombre")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UnidadMedida")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Producto");
                });

            modelBuilder.Entity("InCuarenTime.Models.Propietario", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("ApartamentoID")
                        .HasColumnType("int");

                    b.Property<string>("Apellido")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("Estado")
                        .HasColumnType("bit");

                    b.Property<string>("Nombre")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Telefono")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("ApartamentoID")
                        .IsUnique();

                    b.ToTable("Propietario");
                });

            modelBuilder.Entity("InCuarenTime.Models.Unidad_Residencial", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("CiudadID")
                        .HasColumnType("int");

                    b.Property<string>("Direccion")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("Estado")
                        .HasColumnType("bit");

                    b.Property<string>("Nombre")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Telefono")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("CiudadID");

                    b.ToTable("Unidad_Residencial");
                });

            modelBuilder.Entity("InCuarenTime.Models.Apartamento", b =>
                {
                    b.HasOne("InCuarenTime.Models.Unidad_Residencial", "Unidad_Residencial")
                        .WithMany("Apartamentos")
                        .HasForeignKey("Unidad_ResidencialID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("InCuarenTime.Models.Ciudad", b =>
                {
                    b.HasOne("InCuarenTime.Models.Departamento", "Departamento")
                        .WithMany("Ciudades")
                        .HasForeignKey("DepartamentoID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("InCuarenTime.Models.Compra", b =>
                {
                    b.HasOne("InCuarenTime.Models.Mercado", "Mercado")
                        .WithOne("Compra")
                        .HasForeignKey("InCuarenTime.Models.Compra", "MercadoID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("InCuarenTime.Models.Producto", "Productos")
                        .WithMany("Compras")
                        .HasForeignKey("ProductoID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("InCuarenTime.Models.Departamento", b =>
                {
                    b.HasOne("InCuarenTime.Models.Pais", "Pais")
                        .WithMany("Departamentos")
                        .HasForeignKey("PaisID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("InCuarenTime.Models.Mercado", b =>
                {
                    b.HasOne("InCuarenTime.Models.Propietario", "Propietario")
                        .WithMany("Mercados")
                        .HasForeignKey("PropietarioID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("InCuarenTime.Models.Propietario", b =>
                {
                    b.HasOne("InCuarenTime.Models.Apartamento", "Apartamento")
                        .WithOne("Propietario")
                        .HasForeignKey("InCuarenTime.Models.Propietario", "ApartamentoID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("InCuarenTime.Models.Unidad_Residencial", b =>
                {
                    b.HasOne("InCuarenTime.Models.Ciudad", "Ciudad")
                        .WithMany("Unidad_Residenciales")
                        .HasForeignKey("CiudadID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}
