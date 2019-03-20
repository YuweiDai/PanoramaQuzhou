using QZCHY.PanoramaQuzhou.Core;
using QZCHY.PanoramaQuzhou.Core.Data;
using QZCHY.PanoramaQuzhou.Core.Infrastructure;

namespace QZCHY.PanoramaQuzhou.Data
{
    public class EfStartUpTask : IStartupTask
    {
        public void Execute()
        {
            var provider = EngineContext.Current.Resolve<IDataProvider>();
            if (provider == null)
                throw new QZCHYPanoramaQuzhouException("No IDataProvider found");
            provider.SetDatabaseInitializer();
        }

        public int Order
        {
            //ensure that this task is run first 
            get { return -1000; }
        }
    }
}
