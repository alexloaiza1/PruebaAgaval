using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace AgavalPruebaPart1.Models.DB
{
    public partial class ServiciosAgavalContext : DbContext
    {
        public ServiciosAgavalContext()
        {
        }

        public ServiciosAgavalContext(DbContextOptions<ServiciosAgavalContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Cliente> Clientes { get; set; } = null!;
        public virtual DbSet<Empleado> Empleados { get; set; } = null!;
        public virtual DbSet<Producto> Productos { get; set; } = null!;
        public virtual DbSet<Proveedore> Proveedores { get; set; } = null!;
        public virtual DbSet<ProveedoresProducto> ProveedoresProductos { get; set; } = null!;
        public virtual DbSet<Seccione> Secciones { get; set; } = null!;
        public virtual DbSet<SeccionesEmpleado> SeccionesEmpleados { get; set; } = null!;
        public virtual DbSet<Tipospersona> Tipospersonas { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer("ConnectionSqlServer");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Cliente>(entity =>
            {
                entity.HasKey(e => e.Idcliente)
                    .HasName("PK__CIENTE__9B8553FC0B738433");

                entity.ToTable("CLIENTE");

                entity.Property(e => e.Idcliente).HasColumnName("IDCliente");

                entity.Property(e => e.Direccion)
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.Email)
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.Identificacion)
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.Idtipo).HasColumnName("IDTipo");

                entity.Property(e => e.Nombre)
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.Telefono)
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.HasOne(d => d.oTipoPersona)
                    .WithMany(p => p.Clientes)
                    .HasForeignKey(d => d.Idtipo)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_Tipo");
            });

            modelBuilder.Entity<Empleado>(entity =>
            {
                entity.HasKey(e => e.Idempleado)
                    .HasName("PK__EMPLEADO__50621DCDF0723D4B");

                entity.ToTable("EMPLEADOS");

                entity.Property(e => e.Idempleado).HasColumnName("IDEmpleado");

                entity.Property(e => e.Direccion)
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.Identificacion)
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.Nombre)
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.Telefono)
                    .HasMaxLength(255)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Producto>(entity =>
            {
                entity.HasKey(e => e.Idproducto)
                    .HasName("PK__Producto__ABDAF2B474C91B56");

                entity.ToTable("PRODUCTOS");

                entity.Property(e => e.Idproducto).HasColumnName("IDProducto");

                entity.Property(e => e.Descripcion)
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.Idcliente).HasColumnName("IDCliente");

                entity.Property(e => e.Nombre)
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.HasOne(d => d.oClientess)
                    .WithMany(p => p.Productos)
                    .HasForeignKey(d => d.Idcliente)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_Cliente");
            });

            modelBuilder.Entity<Proveedore>(entity =>
            {
                entity.HasKey(e => e.Idproveedor)
                    .HasName("PK__Proveedo__4CD732404A3AE62C");

                entity.ToTable("PROVEEDORES");

                entity.Property(e => e.Idproveedor).HasColumnName("IDProveedor");

                entity.Property(e => e.Identificacion)
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.Nombre)
                    .HasMaxLength(255)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<ProveedoresProducto>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("PROVEEDORES_PRODUCTOS");

                entity.Property(e => e.DescripcionContrato)
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.Idproducto).HasColumnName("IDProducto");

                entity.Property(e => e.Idproveedor).HasColumnName("IDProveedor");

                entity.HasOne(d => d.IdproductoNavigation)
                    .WithMany()
                    .HasForeignKey(d => d.Idproducto)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_Producto");

                entity.HasOne(d => d.IdproveedorNavigation)
                    .WithMany()
                    .HasForeignKey(d => d.Idproveedor)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_Proveedor");
            });

            modelBuilder.Entity<Seccione>(entity =>
            {
                entity.HasKey(e => e.Idseccion)
                    .HasName("PK__SECCIONE__7DEBD45D48DFBF50");

                entity.ToTable("SECCIONES");

                entity.Property(e => e.Idseccion).HasColumnName("IDSeccion");

                entity.Property(e => e.Descripcion)
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.Idcliente).HasColumnName("IDCliente");

                entity.HasOne(d => d.oCliente)
                    .WithMany(p => p.Secciones)
                    .HasForeignKey(d => d.Idcliente)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_ClienteSeccion");
            });

            modelBuilder.Entity<SeccionesEmpleado>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("SECCIONES_EMPLEADOS");

                entity.Property(e => e.Cargo)
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.Idempleado).HasColumnName("IDEmpleado");

                entity.Property(e => e.Idseccion).HasColumnName("IDSeccion");

                entity.HasOne(d => d.IdempleadoNavigation)
                    .WithMany()
                    .HasForeignKey(d => d.Idempleado)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_Empleado");

                entity.HasOne(d => d.IdseccionNavigation)
                    .WithMany()
                    .HasForeignKey(d => d.Idseccion)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_Seccion");
            });

            modelBuilder.Entity<Tipospersona>(entity =>
            {
                entity.HasKey(e => e.Idtipo)
                    .HasName("PK__TIPOSPER__BEB088A685B1C259");

                entity.ToTable("TIPOSPERSONA");

                entity.Property(e => e.Idtipo).HasColumnName("IDTipo");

                entity.Property(e => e.Nombre)
                    .HasMaxLength(255)
                    .IsUnicode(false);
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
