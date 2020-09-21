using totvs_test.Dtos;

namespace totvs_test.Services
{
    public interface ITokenService
    {
        public TokenDto GenerateToken(User user);
    }
}