using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace projectManagmentSystem.Models
{
    public class Subtask
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public int StatusSubtaskId { get; set; }
        public int UserId { get; set; } //Ответственный за подзадачу
    }
}
