using Microsoft.EntityFrameworkCore;
using NewProject.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NewProject.DAL
{
    public class MonadaMech : DbContext
    {

        public DbSet<User> Users { get; set; }

        public DbSet<Project> Projects { get; set; }

        public DbSet<Exercise> Exercises { get; set; }

        public DbSet<UserProject> UserProject { get; set; }


        public MonadaMech(DbContextOptions<MonadaMech> options) : base(options)
        {

        }

    }
}
