using QZCHY.PanoramaQuzhou.Core.Domain.Accounts;
using QZCHY.PanoramaQuzhou.Data.Mapping;

namespace QZCHY.PanoramaQuzhou.Data.Mapping.Accounts
{
    public partial class AccountUserMap : EntityTypeConfiguration<AccountUser>
    {
        public AccountUserMap()
        {
            this.ToTable("AccountUsers");
            this.HasKey(c => c.Id);            
        }
    }
}
