﻿using QZCHY.PanoramaQuzhou.Core;
using System;
using System.Collections.Generic;

namespace QZCHY.PanoramaQuzhou.Core.Domain.Accounts
{

    public class AccountUser : BaseEntity
    {

        public AccountUser()
        {
            this.AccountUserGuid = Guid.NewGuid();
        }

        /// <summary>
        /// 钉钉用户的唯一Id
        /// </summary>
        public string DDUserId { get; set; }

        public string NickName { get; set; }

        public Guid AccountUserGuid { get; set; }

        public string LastIpAddress { get; set; }

        public DateTime? LastActivityDate { get; set; }

        public DateTime? LastLoginDate { get; set; }

        public string SystemName { get; set; }

        public bool FirstTime { get; set; }


        public bool Active { get; set; }
    }
}
