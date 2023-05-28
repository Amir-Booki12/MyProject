using Application.BusinessLogic;
using Application.ViewModels.User;
using Application.ViewModels.User.RolesClaims;
using Common.Enums;
using Domain.Entities.UserAgg;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace Application.Services.InterfaceClass.User
{
    public interface IUserAccountService
    {
        Task<IBusinessLogicResult<UserBaseInfo>> GetUserRolesClaims(ClaimsPrincipal user);
        Task<IBusinessLogicResult<ApplicationUser>> FindOrRegisterUser(ApplicationUserViewModel user);
        Task<IBusinessLogicResult<int>> RegisterLegalUser(string userName, string name, string mobileNumber);
        Task<IBusinessLogicResult<UserRealViewModel>> RegisterRealUser(string userName, string firstName, string lastName, string mobileNumber);
        Task<IBusinessLogicResult<bool>> SetUserRoleAndClaim(RequestSetUserRoleAndClaimViewModel model);
        Task<IBusinessLogicResult<ResponseGetUserRoleAndClaimViewModel>> GetUsersRolesAndClaims(string NationalCode);
        Task<IBusinessLogicResult<ResponseGetAllRealUserListViewModel>> GetRealUserInformationList(RequestGetAllRealUserListViewModel model);
        Task<IBusinessLogicResult<ResponseGetAllUserListViewModel>> GetAllUserWithFilter(RequestGetAllUserListViewModel model);
        Task<IBusinessLogicResult<ResponseGetAllRealUserListViewModel>> GetAllRealUserWithFilter(RequestGetAllRealUserListViewModel model);
        Task<IBusinessLogicResult<ResponseGetAllLegalUserListViewModel>> GetAllLegalUserWithFilter(RequestGetAllLegalUserListViewModel model);
    }
}