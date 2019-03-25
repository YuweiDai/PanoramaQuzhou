using QZCHY.PanoramaQuzhou.Core.Domain.Panoramas;
using QZCHY.PanoramaQuzhou.Services.Panoramas;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;

namespace QZCHY.PanoramaQuzhou.API.Controllers
{
    [RoutePrefix("Panoramas")]
    public class PanoramaController: ApiController
    {

        private readonly ISceneService _sceneService;
        private readonly ILocationService _locationService;
   

        public PanoramaController(ISceneService sceneService, ILocationService locationService)
        {
            _sceneService = sceneService;
            _locationService = locationService;
        }

        [HttpGet]
        [Route("{id}")]
        public IHttpActionResult  GetSceneById(int id=0)
        {

            var scene = _sceneService.GetPnoramaSceneById(id);

            scene.Views++;
            _sceneService.UpdatePanoramaScene(scene);

            return Ok(scene);
        }

        [HttpGet]
        [Route("addStars/{id}")]
        public IHttpActionResult AddSceneStars(int id) {

            var scene = _sceneService.GetPnoramaSceneById(id);

            scene.Stars++;
            _sceneService.UpdatePanoramaScene(scene);

            return Ok();
        }


        [HttpGet]
        [Route("hot")]
        public IHttpActionResult GetHotPanoramas()
        {
            //默认最多15个
            var hotPanoramas = _sceneService.GetHotPanoramaScenes(15).ToList().Select(ps =>
            {
                return ps.
            });

            return Ok(hotPanoramas);

        }

        [HttpGet]
        [Route("new")]
        public IHttpActionResult GetNewPanoramas()
        {
            //默认最多15个
            var newPanoramas = _sceneService.GetNewPanoramaScenes(15).ToList().Select(ps =>
            {
                return ps.
            });

            return Ok(newPanoramas);

        }
    }
}