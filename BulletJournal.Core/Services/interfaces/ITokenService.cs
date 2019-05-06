using BulletJournal.Core.DTO;
using BulletJournal.Core.Identity;


namespace BulletJournal.Core.Services.interfaces
{
    public interface ITokenService
    {
        LoginResponseDTO Execute(ApplicationUser user, RefreshToken refreshToken = null);
    }
}
