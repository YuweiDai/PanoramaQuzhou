using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Web.Http;

namespace QZCHY.PanoramaQuzhou.API.Controllers
{
    [RoutePrefix("vtiles")]
    public class VMapController : ApiController
    {

        [HttpGet]
        [Route("map/{z}/{x}/{y}")]
        public HttpResponseMessage GetMvt(int x = 0, int y = 0, int z = 0, int v = 0)
        {
            string url = string.Format("http://map.zjditu.cn/vtiles/maps/tdt_zj/{0}/{1}/{2}.mvt?v={3}", z, x, y, v);

            var httpReq = HttpWebRequest.Create(url);
            httpReq.Method = "Get";

            var httpResponse = httpReq.GetResponse() as HttpWebResponse;

            //输出到浏览器
            try
            {
                var stream = httpResponse.GetResponseStream();
                HttpResponseMessage response = new HttpResponseMessage(HttpStatusCode.OK);
                response.Content = new StreamContent(stream);
                response.Content.Headers.ContentType = new MediaTypeHeaderValue("application/x-protobuf");
                return response;
            }
            catch
            {
                return new HttpResponseMessage(HttpStatusCode.NoContent);
            }
        }


        [HttpGet]
        [Route("fonts/{fontstack}/{range}")]
        public HttpResponseMessage GetPbf(string fontstack = "", string range = "")
        {
            string url = string.Format("http://map.zjditu.cn/vtiles/fonts/{0}/{1}.pbf", fontstack, range);

            var httpReq = HttpWebRequest.Create(url);
            httpReq.Method = "Get";

            var httpResponse = httpReq.GetResponse() as HttpWebResponse;

            //输出到浏览器
            try
            {
                var stream = httpResponse.GetResponseStream();
                HttpResponseMessage response = new HttpResponseMessage(HttpStatusCode.OK);
                response.Content = new StreamContent(stream);
                response.Content.Headers.ContentType = new MediaTypeHeaderValue("application/octet-stream");
                return response;
            }
            catch
            {
                return new HttpResponseMessage(HttpStatusCode.NoContent);
            }
        }

    }
}
