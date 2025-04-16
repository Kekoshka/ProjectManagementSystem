using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace projectManagmentSystem.Models
{
    public class Participation
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public int ProjectId { get; set; }
        public int RoleId {get; set; }
        public User User { get; set; }
        public Project Project { get; set; }
        public Role Role { get; set; }
    }
}
