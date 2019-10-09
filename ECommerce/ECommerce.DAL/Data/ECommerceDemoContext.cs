using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace ECommerce.DAL.Model
{
    public partial class ECommerceDemoContext : DbContext
    {
        public ECommerceDemoContext()
        {
        }

        public ECommerceDemoContext(DbContextOptions<ECommerceDemoContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Product> Product { get; set; }
        public virtual DbSet<ProductAttribute> ProductAttribute { get; set; }
        public virtual DbSet<ProductAttributeLookup> ProductAttributeLookup { get; set; }
        public virtual DbSet<ProductCategory> ProductCategory { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
                optionsBuilder.UseSqlServer("Server=.\\SQLExpress;Database=ECommerceDemo;Trusted_Connection=True;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("ProductVersion", "2.2.6-servicing-10079");

            modelBuilder.Entity<Product>(entity =>
            {
                entity.Property(e => e.ProdDescription).IsUnicode(false);

                entity.Property(e => e.ProdName).IsUnicode(false);

                entity.HasOne(d => d.ProdCatagory)
                    .WithMany(p => p.Product)
                    .HasForeignKey(d => d.ProdCatId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Product_ProductCategory");
            });

            modelBuilder.Entity<ProductAttribute>(entity =>
            {
                entity.HasKey(pa => new { pa.ProductId, pa.AttributeId });
                entity.Property(e => e.AttributeValue).IsUnicode(false);

                entity.HasOne(d => d.Attribute)
                    .WithMany(p => p.ProductAttribute)
                    .HasForeignKey(d => d.AttributeId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_ProductAttribute_ProductAttributeLookup");

                entity.HasOne(d => d.Product)
                    .WithMany(p => p.ProductAttribute)
                    .HasForeignKey(d => d.ProductId)
                    .OnDelete(DeleteBehavior.Cascade)
                    .HasConstraintName("FK_ProductAttribute_Product");
            });

            modelBuilder.Entity<ProductAttributeLookup>(entity =>
            {
                entity.Property(e => e.AttributeName).IsUnicode(false);

                entity.HasOne(d => d.ProdCatagory)
                    .WithMany(p => p.ProductAttributeLookup)
                    .HasForeignKey(d => d.ProdCatId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_ProductAttributeLookup_ProductCategory");
            });

            modelBuilder.Entity<ProductCategory>(entity =>
            {
                entity.Property(e => e.CategoryName).IsUnicode(false);
            });
        }
    }
}
