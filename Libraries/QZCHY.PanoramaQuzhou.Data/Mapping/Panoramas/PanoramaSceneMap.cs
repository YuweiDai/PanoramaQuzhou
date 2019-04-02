using QZCHY.PanoramaQuzhou.Core.Domain.Panoramas;

namespace QZCHY.PanoramaQuzhou.Data.Mapping.Panoramas
{
    public class PanoramaSceneMap : EntityTypeConfiguration<PanoramaScene>
    {
        public PanoramaSceneMap()
        {
            this.ToTable("PanoramaScenes");
            this.HasKey(pl => pl.Id);

            //this.HasRequired(ps => ps.Location).WithMany(pl => pl.PanoramaScenes);

            this.HasMany(ps => ps.Tags).WithMany()
                .Map(t => t.ToTable("PanoramaScene_Tags_Mapping"));

        }
    }
}
