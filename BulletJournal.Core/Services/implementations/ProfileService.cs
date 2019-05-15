using System.IO;
using System.Threading.Tasks;
using BulletJournal.Core.EntityFramework;
using BulletJournal.Core.Models;
using BulletJournal.Core.Services.interfaces;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Query.Internal;

namespace BulletJournal.Core.Services.implementations
{
    public class ProfileService : IProfileService
    {
        private readonly BulletJournalDbContext context;

        public ProfileService(BulletJournalDbContext db)
        {
            this.context = db;
        }

        public async Task EditProfile(Profile profile)
        {
                var _profile = await context.Profiles.FirstOrDefaultAsync(o => o.Id == profile.Id);
                _profile.Adress = profile.Adress;
                _profile.BirthDate = profile.BirthDate;
                _profile.FathersName = profile.FathersName;
                _profile.Gender = profile.Gender;
                _profile.Name = profile.Name;
                _profile.Surname = profile.Surname;
                _profile.PhoneNumber = profile.PhoneNumber;
                await context.SaveChangesAsync();
        }

        public async Task<Profile> GetProfileById(int id)
        {
            return await context.Profiles.FirstOrDefaultAsync(profile => profile.Id == id);
        }

        public async Task RegisterProfile(Profile profile)
        {
            await context.Profiles.AddAsync(profile);
        }


    }
}
