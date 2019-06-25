using QZCHY.PanoramaQuzhou.Core;
using QZCHY.PanoramaQuzhou.Core.Domain.Accounts;
using QZCHY.PanoramaQuzhou.Services.Accounts;
using QZCHY.PanoramaQuzhou.Services.DDTalk;
using System;
using System.Web.Http;

namespace QZCHY.PanoramaQuzhou.API.Controllers
{
    [RoutePrefix("Accounts")]
    public class AccountController : ApiController
    {
        private readonly IWebHelper _webHelper;
        private readonly IAccountUserService _accountUserService;
        private readonly IDDTalkService _ddTalkService;

        public AccountController(IWebHelper webHelper, IAccountUserService accountUserService, IDDTalkService ddTalkService)
        {
            this._webHelper = webHelper;
            this._accountUserService = accountUserService;
            this._ddTalkService = ddTalkService;
        }

        [Route("SignIn")]
        [HttpGet]
        public IHttpActionResult LoggingUser(string authCode = "")
        {
            if (string.IsNullOrEmpty(authCode)) return BadRequest("AuthCode is invalid");

            var dingdingUserInfo = _ddTalkService.GetUserInfo(authCode);
            if (dingdingUserInfo.IsError) return BadRequest("Get UserInfo Error ,because " + dingdingUserInfo.ErrMsg);

            var account = _accountUserService.GetAccountUserByDDUserId(dingdingUserInfo.Userid);
            if (account != null)
            {
                account.LastActivityDate = DateTime.Now;
                account.LastLoginDate = DateTime.Now;
                account.LastIpAddress = _webHelper.GetCurrentIpAddress();
                account.FirstTime = false;
                _accountUserService.UpdateAccountUser(account);
            }
            else
            {
                account = new AccountUser
                {
                    FirstTime = true,
                    Active = true,
                    DDUserId = dingdingUserInfo.Userid,
                    NickName = dingdingUserInfo.Name,
                    LastActivityDate = DateTime.Now,
                    LastLoginDate = DateTime.Now,
                    LastIpAddress = _webHelper.GetCurrentIpAddress(),
                };
                _accountUserService.InsertAccountUser(account);
            }

            return Ok("Guid:" + account.AccountUserGuid);
        }

        [HttpGet]
        [Route("{guid}")]
        public IHttpActionResult CheckFirstUser(string guid)
        {
            var account = _accountUserService.GetAccountUserByGuid(new Guid(guid));

            if (account == null || account.FirstTime) return Ok("true");
            else return Ok("false");
        }
    }
}
