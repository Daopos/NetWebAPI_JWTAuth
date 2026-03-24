using JWTAspNet.DTO;
using JWTAspNet.Entities;

namespace JWTAspNet.Services
{
    public interface IAuthService
    {

        Task<User?> RegisterASync(UserDto request);

        Task<TokenResponseDto?> LoginAsync(UserDto request);

        Task<TokenResponseDto> RefreshTokenAsync(RefreshTokenRequestDto request);
    }
}
