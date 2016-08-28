using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace OP.MvcView
{
    public class CustomException : FilterAttribute, IExceptionFilter
    {
        public void OnException(ExceptionContext filterContext)
        {
            if (!filterContext.ExceptionHandled)
            {
                var exception = filterContext.Exception;
                filterContext.Result = new RedirectResult("~/Content/Error.html");
                filterContext.ExceptionHandled = true;
            }
        }
    }
}