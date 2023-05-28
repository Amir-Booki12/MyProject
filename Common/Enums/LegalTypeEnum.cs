using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common.Enums
{
    public enum LegalTypeEnum
    {
        [Description("کارخانه")]
        Factory = 1,
        [Description("آزمایشگاه")]
        Labratory = 2,
        [Description("پیمانکار")]
        Contractor = 3,
        [Description("مرغ داران")]
        PoultryFarmers = 4,
        [Description("وارد کننده")]
        Importer = 5,
    }
}
