﻿// <auto-generated />
using Loja.API.Persistence;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace Loja.API.Migrations.ContatoDb
{
    [DbContext(typeof(ContatoDbContext))]
    partial class ContatoDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder.HasAnnotation("ProductVersion", "8.0.1");

            modelBuilder.Entity("Loja.API.Entities.Contato", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<int>("ClienteId")
                        .HasColumnType("INTEGER");

                    b.Property<int>("Ddd")
                        .HasColumnType("INTEGER");

                    b.Property<decimal>("Telefone")
                        .HasColumnType("TEXT");

                    b.Property<int>("Tipo")
                        .HasColumnType("INTEGER");

                    b.HasKey("Id");

                    b.ToTable("Contato");
                });
#pragma warning restore 612, 618
        }
    }
}