using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common.Enums.User
{
    public enum DutySystemStatusEnum
    {
        [Description("پایان خدمت")]
        EndCard = 1,
        [Description("معافیت")]
        Exemption = 2,
    }
}
