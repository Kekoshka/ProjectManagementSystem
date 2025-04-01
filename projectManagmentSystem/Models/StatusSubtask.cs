using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace projectManagmentSystem.Models
{
    public class StatusSubtask
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public ICollection<Subtask> Subtasks { get; set; }
    }
}
