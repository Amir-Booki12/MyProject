using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Common.Enum;
using Common.Enums;
using Framework;
using Application.ViewModels.User.PrimaryInformation;
using Common.Enums.User;

namespace Application.ViewModels.User
{
    public class GetUserAccountPrimaryInformationViewModel
    {
        public int Id { get; set; }
        public NatureTypeUserEnum? NatureTypeUser { get; set; }
        public string? NatureTypeUserTitle => NatureTypeUser.GetEnumDescription();
        public string Name { get; set; }
        public string UserName { get; set; }
        public string Email { get; set; }
        public string MobileNumber { get; set; }
        
        public string? PhoneNumber { get; set; }
        public string? PhoneNumber2 { get; set; }
        public string? TellNumber { get; set; }
        public string? TellNumber2 { get; set; }

        public int? ProvinceId { get; set; }
        public string? ProvinceTitle { get; set; }
        public int? CountyId { get; set; }
        public string? CountyTitle { get; set; }

        public int? CityOrVilageId { get; set; }
        public string CityOrVilageTitle { get; set; }
        public string? Address { get; set; }
        public string? PostalCode { get; set; }
        public double? Lat { get; set; }
        public double? Lng { get; set; }
        public string? PicProfile { get; set; }
        public StatusEnum? Status { get; set; }
        public string StatusTitle => Status.GetEnumDescription();
        public string AboutUse { get; set; }


        public string? WebSite { get; set; }
        public string? Instagram { get; set; }
        public string? Telegram { get; set; }
        public string? LinkIn { get; set; }
    }

    public class GetRealUserAccountPrimaryInformationViewModel : GetUserAccountPrimaryInformationViewModel
    {
        public string LastName { get; set; }
        public string? FatherName { get; set; }
        public string NationalCode { get; set; }
        public string? BirthCertificatId { get; set; }
        public string? BirthCertificatIssuedBy { get; set; }
        public DateTime? BirthDate { get; set; }
        public string? BirthDateAsShamsi => BirthDate.ConvertMiladiToJalali();
        public MaritalStatusEnum? MaritalStatus { get; set; }
        public string? MaritalStatusTitle => MaritalStatus.GetEnumDescription();
        public GenderEnum? Gender { get; set; }
        public string? GenderTitle => Gender.GetEnumDescription();
        public DutySystemStatusEnum? DutySystemStatus { get; set; }
        public string? DutySystemStatusTitle => DutySystemStatus.GetEnumDescription();
        public EducationLevelEnum? EducationStatus { get; set; }
        public string? EducationStatusTitle => EducationStatus.GetEnumDescription();

        public FieldOfStudyViewModel FieldOfStudy { get; set; }
        public int FieldOfStudyId { get; set; }

        /// <summary>
        /// تصویر شناسنامه
        /// </summary>
        public string BirthCertificateImage { get; set; }

        /// <summary>
        /// تصویر کارت ملی
        /// </summary>
        public string NationalCardImage { get; set; }

        public int ProvinceId { get; set; }
        public string ProvinceTitle { get; set; }
        public int CountyId { get; set; }
        public string CountyTitle { get; set; }
    }
    
    public class GetLegalUserAccountPrimaryInformationViewModel : GetUserAccountPrimaryInformationViewModel
    {
        public NatureTypeUserEnum NatureTypeUser { get; set; }
        public string NatureTypeUserTitle => NatureTypeUser.GetEnumDescription();
        public string NationalId { get; set; }
        public string EconomicCode { get; set; }
        public string RegistrationNumber { get; set; }
        public DateTime? CompanyRegistrationDate { get; set; }
        public string? CompanyRegistrationDateAsShamsi => CompanyRegistrationDate.ConvertMiladiToJalali();
        public int? EstablishedYear { get; set; }
        public string CompanyRegistrationPlace { get; set; }

        public string? PicProfile { get; set; }



    }

   
}
