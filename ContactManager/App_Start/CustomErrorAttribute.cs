using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web;
using System.Web.Http.Filters;
using System.Net.Http.Formatting;

namespace ContactManager.App_Start
{
    public class CustomErrorAttribute : ExceptionFilterAttribute
    {
        public override void OnException(HttpActionExecutedContext actionExecutedContext)
        {
            //写日志
            //ExceptionCore.Enqueue(actionExecutedContext.Exception)
            var response = new HttpResponseMessage(HttpStatusCode.InternalServerError);
            var obj = new { status = 0, message = ":( 糟了，出现异常了！" };
            response.Content = new ObjectContent(obj.GetType(), obj, new JsonMediaTypeFormatter());
            actionExecutedContext.Response = response;
            //base.OnException(actionExecutedContext);
        }
    }
}
