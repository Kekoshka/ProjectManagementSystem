using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace projectManagmentSystem.Models
{
    public class StatusTask
    {
        public int Id { get; set; }
        public int IdProject { get; set; }
        public string Name { get; set; }
        public ICollection<Task> Tasks { get; set; }
    }
}
