using AutoMapper;
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
                //config.CreateMap<Banner, BannerModel>();

            });
        }
    }
}