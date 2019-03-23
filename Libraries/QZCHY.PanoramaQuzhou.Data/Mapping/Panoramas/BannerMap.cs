using QZCHY.PanoramaQuzhou.Core.Domain.Panoramas;

namespace QZCHY.PanoramaQuzhou.Data.Mapping.Panoramas
{
    public class BannerMap : EntityTypeConfiguration<Banner>
    {
        public BannerMap()
        {
            this.ToTable("Banners");
        }
    }
}
