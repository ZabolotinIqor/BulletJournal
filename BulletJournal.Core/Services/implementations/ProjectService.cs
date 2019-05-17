using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using BulletJournal.Core.DTO;
using BulletJournal.Core.EntityFramework;
using BulletJournal.Core.Models;
using BulletJournal.Core.Services.interfaces;
using Microsoft.EntityFrameworkCore;

namespace BulletJournal.Core.Services.implementations
{
    public class ProjectService : IProjectService
    {
        private readonly BulletJournalDbContext context;

        public ProjectService(BulletJournalDbContext db)
        {
            this.context = db;
        }
        public async Task<Project> AddProject(ProjectDTO project)
        {
            var proj = new Project()
            {
                Name = project.Name,
                Description = project.Description
            };
            await context.AddAsync(proj);
            await context.SaveChangesAsync();
            return proj;
        }

        public async Task DeleteProject(int id)
        {
            var _project = await context.Projects.FirstOrDefaultAsync(proj => proj.Id == id);
            context.Projects.Remove(_project);
            await context.SaveChangesAsync();
        }

        public async Task<Project> EditProject(ProjectDTO project,int id)
        {
            var _project = await context.Projects.FirstOrDefaultAsync(proj => proj.Id == id);
            _project.Name = project.Name;
            _project.Description = project.Description;
            await context.SaveChangesAsync();
            return _project;
        }

        public async Task<IEnumerable<Project>> GetAllProjects()
        {
            return await context.Projects.ToListAsync();
        }
    }
}
