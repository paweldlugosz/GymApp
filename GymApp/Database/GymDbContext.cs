using GymApp.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GymApp.Database
{
    public class GymDbContext : DbContext
    {
        public DbSet<User> Users { get; set; }

        public DbSet<Gym> Gyms { get; set; }

        public DbSet<GymOpinion> GymOpinions { get; set; }
        public GymDbContext(DbContextOptions options)
            : base(options) { }

        public GymDbContext(DbSet<User> users)
        {
            Users = users;
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<Gym>().HasData(new Gym()
            {
                Id = 1,
                Name = "Fitness Platinium",
                Address = "Lea 213, Kraków",
                Description = "Siłownia lepsza niż inne!",
                IsActive = true,
                Website = "fitnesplatinium.pl",
            });

            builder.Entity<Gym>().HasData(new Gym()
            {
                Id = 2,
                Name = "Fitness Platinium",
                Address = "Stawowa 16, Kraków",
                Description = "Siłownia lepsza niż inne!",
                IsActive = true,
                Website = "fitnesplatinium.pl",
            });
        }
    }
}
