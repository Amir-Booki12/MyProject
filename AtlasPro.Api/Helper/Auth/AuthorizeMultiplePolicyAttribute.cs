using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;

namespace Presentation.WebApi
{
    public class AuthorizeMultiplePolicyAttribute : TypeFilterAttribute
    {
        public AuthorizeMultiplePolicyAttribute(string policy, bool IsAll) : base(typeof(AuthorizeMultiplePolicyFilter))
        {
            Arguments = new object[] { policy, IsAll };
        }
    }
}
