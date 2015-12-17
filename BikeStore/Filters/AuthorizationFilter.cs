using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Principal;
using System.Web;

namespace BikeStore.Filters
{
    public class AuthorizationFilter : System.Web.Mvc.IAuthorizationFilter
    {
        public void OnAuthorization(System.Web.Mvc.AuthorizationContext filterContext)
        {
            string role = filterContext.HttpContext.Session["LoggedRole"] as string;
            string username = filterContext.HttpContext.Session["LoggedEmail"] as string;

            if (username != null ){
                filterContext.HttpContext.User = new GenericPrincipal(new GenericIdentity(username), new [] { role });
            }
        }
    }
}