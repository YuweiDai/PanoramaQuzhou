using System;
using System.Collections.Generic;

namespace QZCHY.PanoramaQuzhou.Core.Domain
{

    public class AccountUser : BaseEntity
    {

        public AccountUser()
        {
            this.AccountUserGuid = Guid.NewGuid();          
        }
        

        public string NickName { get; set; }

        public bool Active { get; set; }

        public Guid AccountUserGuid { get; set; }
           
        public string LastIpAddress { get; set; }

        public DateTime? LastActivityDate { get; set; }

        public DateTime? LastLoginDate { get; set; }        

        public bool IsSystemAccount { get; set; }

        public string SystemName { get; set; }

    }
}
