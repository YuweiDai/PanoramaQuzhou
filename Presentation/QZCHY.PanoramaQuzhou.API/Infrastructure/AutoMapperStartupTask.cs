﻿using AutoMapper;
using QZCHY.PanoramaQuzhou.API.Models.Panoramas;
using QZCHY.PanoramaQuzhou.Core.Domain.Panoramas;
using QZCHY.PanoramaQuzhou.Core.Infrastructure;

namespace QZCHY.PanoramaQuzhou.Web.Api.Infrastructure
{
    public class AutoMapperStartupTask : IStartupTask
    {
        public int Order
        {
            get { return 0; }
        }

        public void Execute()
        {

          

            Mapper.Initialize(config => {

                config.CreateMap<Banner, BannerModel>();
                config.CreateMap<Project, ProjectModel>();
                config.CreateMap<Project, SimpleProjectModel>();
                config.CreateMap<PanoramaLocation, PanoramaLocationModel>();
                config.CreateMap<PanoramaLocation, SimplePanoramaLocationModel>();
                config.CreateMap<PanoramaLocation, GeoPanoramaLocationModel>();
                //config.CreateMap<Banner, BannerModel>();

                config.CreateMap<HotspotModel, Hotspot>();
                config.CreateMap<Hotspot, HotspotModel>();

                config.CreateMap<PanoramaSceneModel, PanoramaScene>();
                config.CreateMap<PanoramaScene, PanoramaSceneModel>()
                  .ForMember(dest => dest.ProductionDate, mo => mo.MapFrom(src => src.ProductionDate.ToString("yyyyMMdd")));

                config.CreateMap<PanoramaScene, PanoramaSceneListItemModel>()
                  .ForMember(dest => dest.ProductionDate, mo => mo.MapFrom(src => src.ProductionDate.ToString("yyyy-MM-dd")));
                config.CreateMap<PanoramaScene, PanoramaScenePreviewModel>()
                  .ForMember(dest => dest.Name, mo => mo.MapFrom(src => src.PanoramaLocation.Name))
                  .ForMember(dest => dest.ImgPath, mo => mo.MapFrom( src => src.PanoramaLocation.Name))
                  .ForMember(dest => dest.Lng, mo => mo.MapFrom(src => src.PanoramaLocation.Lng))
                  .ForMember(dest => dest.Lat, mo => mo.MapFrom(src => src.PanoramaLocation.Lat))
                  .ForMember(dest => dest.ProductionDate, mo => mo.MapFrom(src => src.ProductionDate.ToString("yyyy-MM-dd")));

            });
        }
    }
}