using Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.DbContext;

public class Context(DbContextOptions<Context> options) : Microsoft.EntityFrameworkCore.DbContext(options)
{
    public DbSet<Tarefa> Tarefas { get; set; }
    public DbSet<Projeto> Projetos { get; set; }

    public DbSet<TarefaComentario> TarefasComentarios { get; set; }

    public DbSet<TarefaHistorico> TarefasHistoricos { get; set; }
    public DbSet<Usuario> Usuarios { get; set; }

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

        var modelUsuario = modelBuilder.Entity<Usuario>();

        modelUsuario.ToTable("Usuario");
        modelUsuario.HasKey(o => o.IdUsuario);

        modelBuilder.Entity<Usuario>()
            .HasData(new Usuario { IdUsuario = 1, Nome = "Pedro", Funcao = Domain.Enums.EnumFuncao.Gerente });
        modelBuilder.Entity<Usuario>()
            .HasData(new Usuario { IdUsuario = 2, Nome = "Gustavo", Funcao = Domain.Enums.EnumFuncao.Desenvolvedor });
        modelBuilder.Entity<Usuario>()
            .HasData(new Usuario { IdUsuario = 3, Nome = "Aline", Funcao = Domain.Enums.EnumFuncao.PO });

        var modelTarefaHistorico = modelBuilder.Entity<TarefaHistorico>();

        modelTarefaHistorico.ToTable("TarefaHistorico");
        modelTarefaHistorico.HasKey(o => o.IdTarefaHistorico);
    }
}