
using System.IO;
using System;
using System.Linq;
using System.Security.Claims;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace SOP.Api.Helper
{
    public static class Utility
    {
        public static int GetCurrentUserId(this HttpContext httpContext)
        {
            //int.TryParse(httpContext.User.Identity.Name, out int userId);
            int.TryParse(httpContext.User.FindFirst(ClaimTypes.NameIdentifier).Value, out int userId);
            return userId;
        }
    }
}
