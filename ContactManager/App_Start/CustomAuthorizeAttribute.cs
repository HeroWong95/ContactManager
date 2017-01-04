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
            if(identity != null && identity.IsAuthenticated)
            {
                string[] roles = identity.Ticket.UserData.Split(',');
                HttpContext.Current.User = new GenericPrincipal(identity, roles);
            }
            else
            {
                base.OnAuthorization(actionContext);
            }
        }
    }
}