﻿using LuxMed.BusinessLogic.Interfaces;
using LuxMed.BusinessLogic;
using LuxMed.Domain.Entities.Enums;
using LuxMed.Extension;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;
using LuxMed.Domain.Entities.User;

namespace LuxMed.Attributes
{
    public class AdminModeAttribute :ActionFilterAttribute
    {
        private readonly ISession _sessionBusinessLogic;
        public AdminModeAttribute()
        {
            var businessLogic = new BussinessLogic();
            _sessionBusinessLogic = businessLogic.GetSessionBL();
        }

        public override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            var apiCookie = HttpContext.Current.Request.Cookies["X-KEY"];
            if (apiCookie != null)
            {
                var profile = _sessionBusinessLogic.GetUserByCookie(apiCookie.Value);
                if (profile != null && profile.Level == URole.admin)
                {
                    HttpContext.Current.SetMySessionObject(profile);
                }
                else
                {
                    filterContext.Result = new RedirectToRouteResult(new RouteValueDictionary(new { controller = "Home", action = "Home" }));
                }
            }
        }
    }
}
