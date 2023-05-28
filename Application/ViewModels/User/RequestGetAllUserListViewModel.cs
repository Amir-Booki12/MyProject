using Application.ViewModels.Public;
using Common.Enums;
using Common.Enums.User;
using System.Text.Json.Serialization;

namespace Application.ViewModels.User
{
    public class RequestGetAllUserListViewModel : RequestGetListViewModel
    {
        public NatureTypeUserEnum? NatureTypeUser { get; set; }
        public string? NationalCode { get; set; }
        public StatusEnum? Status { get; set; }
    }


    public class RequestGetAllRealUserListViewModel : RequestGetListViewModel
    {
        public int? Id { get; set; }
        public string? Name { get; set; }
        public string? LastName { get; set; }
        public string? NationalCode { get; set; }
        public int? BirthCertificatId { get; set; }
        public int ProvinceId { get; set; }
        public int CountyId { get; set; }
        public int CityOrVillageId { get; set; }
        public StatusEnum? Status { get; set; }

    }
    
    public class RequestGetAllLegalUserListViewModel : RequestGetListViewModel
    {
        public string? Name { get; set; }
        public string? NationalId { get; set; }
        public NatureTypeUserEnum? NatureTypeUser { get; set; }
        
        public int ProvinceId { get; set; }
        public int CountyId { get; set; }
        public int CityOrVillageId { get; set; }
        public StatusEnum? Status { get; set; }

    }
    
 
    
}