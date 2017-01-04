using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web;
using System.Web.Http.Controllers;
using System.Web.Http.Filters;

namespace ContactManager.App_Start
{
    public class CustomActionFilterAttribute : ActionFilterAttribute
    {
        public override void OnActionExecuting(HttpActionContext actionContext)
        {
            actionContext.ActionArguments["desc"] += "在调用Action之前发生。  " + DateTime.Now.Millisecond;
            base.OnActionExecuting(actionContext);
        }

        public override void OnActionExecuted(HttpActionExecutedContext actionExecutedContext)
        {
            actionExecutedContext.ActionContext.ActionArguments["desc"] = "\r\n在调用Action之后发生。  " + DateTime.Now.Millisecond;
            base.OnActionExecuted(actionExecutedContext);
        }
    }
}