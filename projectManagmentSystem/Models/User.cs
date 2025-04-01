using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace projectManagmentSystem.Models
{
    public class User
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Patronumic { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string Mail { get; set; }
        public ICollection<ProjectUser> ProjectUsers { get; set; }
        public ICollection<Project> Projects { get; set; }
        public ICollection<Task> Tasks { get; set; }
        public ICollection<Subtask> Subtasks { get; set; }
    }
}
