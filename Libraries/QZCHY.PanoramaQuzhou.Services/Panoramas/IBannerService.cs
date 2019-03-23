using QZCHY.PanoramaQuzhou.Core.Domain.Panoramas;
using System.Linq;

namespace QZCHY.PanoramaQuzhou.Services.Panoramas
{
    public interface IBannerService
    {
        IQueryable<Banner> GetTopBanners(int count = 3);

        void InsertBanner(Banner banner);
    }
}
