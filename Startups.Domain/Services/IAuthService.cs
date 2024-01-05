using Startups.Domain.Entities;

namespace Startups.Domain.Services
{
    public interface IAuthService
    {
        string CreateToken(Founder founder);

        void CreatePasswordHash(string password, out byte[] passwordHash, out byte[] passwordSalt);

        bool VerifyPasswordHash(string password, byte[] passwordHash, byte[] passwordSalt);
    }
}
