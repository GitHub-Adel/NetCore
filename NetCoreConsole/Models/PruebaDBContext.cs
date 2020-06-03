using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace NetCoreConsole.Models
{
    public partial class PruebaDBContext : DbContext
    {
        public PruebaDBContext()
        {
        }

        public PruebaDBContext(DbContextOptions<PruebaDBContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Cliente> Cliente { get; set; }
        public virtual DbSet<Orden> Orden { get; set; }
        public virtual DbSet<Vendedor> Vendedor { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
//#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
                optionsBuilder.UseSqlServer("Server=tcp:adelson-server.database.windows.net,1433;Initial Catalog=PruebaDB;Persist Security Info=False;User ID=adel809;Password=Amauris809;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Cliente>(entity =>
            {
                entity.Property(e => e.ClienteId).HasColumnName("ClienteID");

                entity.Property(e => e.Cedula)
                    .HasMaxLength(1)
                    .IsUnicode(false);

                entity.Property(e => e.Nombre)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.VendedorId).HasColumnName("VendedorID");

                entity.HasOne(d => d.Vendedor)
                    .WithMany(p => p.Cliente)
                    .HasForeignKey(d => d.VendedorId)
                    .HasConstraintName("FK__Cliente__Vendedo__6383C8BA");
            });

            modelBuilder.Entity<Orden>(entity =>
            {
                entity.HasIndex(e => e.ClienteId);

                entity.Property(e => e.OrdenId).HasColumnName("OrdenID");

                entity.Property(e => e.ClienteId).HasColumnName("ClienteID");

                entity.Property(e => e.Detalle)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.HasOne(d => d.Cliente)
                    .WithMany(p => p.Orden)
                    .HasForeignKey(d => d.ClienteId)
                    .HasConstraintName("FK__Orden__ClienteID__5441852A");
            });

            modelBuilder.Entity<Vendedor>(entity =>
            {
                entity.Property(e => e.VendedorId).HasColumnName("VendedorID");

                entity.Property(e => e.Nombre)
                    .IsRequired()
                    .HasMaxLength(150)
                    .IsUnicode(false);
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
