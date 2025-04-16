﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace projectManagmentSystem.Models
{
    public class Subtask
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string? Description { get; set; }
        public int? TaskId { get; set; }
        public int? UserId { get; set; }//ответственный за подзадачу
        public int ProjectStatusId { get; set; }
        public User? User { get; set; }
        public Task Task { get; set; }
        public ProjectStatus ProjectStatus { get; set; }
    }
}
