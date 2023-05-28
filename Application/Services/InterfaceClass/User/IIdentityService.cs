using System.Collections.Generic;
using System.Security.Claims;
using System.Threading.Tasks;
using Domain.Entities.UserAgg;

namespace Application.Services.InterfaceClass.User
{
    public interface IIdentityService
    {
        public int addUserToIdentity(string username, string pass, string email, string phoneNumber);
        Task<int> AddRoleToUserIdentity(ApplicationUser user, string roleName);
        Task<int> AddUserToIdentity(ApplicationUser initApplicationUser, string password = null);
        Task<int> AddClaimToUser(ApplicationUser user, Claim[] claims);
        Task<List<Claim>> GetUserClaims(string userName);

    }
}