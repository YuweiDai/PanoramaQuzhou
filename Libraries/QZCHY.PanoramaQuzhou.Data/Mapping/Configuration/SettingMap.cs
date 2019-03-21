using QZCHY.PanoramaQuzhou.Core.Domain.Configuration;
using QZCHY.PanoramaQuzhou.Data.Mapping;

namespace QZCHY.Data.Mapping.Configuration
{
    public class SettingMap:EntityTypeConfiguration<Setting>
    {
        public SettingMap()
        {
            this.ToTable("Settings");
            this.HasKey(s => s.Id);
            this.Property(s => s.Name).IsRequired().HasMaxLength(200);
            this.Property(s => s.Value).IsRequired().HasMaxLength(2000);
        }
    }
}
