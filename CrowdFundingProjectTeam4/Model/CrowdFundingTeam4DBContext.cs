﻿using CrowdFundingProjectTeam4.Model;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CrowdFundingProjectTeam4.Model
{
    public class CrowdFundingTeam4DBContext : DbContext
    {
        public DbSet<User> User { get; set; }
        public DbSet<Project> Project { get; set; }
        public DbSet<UserProject> UserProject { get; set; }
        public DbSet<UserFundingPackage> UserFundingPackage { get; set; }
        public DbSet<FundingPackage> FundingPackage { get; set; }
        public DbSet<StatusUpdate> StatusUpdate { get; set; }
        public object Category { get; internal set; }

        //public CrowdFundingTeam4DBContext(DbContextOptions<CrowdFundingTeam4DBContext> options) : base(options) { }

        //public CrowdFundingTeam4DBContext() { }


        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
           // base.OnConfiguring(optionsBuilder);
            optionsBuilder.UseSqlServer("Data Source=localhost;Initial Catalog=CrowdFundDB;Integrated Security=True");
            //optionsBuilder.UseSqlServer("Data Source=localhost;Initial Catalog=CrowdFundDB;User ID=sa;Password=admin!@#123");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<User>().ToTable("Users");
            modelBuilder.Entity<Project>().ToTable("Projects");
            modelBuilder.Entity<UserProject>().ToTable("UserProjects");
            modelBuilder.Entity<UserFundingPackage>().ToTable("UserFundingPackage");
            modelBuilder.Entity<FundingPackage>().ToTable("FundingPackages");
            modelBuilder.Entity<StatusUpdate>().ToTable("StatusUpdates");

            modelBuilder.Entity<User>()
                .HasIndex(User => User.Email)
                .IsUnique();
        }
    }
}
