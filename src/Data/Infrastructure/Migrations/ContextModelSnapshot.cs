﻿// <auto-generated />
using System;
using Infrastructure.DbContext;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace Infrastructure.Migrations
{
    [DbContext(typeof(Context))]
    partial class ContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.2")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("Domain.Entities.Projeto", b =>
                {
                    b.Property<long>("IdProjeto")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<long>("IdProjeto"));

                    b.Property<DateTime>("Created")
                        .HasColumnType("datetime2");

                    b.Property<string>("Titulo")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime?>("Updated")
                        .HasColumnType("datetime2");

                    b.HasKey("IdProjeto");

                    b.ToTable("Projeto", (string)null);
                });

            modelBuilder.Entity("Domain.Entities.Tarefa", b =>
                {
                    b.Property<long>("IdTarefa")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<long>("IdTarefa"));

                    b.Property<DateTime>("Created")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("DataVencimento")
                        .HasColumnType("datetime2");

                    b.Property<long>("IdProjeto")
                        .HasColumnType("bigint");

                    b.Property<int>("Prioridade")
                        .HasColumnType("int");

                    b.Property<int>("Status")
                        .HasColumnType("int");

                    b.Property<string>("Titulo")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime?>("Updated")
                        .HasColumnType("datetime2");

                    b.HasKey("IdTarefa");

                    b.HasIndex("IdProjeto");

                    b.ToTable("Tarefa", (string)null);
                });

            modelBuilder.Entity("Domain.Entities.TarefaComentario", b =>
                {
                    b.Property<long>("IdTarefaComentario")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<long>("IdTarefaComentario"));

                    b.Property<string>("Comentario")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("Created")
                        .HasColumnType("datetime2");

                    b.Property<long>("IdTarefa")
                        .HasColumnType("bigint");

                    b.Property<string>("Titulo")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime?>("Updated")
                        .HasColumnType("datetime2");

                    b.HasKey("IdTarefaComentario");

                    b.HasIndex("IdTarefa");

                    b.ToTable("TarefaComentario", (string)null);
                });

            modelBuilder.Entity("Domain.Entities.TarefaHistorico", b =>
                {
                    b.Property<long>("IdTarefaHistorico")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<long>("IdTarefaHistorico"));

                    b.Property<string>("CamposAlterados")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("Created")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("DataAlteracao")
                        .HasColumnType("datetime2");

                    b.Property<long?>("IdTarefa")
                        .HasColumnType("bigint");

                    b.Property<long?>("IdUsuario")
                        .HasColumnType("bigint");

                    b.Property<DateTime?>("Updated")
                        .HasColumnType("datetime2");

                    b.HasKey("IdTarefaHistorico");

                    b.ToTable("TarefaHistorico", (string)null);
                });

            modelBuilder.Entity("Domain.Entities.Usuario", b =>
                {
                    b.Property<long>("IdUsuario")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<long>("IdUsuario"));

                    b.Property<int>("Funcao")
                        .HasColumnType("int");

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("IdUsuario");

                    b.ToTable("Usuario", (string)null);

                    b.HasData(
                        new
                        {
                            IdUsuario = 1L,
                            Funcao = 0,
                            Nome = "Pedro"
                        },
                        new
                        {
                            IdUsuario = 2L,
                            Funcao = 1,
                            Nome = "Gustavo"
                        },
                        new
                        {
                            IdUsuario = 3L,
                            Funcao = 2,
                            Nome = "Aline"
                        });
                });

            modelBuilder.Entity("Domain.Entities.Tarefa", b =>
                {
                    b.HasOne("Domain.Entities.Projeto", "Projeto")
                        .WithMany("Tarefas")
                        .HasForeignKey("IdProjeto")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Projeto");
                });

            modelBuilder.Entity("Domain.Entities.TarefaComentario", b =>
                {
                    b.HasOne("Domain.Entities.Tarefa", "Tarefa")
                        .WithMany("TarefaComentarios")
                        .HasForeignKey("IdTarefa")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Tarefa");
                });

            modelBuilder.Entity("Domain.Entities.Projeto", b =>
                {
                    b.Navigation("Tarefas");
                });

            modelBuilder.Entity("Domain.Entities.Tarefa", b =>
                {
                    b.Navigation("TarefaComentarios");
                });
#pragma warning restore 612, 618
        }
    }
}
