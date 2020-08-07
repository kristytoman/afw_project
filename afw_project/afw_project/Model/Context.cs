﻿using Microsoft.EntityFrameworkCore;
using Xamarin.Essentials;
using System;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;
using System.IO;
using Newtonsoft.Json;
using afw_project.Model;

namespace afw_project
{
    
   
    class Context : DbContext
    {
        
        /// <summary>
        ///
        /// </summary>
        public DbSet<Category> Categories { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public DbSet<Product> Products { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public DbSet<Customer> Customers { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public DbSet<Order> Orders { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public DbSet<ProductOrder> ProductOrders { get; set; }


        public Context() 
        {
            
        }
       

        /// <summary>
        /// 
        /// </summary>
        /// <param name="optionsBuilder"></param>
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseMySQL(ContextCredentials.Connection);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="modelBuilder"></param>
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Category>(entity =>
            {
                entity.HasKey(e => e.ID);
                entity.Property(e => e.ID).ValueGeneratedOnAdd();
            });
            modelBuilder.Entity<Product>(entity =>
            {
                entity.HasKey(e => e.ID);
                entity.Property(e => e.ID).ValueGeneratedOnAdd();
                entity.HasOne(c => c.Category).WithMany(p => p.Products);
            });
            modelBuilder.Entity<Order>(entity =>
            {
                entity.HasKey(e => e.ID);
                entity.Property(e => e.ID).ValueGeneratedOnAdd();
                entity.HasOne(c => c.Customer).WithMany(o => o.Orders);
            });
            modelBuilder.Entity<Customer>(entity =>
            {
                entity.HasKey(e => e.ID);
                entity.Property(e => e.ID).ValueGeneratedOnAdd();
            });
            modelBuilder.Entity<ProductOrder>(entity =>
            {
                entity.HasKey(c => new { c.OrderID, c.ProductID });
                entity.HasOne(p => p.Product).WithMany(o => o.ProductOrders).HasForeignKey(k => k.ProductID);
                entity.HasOne(o => o.Order).WithMany(p => p.ProductOrders).HasForeignKey(k => k.OrderID);
            });
        }
    }

}