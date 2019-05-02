
namespace BulletJournal.Core.DTO
{
    public class LoginResponseDTO
    {
        public string access_token { get; set; }
        public string refresh_token { get; set; }
        public int expires_in { get; set; }
        public string userName { get; set; }
    }
}
