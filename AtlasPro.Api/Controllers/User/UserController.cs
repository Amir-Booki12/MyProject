using System.Threading.Tasks;
using Application.BusinessLogic;
using Application.Services.InterfaceClass.User;
using Application.ViewModels;
using Application.ViewModels.User;
using Application.ViewModels.User.PrimaryInformation;
using Application.ViewModels.User.RolesClaims;
using Common.Enums;
using Common.Enums.RolesManagment;
using Infrastructure.Security;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace SOP.Api.Controllers.User
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ApiController
    {
        private readonly IUserAccountService _userAccountService;
        private readonly ILogger<UserController> _logger;
        //private readonly NLog.Logger _logger = NLog.LogManager.GetCurrentClassLogger();
        public UserController(IUserAccountService userAccountService,
            ILogger<UserController> logger)
        {
            _userAccountService = userAccountService;
            _logger = logger;
        }


        //[HttpPost("RegisterLegalUser")]
        //[PermissionChecker(nameof(UserRolesEnum.SupperAdmin), nameof(UserRolesEnum.AdminProvince))]
        //public async Task<IActionResult> RegisterUser([FromBody] TestViewModel testView)
        //{
        //    var _data = new BusinessLogicResult<int>(succeeded: true, result: 0);
        //    return ApiResult(_data);
        //}

        /// <summary>
        /// تغییر تصویر پروفایل
        /// </summary>
        //[ProducesResponseType(statusCode: 200, type: typeof(bool))]
        //[HttpPost("[action]")]
        //[PermissionChecker]
        //public async Task<IActionResult> ChangeUserProfilePic([FromForm] ChangeProfilePicViewModel model)
        //{
        //    return ApiResult(await _userPrimaryInformationService.ChangeUserProfilePic(
        //        model,
        //        User));
        //}

        /// <summary>
        /// ثبت اطلاعات کاربر توسط کاربر حقوقی در زمان ثبت اعضا
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        //[ProducesResponseType(statusCode: 200, type: typeof(bool))]
        //[HttpPost("[action]")]
        //[PermissionChecker(nameof(UserRolesEnum.ExpertUnionnMainLocation),
        //                   nameof(UserRolesEnum.AdminUnionMainLocation),
        //                   nameof(UserRolesEnum.ManagerUnionMainLocation),
        //                   nameof(UserRolesEnum.UserLegal))]
        //public async Task<IActionResult> RegisterUserByAdmin([FromBody] RequestRegisterBaseInfoUserViewModel request)
        //{
        //    return ApiResult(await _userPrimaryInformationService.RegisterUserByAdmin(request));
        //}

        /// <summary>
        /// گرفتن لیست role and claims کاربر جاری
        /// </summary>
        /// <returns></returns>
        [ProducesResponseType(statusCode: 200, type: typeof(bool))]
        [HttpGet("[action]")]
        [PermissionChecker]
        public async Task<IActionResult> GetUserRolesClaims()
        {
            _logger.LogInformation("GetUserRolesClaims");
            return ApiResult(await _userAccountService.GetUserRolesClaims(User));
        }

        /// <summary>
        ///  دادن نقش به کاربر حقیقی
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        //[HttpPost("[action]")]
        //[PermissionChecker(nameof(UserRolesEnum.SupperAdmin),
        //                   nameof(UserRolesEnum.ExpertUnionnMainLocation),
        //                   nameof(UserRolesEnum.AdminUnionMainLocation),
        //                   nameof(UserRolesEnum.ManagerUnionMainLocation))]
        //public async Task<IActionResult> SetUserRoleAndClaim([FromBody] RequestSetUserRoleAndClaimViewModel model)
        //{
        //    return ApiResult(await _userAccountService.SetUserRoleAndClaim(model));
        //}

        /// <summary>
        ///  دریافت لیست کاربران به همراه نقش آنها
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        //[HttpGet("[action]")]
        //[PermissionChecker(nameof(UserRolesEnum.SupperAdmin),
        //                   nameof(UserRolesEnum.ExpertUnionnMainLocation),
        //                   nameof(UserRolesEnum.AdminUnionMainLocation),
        //                   nameof(UserRolesEnum.ManagerUnionMainLocation))]
        //public async Task<IActionResult> GetUsersRolesAndClaims(string NationalCode)
        //{
        //    return ApiResult(await _userAccountService.GetUsersRolesAndClaims(NationalCode));
        //}

        /// <summary>
        ///  دریافت لیست کاربران حقیقی
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        [HttpPost("[action]")]
        public async Task<IActionResult> GetRealUserInformationList([FromBody] RequestGetAllRealUserListViewModel model)
        {
            return ApiResult(await _userAccountService.GetRealUserInformationList(model));
        }



    }
}
