using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common.Enums.Location
{
    public enum CityOrVilageTypeEnum
    {
        [Description("روستا")]
        Village = 1,

        [Description("شهر")]
        City = 2,

        [Description("دهستان")]
        RuralDistrict = 3
    }
}
