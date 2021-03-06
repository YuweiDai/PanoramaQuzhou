﻿using QZCHY.PanoramaQuzhou.Core.Configuration;
using System.Collections.Generic;

namespace QZCHY.PanoramaQuzhou.Core.Domain.Security
{
    public class SecuritySettings : ISettings
    {
        /// <summary>
        /// Gets or sets a value indicating whether all pages will be forced to use SSL (no matter of a specified [CSCZJHttpsRequirementAttribute] attribute)
        /// </summary>
        public bool ForceSslForAllPages { get; set; }

        /// <summary>
        /// Gets or sets an encryption key
        /// </summary>
        public string EncryptionKey { get; set; }

        /// <summary>
        /// Gets or sets a list of admin area allowed IP addresses
        /// </summary>
        public List<string> AdminAreaAllowedIpAddresses { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether XSRF protection for admin area should be enabled
        /// </summary>
        public bool EnableXsrfProtectionForAdminArea { get; set; }
        /// <summary>
        /// Gets or sets a value indicating whether XSRF protection for public store should be enabled
        /// </summary>
        public bool EnableXsrfProtectionForPublicStore { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether honeypot is enabled on the registration page
        /// </summary>
        public bool HoneypotEnabled { get; set; }
        /// <summary>
        /// Gets or sets a honeypot input name
        /// </summary>
        public string HoneypotInputName { get; set; }
    }
}
