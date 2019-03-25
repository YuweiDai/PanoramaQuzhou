using QZCHY.PanoramaQuzhou.Web.Framework.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace QZCHY.PanoramaQuzhou.API.Models.Panoramas
{
    public class PanoramaSceneModel: BaseQMEntityModel
    {

        public string Name { get; set; }
        public int Views { get; set; }
        public int Stars { get; set; }

        public IList<HotspotModel> hotspots { get; set; }

    }
}