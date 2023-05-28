using Domain.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities.UserAgg
{
    [EntityTypeAttribute]
    public class UserLegal : ApplicationUser
    {
        /// <summary>
        /// شناسه ملی
        /// </summary>
        public string NationalId { get; set; }
        /// <summary>
        /// شماره ثبت شرکت
        /// </summary>
        public string RegistrationNumber { get; set; }
        /// <summary>
        /// تاریخ ثبت
        /// </summary>
        public DateTime CompanyRegistrationDate { get; set; }
        /// <summary>
        /// سال تأسیس
        /// </summary>
        public int? EstablishedYear { get; set; }
        /// <summary>
        /// محل ثبت شرکت
        /// </summary>
        public string CompanyRegistrationPlace { get; set; }
        /// <summary>
        /// کد اقتصادی
        /// </summary>
        public string EconomicCode { get; set; }
    }
}
