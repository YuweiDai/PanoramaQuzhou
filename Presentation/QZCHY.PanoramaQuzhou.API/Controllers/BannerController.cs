using QZCHY.PanoramaQuzhou.Core.Domain.Panoramas;
using QZCHY.PanoramaQuzhou.Services.Panoramas;
using QZCHY.PanoramaQuzhou.Web.Api.Extensions;
using System.Linq;
using System.Web.Http;

namespace QZCHY.PanoramaQuzhou.API.Controllers
{
    [RoutePrefix("Banners")]
    public class BannerController : ApiController
    {
        private readonly IBannerService _bannerService;

        public BannerController(IBannerService bannerService)
        {
            this._bannerService = bannerService;
        }

        [HttpGet]
        [Route("Top")]
        public IHttpActionResult GetTopThreeBanners(int count=3)
        {
            var banners = _bannerService.GetTopBanners(count).ToList().Select(b => {
                return b.ToModel();
            });            
            return Ok(banners);
        }

        [HttpGet]
        [Route("Add")]
        public IHttpActionResult AddBanners()
        {
            var banner = new Banner()
            {
                ImageUrl = "b1.jpg",
                NavToUrl = "panorama?sceneId=1",
                Name = "b1",
                Order = 1
            };

            _bannerService.InsertBanner(banner);

            banner = new Banner()
            {
                ImageUrl = "b2.jpg",
                NavToUrl = "panorama?sceneId=1",
                Name = "b2",
                Order = 1
            };

            _bannerService.InsertBanner(banner);

            banner = new Banner()
            {
                ImageUrl = "b3.jpg",
                NavToUrl = "panorama?sceneId=1",
                Name = "b3",
                Order = 1
            };

            _bannerService.InsertBanner(banner);

            return Ok("");
        }

    }
}
