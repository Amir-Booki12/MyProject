using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common.Enums.Organizations
{
    public enum OrganizationTypeEnum
    {
        /// <summary>
        /// دولتی
        /// </summary>
        [Description("دولتی")]
        GovernmentalOrganization = 1,
        /// <summary>
        /// خصوصی
        /// </summary>
        [Description("خصوصی")]
        PrivateCompany = 2,
    }
}
