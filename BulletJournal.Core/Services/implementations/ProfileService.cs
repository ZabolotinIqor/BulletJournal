using System.Threading.Tasks;
using BulletJournal.Core.EntityFramework;
using BulletJournal.Core.Models;
using BulletJournal.Core.Services.interfaces;
using Microsoft.EntityFrameworkCore;

namespace BulletJournal.Core.Services.implementations
{
    public class ProfileService : IProfileService
    {
        private readonly BulletJournalDbContext context;

        public ProfileService(BulletJournalDbContext db)
        {
            this.context = db;
        }
        public Task<Profile> GetProfileById(int id)
        {
            return context.Profiles.FirstOrDefaultAsync(profile => profile.Id == id);
        }

        public Task RegisterProfile(Profile profile)
        {
            return context.Profiles.AddAsync(profile);
        }
    }
}
