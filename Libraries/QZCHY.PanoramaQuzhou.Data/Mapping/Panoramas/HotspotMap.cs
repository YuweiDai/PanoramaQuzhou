using QZCHY.PanoramaQuzhou.Core.Domain.Panoramas;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QZCHY.PanoramaQuzhou.Data.Mapping.Panoramas
{
   public class HotspotMap: EntityTypeConfiguration<Hotspot>
    {
        public HotspotMap()
        {
            this.ToTable("Hotspots");
            this.HasKey(t => t.Id);
            this.HasRequired(ps => ps.PanoramaScene).WithMany(pl => pl.Hotspots);

        }

    }
}
