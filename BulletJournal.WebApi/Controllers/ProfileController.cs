using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BulletJournal.Core.Services.interfaces;
using Microsoft.AspNetCore.Mvc;

namespace BulletJournal.WebApi.Controllers
{
    [Route("[controller]/[action]")]
    public class ProfileController:Controller
    {
        private readonly IProfileService profileService;

        public ProfileController(IProfileService profileService)
        {
            this.profileService = profileService;
        }

    }
}
