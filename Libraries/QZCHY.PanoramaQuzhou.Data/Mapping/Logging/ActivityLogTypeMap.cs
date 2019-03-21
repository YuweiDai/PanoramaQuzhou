using QZCHY.PanoramaQuzhou.Core.Domain.Logging;
using QZCHY.PanoramaQuzhou.Data.Mapping;

namespace QZCHY.Data.Mapping.Logging
{
    public partial class ActivityLogTypeMap : EntityTypeConfiguration<ActivityLogType>
    {
        public ActivityLogTypeMap()
        {
            this.ToTable("ActivityLogTypes");
            this.HasKey(alt => alt.Id);

            this.Property(alt => alt.SystemKeyword).IsRequired().HasMaxLength(100);
            this.Property(alt => alt.Name).IsRequired().HasMaxLength(200);
        }
    }
}
