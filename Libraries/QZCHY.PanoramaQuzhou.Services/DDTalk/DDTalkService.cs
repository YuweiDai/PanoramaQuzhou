using DingTalk.Api;
using DingTalk.Api.Request;
using DingTalk.Api.Response;
using System;

namespace QZCHY.PanoramaQuzhou.Services.DDTalk
{
    public class DDTalkService : IDDTalkService
    {
       private const string appkey = "dingyxmp0asrxgyqmymz";
        private const string appsecret = "9P3-DvVhEIiIpAXj6qS32L3EPJ1AIbPAA9KdhTI04E19pCqVMpiUIMmx3vAheyA9";

        //private const string appkey = "dingtphwwjh8iitdhnba";
//        private const string appsecret = "3GL0snAqDpc-grzjHdlXAMg87lIoA98y5SlVhrcjwE96TcGdHlrequK-ALdVLnjU";

        private DateTime access_token_expiredTime = DateTime.Now;
        public string access_Token = "";

        private void SetAccessToken()
        {
            if (DateTime.Now >= access_token_expiredTime)
            {
                try
                {
                    DefaultDingTalkClient client = new DefaultDingTalkClient("https://oapi.dingtalk.com/gettoken");
                    OapiGettokenRequest request = new OapiGettokenRequest();
                    request.Appkey = appkey;
                    request.Appsecret = appsecret;
                    request.SetHttpMethod("GET");
                    OapiGettokenResponse response = client.Execute(request);

                    access_Token = response.AccessToken;
                    access_token_expiredTime = DateTime.Now.AddSeconds(response.ExpiresIn - 300);
                }
                catch
                {
                    access_Token = string.Empty;
                    access_token_expiredTime = DateTime.Now.AddSeconds(-1000);
                }
            }
        }

        public string GetUserId(string authCode)
        {
           SetAccessToken();

            IDingTalkClient client = new DefaultDingTalkClient("https://oapi.dingtalk.com/user/getuserinfo");
            OapiUserGetuserinfoRequest request = new OapiUserGetuserinfoRequest();
            request.Code = authCode;
            request.SetHttpMethod("GET");
            OapiUserGetuserinfoResponse response = client.Execute(request, this.access_Token);
            if (response.IsError) return string.Empty;
            else return response.Userid;
        }

        public OapiUserGetResponse GetUserInfo(string authCode)
        {
            var userId = GetUserId(authCode);

            IDingTalkClient client = new DefaultDingTalkClient("https://oapi.dingtalk.com/user/get");
            OapiUserGetRequest request = new OapiUserGetRequest();
            if (string.IsNullOrEmpty(userId)) return new OapiUserGetResponse { ErrCode = "400" ,ErrMsg="get user id error"};
            else
            {
                request.Userid = userId;
                request.SetHttpMethod("GET");
                return client.Execute(request, this.access_Token);

            }
        }        
    }
}
