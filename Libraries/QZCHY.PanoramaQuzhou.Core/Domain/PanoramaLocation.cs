using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QZCHY.PanoramaQuzhou.Core.Domain
{
    /// <summary>
    /// 拍摄点
    /// </summary>
    public class PanoramaLocation:BaseEntity
    {
        public string Name { get; set; }

        /// <summary>
        /// 区域
        /// </summary>
        public string Region { get; set; }

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
      
        public virtual ICollection<Panorama> Panorams { get; set; }
    }
}
