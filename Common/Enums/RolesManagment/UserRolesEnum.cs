using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common.Enums.RolesManagment
{
    public enum UserRolesEnum
    {

        [Description("کاربر حقیقی")]
        UserReal = 1,
        [Description("کاربر حقوقی")]
        UserLegal = 2,


        [Description("ادمین کل سیستم")]
        AdminSystem,

        [Description("ادمین کل سازمان")]
        [ClaimLevel("Organization")]
        [ClaimLocation(claimLocation: "AdminGeneralOrganization.OrganizationId")]
        AdminGeneralOrganization,


        [Description("ادمین سازمان")]
        [ClaimLevel("Organization")]
        [ClaimLocation(claimLocation: "AdminOrganization.OrganizationId")]
        AdminOrganization,

        
    }

}
