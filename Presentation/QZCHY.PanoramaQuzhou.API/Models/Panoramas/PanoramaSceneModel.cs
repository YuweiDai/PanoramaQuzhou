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
        public string Title { get; set; }
        public int Views { get; set; }
        public int Stars { get; set; }

        public IList<HotspotModel> hotspots { get; set; }
        public string ProductionDate { get; set; }

        public int SceneNum { get; set; }
    }

    /// <summary>
    /// 用于CSS预览展示
    /// </summary>
    public class PanoramaScenePreviewModel:BaseQMEntityModel
    {
        public string Name { get; set; }

        public int Views { get; set; }
        
        public string ProductionDate { get; set; }
        public string Produce { get; set; }

        public string ImgPath { get; set; }

        public double Lng { get; set; }

        public double Lat { get; set; }

        public double Dist { get; set; }

        public int Stars { get; set; }

        public int LocationId { get; set; }
    }

    public class PanoramaSceneListItemModel : BaseQMEntityModel
    {
        public string Name { get; set; }
        public int Views { get; set; }

        public string LogoUrl { get; set; }
        public string ProductionDate { get; set; }

        public int LocationId { get; set; }
    }
}