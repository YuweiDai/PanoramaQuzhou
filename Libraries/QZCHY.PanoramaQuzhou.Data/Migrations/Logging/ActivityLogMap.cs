using QZCHY.PanoramaQuzhou.Core.Domain.Logging;
using QZCHY.PanoramaQuzhou.Data.Mapping;

namespace CSCZJ.Data.Mapping.Logging
{
    public partial class ActivityLogMap : EntityTypeConfiguration<ActivityLog>
    {
        public ActivityLogMap()
        {
            this.ToTable("ActivityLogs");
            this.HasKey(al => al.Id);
            this.Property(al => al.Comment).IsRequired();

            this.HasRequired(al => al.ActivityLogType)
                .WithMany()
                .HasForeignKey(al => al.ActivityLogTypeId);

            this.HasRequired(al => al.AccountUser)
                .WithMany()
                .HasForeignKey(al => al.AccountUserId);
        }
    }
}
