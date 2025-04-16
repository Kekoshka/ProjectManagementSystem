using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace projectManagmentSystem.Models
{
    public class Project
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string? Description { get; set; }
        public bool Private { get; set; }
        public ICollection<Task>? Tasks { get; set; }
        public ICollection<Participation>? Participations{ get; set; }
        public ICollection<ProjectStatus> ProjectStatuses { get; set; }
    }
}
