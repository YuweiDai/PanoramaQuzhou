using QZCHY.PanoramaQuzhou.Core.Domain.Panoramas;
using QZCHY.PanoramaQuzhou.Services.Panoramas;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;

namespace QZCHY.PanoramaQuzhou.API.Controllers
{
    [RoutePrefix("Panorama")]
    public class PanoramaController: ApiController
    {

        private readonly ISceneService _sceneService;
   

        public PanoramaController(ISceneService sceneService)
        {

            _sceneService = sceneService;
        }

        [HttpGet]
        [Route("{id:int}")]
        public IHttpActionResult  GetSceneById(int id=0)
        {

            var scene = _sceneService.GetSceneById(id);

            return Ok(scene.Name);
        }

        [HttpGet]
        [Route("addViews")]
        public IHttpActionResult AddSceneViews(int id) {

            var scene = _sceneService.GetSceneById(id);
            scene.Views++;
            _sceneService.UpdatePanoramaScene(scene);

            return Ok("添加成功");
        }

        [HttpGet]
        [Route("addStars")]
        public IHttpActionResult AddSceneStars(int id)
        {

            var scene = _sceneService.GetSceneById(id);
            scene.Stars++;
            _sceneService.UpdatePanoramaScene(scene);

            return Ok("添加成功");
        }


    }
}