using Common.Enums;
using Common.Enums.User;
using Domain.Attributes;
using Domain.Entities.LocationsAgg;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities.UserAgg
{
    /// <summary>
    /// کاربر
    /// </summary>
    //[AuditableAttribute]
    public class ApplicationUser : IdentityUser<int>
    {
        public NatureTypeUserEnum? NatureTypeUser { get; set; }
        /// <summary>
        /// کاربر معتبر از SSO
        /// </summary>
        public bool IsAuthorizedUser { get; set; } = true;
        /// <summary>
        /// کد کاربرِی در SSO
        /// </summary>
        public int? IdentityUserId { get; set; }
        /// <summary>
        /// نام
        /// </summary>
        public string Name { get; set; }
        /// <summary>
        /// نام کاربری در SSO
        /// </summary>
        /// <summary>
        /// تصویر پروفایل
        /// </summary>
        public string? PicProfile { get; set; }
        /// <summary>
        /// وضعیت
        /// </summary>
        public StatusEnum? Status { get; set; }
        /// <summary>
        /// شماره تماس
        /// </summary>
        public string MobileNumber { get; set; }
        /// <summary>
        /// تلفن 1
        /// </summary>
        public string TellNumber { get; set; }

        /// <summary>
        /// شهر یا روستا آدرس
        /// </summary>
        public CityOrVilage CityOrVilage { get; set; }
        public int? CityOrVilageId { get; set; }
        /// <summary>
        /// آدرس
        /// </summary>
        public string? Address { get; set; }
        public double? Lat { get; set; }
        public double? Lng { get; set; }
        public string? PostalCode { get; set; }

        public string? WebSite { get; set; }
        public string? Instagram { get; set; }
        public string? Telegram { get; set; }
        public string? LinkIn { get; set; }

        public DateTime? InsertTime { get; set; }
        public DateTime? UpdateTime { get; set; }

    }
}
