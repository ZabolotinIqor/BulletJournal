using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using BulletJournal.Core.Models;

namespace BulletJournal.Core.Services.interfaces
{
    public interface ITaskService
    {
        Task<IEnumerable<ToDoTask>> GetAllTasks();
        Task<IEnumerable<ToDoTask>> GetTaskByDate(DateTime date);
        Task<IEnumerable<ToDoTask>> GetTasksByRangeDate(DateTime from, DateTime to);
        Task AddTask(ToDoTask task);
        Task EditTask(ToDoTask task);
        Task DeleteTask(int id);
        Task<ToDoTask> GetTaskById(int id);

    }
}
