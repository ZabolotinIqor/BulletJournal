using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
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
    }
}
