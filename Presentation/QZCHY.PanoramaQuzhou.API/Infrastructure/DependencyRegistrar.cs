using Autofac;
using QZCHY.PanoramaQuzhou.Core.Infrastructure;
using QZCHY.PanoramaQuzhou.Core.Infrastructure.DependencyManagement;

namespace QZCHY.PanoramaQuzhou.ApiInfrastructure
{
    public class DependencyRegistrar : IDependencyRegistrar
    {
        public int Order
        {
            get { return 2; }
        }

        public void Register(ContainerBuilder builder, ITypeFinder typeFinder)
        {

            //TODO:
        }
    }
}