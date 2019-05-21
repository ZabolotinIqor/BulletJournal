using System.Threading.Tasks;
using BulletJournal.Core.DTO;
using BulletJournal.Core.Models;

namespace BulletJournal.Core.Services.interfaces
{
    public interface IProfileService
    {
        Task<Profile> GetProfileById(int id);
        Task<Profile> RegisterProfile(ProfileDTO profile);
        Task<Profile> EditProfile(ProfileDTO profile, int profileId);

    }
}
