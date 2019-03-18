using System;

namespace QZCHY.PanoramaQuzhou.Core.Domain
{
    public class PanoramaScene: BaseEntity
    {        

        /// <summary>
        /// 用于识别全景文件夹
        /// </summary>
        public string Scene { get; set; }

        /// <summary>
        /// 浏览次数
        /// </summary>
        public int ViewerCounter { get; set; }

        /// <summary>
        /// 点赞次数
        /// </summary>
        public int Stars { get; set; }


        /// <summary>
        /// 生产日期
        /// </summary>
        public DateTime ProductionDate { get; set; }


        public virtual PanoramaLocation Location { get; set; }
    }
}
