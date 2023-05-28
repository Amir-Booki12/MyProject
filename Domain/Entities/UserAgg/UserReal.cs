using Domain.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities.UserAgg
{

    [EntityTypeAttribute]
    public class UserReal : ApplicationUser
    {
        //// <summary>
        /// نام خانوادگی
        /// </summary>
        public string LastName { get; set; }
        /// <summary>
        /// نام پدر
        /// </summary>
        public string FatherName { get; set; }
        /// <summary>
        /// شماره شناسنامه
        /// </summary>
        public int? BirthCertificatId { get; set; }
        /// <summary>
        /// کد ملی
        /// </summary>
        public string NationalCode { get; set; }
    }
}
