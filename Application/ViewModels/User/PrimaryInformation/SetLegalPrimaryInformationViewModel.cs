using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Common.Enums.User;
using Common;

namespace Application.ViewModels.User.PrimaryInformation
{
    public class SetLegalPrimaryInformationViewModel : SetAddressViewModel
    {
        public int? Id { get; set; }
        public string Name { get; set; }
        public string NationalCode { get; set; }
        public string EconomicCode { get; set; }
        [MaxLength(64)]
        public string RegistrationNumber { get; set; }

        public string CompanyRegistrationDateAsShamsi { get; set; }
        public DateTime? CompanyRegistrationDate => CompanyRegistrationDateAsShamsi.ConvertJalaliToMiladi();

        public int? EstablishedYear { get; set; }

        [MaxLength(400)]
        public string CompanyRegistrationPlace { get; set; }


    }
}
