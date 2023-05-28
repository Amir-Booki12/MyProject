using Common.GetClaimUtils;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Validations.AttributePermition
{
    public class PermistionClaimCheckerAttribute : ValidationAttribute
    {
        public string _ClaimType { get; set; }
        //public object _ClaimValue { get; set; }
        public PermistionClaimCheckerAttribute(string claimtype)//, object claimvalue)
        {
            _ClaimType = claimtype;
            //_ClaimValue = claimvalue;
        }
        public string GetErrorMessage() => $"شما داده‌ای خارج از محدوده دسترسی خود انتخاب کرده‌اید";

        protected override ValidationResult IsValid(
            object value,
            ValidationContext validationContext)
        {            
            var httpContextAccessor = (IHttpContextAccessor)validationContext.GetService(typeof(IHttpContextAccessor));
            var user = httpContextAccessor.HttpContext.User;

            var _claimvalues = user.GetUserClaimsValue(_ClaimType);

            var PropertyValue = ((int)value!);

            if (!_claimvalues.Contains(PropertyValue.ToString()))
            {
                return new ValidationResult(GetErrorMessage());
            }

            return ValidationResult.Success;
        }
    }
}
