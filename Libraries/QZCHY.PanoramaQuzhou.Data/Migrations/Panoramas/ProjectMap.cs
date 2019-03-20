using QZCHY.PanoramaQuzhou.Core.Domain;
using QZCHY.PanoramaQuzhou.Core.Domain.Panoramas;
using QZCHY.PanoramaQuzhou.Data.Mapping;

namespace QZCHY.PanoramaQuzhou.Data.Migrations.Panoramas
{
    public class ProjectMap : EntityTypeConfiguration<Project>
    {
        public ProjectMap()
        {
            this.ToTable("Projects");
            this.HasKey(p => p.Id);

            this.HasMany(p => p.PanoramaLocations).WithMany()
                .Map(t => t.ToTable("Project_PonoramaLocation_Mapping"));
        }
    }
}
