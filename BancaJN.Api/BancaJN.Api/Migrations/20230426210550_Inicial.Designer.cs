﻿// <auto-generated />
using System;
using BancaJN.Api.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace BancaJN.Api.Migrations
{
    [DbContext(typeof(BancaDbContext))]
    [Migration("20230426210550_Inicial")]
    partial class Inicial
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.5")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("BancaJN.Api.Entities.Categoria", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Nome")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Categorias");
                });

            modelBuilder.Entity("BancaJN.Api.Entities.Fornecedor", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Cnpj")
                        .HasPrecision(14)
                        .HasColumnType("CHAR(14)");

                    b.Property<decimal>("Margem")
                        .ValueGeneratedOnAdd()
                        .HasPrecision(4, 3)
                        .HasColumnType("decimal(4,3)")
                        .HasDefaultValue(0.0m);

                    b.Property<string>("Nome")
                        .ValueGeneratedOnAdd()
                        .HasPrecision(100)
                        .HasColumnType("nvarchar(max)")
                        .HasDefaultValue("NÃO IDENTIFICADO");

                    b.HasKey("Id");

                    b.HasIndex("Cnpj")
                        .IsUnique()
                        .HasFilter("[Cnpj] IS NOT NULL");

                    b.ToTable("Fornecedores");
                });

            modelBuilder.Entity("BancaJN.Api.Entities.Produto", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("CategoriaId")
                        .HasColumnType("int");

                    b.Property<string>("Codigo")
                        .HasPrecision(50)
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Descricao")
                        .HasPrecision(100)
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ImagemUrl")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Nome")
                        .ValueGeneratedOnAdd()
                        .HasPrecision(50)
                        .HasColumnType("nvarchar(450)")
                        .HasDefaultValue("NÃO IDENTIFICADO");

                    b.Property<string>("NotaFiscal")
                        .HasPrecision(50)
                        .HasColumnType("nvarchar(max)");

                    b.Property<decimal>("Preco")
                        .ValueGeneratedOnAdd()
                        .HasPrecision(10, 2)
                        .HasColumnType("decimal(10,2)")
                        .HasDefaultValue(0m);

                    b.Property<int>("Quantidade")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasDefaultValue(0);

                    b.HasKey("Id");

                    b.HasIndex("CategoriaId");

                    b.HasIndex("Codigo")
                        .IsUnique()
                        .HasFilter("[Codigo] IS NOT NULL");

                    b.HasIndex("Nome")
                        .IsUnique()
                        .HasFilter("[Nome] IS NOT NULL");

                    b.ToTable("Produtos");
                });

            modelBuilder.Entity("BancaJN.Api.Entities.ProdutoFornecedor", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<DateTime>("DataRecebimento")
                        .HasColumnType("DATETIME");

                    b.Property<int>("FornecedorId")
                        .HasColumnType("int");

                    b.Property<int>("ProdutoId")
                        .HasColumnType("int");

                    b.Property<int>("QuantidadeRecebida")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("FornecedorId");

                    b.HasIndex("ProdutoId");

                    b.ToTable("ProdutosFornecedores");
                });

            modelBuilder.Entity("BancaJN.Api.Entities.Produto", b =>
                {
                    b.HasOne("BancaJN.Api.Entities.Categoria", "Categoria")
                        .WithMany("Produtos")
                        .HasForeignKey("CategoriaId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("Categoria");
                });

            modelBuilder.Entity("BancaJN.Api.Entities.ProdutoFornecedor", b =>
                {
                    b.HasOne("BancaJN.Api.Entities.Fornecedor", "Fornecedor")
                        .WithMany("ProdutosFornecedores")
                        .HasForeignKey("FornecedorId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("BancaJN.Api.Entities.Produto", "Produto")
                        .WithMany("ProdutosFornecedores")
                        .HasForeignKey("ProdutoId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Fornecedor");

                    b.Navigation("Produto");
                });

            modelBuilder.Entity("BancaJN.Api.Entities.Categoria", b =>
                {
                    b.Navigation("Produtos");
                });

            modelBuilder.Entity("BancaJN.Api.Entities.Fornecedor", b =>
                {
                    b.Navigation("ProdutosFornecedores");
                });

            modelBuilder.Entity("BancaJN.Api.Entities.Produto", b =>
                {
                    b.Navigation("ProdutosFornecedores");
                });
#pragma warning restore 612, 618
        }
    }
}
