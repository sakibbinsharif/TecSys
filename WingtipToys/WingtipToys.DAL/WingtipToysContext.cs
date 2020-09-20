﻿using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.Extensions.Options;
using WingtipToys.BLL;
using WingtipToys.BLL.Models;

namespace WingtipToys.DAL
{
    public partial class WingtipToysContext : DbContext
    {
        public WingtipToysContext()
        {
           
        }

        public WingtipToysContext(DbContextOptions<WingtipToysContext> options)
            : base(options)
        {
          
        }

        public virtual DbSet<CartItem> CartItems { get; set; }
        public virtual DbSet<Category> Categories { get; set; }
        public virtual DbSet<OrderDetail> OrderDetails { get; set; }
        public virtual DbSet<Order> Orders { get; set; }
        public virtual DbSet<Product> Products { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                throw new Exception("Configuration failure for data context");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<CartItem>(entity =>
            {
                entity.ToTable("CartItems");

                entity.HasKey(e => e.ItemId)
                    .HasName("PK_dbo.CartItems");

                entity.HasIndex(e => e.ProductId)
                    .HasName("IX_ProductId");

                entity.Property(e => e.ItemId).HasMaxLength(128);

                entity.Property(e => e.DateCreated).HasColumnType("datetime");

                entity.HasOne(d => d.Product)
                    .WithMany(p => p.CartItems)
                    .HasForeignKey(d => d.ProductId)
                    .HasConstraintName("FK_dbo.CartItems_dbo.Products_ProductId");
            });

            modelBuilder.Entity<Category>(entity =>
            {
                entity.ToTable("Categories");

                entity.HasKey(e => e.CategoryId)
                    .HasName("PK_dbo.Categories");

                entity.Property(e => e.CategoryId).HasColumnName("CategoryID");

                entity.Property(e => e.CategoryName)
                    .IsRequired()
                    .HasMaxLength(100);
            });

            modelBuilder.Entity<OrderDetail>(entity =>
            {
                entity.ToTable("OrderDetails");
                entity.HasKey(e => e.OrderDetailId)
                    .HasName("PK_dbo.OrderDetails");

                entity.HasIndex(e => e.OrderId)
                    .HasName("IX_OrderId");

                entity.HasOne(d => d.Order)
                    .WithMany(p => p.OrderDetails)
                    .HasForeignKey(d => d.OrderId)
                    .HasConstraintName("FK_dbo.OrderDetails_dbo.Orders_OrderId");
            });

            modelBuilder.Entity<Order>(entity =>
            {
                entity.ToTable("Orders");

                entity.HasKey(e => e.OrderId)
                    .HasName("PK_dbo.Orders");

                entity.Property(e => e.Address)
                    .IsRequired()
                    .HasMaxLength(70);

                entity.Property(e => e.City)
                    .IsRequired()
                    .HasMaxLength(40);

                entity.Property(e => e.Country)
                    .IsRequired()
                    .HasMaxLength(40);

                entity.Property(e => e.Email).IsRequired();

                entity.Property(e => e.FirstName)
                    .IsRequired()
                    .HasMaxLength(160);

                entity.Property(e => e.LastName)
                    .IsRequired()
                    .HasMaxLength(160);

                entity.Property(e => e.OrderDate).HasColumnType("datetime");

                entity.Property(e => e.Phone).HasMaxLength(24);

                entity.Property(e => e.PostalCode)
                    .IsRequired()
                    .HasMaxLength(10);

                entity.Property(e => e.State)
                    .IsRequired()
                    .HasMaxLength(40);

                entity.Property(e => e.Total).HasColumnType("decimal(18, 2)");
            });

            modelBuilder.Entity<Product>(entity =>
            {
                entity.ToTable("Products");

                entity.HasKey(e => e.ProductId)
                    .HasName("PK_dbo.Products");

                entity.HasIndex(e => e.CategoryId)
                    .HasName("IX_CategoryID");

                entity.Property(e => e.ProductId).HasColumnName("ProductID");

                entity.Property(e => e.CategoryId).HasColumnName("CategoryID");

                entity.Property(e => e.Description).IsRequired();

                entity.Property(e => e.ProductName)
                    .IsRequired()
                    .HasMaxLength(100);

                entity.HasOne(d => d.Category)
                    .WithMany(p => p.Products)
                    .HasForeignKey(d => d.CategoryId)
                    .HasConstraintName("FK_dbo.Products_dbo.Categories_CategoryID");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
