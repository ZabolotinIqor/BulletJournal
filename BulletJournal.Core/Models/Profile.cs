using System;
using System.Collections.Generic;

namespace BulletJournal.Core.Models
{
    public class Profile
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public string FathersName { get; set; }
        public string Gender { get; set; }
        public DateTime BirthDate { get; set; }
        public string PhoneNumber { get; set; }
        public string Adress { get; set; }
        public List<ToDoTask> Tasks { get; set; }
    }
}
