using Microsoft.EntityFrameworkCore;
using projectManagmentSystem.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace projectManagmentSystem.Context
{
    public class ApplicationContext : DbContext
    {
        public DbSet<Project> Projects { get; set; }
        public DbSet<Participation> Participations{ get; set; }
        public DbSet<Role> Roles { get; set; }
        public DbSet<Subtask> Subtasks { get; set; }
        public DbSet<Models.Task> Tasks { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<ProjectStatus> ProjectStatuses { get; set; }

        public ApplicationContext()
        {
            Database.EnsureCreated();
        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.EnableSensitiveDataLogging();
            optionsBuilder
                .UseSqlServer(Common.Config.ConnectionString)
                .UseSeeding((context,_)=>
                {
                    var roles = context.Set<Role>().ToList();
                    if(roles.Count == 0)
                    {
                        List<Role> rolesAdd = new List<Role> { new Role{ Name = "Owner" }, new Role { Name = "Admin" } , new Role { Name = "User" } };
                        context.Set<Role>().AddRange(rolesAdd);
                        context.SaveChanges();
                    }
                });
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
                      
        }
    }
}
