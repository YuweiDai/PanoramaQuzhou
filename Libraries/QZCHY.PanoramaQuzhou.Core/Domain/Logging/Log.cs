using QZCHY.PanoramaQuzhou.Core;
using QZCHY.PanoramaQuzhou.Core.Domain;
using QZCHY.PanoramaQuzhou.Core.Domain.Accounts;

namespace QZCHY.PanoramaQuzhou.Core.Domain.Logging
{
    /// <summary>
    /// Represents a log record
    /// </summary>
    public partial class Log : BaseEntity
    {
        /// <summary>
        /// Gets or sets the log level identifier
        /// </summary>
        public int LogLevelId { get; set; }

        /// <summary>
        /// Gets or sets the short message
        /// </summary>
        public string ShortMessage { get; set; }

        /// <summary>
        /// Gets or sets the full exception
        /// </summary>
        public string FullMessage { get; set; }

        /// <summary>
        /// Gets or sets the IP address
        /// </summary>
        public string IpAddress { get; set; }

        /// <summary>
        /// Gets or sets the customer identifier
        /// </summary>
        public int? CustomerId { get; set; }

        /// <summary>
        /// Gets or sets the page URL
        /// </summary>
        public string PageUrl { get; set; }

        /// <summary>
        /// Gets or sets the referrer URL
        /// </summary>
        public string ReferrerUrl { get; set; }

        /// <summary>
        /// Gets or sets the log level
        /// </summary>
        public LogLevel LogLevel
        {
            get
            {
                return (LogLevel)this.LogLevelId;
            }
            set
            {
                this.LogLevelId = (int)value;
            }
        }

        /// <summary>
        /// Gets or sets the customer
        /// </summary>
        public virtual AccountUser AccountUser { get; set; }
    }
}
