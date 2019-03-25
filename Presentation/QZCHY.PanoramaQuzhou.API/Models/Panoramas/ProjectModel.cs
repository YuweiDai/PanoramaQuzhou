using QZCHY.PanoramaQuzhou.Web.Framework.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace QZCHY.PanoramaQuzhou.API.Models.Panoramas
{
    public class ProjectModel : BaseQMEntityModel
    {
        public string Name { get; set; }

        public string Remark { get; set; }

        public string LogoUrl { get; set; }

        public int Order { get; set; }

        public virtual ICollection<PanoramaLocationModel> PanoramaLocations { get; set; }
    }



    public class SimpleProjectModel: BaseQMEntityModel
    {
        public string Name { get; set; }
        public string LogoUrl { get; set; }
    }


}