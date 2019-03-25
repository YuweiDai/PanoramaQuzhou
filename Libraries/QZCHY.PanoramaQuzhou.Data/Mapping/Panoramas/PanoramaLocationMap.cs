using QZCHY.PanoramaQuzhou.Core.Domain.Panoramas;

namespace QZCHY.PanoramaQuzhou.Data.Mapping.Panoramas
{
    public class PanoramaLocationMap : EntityTypeConfiguration<PanoramaLocation>
    {
        public PanoramaLocationMap()
        {
            this.ToTable("PanoramaLocations");
            this.HasKey(pl => pl.Id);

            this.HasMany(pl => pl.PanoramaScenes).WithMany()
                .Map(t => t.ToTable("PonoramaLocation_PanoramaScene_Mapping"));

            this.HasMany(pl => pl.Tags).WithMany()
                .Map(t => t.ToTable("PonoramaLocation_Tag_Mapping"));
        }
    }
}
