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
        public string Description { get; set; }
        public bool Private { get; set; }
        public int UserId { get; set; } //Создатель проекта
        public ICollection<StatusTask> StatusTasks { get; set; }
    }
}
