using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using BulletJournal.Core.DTO;
using BulletJournal.Core.Identity;
using BulletJournal.Core.Services.interfaces;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;

namespace BulletJournal.Core.Services.implementations
{
    public class TokenService: ITokenService
    {
        private readonly IConfiguration config;
        private readonly UserDbContext db;

        public TokenService(IConfiguration config, UserDbContext db)
        {
            this.config = config;
            this.db = db;
        }

        public LoginResponseDTO Execute(ApplicationUser user, RefreshToken refreshToken = null)
        {
            var now = DateTime.UtcNow;

            var claims = new List<Claim>()
            {
                new Claim(JwtRegisteredClaimNames.NameId, user.Id),
                new Claim(JwtRegisteredClaimNames.Jti, user.Id.ToString()),
                new Claim(JwtRegisteredClaimNames.Iat, new DateTimeOffset(now).ToUniversalTime().ToUnixTimeSeconds().ToString(), ClaimValueTypes.Integer64),
                new Claim(JwtRegisteredClaimNames.Sub, user.UserName),
            };

            var expiration = TimeSpan.FromMinutes(Convert.ToInt32(this.config["JwtExpires"]));
            var issuer = this.config["JwtIssuer"];
            var audience = this.config["JwtAudience"];
            var key = new SymmetricSecurityKey(Encoding.ASCII.GetBytes(this.config["JwtKey"]));
            var credentials = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

            if (refreshToken == null)
            {
                refreshToken = new RefreshToken()
                {
                    UserId = user.Id,
                    Token = Guid.NewGuid().ToString("N"),
                };
                this.db.InsertNew(refreshToken);
            }

            refreshToken.IssuedUtc = now;
            refreshToken.ExpiresUtc = now.Add(expiration);
            this.db.SaveChanges();

            var jwt = new JwtSecurityToken(
                issuer: issuer,
                audience: audience,
                claims: claims.ToArray(),
                notBefore: now,
                expires: now.Add(expiration),
                signingCredentials: credentials);
            var encodedJwt = new JwtSecurityTokenHandler().WriteToken(jwt);

            var response = new LoginResponseDTO
            {
                access_token = encodedJwt,
                refresh_token = refreshToken.Token,
                expires_in = (int)expiration.TotalSeconds,
                userName = user.UserName,
            };
            return response;
        }
    }
}
