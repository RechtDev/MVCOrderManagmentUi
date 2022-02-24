using System;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

#nullable disable

namespace MVCOrderManagmentUi.Models
{
    public partial class GSparkShopDBContext : DbContext
    {
        public GSparkShopDBContext()
        {
        }

        public GSparkShopDBContext(DbContextOptions<GSparkShopDBContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Product> Products { get; set; }
        public virtual DbSet<ShoppingCart> ShoppingCarts { get; set; }
        public virtual DbSet<ShoppingCartContent> ShoppingCartContents { get; set; }
        //        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        //        {
        //            if (!optionsBuilder.IsConfigured)
        //            {
        //#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
        //                optionsBuilder.UseSqlServer("Data Source=FQRK8G3;Initial Catalog=GSparkShopDB;Integrated Security=True");
        //            }
        //        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("Relational:Collation", "SQL_Latin1_General_CP1_CI_AS");

            modelBuilder.Entity<Product>(entity =>
            {
                entity.HasKey(e => e.ProdId)
                    .HasName("PK__PRODUCTS__56958AB29A69EB3E");

                entity.ToTable("PRODUCTS");

                entity.Property(e => e.ProdId).HasColumnName("prod_id");

                entity.Property(e => e.ProdName)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("prod_name");

                entity.Property(e => e.ProdPrice)
                    .HasColumnType("decimal(18, 2)")
                    .HasColumnName("prod_price");

                entity.Property(e => e.ProdType)
                    .HasMaxLength(15)
                    .IsUnicode(false)
                    .HasColumnName("prod_type");
            });

            modelBuilder.Entity<ShoppingCart>(entity =>
            {
                entity.HasKey(e => e.CartId)
                    .HasName("PK__Shopping__2EF52A27390804F9");

                entity.ToTable("ShoppingCart");

                entity.Property(e => e.CartId).HasColumnName("cart_id");

                entity.Property(e => e.CartName)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("cart_name");
            });

            modelBuilder.Entity<ShoppingCartContent>(entity =>
            {
                entity.HasKey(e=> e.ShoppingCartContentID)
                .HasName("PK__ShoppingC__shopp__2982930DB");

                entity.ToTable("ShoppingCart_Contents");

                entity.Property(e => e.ProdId).HasColumnName("prod_id");

                entity.Property(e => e.ShoppingCartId).HasColumnName("shoppingCart_id");

                entity.HasOne(d => d.Prod)
                    .WithMany()
                    .HasForeignKey(d => d.ProdId)
                    .HasConstraintName("FK__ShoppingC__prod___276EDEB3");

                entity.HasOne(d => d.ShoppingCart)
                    .WithMany()
                    .HasForeignKey(d => d.ShoppingCartId)
                    .HasConstraintName("FK__ShoppingC__shopp__286302EC");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
