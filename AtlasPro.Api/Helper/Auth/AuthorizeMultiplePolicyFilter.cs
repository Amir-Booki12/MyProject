using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace SOP.Api.Helper.Auth
{
    public class AuthorizeMultiplePolicyFilter : IAsyncAuthorizationFilter
    {
        private readonly IAuthorizationService _authorization;
        public string Policy { get; private set; }
        public bool IsAll { get; set; }
        public AuthorizeMultiplePolicyFilter(string policy, bool isAll, IAuthorizationService authorization)
        {
            Policy = policy;
            _authorization = authorization;
            IsAll = isAll;
        }

        public async Task OnAuthorizationAsync(AuthorizationFilterContext context)
        {
            var policies = Policy.Split(";").ToList();
            var isAuthenticated = context.HttpContext.User.Identity.IsAuthenticated;
            if (IsAll)
            {
                foreach (var policy in policies)
                {
                    var authorized = await _authorization.AuthorizeAsync(context.HttpContext.User, policy);
                    if (isAuthenticated && !authorized.Succeeded)
                    {
                        context.Result = new StatusCodeResult(statusCode: 403);
                        return;
                    }
                    else
                    {
                        context.Result = new UnauthorizedResult();
                        return;
                    }
                }
            }
            else
            {
                foreach (var policy in policies)
                {
                    var authorized = await _authorization.AuthorizeAsync(context.HttpContext.User, policy);
                    if (authorized.Succeeded)
                    {
                        return;
                    }
                }

                context.Result = isAuthenticated ? new StatusCodeResult(statusCode: 403) : new UnauthorizedResult();
                return;
            }
        }
    }
}
