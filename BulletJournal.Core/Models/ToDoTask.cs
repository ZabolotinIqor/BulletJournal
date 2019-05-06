using System;
using System.Collections.Generic;
using System.Text;

namespace BulletJournal.Core.Models
{
    public class ToDoTask
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public DateTime EstimatedDate { get; set; }
        public Profile Profile { get; set; }
        public Project Project { get; set; }
        public Marks Marks { get; set; }
    }
}
