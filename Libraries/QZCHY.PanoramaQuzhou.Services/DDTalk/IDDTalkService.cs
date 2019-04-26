using DingTalk.Api.Response;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QZCHY.PanoramaQuzhou.Services.DDTalk
{
    public interface IDDTalkService
    {
       

        string  GetUserId(string authCode);

        OapiUserGetResponse GetUserInfo(string authCode);
    }
}
