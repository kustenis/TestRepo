using CMS.Functionality.Interface;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace CMS.Functionality.Implementation
{
    public class CmsDbContext: DbContext
    {
        public CmsDbContext(DbContextOptions<CmsDbContext> options):base(options)
        { 

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Limit>().ToTable("Limit");
            
            modelBuilder.Entity<Account>().ToTable("Account");
            modelBuilder.Entity<Account>()
                .HasIndex(prop => new { prop.Number, prop.Type}).IsUnique();

            modelBuilder.Entity<Transaction>().ToTable("Transaction");
            modelBuilder.Entity<Transaction>()
                .HasIndex(prop => new { prop.AccountId, prop.TransactionDate });
        }
    }
}
