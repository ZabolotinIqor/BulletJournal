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
    public class ProjectController:Controller
    {
        private readonly IProjectService projectService;

        public ProjectController(IProjectService projectService)
        {
            this.projectService = projectService;
        }

        [HttpDelete("DeleteProject")]
        public async Task<ActionResult> DeleteProject(int id)
        {
            var result = projectService.DeleteProject(id);
            if (result == null)
            {
                return NotFound();
            }

            return Ok(result);
        }
        [HttpPut("EditProject")]
        public async Task<ActionResult> EditProject([FromBody]ProjectDTO project, int id)
        {
            if (ModelState.IsValid)
            {
                var result = await projectService.EditProject(project, id);
                if (result == null)
                {
                    return NotFound();
                }
                return Ok(result);
            }
            return BadRequest("Not correct query");
        }
        [HttpPost("AddProject")]
        public async Task<ActionResult> AddProject([FromBody]ProjectDTO project)
        {
            if (ModelState.IsValid)
            {
                var result = await projectService.AddProject(project);
                if (result == null)
                {
                    return NotFound();
                }
                return Ok(result);
            }
            return BadRequest("Not correct query");
        }

        [HttpGet("GetAllProjects")]
        public async Task<ActionResult> GetAllProjects()
        {
            var result = await projectService.GetAllProjects();
            if (result == null)
            {
                return NotFound();
            }

            return Ok(result);
        }
    }
}
