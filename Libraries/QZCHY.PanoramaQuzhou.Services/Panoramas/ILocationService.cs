﻿using QZCHY.PanoramaQuzhou.Core.Domain.Panoramas;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QZCHY.PanoramaQuzhou.Services.Panoramas
{
    public interface ILocationService
    {

        PanoramaLocation GetLocationById(int id);

        PanoramaLocation GetLocationBySceneId(int sceneId);

        IQueryable<PanoramaLocation> GetAllLocations();

        IQueryable<PanoramaLocation> GetLocationsByProjectId(int projectId);




        void InsertPanoramaLocation(PanoramaLocation panoramaLocation);
    }
}
