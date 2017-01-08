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
    public class CustomAuthorizeAttribute : AuthorizeAttribute
    {
        public override void OnAuthorization(HttpActionContext actionContext)
        {
            var identity = HttpContext.Current.User?.Identity as FormsIdentity;
            var response = new HttpResponseMessage(HttpStatusCode.Unauthorized);
            if(identity == null)
            {
                response.Content = new StringContent("请登录");
                actionContext.Response = response;
            }
            else if(!identity.IsAuthenticated)
            {
                response.Content = new StringContent("身份验证失败");
                actionContext.Response = response;
            }
            else
            {
                string[] roles = identity.Ticket.UserData.Split(',');
                HttpContext.Current.User = new GenericPrincipal(identity, roles);
            }
            base.OnAuthorization(actionContext);
        }
    }
}