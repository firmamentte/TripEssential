﻿using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace TripEssential.Filters
{
    public class TripEssentialAPIErrorHandler : ExceptionFilterAttribute
    {
        public override void OnException(ExceptionContext context)
        {
            context.HttpContext.Response.StatusCode = 500;
            context.Result = new JsonResult(new ApiErrorResp(context.Exception.Message));

            base.OnException(context);
        }
    }
}
