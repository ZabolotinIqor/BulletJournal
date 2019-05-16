using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BulletJournal.Core.DTO;
using BulletJournal.Core.EntityFramework;
using BulletJournal.Core.Models;
using BulletJournal.Core.Services.interfaces;
using Microsoft.EntityFrameworkCore;

namespace BulletJournal.Core.Services.implementations
{
    public class MarksService : IMarksService
    {
        private readonly BulletJournalDbContext context;

        public MarksService(BulletJournalDbContext db)
        {
            this.context = db;
        }

        public async Task AddMark(MarkDTO marks)
        {
            var mark = new Marks();
            mark.Name = marks.Name;
            mark.Description = marks.Description;
            mark.Image = marks.Image;
            await context.Markses.AddAsync(mark);
        }

        public async Task<IEnumerable<Marks>> GetAllMarks()
        {
            return await context.Markses.ToListAsync();
        }
    }
}
