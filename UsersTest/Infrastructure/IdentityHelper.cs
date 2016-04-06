﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Microsoft.AspNet.Identity.Owin;
using System.Security.Claims;
using System.Reflection;


namespace UsersTest.Infrastructure
{
    public static class IdentityHelper
    {
        public static MvcHtmlString GetUserName(this HtmlHelper html, string id)
        {
            AppUserManager mgr = HttpContext.Current.GetOwinContext().GetUserManager<AppUserManager>();
            return new MvcHtmlString(mgr.FindByIdAsync(id).Result.UserName);
        }
        public static MvcHtmlString ClaimType(this HtmlHelper html, string claimtype)
        {
            FieldInfo[] fields = typeof(ClaimTypes).GetFields();
            foreach(FieldInfo field in fields)
            {
                if(field.GetValue(null).ToString() == claimtype)
                {
                    return new MvcHtmlString(field.Name);
                }
            }
            return new MvcHtmlString(string.Format("{0}", claimtype.Split('/', '.').Last()));
        }
    }
}