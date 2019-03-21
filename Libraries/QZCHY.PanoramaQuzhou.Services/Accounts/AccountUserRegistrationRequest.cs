using QZCHY.PanoramaQuzhou.Core.Domain.Accounts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QZCHY.PanoramaQuzhou.Services.Accounts
{
    public class AccountUserRegistrationRequest
    {
        public AccountUser AccountUser { get; set; }
      
        public string Username { get; set; }

        public string Password { get; set; }
        

        public bool IsApproved { get; set; }

    }
}
