using QZCHY.PanoramaQuzhou.Core.Domain;
using QZCHY.PanoramaQuzhou.Core.Domain.Panoramas;
using QZCHY.PanoramaQuzhou.Data.Mapping;

namespace QZCHY.PanoramaQuzhou.Data.Mapping.Panoramas
{
    public class ProjectMap : EntityTypeConfiguration<Project>
    {
        public ProjectMap()
        {
            this.ToTable("Projects");
            this.HasKey(p => p.Id);

            this.HasMany(pr => pr.PanoramaLocations).WithMany(p=>p.Projects)
                .Map(t => t.ToTable("Project_PonoramaLocation_Mapping"));
        }
    }
}
