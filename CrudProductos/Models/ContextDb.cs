using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace CrudProductos.Models
{
    public class ContextDb : DbContext
    {
        public ContextDb(DbContextOptions<ContextDb> options) : base(options)
        {

        }
        public DbSet<Productos> Productos { get; set; }
        public DbSet<MovimientosStock> MovimientosStock { get; set; }
        public DbSet<Almacenes> Almacenes { get; set; }
        public DbSet<Categorias> Categorias { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Productos>().ToTable("Productos");
            modelBuilder.Entity<MovimientosStock>().ToTable("MovimientosStock");
            modelBuilder.Entity<Almacenes>().ToTable("Almacenes");
            modelBuilder.Entity<Categorias>().ToTable("Categorias");

            modelBuilder.Entity<Productos>()
                .HasOne(p => p.Categoria)
                .WithMany(c => c.Productos)
                .HasForeignKey(p => p.id_categoria);

            modelBuilder.Entity<MovimientosStock>()
                .HasOne(m => m.Producto)
                .WithMany(p => p.MovimientosStock)
                .HasForeignKey(m => m.id_producto);

            modelBuilder.Entity<MovimientosStock>()
                .HasOne(m => m.Almacen)
                .WithMany(a => a.MovimientosStock)
                .HasForeignKey(m => m.id_almacen);

            modelBuilder.Entity<Almacenes>()
                .HasMany(a => a.MovimientosStock)
                .WithOne(m => m.Almacen)
                .HasForeignKey(m => m.id_almacen);

            modelBuilder.Entity<Categorias>()
                .HasMany(c => c.Productos)
                .WithOne(p => p.Categoria)
                .HasForeignKey(p => p.id_categoria);
        }

        
    }
}