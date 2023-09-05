using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace LoginFormEasy.Models
{
    public partial class SmartFactoryDbContext : DbContext
    {
        public SmartFactoryDbContext()
        {
        }

        public SmartFactoryDbContext(DbContextOptions<SmartFactoryDbContext> options)
            : base(options)
        {
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
           
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            OnModelCreatingPartial(modelBuilder);
        }

        public DbSet<User> User { get; set; }


        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
