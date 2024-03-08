using Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.DbContext;

public class Context(DbContextOptions<Context> options) : Microsoft.EntityFrameworkCore.DbContext(options)
{
    public DbSet<Tarefa> Tarefas { get; set; }
    public DbSet<Projeto> Projetos { get; set; }

    public DbSet<TarefaComentario> TarefasComentarios { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        CustomerModelBuilder(modelBuilder);
    }

    private static void CustomerModelBuilder(ModelBuilder modelBuilder)
    {
        var modelTarefa = modelBuilder.Entity<Tarefa>();

        modelTarefa.ToTable("Tarefa");
        modelTarefa.HasKey(o => o.IdTarefa);

        var modelProjeto = modelBuilder.Entity<Projeto>();

        modelProjeto.ToTable("Projeto");
        modelProjeto.HasKey(o => o.IdProjeto);

        modelBuilder.Entity<Projeto>()
            .HasMany(s => s.Tarefas)
            .WithOne(s => s.Projeto)
            .HasForeignKey(s=> s.IdProjeto)
            .IsRequired();

        var modelTarefaComentario = modelBuilder.Entity<TarefaComentario>();
        
        modelTarefaComentario.ToTable("TarefaComentario");
        modelTarefaComentario.HasKey(o => o.IdTarefaComentario);

        modelBuilder.Entity<Tarefa>()
            .HasMany(s => s.TarefaComentarios)
            .WithOne(s => s.Tarefa)
            .HasForeignKey(s => s.IdTarefa)
            .IsRequired();
    }
}