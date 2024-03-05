using Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.DbContext;

public class Context(DbContextOptions<Context> options) : Microsoft.EntityFrameworkCore.DbContext(options)
{
    public DbSet<Tarefa> Tarefas { get; set; }
    public DbSet<Projeto> Projetos { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        CustomerModelBuilder(modelBuilder);
    }

    private static void CustomerModelBuilder(ModelBuilder modelBuilder)
    {
        var modelTarefa = modelBuilder.Entity<Tarefa>();

        modelTarefa.ToTable("Tarefa");

        var modelProjeto = modelBuilder.Entity<Projeto>();

        modelProjeto.ToTable("Projeto");
    }
}