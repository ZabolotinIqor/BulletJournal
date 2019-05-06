﻿using System;
using System.Collections.Generic;
using System.Text;

namespace BulletJournal.Core.Models
{
    public class Project
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public List<ToDoTask> Tasks { get; set; }
    }
}
