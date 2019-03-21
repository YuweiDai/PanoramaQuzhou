using Autofac;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using QZCHY.PanoramaQuzhou.Core.Infrastructure;
using QZCHY.PanoramaQuzhou.Core.Infrastructure.DependencyManagement;

namespace QZCHY.PanoramaQuzhou.Web.Api.Infrastructure
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