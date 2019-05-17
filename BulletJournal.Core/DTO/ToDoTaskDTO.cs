using System;
using System.Collections.Generic;
using System.Text;

namespace BulletJournal.Core.DTO
{
    public class ToDoTaskDTO
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public DateTime EstimatedDate { get; set; }
    }
}
