using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QZCHY.PanoramaQuzhou.Core.Domain.Panoramas
{
    /// <summary>
    /// 拍摄点
    /// </summary>
    public class PanoramaLocation:BaseEntity
    {
        private ICollection<Tag> _tags;
        private ICollection<PanoramaScene> _panoramaScenes;

        public string Name { get; set; }

        public string LogoUrl { get; set; }

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

        /// <summary>
        /// 是否为项目拍摄点
        /// </summary>
        public bool IsProject{ get; set; }

        /// <summary>
        /// 默认的全景SceneId
        /// </summary>
        public int DefaultPanoramaSceneId { get; set; }

        /// <summary>
        /// Location标签，不包括Location的标签，标签直接;号隔开
        /// </summary>
        public virtual ICollection<Tag> Tags
        {
            get { return _tags ?? (_tags = new List<Tag>()); }
            protected set { _tags = value; }
        }

        /// <summary>
        /// 一个点对应的全景集合
        /// </summary>
        public virtual ICollection<PanoramaScene> PanoramaScenes {
            get { return _panoramaScenes ?? (_panoramaScenes = new List<PanoramaScene>()); }
            protected set { _panoramaScenes = value; }
        }
    }
}
