using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Security.Principal;
using System.Web;
using System.Web.Http;
using System.Web.Http.Controllers;
using System.Web.Security;

namespace ContactManager.App_Start
{
    /// <summary>
    /// 自定义Authorize特性
    /// </summary>
    public class CustomAuthorizeAttribute : AuthorizeAttribute
    {
        /// <summary>
        /// 在操作授权时调用
        /// </summary>
        /// <param name="actionContext"></param>
        public override void OnAuthorization(HttpActionContext actionContext)
        {
            var identity = HttpContext.Current.User?.Identity as FormsIdentity;
            var response = new HttpResponseMessage();
            if(identity == null)
            {
                response.StatusCode = HttpStatusCode.Redirect;
                response.Content = new StringContent("请登录");
                response.Headers.Location = new Uri(actionContext.Request.RequestUri, "/api/User");
                actionContext.Response = response;
            }
            else if(!identity.IsAuthenticated)
            {
                response.StatusCode = HttpStatusCode.Unauthorized;
                response.Content = new StringContent("身份验证失败");
                actionContext.Response = response;
            }
            else
            {
                string[] roles = identity.Ticket.UserData.Split(',');
                HttpContext.Current.User = new GenericPrincipal(identity, roles);
                base.OnAuthorization(actionContext);
            }
        }
    }
}