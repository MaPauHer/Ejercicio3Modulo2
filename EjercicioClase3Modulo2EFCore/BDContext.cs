using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace EjercicioClase3Modulo2EFCore
{
    internal class BDContext: DbContext
    {
        public DbSet<Actor> Actor { get; set; }

        public BDContext(DbContextOptions<BDContext> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Actor>().Property(prop => prop.Id).HasColumnName("id");
            modelBuilder.Entity<Actor>().Property(prop => prop.Nombre).HasColumnName("nombre");
            modelBuilder.Entity<Actor>().Property(prop => prop.Apellido).HasColumnName("apellido");
            modelBuilder.Entity<Actor>().Property(prop => prop.NombreArtistico).HasColumnName("nombre_artistico");
            modelBuilder.Entity<Actor>().Property(prop => prop.Edad).HasColumnName("edad");
            modelBuilder.Entity<Actor>().Property(prop => prop.Nacionalidad).HasColumnName("nacionalidad");
            modelBuilder.Entity<Actor>().Property(prop => prop.Genero).HasColumnName("genero");

            base.OnModelCreating(modelBuilder);
        }

    }
}
