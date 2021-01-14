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

        public GymDbContext(DbContextOptions options)
            : base(options) { }

        public GymDbContext(DbSet<User> users)
        {
            Users = users;
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {

        }
    }
}
