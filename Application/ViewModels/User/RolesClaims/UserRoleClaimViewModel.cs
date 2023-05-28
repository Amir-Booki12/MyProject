using Common.Enums;
using Common.Enums.RolesManagment;
using Common.Enums.User;
using Common.GetClaimUtils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.ViewModels.User.RolesClaims
{
    public class UserBaseInfo
    {
        public bool IsExistUser { get; set; } = false;
        public StatusEnum? StatusUser { get; set; }
        public UserRoleClaimViewModel UserRoleClaim { get; set; }
    }
    public class UserRoleClaimViewModel
    {
        public string NationalCode { get; set; }
        public string FName { get; set; }
        public string LName { get; set; }
        public string PhoneNumber { get; set; }
        public string Pic { get; set; }
        public NatureTypeUserEnum? NatureTypeUser { get; set; }
        public string NatureTypeUserTitle => NatureTypeUser.GetEnumDescription();
        public LegalTypeEnum? LegalType { get; set; }
        public string LegalTypeTitle => LegalType.GetEnumDescription();
        public List<RoleValueUser> Roles { get; set; } //in Common
        public List<ClaimValueUser> Claims { get; set; } //in Common
    }

    public class UserRealViewModel
    {
        public NatureTypeUserEnum NatureTypeUser { get; set; }
        public string Name { get; set; }
        public string LastName { get; set; }
        public string NationalCode { get; set; }
        public string MobileNumber { get; set; }
    }
    public class ApplicationUserViewModel
    {
        public bool IsAuthorizedUser { get; set; }
        public int IdentityUserId { get; set; }
        public NatureTypeUserEnum NatureTypeUser { get; set; }
        public string Name { get; set; }
        public string UserName { get; set; }
        public string PhoneNumber { get; set; }
    }
   
   

    public class RequestSetUserRoleAndClaimViewModel
    {
        public string NationalCode { get; set; }
        public List<RolesClaimsViewModel> RolesClaims { get; set; }
    }
    public class RolesClaimsViewModel
    {
        public UserRolesEnum Role { get; set; }
        public LevelLocationEnum? LevelLocation { get; set; }
        public int? LocationId { get; set; }
    }

    public class ResponseGetUserRoleAndClaimViewModel
    {
        public List<UserRoleAndClaimViewModel> Items { get; set; }
    }

    public class UserRoleAndClaimViewModel : UserRoleViewModel
    {
        public List<ListRolesViewModel>? Roles { get; set; }
        public List<ListClaimsViewModel>? Claims { get; set; }
    }

    public class UserRoleViewModel
    {
        public string NationalCode { get; set; }
        public string FName { get; set; }
        public string LName { get; set; }
    }

    public class ListRolesViewModel
    {
        public UserRolesEnum UserRole { get; set; }
        public string UserRoleStr { get; set; }
        public string UserRoleTitle => UserRole.GetEnumDescription();
    }

    public class ListClaimsViewModel
    {
        public LevelLocationEnum? LevelLocation { get; set; }
        public string LevelLocationTitle => LevelLocation.GetEnumDescription();
        public int LocationId { get; set; }
        public string LocationTitle { get; set; }
        public string ClaimLocationType { get; set; }
        public UserRolesEnum? RoleClaimLocation { get; set; }
        public string RoleClaimLocationTitle => RoleClaimLocation.GetEnumDescription();
    }


}
