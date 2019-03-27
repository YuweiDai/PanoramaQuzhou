using QZCHY.PanoramaQuzhou.API.Models.Panoramas;
using QZCHY.PanoramaQuzhou.Core.Domain.Panoramas;
using QZCHY.PanoramaQuzhou.Services.Panoramas;
using QZCHY.PanoramaQuzhou.Web.Api.Extensions;
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
        private readonly IHotspotService _hotspotService;

        public PanoramaController(ISceneService sceneService, ILocationService locationService, IHotspotService hotspotService)
        {
            _sceneService = sceneService;
            _locationService = locationService;
            _hotspotService = hotspotService;
        }

        [HttpGet]
        [Route("{id}")]
        public IHttpActionResult  GetSceneById(int id=0)
        {

            var scene = _sceneService.GetPnoramaSceneById(id);

            scene.Views++;
            _sceneService.UpdatePanoramaScene(scene);

            var response = scene.ToModel();
            response.Name = scene.Location.Name+ response.ProductionDate;
            response.Title = scene.Location.Name;
            response.hotspots = scene.Hotspots.Select(h =>
            {
                var hmodel = h.ToModel();
                return hmodel;

            }).ToList();

            return Ok(response);
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
        [Route("Test")]
        public IHttpActionResult Test()
        {
            var scene = _sceneService.GetPnoramaSceneById(9);
            var location = _locationService.GetLocationById(136);

            return Ok("");
        }

        [HttpGet]
        [Route("hot")]
        public IHttpActionResult GetHotPanoramas()
        {
            //默认最多15个
            var hotPanoramas = _sceneService.GetHotPanoramaScenes(15).ToList().Select(ps =>
            {
                var psm = ps.ToListItemModel();
                psm.Name = ps.Location.Name;
                return psm;
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

                var psm = ps.ToListItemModel();
                psm.Name = ps.Location.Name;
                return psm;
            });

            return Ok(newPanoramas);

        }

        [HttpPost]
        [Route("addhotspot")]
        public IHttpActionResult AddHotSpot(HotspotModel hotspotModel) {

            var scence = _sceneService.GetPnoramaSceneById(hotspotModel.Scence_Id);
            var hotspot = new Hotspot();
            hotspot = hotspotModel.ToEntity();
            hotspot.PanoramaScene = scence;

            _hotspotService.InsertHotspot(hotspot);

            return Ok();
        }

        [HttpGet]
        [Route("previewlist")]
        public IHttpActionResult GetPreviewList()
        {
            var scenes = _sceneService.GetAllPanoramaScenes().ToList().Select(ps =>
            {
                var previewModel = ps.ToPreviewModel();
                previewModel.Produce = "衢州市地理信息中心";
                previewModel.ImgPath += ps.ProductionDate.ToString("yyyyMMdd") + ".tiles";
                return previewModel;
            });

            return Ok(scenes);
        }


    }
}