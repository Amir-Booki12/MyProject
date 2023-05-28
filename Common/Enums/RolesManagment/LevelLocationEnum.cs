using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common.Enums.RolesManagment
{
    public enum LevelLocationEnum
    {
        [Description("استان")]
        Province = 1,

        [Description("شهرستان")]
        County = 2,

        [Description("شهر یا روستا")]
        CityOrVillage = 3,
    }
}
