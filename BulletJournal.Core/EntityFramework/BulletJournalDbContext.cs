using System;
using System.Collections.Generic;
using System.Text;
using BulletJournal.Core.Models;
using Microsoft.EntityFrameworkCore;

namespace BulletJournal.Core.EntityFramework
{
    public class BulletJournalDbContext:DbContext
    {
        public BulletJournalDbContext(DbContextOptions<BulletJournalDbContext> options) : base(options) { }
        public virtual DbSet<Marks> Markses { get; set; }

        public virtual DbSet<Profile> Profiles { get; set; }

        public virtual DbSet<Project> Projects { get; set; }

        public virtual DbSet<ToDoTask> Tasks { get; set; }

    }
}
