using QZCHY.PanoramaQuzhou.Services.Panoramas;
using QZCHY.PanoramaQuzhou.Web.Api.Extensions;
using System.Linq;
using System.Web.Http;

namespace QZCHY.PanoramaQuzhou.API.Controllers
{
    [RoutePrefix("Panolocations")]
    public class PanoramaLocationController : ApiController
    {
        private readonly ILocationService _locationService;


        public PanoramaLocationController(ILocationService locationService)
        {
            this._locationService = locationService;
        }

        [HttpGet]
        [Route("Map")]
        public IHttpActionResult GetAllInMap()
        {
            var locations = _locationService.GetAllLocations().ToList().Select(pl=> {
                return pl.ToGeoModel();
            });


            return Ok(locations);
        }


    }
}
