using BulletJournal.Core.Identity;
using BulletJournal.Core.Services.interfaces;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
using System;
using System.Linq;
using System.Threading.Tasks;
using BulletJournal.Core.DTO;
using Newtonsoft.Json.Linq;
using Microsoft.EntityFrameworkCore;

namespace BulletJournal.WebApi.Controllers
{

    //TODO: Перенести весь функционал в сервисы.
    [Route("[controller]/[action]")]
    public class AccountController:Controller
    {
        private readonly ITokenService tokenService;
        private readonly UserDbContext db;
        private readonly SignInManager<ApplicationUser> signInManager;
        private readonly UserManager<ApplicationUser> userManager;
        private readonly JsonSerializerSettings serializerSettings;
        private readonly IConfiguration config;

        public AccountController(IConfiguration config,
            ITokenService tokenService,
            UserDbContext db,
            SignInManager<ApplicationUser> signInManager,
            UserManager<ApplicationUser> userManager)
        {
            this.tokenService = tokenService;
            this.config = config;
            this.db = db;
            this.signInManager = signInManager;
            this.userManager = userManager;
            this.serializerSettings = new JsonSerializerSettings
            {
                Formatting = Formatting.Indented
            };
        }

        [HttpPost]
        public async Task<IActionResult> Login([FromBody]LoginDTO model)
        {
            var result = await this.signInManager.PasswordSignInAsync(model.Email, model.Password, false, false);
            if (result.Succeeded)
            {
                var user = this.userManager.Users.FirstOrDefault(u => u.Email == model.Email);
                return new ObjectResult(this.tokenService.Execute(user));
            }
            return BadRequest("Login failed.");
        }

        //TODO: переработать регистрацию сделать привязку с Profile 
        [HttpPost]
        public async Task<IActionResult> Register([FromBody]RegisterDTO model)
        {
            var user = new ApplicationUser
            {
                UserName = model.Email,
                Email = model.Email
            };
            var result = await this.userManager.CreateAsync(user, model.Password);

            if (result.Succeeded)
            {
                await this.signInManager.SignInAsync(user, false);
                return new ObjectResult(this.tokenService.Execute(user));
            }
            return BadRequest("Register failed.");
        }

        [HttpPost]
        public async Task<IActionResult> Refresh([FromBody]JToken refreshToken)
        {
            var rToken = refreshToken.ToString();
            if (string.IsNullOrWhiteSpace(rToken))
            {
                return BadRequest();
            }

            var refreshTokenModel = this.db.RefreshTokens.Include(x => x.User).SingleOrDefault(i => i.Token == rToken);

            if (refreshTokenModel == null)
            {
                return BadRequest("User must relogin.");
            }

            if (!await this.signInManager.CanSignInAsync(refreshTokenModel.User))
            {
                return BadRequest("User is unable to login.");
            }

            if (this.userManager.SupportsUserLockout && await this.userManager.IsLockedOutAsync(refreshTokenModel.User))
            {
                return BadRequest("User is locked out.");
            }

            var user = refreshTokenModel.User;
            var token = this.tokenService.Execute(user, refreshTokenModel);
            return new ObjectResult(token);
        }
    }
}
