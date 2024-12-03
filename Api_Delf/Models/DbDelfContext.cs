using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace Api_Delf.Models;

public partial class DbDelfContext : DbContext
{
    public DbDelfContext()
    {
    }

    public DbDelfContext(DbContextOptions<DbDelfContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Articulo>? Articulos { get; set; }

    public virtual DbSet<ArticuloCantidade>? ArticuloCantidades { get; set; }

    public virtual DbSet<Categoria>? Categorias { get; set; }

    public virtual DbSet<Cliente>? Clientes { get; set; }

    public virtual DbSet<Pedido>? Pedidos { get; set; }

    public virtual DbSet<Usuario>? Usuarios { get; set; }

    public virtual DbSet<Viajante>? Viajantes { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        => optionsBuilder.UseSqlServer("Name=CadenaSQL");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Articulo>(entity =>
        {
            entity.HasIndex(e => e.CategoriaId, "IX_Articulos_CategoriaId");

            entity.Property(e => e.Precio).HasColumnType("decimal(18, 2)");

            entity.HasOne(d => d.Categoria).WithMany(p => p.Articulos).HasForeignKey(d => d.CategoriaId);
        });

        modelBuilder.Entity<ArticuloCantidade>(entity =>
        {
            entity.HasKey(e => new { e.PedidoId, e.ArticuloId });
            entity.HasOne(d => d.Pedido)
            .WithMany(p => p.ArticuloCantidades)
            .HasForeignKey(d => d.PedidoId)
            .OnDelete(DeleteBehavior.Cascade);
            entity.HasOne(d => d.Articulo)
            .WithMany(p => p.ArticuloCantidades)
            .HasForeignKey(d => d.ArticuloId);
        });


        modelBuilder.Entity<Cliente>(entity =>
        {
            entity.HasIndex(e => e.ViajanteId, "IX_Clientes_ViajanteId");

            entity.HasOne(d => d.Viajante).WithMany(p => p.Clientes).HasForeignKey(d => d.ViajanteId);
        });

        modelBuilder.Entity<Pedido>(entity =>
        {
            entity.HasOne(d => d.Cliente)
            .WithMany(p => p.Pedidos)
            .HasForeignKey(d => d.ClienteId)
            .OnDelete(DeleteBehavior.Cascade); 
            entity.HasMany(d => d.ArticuloCantidades)
            .WithOne(p => p.Pedido)
            .HasForeignKey(d => d.PedidoId).OnDelete(DeleteBehavior.Cascade);
        
    });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
