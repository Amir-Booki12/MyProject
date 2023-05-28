﻿using Common.GetClaimUtils;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Security
{
    public class PermissionChecker : AuthorizeAttribute, IAsyncAuthorizationFilter
    {
        List<string> _UserRoles;
        public PermissionChecker(params string[] Role)
        {
            _UserRoles = Role.ToList();
        }

        public async Task OnAuthorizationAsync(AuthorizationFilterContext context)
        {
            if (HasAllowAnonymous(context))
                return;

            if (context.HttpContext.User.Identity.IsAuthenticated)
            {
                if (!(_UserRoles == null || _UserRoles.Count == 0))
                {
                    if (await UserHasPermission(context) == false)
                    {
                        context.Result = new ForbidResult();
                    }
                }
            }
            else
            {
                context.Result = new UnauthorizedObjectResult("Unauthorize");
            }
        }

        private bool HasAllowAnonymous(AuthorizationFilterContext context)
        {
            var metaData = context.ActionDescriptor.EndpointMetadata.OfType<dynamic>().ToList();
            bool hasAllowAnonymous = false;
            foreach (var f in metaData)
            {
                try
                {
                    hasAllowAnonymous = f.TypeId.Name == "AllowAnonymousAttribute";
                    if (hasAllowAnonymous)
                        break;
                }
                catch
                {
                    // ignored
                }
            }

            return hasAllowAnonymous;
        }

        private async Task<bool> UserHasPermission(AuthorizationFilterContext context)
        {
            //var user = context.HttpContext.User.GetUserId();
            //if (user == null || user == 0)
            //    return false;

            var userRoles = context.HttpContext.User.GetUserRolesValue();

            foreach(var userrole in userRoles)
            {
                if (_UserRoles.Contains(userrole))
                    return true;
            }
            return false;
        }

    }
}
