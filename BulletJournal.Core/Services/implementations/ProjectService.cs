using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
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
        public async Task AddProject(Project project)
        {
            await context.AddAsync(project);
        }

        public async Task DeleteProject(int id)
        {
            var _project = await context.Projects.FirstOrDefaultAsync(proj => proj.Id == id);
            context.Projects.Remove(_project);
        }

        public async Task EditProject(Project project)
        {
            var _project = await context.Projects.FirstOrDefaultAsync(proj => proj.Id == project.Id);
            _project = project;
            await context.SaveChangesAsync();
        }

        public async Task<IEnumerable<Project>> GetAllProjects()
        {
            return await context.Projects.ToListAsync();
        }
    }
}
