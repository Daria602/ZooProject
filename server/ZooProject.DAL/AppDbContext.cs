using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using ZooProject.DAL.Entities;
using ZooProject.DAL.EntityConfiguration;

namespace ZooProject.DAL
{
    public class AppDbContext : IdentityDbContext<
        User,
        Role,
        int,
        IdentityUserClaim<int>,
        UserRole,
        IdentityUserLogin<int>,
        IdentityRoleClaim<int>,
        IdentityUserToken<int>>
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {

        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseLoggerFactory(LoggerFactory.Create(builder => builder.AddConsole()));
        }
        public DbSet<Animal> Animals { get; set; }
        public DbSet<Enclosure> Enclosures { get; set; }
        public DbSet<Diet> Diets { get; set; }
        public DbSet<Zookeeper> Zookeepers { get; set; }
        public DbSet<AnimalZookeeper> AnimalZookeepers { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.ApplyConfiguration(new AnimalConfiguration());
            modelBuilder.ApplyConfiguration(new EnclosureConfiguration());
            modelBuilder.ApplyConfiguration(new DietConfiguration());
            modelBuilder.ApplyConfiguration(new ZookeeperConfiguration());
            modelBuilder.ApplyConfiguration(new AnimalZookeeperConfiguration());
        }
    }
}