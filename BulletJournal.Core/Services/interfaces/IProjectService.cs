using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using BulletJournal.Core.DTO;
using BulletJournal.Core.Models;

namespace BulletJournal.Core.Services.interfaces
{
    public interface IProjectService
    {
        Task<IEnumerable<Project>> GetAllProjects();
        Task<Project> EditProject(ProjectDTO project,int id);
        Task DeleteProject(int id);
        Task<Project> AddProject(ProjectDTO project);
    }
}
