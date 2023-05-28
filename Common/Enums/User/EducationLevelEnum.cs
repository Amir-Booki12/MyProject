using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common.Enums.User
{
    public enum EducationLevelEnum
    {
        [Description("فوق دکترا")]
        PhdPlus = 1,

        [Description("دکترا")]
        Phd = 2,

        [Description("کارشناسی ارشد")]
        Master = 3,

        [Description("کارشناسی")]
        Bachelor = 4,

        [Description("فوق دیپلم")]
        CertificatePlus = 5,

        [Description("دیپلم")]
        Certificate = 6,

        [Description("سیکل")]
        MiddleSchoolDegree = 7,

        [Description("ابتدایی")]
        Elementary = 8,

        [Description("بی سواد")]
        Illiterate = 9,
    }
}
