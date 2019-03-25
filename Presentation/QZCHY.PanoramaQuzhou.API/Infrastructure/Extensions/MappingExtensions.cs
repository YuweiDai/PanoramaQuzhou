using AutoMapper;
using QZCHY.PanoramaQuzhou.API.Models.Panoramas;
using QZCHY.PanoramaQuzhou.Core.Domain.Panoramas;

namespace QZCHY.PanoramaQuzhou.Web.Api.Extensions
{
    /// <summary>
    /// 实体到模型映射
    /// </summary>
    public static class MappingExtensions
    {
        public static TDestination MapTo<TSource, TDestination>(this TSource source)
        {
            return Mapper.Map<TSource, TDestination>(source);
        }

        public static TDestination MapTo<TSource, TDestination>(this TSource source, TDestination destination)
        {
            return Mapper.Map(source, destination);
        }


        public static HotspotModel ToModel(this Hotspot entity)
        {
            return entity.MapTo<Hotspot, HotspotModel>();
        }
        public static Hotspot ToEntity(this HotspotModel createmodel)
        {
            return createmodel.MapTo<HotspotModel, Hotspot>();
        }

        public static Hotspot ToEntity(this HotspotModel createmodel, Hotspot destination)
        {
            return createmodel.MapTo(destination);
        }


        public static PanoramaSceneModel ToModel(this PanoramaScene entity)
        {
            return entity.MapTo<PanoramaScene, PanoramaSceneModel>();
        }
        public static PanoramaSceneListItemModel ToListItemModel(this PanoramaScene entity)
        {
            return entity.MapTo<PanoramaScene, PanoramaSceneListItemModel>();
        }
        public static PanoramaScene ToEntity(this PanoramaSceneModel createmodel)
        {
            return createmodel.MapTo<PanoramaSceneModel, PanoramaScene>();
        }

        public static PanoramaScene ToEntity(this PanoramaSceneModel createmodel, PanoramaScene destination)
        {
            return createmodel.MapTo(destination);
        }


        //banner
        public static BannerModel ToModel(this Banner entity)
        {
            return entity.MapTo<Banner, BannerModel>();
        }

        public static ProjectModel ToModel(this Project entity)
        {
            return entity.MapTo<Project, ProjectModel>();
        }

        public static SimpleProjectModel ToSimpleModel(this Project entity)
        {
            return entity.MapTo<Project, SimpleProjectModel>();
        }

        public static PanoramaLocationModel ToModel(this PanoramaLocation entity)
        {
            return entity.MapTo<PanoramaLocation, PanoramaLocationModel>();
        }

        public static SimplePanoramaLocationModel ToSimpleModel(this PanoramaLocation entity)
        {
            return entity.MapTo<PanoramaLocation, SimplePanoramaLocationModel>();
        }
    }
}