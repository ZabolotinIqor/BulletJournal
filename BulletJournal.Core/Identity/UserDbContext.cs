using System.Linq;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace BulletJournal.Core.Identity
{
    public class UserDbContext:IdentityDbContext<ApplicationUser>
    {
        public UserDbContext(DbContextOptions<UserDbContext> options) : base(options) { }

        public DbSet<RefreshToken> RefreshTokens { get; set; }

        public void InsertNew(RefreshToken token)
        {
            var tokenModel = this.RefreshTokens.SingleOrDefault(i => i.UserId == token.UserId);
            if (tokenModel != null)
            {
                this.RefreshTokens.Remove(tokenModel);
                SaveChanges();
            }
            this.RefreshTokens.Add(token);
            SaveChanges();
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<RefreshToken>()
                .HasAlternateKey(c => c.UserId)
                .HasName("refreshToken_UserId");
            modelBuilder.Entity<RefreshToken>()
                .HasAlternateKey(c => c.Token)
                .HasName("refreshToken_Token");
            base.OnModelCreating(modelBuilder);
        }
    }
}
