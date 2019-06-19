﻿using QZCHY.PanoramaQuzhou.API.Models.Panoramas;
using QZCHY.PanoramaQuzhou.Core.Domain.Panoramas;
using QZCHY.PanoramaQuzhou.Services.Panoramas;
using QZCHY.PanoramaQuzhou.Web.Api.Extensions;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;

namespace QZCHY.PanoramaQuzhou.API.Controllers
{
    [RoutePrefix("Projects")]
    public class ProjectController : ApiController
    {
        private readonly IProjectService _projectService;
        private readonly ILocationService _locationService;
        private readonly ISceneService _sceneService;

        public ProjectController (IProjectService projectService, ILocationService locationService, ISceneService sceneService)
        {
            this._projectService = projectService;
            this._locationService = locationService;
            this._sceneService = sceneService;
        }


        [HttpGet]
        [Route("")]
        public IHttpActionResult GetAllProjects()
        {
            var topProjects = _projectService.GetAllProjects().ToList().Select(p => {
                return p.ToModel();
            });
            return Ok(topProjects);
        }

        [HttpGet]
        [Route("Top")]
        public IHttpActionResult GetTopProjects(int count = 5)
        {
            var topProjects = _projectService.GetTopProjects(count).ToList().Select(p => {
                return p.ToSimpleModel();
            });
            return Ok(topProjects);
        }

        [HttpGet]
        [Route("{pid:int}")]
        public IHttpActionResult GetProject(int pid)
        {

            var project = _projectService.GetProjectById(pid);
            if (project == null) return NotFound();
            else
            {
                var projectModel = project.ToModel();

               foreach(var pl in projectModel.PanoramaLocations)
                {
                    var panoramaScene = _sceneService.GetPnoramaSceneById(pl.DefaultPanoramaSceneId);
                    if (panoramaScene != null)
                        pl.LogoUrl = pl.Name + panoramaScene.ProductionDate.ToString("yyyyMMdd") + ".tiles/pano_f.jpg";                     
                }

                return Ok(projectModel);
            }
        }

        [HttpGet]
        [Route("{pid:int}/panolocations")]
        public IHttpActionResult GetProjectLocations(int pid)
        {

            var project = _projectService.GetProjectById(pid);

            if(project!=null)
            {

                var panoLocations =project.PanoramaLocations.ToList().Select(p => {
                    var pl = p.ToSimpleModel();

                  

                    return pl;
                });

                return Ok(panoLocations);
            }
            else
            {
                return Ok(new List<SimplePanoramaLocationModel>()); 
            }

        }
    }
}
