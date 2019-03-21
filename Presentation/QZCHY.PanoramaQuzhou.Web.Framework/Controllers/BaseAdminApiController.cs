using QZCHY.PanoramaQuzhou.Core;
using QZCHY.PanoramaQuzhou.Core.Domain.Accounts;
using QZCHY.PanoramaQuzhou.Core.Infrastructure;
using QZCHY.PanoramaQuzhou.Web.Framework.Security;
using System.Web.Http;
using System.Web.Http.Controllers;

namespace QZCHY.PanoramaQuzhou.Web.Framework.Controllers
{
    //[QMHttpsRequirement(SslRequirement.Yes)]
    [AdminValidateIpAddress]
    [QMAdminAuthorize]
    public class BaseAdminApiController : BaseApiController
    {
        protected override void Initialize(HttpControllerContext controllerContext)
        {
            //set work context to admin mode
            EngineContext.Current.Resolve<IWorkContext>().IsAdmin = true;
            base.Initialize(controllerContext);
        }
    }

    /// <summary>
    /// 后台管理API 角色验证
    /// </summary>
    public class QMAdminAuthorizeAttribute : AuthorizeAttribute
    {
        public QMAdminAuthorizeAttribute()
        {
            Roles = SystemAccountUserRoleNames.Registered;
        }

        public override void OnAuthorization(HttpActionContext actionContext)
        {
            base.OnAuthorization(actionContext);
        }

        protected override bool IsAuthorized(HttpActionContext actionContext)
        {
            return base.IsAuthorized(actionContext);
        }
    }
}
