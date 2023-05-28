using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common.Enums.Organizations
{
    public enum GovernmentalOrganizationTypeEnum
    {
        /// <summary>
        /// اداره کل
        /// </summary>
        [Description("اداره کل")]
        GeneralOffice = 1,
        /// <summary>
        /// سازمان شهرستانی
        /// </summary>
        [Description("سازمان شهرستانی")]
        CityOrganization = 2,
        /// <summary>
        /// معاونت
        /// </summary>
        [Description("معاونت")]
        assistanceOffice = 3,
        /// <summary>
        /// مدیریت
        /// </summary>
        [Description("مدیریت")]
        ManagmentOffice = 4,
        /// <summary>
        /// گروه
        /// </summary>
        [Description("گروه")]
        GroupOffice = 5,
        /// <summary>
        /// اداره
        /// </summary>
        [Description("اداره")]
        Office = 6,
        /// <summary>
        /// واحد
        /// </summary>
        [Description("واحد")]
        UnitOffice = 6,
    }
}
