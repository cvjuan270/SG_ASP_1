using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Linq;

namespace SG_ASP_1.Models
{
    public partial class SG_ASP_1Context : DbContext
    {
        public SG_ASP_1Context()
            : base("name=SG_ASP_1Context")
        {
        }

        public virtual DbSet<Admision> Admision { get; set; }
        public virtual DbSet<Atenciones> Atenciones { get; set; }
        public virtual DbSet<Auditoria> Auditoria { get; set; }
        public virtual DbSet<Interconsulta> Interconsulta { get; set; }
        public virtual DbSet<Medicina> Medicina { get; set; }
        public virtual DbSet<Medicos> Medicos { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Admision>()
                .Property(e => e.Usuari)
                .IsUnicode(false);

            modelBuilder.Entity<Admision>()
                .Property(e => e.Pendie)
                .IsUnicode(false);

            modelBuilder.Entity<Admision>()
                .Property(e => e.UserName)
                .IsUnicode(false);

            modelBuilder.Entity<Atenciones>()
                .Property(e => e.Local0)
                .IsUnicode(false);

            modelBuilder.Entity<Atenciones>()
                .Property(e => e.TipExa)
                .IsUnicode(false);

            modelBuilder.Entity<Atenciones>()
                .Property(e => e.NomApe)
                .IsUnicode(false);

            modelBuilder.Entity<Atenciones>()
                .Property(e => e.DocIde)
                .IsUnicode(false);

            modelBuilder.Entity<Atenciones>()
                .Property(e => e.Empres)
                .IsUnicode(false);

            modelBuilder.Entity<Atenciones>()
                .Property(e => e.SubCon)
                .IsUnicode(false);

            modelBuilder.Entity<Atenciones>()
                .Property(e => e.Proyec)
                .IsUnicode(false);

            modelBuilder.Entity<Atenciones>()
                .Property(e => e.Perfil)
                .IsUnicode(false);

            modelBuilder.Entity<Atenciones>()
                .Property(e => e.Area)
                .IsUnicode(false);

            modelBuilder.Entity<Atenciones>()
                .Property(e => e.PueTra)
                .IsUnicode(false);

            modelBuilder.Entity<Atenciones>()
                .Property(e => e.PeReAd)
                .IsUnicode(false);

            modelBuilder.Entity<Atenciones>()
                .Property(e => e.Medico)
                .IsUnicode(false);

            modelBuilder.Entity<Atenciones>()
                .HasMany(e => e.Admision)
                .WithOptional(e => e.Atenciones)
                .HasForeignKey(e => e.AtenId);

            modelBuilder.Entity<Atenciones>()
                .HasMany(e => e.Auditoria)
                .WithOptional(e => e.Atenciones)
                .HasForeignKey(e => e.AtenId);

            modelBuilder.Entity<Atenciones>()
                .HasMany(e => e.Interconsulta)
                .WithOptional(e => e.Atenciones)
                .HasForeignKey(e => e.AtenId);

            modelBuilder.Entity<Atenciones>()
                .HasMany(e => e.Medicina)
                .WithOptional(e => e.Atenciones)
                .HasForeignKey(e => e.AtenId);

            modelBuilder.Entity<Auditoria>()
                .Property(e => e.ExaCom1)
                .IsUnicode(false);

            modelBuilder.Entity<Auditoria>()
                .Property(e => e.DatInc1)
                .IsUnicode(false);

            modelBuilder.Entity<Auditoria>()
                .Property(e => e.AptErr1)
                .IsUnicode(false);

            modelBuilder.Entity<Auditoria>()
                .Property(e => e.FaFiMe1)
                .IsUnicode(false);

            modelBuilder.Entity<Auditoria>()
                .Property(e => e.FaFiPa1)
                .IsUnicode(false);

            modelBuilder.Entity<Auditoria>()
                .Property(e => e.Restri1)
                .IsUnicode(false);

            modelBuilder.Entity<Auditoria>()
                .Property(e => e.Contro1)
                .IsUnicode(false);

            modelBuilder.Entity<Auditoria>()
                .Property(e => e.Diagno1)
                .IsUnicode(false);

            modelBuilder.Entity<Auditoria>()
                .Property(e => e.ErrLle1)
                .IsUnicode(false);

            modelBuilder.Entity<Auditoria>()
                .Property(e => e.ObNoRe)
                .IsUnicode(false);

            modelBuilder.Entity<Auditoria>()
                .Property(e => e.EmSnOb1)
                .IsUnicode(false);

            modelBuilder.Entity<Auditoria>()
                .Property(e => e.UserName)
                .IsUnicode(false);

            modelBuilder.Entity<Interconsulta>()
                .Property(e => e.IntCon)
                .IsUnicode(false);

            modelBuilder.Entity<Interconsulta>()
                .Property(e => e.PeEnCo)
                .IsUnicode(false);

            modelBuilder.Entity<Interconsulta>()
                .Property(e => e.PeCoPa)
                .IsUnicode(false);

            modelBuilder.Entity<Interconsulta>()
                .Property(e => e.UserName)
                .IsUnicode(false);

            modelBuilder.Entity<Medicina>()
                .Property(e => e.Medico)
                .IsUnicode(false);

            modelBuilder.Entity<Medicina>()
                .Property(e => e.Aptitu)
                .IsUnicode(false);

            modelBuilder.Entity<Medicina>()
                .Property(e => e.Coment)
                .IsUnicode(false);

            modelBuilder.Entity<Medicina>()
                .Property(e => e.Observ)
                .IsUnicode(false);

            modelBuilder.Entity<Medicina>()
                .Property(e => e.UserName)
                .IsUnicode(false);

            modelBuilder.Entity<Medicos>()
                .Property(e => e.Medico)
                .IsUnicode(false);
        }

        public System.Data.Entity.DbSet<SG_ASP_1.Models.EnfermeriaViewModel> EnfermeriaViewModels { get; set; }

        public System.Data.Entity.DbSet<SG_ASP_1.Models.ExaMedico> ExaMedicoes { get; set; }
    }
}
