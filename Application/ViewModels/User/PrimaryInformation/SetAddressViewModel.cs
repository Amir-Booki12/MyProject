using Microsoft.AspNetCore.Http;

namespace Application.ViewModels.User.PrimaryInformation
{
    public class SetAddressViewModel
    {
        public int? CityOrVilageId { get; set; }

        public string? Address { get; set; }
        public double? Lat { get; set; }
        public double? Lng { get; set; }
        
        public string? PostalCode { get; set; }


        public string? DomainName { get; set; }
        public IFormFile? Logo { get; set; }

    }

    public class SetContactUsViewModel: AboutUseViewModel
    {
        /// <summary>
        /// تلفن 2
        /// </summary>
        public string? TellNumber2 { get; set; }
        public string? TellNumber { get; set; }

        /// <summary>
        /// فکس 1
        /// </summary>
        public string? FaxNumber { get; set; }

        /// <summary>
        /// فکس 2
        /// </summary>
        public string? FaxNumber2 { get; set; }

        public string? WebSite { get; set; }
        public string? Instagram { get; set; }
        public string? Telegram { get; set; }
        public string? LinkIn { get; set; }
    }

    public class AboutUseViewModel
    {
        public string AboutUse { get; set; }
    }
}