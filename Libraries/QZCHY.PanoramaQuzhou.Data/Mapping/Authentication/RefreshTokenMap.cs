using QZCHY.PanoramaQuzhou.Core.Domain.Authentication;
using QZCHY.PanoramaQuzhou.Data.Mapping;

namespace QZCHY.Data.Mapping.Authentication
{
    public class RefreshTokenMap : EntityTypeConfiguration<RefreshToken>
    {
        public RefreshTokenMap()
        {
            this.ToTable("RefreshTokens");
            this.HasKey(tc => tc.Id);
        }
    }
}
