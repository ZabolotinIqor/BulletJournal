using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using BulletJournal.Core.Models;

namespace BulletJournal.Core.Services.interfaces
{
    public interface IProfileService
    {
        Task<Profile> GetProfileById(int id);
        Task RegisterProfile(Profile profile);
        Task EditProfile(Profile profile);

    }
}
