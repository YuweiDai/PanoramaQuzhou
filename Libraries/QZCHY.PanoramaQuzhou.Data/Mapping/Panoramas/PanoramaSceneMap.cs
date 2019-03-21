using QZCHY.PanoramaQuzhou.Core.Domain.Panoramas;
using QZCHY.PanoramaQuzhou.Data.Mapping;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QZCHY.PanoramaQuzhou.Data.Mapping.Panoramas
{
    public class PanoramaSceneMap : EntityTypeConfiguration<PanoramaScene>
    {
        public PanoramaSceneMap()
        {
            this.ToTable("PanoramaPanoramaScenes");
            this.HasKey(pl => pl.Id);

            this.HasMany(ps => ps.Tags).WithMany()
                .Map(t => t.ToTable("PanoramaScene_Tags_Mapping"));
        }
    }
}
