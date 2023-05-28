using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common.Enums
{
    public enum StatusEnum
    {
        [Description("در انتظار تعیین وضعیت")]
        WaitingStatus = 0,
        [Description("فعال")]
        Active = 1,
        [Description("غیرفعال")]
        Notctive = 2,
        [Description("مسدود")]
        Blocked = 3,
        [Description("رد جهت اصلاح")]
        RejectForEdit = 4,
    }
}
