using Microsoft.EntityFrameworkCore;
using DeliveryApp.Models;
using System.Collections.Generic;
using System.Reflection.Emit;

namespace DeliveryApp.Data
{
    public class DeliveryContext : DbContext
    {
        public DeliveryContext(DbContextOptions<DeliveryContext> options) : base(options)
        {
        }
        public DbSet<Order> Orders { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Order>().ToTable("Orders");
        }
    }
}
