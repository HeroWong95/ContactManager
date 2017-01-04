using ContactManager.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web;
using System.Web.Http;
using System.Web.Security;

namespace ContactManager.Controllers
{
    public class UserController : ApiController
    {
        public HttpResponseMessage Post(UserLogin user)
        {
            if(ModelState.IsValid)
            {
                var response = new HttpResponseMessage();
                if(user.UserName == user.Password)
                {
                    string roles = "Admin,Test";
                    DateTime start = DateTime.Now;
                    DateTime end = start.Add(FormsAuthentication.Timeout);
                    var ticket = new FormsAuthenticationTicket(1, user.UserName, start, end, false, roles);
                    HttpCookie cookie = new HttpCookie(FormsAuthentication.FormsCookieName, FormsAuthentication.Encrypt(ticket));
                    HttpContext.Current.Response.Cookies.Add(cookie);
                    response.StatusCode = HttpStatusCode.Redirect;
                    response.Content = new StringContent("登录成功");
                    response.Headers.Location = new Uri(Request.RequestUri, "/api/Contact/1");
                    return response;
                }
                else
                {
                    response.StatusCode = HttpStatusCode.Unauthorized;
                    response.Content = new StringContent("密码错误");
                    return response;
                }
            }
            else
            {
                string message = ModelState.Values.FirstOrDefault().Errors[0].ErrorMessage;
                return Request.CreateErrorResponse(HttpStatusCode.Unauthorized, message);
            }
        }
    }
}
