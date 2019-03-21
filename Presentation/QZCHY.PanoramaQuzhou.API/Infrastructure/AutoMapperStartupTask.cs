using QZCHY.PanoramaQuzhou.Core.Infrastructure;
using System;

namespace QZCHY.PanoramaQuzhou.ApiInfrastructure
{
    public class AutoMapperStartupTask : IStartupTask
    {
        public int Order
        {
            get { return 0; }
        }

        public void Execute()
        {
        }
    }
}