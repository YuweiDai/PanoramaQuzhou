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
        [Route("{id}")]
        public IHttpActionResult  GetSceneById(int id=0)
        {

            var location = _sceneService.GetLocationBySceneId(id);

            return Ok(location.Name);
        }

        [HttpPost]
        [Route("add")]
        public IHttpActionResult AddScene() {

            var scene = new PanoramaScene();

            scene.Name = "盈川小区";
            _sceneService.InsertPanoramaScene(scene);

            return Ok("添加成功");
        }


    }
}