using QZCHY.PanoramaQuzhou.Core.Domain.Authentication;
using System.Threading.Tasks;

namespace QZCHY.PanoramaQuzhou.Services.Authentication
{
    public interface IRefreshTokenService
    {
        Task<bool> DeleteRefreshToken(RefreshToken refreshToken);

        Task<bool> DeleteRefreshToken(string refreshTokenHashId);

        Task<RefreshToken> FindRefreshTokenAsync(string refreshTokenHashId);            

        Task<bool> InsertRefreshTokenAsync(RefreshToken token);
    }
}
