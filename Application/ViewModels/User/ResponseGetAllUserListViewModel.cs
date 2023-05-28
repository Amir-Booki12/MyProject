using System;
using System.Collections.Generic;
using Application.ViewModels.Public;
using Common.Enums;
using Common.Enums.User;


namespace Application.ViewModels.User
{
    public class ResponseGetAllUserListViewModel : ResponseGetListViewModel
    {
        public List<GetUserItemViewModel> Items { get; set; }
    }

    public class ResponseGetAllRealUserListViewModel : ResponseGetListViewModel
    {
        public List<GetRealUserItemViewModel> Items { get; set; }
    }
    
    public class ResponseGetAllLegalUserListViewModel : ResponseGetListViewModel
    {
        public List<GetLegalUserItemViewModel> Items { get; set; }
    }

    public class GetUserItemViewModel
    {
        public int Id { get; set; }
        public NatureTypeUserEnum? NatureTypeUser { get; set; }
        public string NatureTypeUserTitle => NatureTypeUser.GetEnumDescription();
        public StatusEnum? Status { get; set; }
        public string StatusTitle => Status.GetEnumDescription();

        public string Name { get; set; }
        public string TellNumber { get; set; }

        public int? CityOrVilageId { get; set; }
        public string CityOrVilageTitle { get; set; }
        public string? Address { get; set; }
        public string? PostalCode { get; set; }
        public double? Lat { get; set; }
        public double? Lng { get; set; }
    }

    public class GetLegalUserItemViewModel : GetLegalUserAccountPrimaryInformationViewModel
    {
    }


    public class GetRealUserItemViewModel : GetRealUserAccountPrimaryInformationViewModel
    {
    }
}