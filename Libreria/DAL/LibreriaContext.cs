using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Linq;
using System.Web;
using Libreria.Models;

namespace Libreria.DAL
{
    public class LibreriaContext : DbContext
    {
        public LibreriaContext() : base("LibreriaContext") { }

        public DbSet<Autor> Autors { get; set; }
        public DbSet<Locacion> Locacions { get; set; }
        public DbSet<Miembro> Miembros { get; set; }
        public DbSet<Categoria> Categorias { get; set; }
        public DbSet<Libro> Libros { get; set; }
        public DbSet<CopiaLIbro> CopiaLIbros { get; set; }
        public DbSet<Prestamo> Prestamos { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
        }

    }
}