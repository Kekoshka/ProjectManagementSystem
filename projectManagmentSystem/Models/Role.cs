using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace projectManagmentSystem.Models
{
    class Role
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public ICollection<ProjectUser> ProjectUsers{ get; set; }
    }
}
