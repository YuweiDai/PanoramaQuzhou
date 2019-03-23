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

            var location = _locationService.GetLocationBySceneId(id);

            return Ok(location.Name);
        }






        [HttpGet]
        [Route("add")]
        public IHttpActionResult AddScene() {

            var scene = new PanoramaScene()
            {
                Name = "盈川小区",
                LastViewDate = DateTime.Now,
                ProductionDate = DateTime.Now,
                Views = 12
            };
            
            _sceneService.InsertPanoramaScene(scene);

            return Ok("添加成功");
        }


    }
}