using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BulletJournal.Core.EntityFramework;
using BulletJournal.Core.Models;
using BulletJournal.Core.Services.interfaces;
using Microsoft.EntityFrameworkCore;

namespace BulletJournal.Core.Services.implementations
{
    public class TaskService : ITaskService
    {
        private readonly BulletJournalDbContext context;

        public TaskService(BulletJournalDbContext db)
        {
            this.context = db;
        }
        public async Task AddTask(ToDoTask task)
        {
            await context.AddAsync(task);
        }

        public async Task DeleteTask(int id)
        {
            var _task = await context.Tasks.FirstOrDefaultAsync(p => p.Id == id);
            context.Tasks.Remove(_task);
        }

        public async Task EditTask(ToDoTask task)
        {
            var _task = await context.Tasks.FirstOrDefaultAsync(p => p.Id == task.Id);
            _task = task;
            await context.SaveChangesAsync();
        }

        public async Task<IEnumerable<ToDoTask>> GetAllTasks()
        {
            return await context.Tasks.ToListAsync();
        }

        public async Task<IEnumerable<ToDoTask>> GetTaskByDate(DateTime date)
        {
            return await context.Tasks.Where(p => p.StartDate == date).ToListAsync();
        }

        public async Task<ToDoTask> GetTaskById(int id)
        {
            return await context.Tasks.FirstOrDefaultAsync(p => p.Id == id);
        }

        public async Task<IEnumerable<ToDoTask>> GetTasksByRangeDate(DateTime from, DateTime to)
        {
            return await context.Tasks.Where(p => p.StartDate >= from && p.EndDate <= to).ToListAsync();
        }
    }
}
