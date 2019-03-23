using QZCHY.PanoramaQuzhou.Core.Domain.Panoramas;
using QZCHY.PanoramaQuzhou.Services.Panoramas;
using QZCHY.PanoramaQuzhou.Web.Api.Extensions;
using System.Linq;
using System.Web.Http;

namespace QZCHY.PanoramaQuzhou.API.Controllers
{
    [RoutePrefix("Projects")]
    public class ProjectController : ApiController
    {
        private readonly IProjectService _projectService;

        public ProjectController (IProjectService projectService)
        {
            this._projectService = projectService;
        }


        [HttpGet]
        [Route("Top")]
        public IHttpActionResult GetTopThreeBanners(int count = 5)
        {
            var topProjects = _projectService.GetTopProjects(count).ToList().Select(p => {
                return p.ToModel();
            });
            return Ok(topProjects);
        }
    }
}
