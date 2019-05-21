using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using BulletJournal.Core.DTO;
using BulletJournal.Core.Models;

namespace BulletJournal.Core.Services.interfaces
{
    public interface ITaskService
    {
        Task<IEnumerable<ToDoTask>> GetAllTasks();
        Task<IEnumerable<ToDoTask>> GetTaskByDate(DateTime date);
        Task<IEnumerable<ToDoTask>> GetTasksByRangeDate(DateTime from, DateTime to);
        Task<ToDoTask> AddTask(ToDoTaskDTO task);
        Task<ToDoTask> EditTask(ToDoTaskDTO task,int id);
        Task DeleteTask(int id);
        Task<ToDoTask> GetTaskById(int id);

    }
}
