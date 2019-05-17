using System.IO;
using System.Threading.Tasks;
using BulletJournal.Core.DTO;
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

        public async Task<Profile> EditProfile(ProfileDTO profile,int profileId)
        {
                var _profile = await context.Profiles.FirstOrDefaultAsync(o => o.Id == profileId);
                _profile.Adress = profile.Adress;
                _profile.BirthDate = profile.BirthDate;
                _profile.FathersName = profile.FathersName;
                _profile.Gender = profile.Gender;
                _profile.Name = profile.Name;
                _profile.Surname = profile.Surname;
                _profile.PhoneNumber = profile.PhoneNumber;
                await context.SaveChangesAsync();
                return _profile;
        }

        public async Task<Profile> GetProfileById(int id)
        {
            return await context.Profiles.FirstOrDefaultAsync(profile => profile.Id == id);
        }

        public async Task<Profile> RegisterProfile(ProfileDTO profile)
        {
            var prof = new Profile()
            {
                Name = profile.Name,
                Surname = profile.Surname,
                FathersName = profile.FathersName,
                Gender = profile.Gender,
                BirthDate = profile.BirthDate,
                PhoneNumber = profile.PhoneNumber,
                Adress = profile.Adress
            };
            await context.Profiles.AddAsync(prof);
            await context.SaveChangesAsync();
            return prof;
        }


    }
}
