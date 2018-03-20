namespace ProjetoDev.Infrastructure.Data
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;
    using ProjetoDev.Core;

    public partial class cTesteideianoardev99 : DbContext
    {
        public cTesteideianoardev99()
            : base("name=testeideianoardev99")
        {
        }

        public virtual DbSet<Cliente> Cliente { get; set; }
        public virtual DbSet<Empresa> Empresa { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Cliente>()
                .Property(e => e.Nome)
                .IsUnicode(false);

            modelBuilder.Entity<Cliente>()
                .Property(e => e.Telefone)
                .IsUnicode(false);

            modelBuilder.Entity<Cliente>()
                .Property(e => e.OutrasInformacoes)
                .IsUnicode(false);

            modelBuilder.Entity<Empresa>()
                .Property(e => e.RazaoSocial)
                .IsUnicode(false);

            modelBuilder.Entity<Empresa>()
                .Property(e => e.NomeFantasia)
                .IsUnicode(false);

            modelBuilder.Entity<Empresa>()
                .Property(e => e.ModeloNegocio)
                .IsUnicode(false);

            modelBuilder.Entity<Empresa>()
                .Property(e => e.Endereco)
                .IsUnicode(false);
        }
    }
}
