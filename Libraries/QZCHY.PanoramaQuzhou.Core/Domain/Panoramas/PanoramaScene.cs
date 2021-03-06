﻿using QZCHY.PanoramaQuzhou.Core;
using System;
using System.Collections.Generic;

namespace QZCHY.PanoramaQuzhou.Core.Domain.Panoramas
{
    /// <summary>
    /// 全景拍摄点
    /// </summary>
    public class PanoramaScene: BaseEntity
    {
        private ICollection<Tag> _tags;
        private ICollection<Hotspot> _hotspots;
        public PanoramaScene()
        { 
        }     
        /// <summary>
        /// 封面图片
        /// </summary>
        public string LogoUrl { get; set; }

        /// <summary>
        /// 缩略图路径，用于CSS模式的展示
        /// </summary>
        public string ThumPath{ get; set; }

        /// <summary>
        /// 浏览次数
        /// </summary>
        public int Views { get; set; }

        /// <summary>
        /// 点赞次数
        /// </summary>
        public int Stars { get; set; }

        /// <summary>
        /// 生产日期
        /// </summary>
        public DateTime ProductionDate { get; set; }

        /// <summary>
        /// 最后一次访问日期
        /// </summary>
        public DateTime LastViewDate { get; set; }


        public virtual PanoramaLocation PanoramaLocation { get; set; }

        /// <summary>
        /// Scene标签，不包括Location的标签，标签直接;号隔开
        /// </summary>
        public virtual ICollection<Tag> Tags {
            get { return _tags ?? (_tags = new List<Tag>()); }
            protected set { _tags = value; }
        }

        public virtual ICollection<Hotspot> Hotspots
        {
            get { return _hotspots ?? (_hotspots = new List<Hotspot>()); }
            protected set { _hotspots = value; }
        }

    }
}
