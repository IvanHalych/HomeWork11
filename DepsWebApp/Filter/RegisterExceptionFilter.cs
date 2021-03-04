using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using DepsWebApp.Models;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.AspNetCore.Mvc.ViewFeatures;
using Microsoft.Extensions.Hosting;

namespace DepsWebApp.Filter
{
#pragma warning disable 1591
    public class RegisterExceptionFilter : ExceptionFilterAttribute
    {
        public override void OnException(ExceptionContext context)
        {
            if (!context.ExceptionHandled)
            {
                var result =
                    new JsonResult(new ExceptionModel(context.Exception.HResult, context.Exception.Message))
                    {
                        StatusCode = (int)HttpStatusCode.Unauthorized
                    };
                context.Result = result;
                context.ExceptionHandled = true;
            }

        }
    }
#pragma warning restore 1591
}
