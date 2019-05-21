﻿using System.Collections.Generic;

namespace BulletJournal.Core.Models
{
    public class Marks
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string Image { get; set; }
        public List<ToDoTask> Tasks { get; set; }

    }
}
