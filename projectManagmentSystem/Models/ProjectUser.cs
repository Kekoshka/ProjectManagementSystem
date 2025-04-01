using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace projectManagmentSystem.Models
{
    public class ProjectUser
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public int ProjectId { get; set; }
        public int RoleId { get; set; }
    }
}
