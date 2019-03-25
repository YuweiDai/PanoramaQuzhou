using QZCHY.PanoramaQuzhou.Web.Framework.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace QZCHY.PanoramaQuzhou.API.Models.Panoramas
{
    public class PanoramaLocationModel: BaseQMEntityModel
    {
        public string Name { get; set; }

        public string LogoUrl { get; set; }

        /// <summary>
        /// 经度
        /// </summary>
        public double Lng { get; set; }

        /// <summary>
        /// 纬度
        /// </summary>
        public double Lat { get; set; }

        /// <summary>
        /// 高度
        /// </summary>
        public double Height { get; set; }

        public int DefaultPanoramaSceneId { get; set; }
    }

    public class SimplePanoramaLocationModel : BaseQMEntityModel
    {
        public string Name { get; set; }

        public string LogoUrl { get; set; }
    }
}