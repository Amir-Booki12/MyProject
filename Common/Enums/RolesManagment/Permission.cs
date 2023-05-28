using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common.Enums.RolesManagment
{
    public enum Permission
    {
        //کارخانه
        Factory_CRUD = 1,
        Factory_Report,

        //آزمایشگاه
        Labratory_CRUD,
        Labratory_Report,

        //پیمانکار
        Contractor_CRUD,
        Contractor_Report,

        //اشخاص حقیقی
        UserReal_CRUD,
        UserReal_Report,

        //اتحادیه

        /// <summary>
        /// تأیید ثبت نامی‌ها
        /// </summary>
        Union_VerificationRegistrations,
        Union_CRUD,
        Union_Report,

        //جهاد کشاورزی
    }
}
