using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common.Enums.User
{
    public enum MaritalStatusEnum
    {
        [Description("متأهل")]
        Married = 1,
        [Description("مجرد")]
        Single = 2,
    }
}
