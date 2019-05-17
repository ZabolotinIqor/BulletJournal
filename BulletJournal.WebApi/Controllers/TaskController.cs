using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BulletJournal.Core.DTO;
using BulletJournal.Core.Models;
using BulletJournal.Core.Services.interfaces;

namespace BulletJournal.WebApi.Controllers
{
    [Route("[controller]/[action]")]
    public class TaskController:Controller
    {
        private readonly ITaskService taskService;

        public TaskController(ITaskService taskService)
        {
            this.taskService = taskService;
        }
        [HttpGet("GetAllTasks")]
        public async Task<ActionResult> GetAllTasks()
        {
            var result = await taskService.GetAllTasks();
            if (result == null)
            {
                return NotFound();
            }

            return Ok(result);
        }
        [HttpGet("GetTaskByDate")]
        public async Task<ActionResult> GetTaskByDate(DateTime fromDate)
        {
            var result = await taskService.GetTaskByDate(fromDate);
            if (result == null)
            {
                return NotFound();
            }

            return Ok(result);
        }
        [HttpGet("GetTaskByRangeDate")]
        public async Task<ActionResult> GetTaskByRangeDate(DateTime fromDate,DateTime toDate)
        {
            var result = await taskService.GetTasksByRangeDate(fromDate,toDate);
            if (result == null)
            {
                return NotFound();
            }

            return Ok(result);
        }
        [HttpGet("GetTaskById")]
        public async Task<ActionResult> GetTaskById(int id)
        {
            var result = await taskService.GetTaskById(id);
            if (result == null)
            {
                return NotFound();
            }

            return Ok(result);
        }
        [HttpPost("AddTask")]
        public async Task<ActionResult> AddTask([FromBody]ToDoTaskDTO toDoTask)
        {
            if (ModelState.IsValid)
            {
                var result = await taskService.AddTask(toDoTask);
                if (result == null)
                {
                    return NotFound();
                }
                return Ok(result);
            }
            return BadRequest("Not correct query");
        }
        [HttpPut("EditTask")]
        public async Task<ActionResult> EditTask([FromBody]ToDoTaskDTO toDoTask, int id)
        {
            if (ModelState.IsValid)
            {
                var result = await taskService.EditTask(toDoTask, id);
                if (result == null)
                {
                    return NotFound();
                }
                return Ok(result);
            }
            return BadRequest("Not correct query");
        }

        [HttpDelete("DeleteTask")]
        public async Task<ActionResult> DeleteTask(int id)
        {
            var result = taskService.DeleteTask(id);
            if (result == null)
            {
                return NotFound();
            }

            return Ok(result);
        }
    }
}
