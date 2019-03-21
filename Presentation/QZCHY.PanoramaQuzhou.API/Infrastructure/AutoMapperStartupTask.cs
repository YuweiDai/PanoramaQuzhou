using QZCHY.PanoramaQuzhou.Core.Infrastructure;

namespace QZCHY.PanoramaQuzhou.Web.Api.Infrastructure
{
    public class AutoMapperStartupTask : IStartupTask
    {
        public int Order
        {
            get { return 0; }
        }

        public void Execute() { }
    }
}