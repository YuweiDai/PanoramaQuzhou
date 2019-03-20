using System.Collections.Generic;

namespace QZCHY.PanoramaQuzhou.Core.Domain.Panoramas
{
    public class Project:BaseEntity
    {

        private ICollection<PanoramaLocation> _panoramaLocations;

        public string Name { get; set; }

        public string Remark { get; set; }

        /// <summary>
        /// 封面图片
        /// </summary>
        public string LogoUrl { get; set; }

        public int Order { get; set; }

        public virtual ICollection<PanoramaLocation> PanoramaLocations
        {
            get { return _panoramaLocations ?? (_panoramaLocations = new List<PanoramaLocation>()); }
            protected set { _panoramaLocations = value; }
        }
    }
}
