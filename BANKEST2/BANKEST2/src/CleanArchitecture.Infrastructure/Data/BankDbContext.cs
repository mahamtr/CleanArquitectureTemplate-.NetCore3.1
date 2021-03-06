﻿using Microsoft.EntityFrameworkCore;
using CleanArchitecture.Core.Entities;
using Ardalis.EFCore.Extensions;

namespace CleanArchitecture.Infrastructure.Data
{
    public class BankDbContext : DbContext
    {

        public BankDbContext(DbContextOptions<BankDbContext> options  )
            : base(options)
        {

        }

        public DbSet<Users> Users { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.ApplyAllConfigurationsFromCurrentAssembly();
            modelBuilder.Entity<Users>().ToTable("Users");
        }



        public override int SaveChanges()
        {
            return SaveChangesAsync().GetAwaiter().GetResult();
        }
    }
}