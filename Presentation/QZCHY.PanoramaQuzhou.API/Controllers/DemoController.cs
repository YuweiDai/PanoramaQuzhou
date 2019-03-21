using QZCHY.PanoramaQuzhou.Core;
using QZCHY.PanoramaQuzhou.Core.Domain.Accounts;
using QZCHY.PanoramaQuzhou.Core.Domain.Common;
using QZCHY.PanoramaQuzhou.Core.Domain.Security;
using QZCHY.PanoramaQuzhou.Services.Accounts;
using QZCHY.PanoramaQuzhou.Services.Authentication;
using QZCHY.PanoramaQuzhou.Services.Configuration;
using QZCHY.PanoramaQuzhou.Services.Security;
using System;
using System.Collections.Generic;
using System.Data.Entity.Spatial;
using System.IO;
using System.Linq;
using System.Text;
using System.Web.Http;

namespace QZCHY.PanoramaQuzhou.API.Controllers
{
    [RoutePrefix("Demo")]
    public class DemoController : ApiController
    {
        private readonly IAuthenticationService _authenticationService;
        private readonly IAccountUserService _accountUserService;
        private readonly IAccountUserRegistrationService _accountUserRegistrationService;
        //private readonly IGenericAttributeService _genericAttributeService;
        //private readonly IWorkflowMessageService _workflowMessageService;
        private readonly IEncryptionService _encryptionService;

        private readonly IWebHelper _webHelper;
        private readonly IWorkContext _workContext;
        private readonly AccountUserSettings _accountUserSettings;
        private readonly CommonSettings _commonSettings;
        private readonly SecuritySettings _securitySettings;
        private readonly ISettingService _settingService;

        public DemoController()
        {

        }

        public DemoController(IAuthenticationService authenticationService, IAccountUserService customerService,
            IAccountUserRegistrationService customerRegistrationService,
        IEncryptionService encryptionService,  
        IWebHelper webHelper,
            IWorkContext workContext,
        AccountUserSettings customerSettings, CommonSettings commonSettings, SecuritySettings securitySettings, ISettingService settingService
            )
        {
            _authenticationService = authenticationService;
            _accountUserService = customerService;
            _accountUserRegistrationService = customerRegistrationService;
            _encryptionService = encryptionService;

            _webHelper = webHelper;
            _workContext = workContext;
            _accountUserSettings = customerSettings;

            _commonSettings = commonSettings;
            _securitySettings = securitySettings;
            _settingService = settingService;
        }

        [HttpGet]
        [Route("settings")]
        public IHttpActionResult GetAll()
        { 

            _settingService.SaveSetting<AccountUserSettings>(_accountUserSettings);

            _securitySettings.EncryptionKey = "qzczjwithqzghchy";
            _settingService.SaveSetting(_securitySettings);

            _commonSettings.TelAndMobliePartten = @"^(0[0-9]{2,3}\-)?([2-9][0-9]{6,7})+(\-[0-9]{1,4})?$|(^(13[0-9]|15[0|3|6|7|8|9]|18[0-9])\d{8}$)";
            _commonSettings.Time24Partten = @"^((1|0?)[0-9]|2[0-4]):([0-5][0-9])";

            _settingService.SaveSetting<CommonSettings>(_commonSettings);
             

            _settingService.SaveSetting(_accountUserSettings);

            return Ok("配置保存成功！");
        }
  
    }
}