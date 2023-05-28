using Common.Enum;
using Common.Enums;
using Common.Enums.User;
using Framework;
using Microsoft.AspNetCore.Http;
using System;

namespace Application.ViewModels.User.PrimaryInformation
{
    public class SetRealUserPrimaryInformationViewModel : SetAddressViewModel
    {
        public string Name { get; set; }
        public string LastName { get; set; }
        public string? FatherName { get; set; }
        public GenderEnum? Gender { get; set; }
        public string? BirthCertificatId { get; set; }

        /// <summary>
        /// تصویر کارت ملی
        /// </summary>
        public IFormFile NationalCardImage { get; set; }
        /// <summary>
        /// تصویر شناسنامه
        /// </summary>
        public IFormFile BirthCertificateImage { get; set; }

        public string BirthDateAsShamsi { get; set; }
        public DateTime? BirthDate => BirthDateAsShamsi.ConvertJalaliToMiladi();
        public string? BirthCertificatIssuedBy { get; set; }
        public MaritalStatusEnum? MaritalStatus { get; set; }
        public EducationLevelEnum? EducationStatus { get; set; }
        //public FieldOfStudyViewModel FieldOfStudy { get; set; }
        /// <summary>
        /// رشته تحصیلی
        /// </summary>
        public int? FieldOfStudyId { get; set; }
        public DutySystemStatusEnum? DutySystemStatus { get; set; }
        /// <summary>
        /// شماره تماس
        /// </summary>
        public string MobileNumber { get; set; }
        /// <summary>
        /// تلفن 1
        /// </summary>
        public string TellNumber { get; set; }


    }

    public class FieldOfStudyViewModel
    {
        public int Id { get; set; }
        public EducationLevelEnum EducationLevel { get; set; }
        public string EducationLevelTitle => EducationLevel.GetEnumDescription();
        public string Title { get; set; }
    }

    public class ChangeProfilePicViewModel
    {
        /// <summary>
        /// تصویر
        /// </summary>
        public IFormFile PicProfile { get; set; }
    }
}
