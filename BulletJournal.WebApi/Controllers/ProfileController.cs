using System.Threading.Tasks;
using BulletJournal.Core.DTO;
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

        [HttpPost("RegisterProfile")]
        public async Task<ActionResult> RegisterProfile([FromBody]ProfileDTO profile)
        {
            if (ModelState.IsValid)
            {
                var result =  await profileService.RegisterProfile(profile);
                if (result == null)
                {
                    return NotFound();
                }
                return Ok(result);
            }
            return BadRequest("Not correct query");
        }
        [HttpPut("EditProfile")]
        public async Task<ActionResult> EditProfile([FromBody]ProfileDTO profile,int id)
        {
            if (ModelState.IsValid)
            {
                var result = await profileService.EditProfile(profile,id);
                if (result == null)
                {
                    return NotFound();
                }
                return Ok(result);
            }
            return BadRequest("Not correct query");
        }

        [HttpGet("GetProfileById")]
        public async Task<ActionResult> GetProfileById(int id)
        {
            var result = await profileService.GetProfileById(id);
            if (result == null)
            {
                return NotFound();
            }

            return Ok(result);
        }

    }
}
