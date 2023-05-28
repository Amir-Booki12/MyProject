using Application.BusinessLogic;
using Application.Services.InterfaceClass.User;
using Application.Services.Response;
using Application.ViewModels.User;
using Domain.Entities.UserAgg;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using Application.BusinessLogic.Message;
using Application.IRepositories;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using Common.Enums;
using Microsoft.EntityFrameworkCore;
using Application.ViewModels.User.RolesClaims;
using Domain.Entities.LocationsAgg;
using Common.Enums.RolesManagment;
using Common.Enums.User;
using Newtonsoft.Json;
using static QRCoder.PayloadGenerator;
using Common;
using Common.GetClaimUtils;

namespace Application.Services.ConcreateClass.User
{
    public class UserAccountService : ResponseService<UserAccountService>, IUserAccountService
    {
        private readonly IRepository<Province> _provinceRepository;
        private readonly IRepository<County> _countyRepository;
        private readonly IRepository<CityOrVilage> _cityOrVillageRepository;

        private readonly UserManager<ApplicationUser> _userManager;
        private readonly IIdentityService _identityService;
        private readonly IMapper _mapper;
        private readonly ILogger<UserAccountService> _logger;

        public UserAccountService(IUnitOfWork unitOfWork, IMapper mapper, IIdentityService identityService,
            UserManager<ApplicationUser> userManager, ILogger<UserAccountService> logger) : base(logger)
        {
            _provinceRepository = unitOfWork.GetRepository<Province>();
            _countyRepository = unitOfWork.GetRepository<County>();
            _cityOrVillageRepository = unitOfWork.GetRepository<CityOrVilage>();

            _userManager = userManager;
            _identityService = identityService;
            _mapper = mapper;
            _logger = logger;
        }

        public async Task<IBusinessLogicResult<UserBaseInfo>> GetUserRolesClaims(ClaimsPrincipal user)
        {
            try
            {
                var _userroleclaim = new UserRoleClaimViewModel();
                _userroleclaim.NationalCode = user.GetNationalCode();
                _userroleclaim.FName = user.GetFirstName();
                _userroleclaim.LName = user.GetLastName();
                _userroleclaim.PhoneNumber = user.GetPhoneNumber();
                _userroleclaim.Roles = user.GetRoles();
                var jsondata = JsonConvert.SerializeObject(_userroleclaim);
                _logger.LogInformation(jsondata);

                var _User = (await FindOrRegisterUser(new ApplicationUserViewModel
                {
                    IsAuthorizedUser = true,
                    IdentityUserId = (int)user.GetUserId(),
                    NatureTypeUser = NatureTypeUserEnum.Real,
                    Name = _userroleclaim.FName,
                    UserName = _userroleclaim.NationalCode,
                    PhoneNumber = _userroleclaim.PhoneNumber,
                })).Result;

                _userroleclaim.FName = _User.Name;
                _userroleclaim.NatureTypeUser = _User.NatureTypeUser;
                _userroleclaim.LName = (_User.NatureTypeUser == NatureTypeUserEnum.Real)
                    ? (_User as UserReal)?.LastName
                    : "";
                _userroleclaim.Pic = _User.PicProfile;

                var _roles = EnumHelper<UserRolesEnum>.GetValueAndDescription();
                _userroleclaim.Claims = new List<ClaimValueUser>();
                foreach (var _claim in user.Claims)
                {
                    var _findClaimRole = _roles.FirstOrDefault(x => (x.value) + ".LocationId" == _claim.Type);
                    if (_findClaimRole != null)
                    {
                        _userroleclaim.Claims.Add(
                        new ClaimValueUser
                        {
                            ClaimType = _claim.Type,
                            //Description = _findClaimRole.Description,
                            //CliameValueTitle = claimValuetitle == null ? "" : claimValuetitle,
                            CliameValue = _claim.Value,
                            //Attribute = _claim.Type,
                        });
                    }
                }

                return await SuccessServiceResultAsync(new UserBaseInfo()
                {
                    IsExistUser = true,
                    StatusUser = _User.Status,
                    UserRoleClaim = _userroleclaim,
                });
            }
            catch (Exception ex)
            {
                return await ExceptionServiceResultAsync<UserBaseInfo>(
                    response: null,
                    loggerMessage: "error while setting user primary information"
                );
            }
        }

        public async Task<IBusinessLogicResult<bool>> SetUserRoleAndClaim(RequestSetUserRoleAndClaimViewModel model)
        {
            try
            {
                var _User = await _userManager.FindByNameAsync(model.NationalCode);
                if (_User == null)
                {
                    return await ErrorServiceResultAsync<bool>(false, MessageId.NotExistsUser, $"Not Exist User By NationalCode {model.NationalCode}");
                }

                //حذف تمام نقش های قبلی کاربر
                foreach(var _role in (await _userManager.GetRolesAsync(_User)).ToList())
                {
                    _ = await _userManager.RemoveFromRoleAsync(_User, _role);
                }
                //حذف تمام کلیم های قبلی کاربر
                foreach (var _claim in (await _userManager.GetClaimsAsync(_User)).ToList())
                {
                    _ = await _userManager.RemoveClaimAsync(_User, _claim);
                }

                //افزودن نقش و کلیم های جدید به کاربر
                foreach (var _roleclaim in model.RolesClaims)
                {
                    _ = await _userManager.AddToRoleAsync(_User, _roleclaim.Role.ToString());

                    if (_roleclaim.LocationId != null && _roleclaim.LocationId > 0)
                    {
                       var _UserRole = (UserRolesEnum)Enum.Parse(typeof(UserRolesEnum), _roleclaim.Role.ToString());
                       var _claimType = _UserRole.GetAttribute<ClaimLocationAttribute>().ClaimLocation;
                        _ = await _userManager.AddClaimAsync(_User, new Claim(_claimType, _roleclaim.LocationId.ToString()));
                    }
                }

                return await SuccessServiceResultAsync<bool>(true);
            }
            catch (Exception ex)
            {
                return await ExceptionServiceResultAsync<bool>(
                    response: false,
                    "error while getting all user with filter"
                );
            }
        }

        public async Task<IBusinessLogicResult<ResponseGetAllRealUserListViewModel>>
            GetRealUserInformationList(RequestGetAllRealUserListViewModel model)
        {
            try
            {
                var users = _userManager.Users
                    .Include(x => x.CityOrVilage)
                    .Select(x => (UserReal)x)
                    .AsQueryable();

                if (model.Id != null && model.Id > 0)
                    users = users.Where(x => x.Id == model.Id);

                if (!string.IsNullOrEmpty(model.Name))
                    users = users.Where(x => x.Name.Contains(model.Name));

                if (!string.IsNullOrEmpty(model.LastName))
                    users = users.Where(x => x.LastName.Contains(model.LastName));

                if (!string.IsNullOrEmpty(model.NationalCode))
                    users = users.Where(x => x.NationalCode == model.NationalCode);

                if (model.BirthCertificatId is > 0)
                    users = users.Where(x => x.BirthCertificatId == model.BirthCertificatId);

                if (model.CityOrVillageId > 0)
                    users = users.Where(x => x.CityOrVilageId == model.CityOrVillageId);

                if (model.CountyId > 0)
                    users = users.Where(x => x.CityOrVilage.Part.CountyId == model.CountyId);

                if (model.ProvinceId > 0)
                    users = users.Where(x => x.CityOrVilage.Part.County.ProvinceId == model.ProvinceId);

                if (model.Status != null)
                    users = users.Where(x => x.Status == model.Status);

                var userItems = users.ProjectTo<GetRealUserItemViewModel>(_mapper.ConfigurationProvider)
                    .AsEnumerable().ToPaged(model.Page, model.PageSize, out var rowCount);

                var result = new ResponseGetAllRealUserListViewModel()
                {
                    Count = rowCount,
                    CurrentPage = model.Page,
                    TotalCount = users.Count(),
                    Items = userItems.ToList()
                };

                return await SuccessServiceResultAsync(result);
            }
            catch (Exception e)
            {
                return await ErrorServiceResultAsync<ResponseGetAllRealUserListViewModel>(
                    response: null,
                    message: MessageId.Exception,
                    loggerMessage: $"error while getting all real user list | {e.Message}"
                );
            }
        }

        public async Task<IBusinessLogicResult<ResponseGetUserRoleAndClaimViewModel>> GetUsersRolesAndClaims(string NationalCode)
        {
            try
            {
                var _users = _userManager.Users.Where(x => x.UserName != null).Select(x => x as UserReal);
                if (!string.IsNullOrEmpty(NationalCode))
                    _users = _users.Where(x => x.NationalCode == NationalCode);

                if (_users == null)
                {
                    return await ErrorServiceResultAsync<ResponseGetUserRoleAndClaimViewModel>(null, MessageId.NotExistsUser, $"Not Exist User By NationalCode {NationalCode}");
                }

                ResponseGetUserRoleAndClaimViewModel _ResponseGetUserRoleAndClaim = new ResponseGetUserRoleAndClaimViewModel();
                _ResponseGetUserRoleAndClaim.Items = new List<UserRoleAndClaimViewModel>();
                foreach (var user in _users)
                {
                    if (user != null)
                    {
                        UserRoleAndClaimViewModel userRoleAndClaim = new UserRoleAndClaimViewModel();
                        userRoleAndClaim.FName = user.Name;
                        userRoleAndClaim.LName = user.LastName;
                        userRoleAndClaim.NationalCode = user.NationalCode;

                        List<string> _roles = (await _userManager.GetRolesAsync(user)).ToList();
                        List<Claim> _claims = (await _userManager.GetClaimsAsync(user)).ToList();

                        userRoleAndClaim.Roles = new List<ListRolesViewModel>();
                        foreach (var role in _roles)
                        {
                            ListRolesViewModel _userrole = new ListRolesViewModel();
                            _userrole.UserRole = (UserRolesEnum)Enum.Parse(typeof(UserRolesEnum), role);
                            _userrole.UserRoleStr = role;
                            userRoleAndClaim.Roles.Add(_userrole);
                        }

                        userRoleAndClaim.Claims = new List<ListClaimsViewModel>();
                        foreach (var claim in _claims)
                        {
                            ListClaimsViewModel _userclaim = new ListClaimsViewModel();

                            var userRoles = Enum.GetValues(typeof(UserRolesEnum)).Cast<UserRolesEnum>();

                            UserRolesEnum? _roleuser = null;
                            foreach (var userRole in userRoles)
                            {
                                try
                                {
                                    var _RoleByClaim = userRole.GetAttribute<ClaimLocationAttribute>().ClaimLocation;
                                    if (_RoleByClaim == claim.Type)
                                    {
                                        _userclaim.LevelLocation = (LevelLocationEnum)Enum.Parse(typeof(LevelLocationEnum), userRole.GetAttribute<ClaimLevelAttribute>().ClaimLevel);
                                        _roleuser = userRole;
                                        break;
                                    }
                                }
                                catch(Exception exp)
                                { }
                            }
                            _userclaim.LocationId = int.Parse(claim.Value);
                            if (_userclaim.LevelLocation == LevelLocationEnum.Province)
                                _userclaim.LocationTitle = _provinceRepository.Find(_userclaim.LocationId).Title;
                            else if (_userclaim.LevelLocation == LevelLocationEnum.County)
                                _userclaim.LocationTitle = _countyRepository.Find(_userclaim.LocationId).Title;
                            else if (_userclaim.LevelLocation == LevelLocationEnum.CityOrVillage)
                                _userclaim.LocationTitle = _cityOrVillageRepository.Find(_userclaim.LocationId).Title;

                            _userclaim.ClaimLocationType = claim.Type;
                            _userclaim.RoleClaimLocation = _roleuser;

                            userRoleAndClaim.Claims.Add(_userclaim);
                        }


                        _ResponseGetUserRoleAndClaim.Items.Add(userRoleAndClaim);
                    }
                }


                return await SuccessServiceResultAsync<ResponseGetUserRoleAndClaimViewModel>(_ResponseGetUserRoleAndClaim);
            }
            catch(Exception exp)
            {
                return await ExceptionServiceResultAsync<ResponseGetUserRoleAndClaimViewModel>(null, "Error Exception");
            }
        }

        public async Task<IBusinessLogicResult<ResponseGetAllUserListViewModel>> GetAllUserWithFilter(
            RequestGetAllUserListViewModel model)
        {
            try
            {
                var users = _userManager.Users
                    .Include(x => x.CityOrVilage)
                    .AsQueryable();
                if (!string.IsNullOrEmpty(model.NationalCode))
                    users = users.Where(x => x.UserName == model.NationalCode);
                if (model.Status != null)
                {
                    users = users.Where(x => x.Status == model.Status);
                }

                if (model.NatureTypeUser != null)
                {
                    users = users.Where(x => x.NatureTypeUser == model.NatureTypeUser);
                }

                var userItems = users.AsQueryable().ProjectTo<GetUserItemViewModel>(_mapper.ConfigurationProvider)
                    .AsEnumerable().ToPaged(model.Page, model.PageSize, out var rowCount);

                var result = new ResponseGetAllUserListViewModel
                {
                    Count = rowCount,
                    CurrentPage = model.Page,
                    TotalCount = users.Count(),
                    Items = userItems.ToList()
                };

                return await SuccessServiceResultAsync(result);
            }
            catch (Exception ex)
            {
                return await ExceptionServiceResultAsync<ResponseGetAllUserListViewModel>(
                    response: null,
                    "error while getting all user with filter"
                );
            }
        }

        public async Task<IBusinessLogicResult<ResponseGetAllRealUserListViewModel>> GetAllRealUserWithFilter(
            RequestGetAllRealUserListViewModel model)
        {
            try
            {
                var users = _userManager.Users.Where(x => x.NatureTypeUser == NatureTypeUserEnum.Real)
                    .Include(x => x.CityOrVilage)
                    .Select(x => (UserReal) x)
                    .AsQueryable();

                if (!string.IsNullOrEmpty(model.Name))
                    users = users.Where(x => x.Name.Contains(model.Name));

                if (!string.IsNullOrEmpty(model.LastName))
                    users = users.Where(x => x.LastName.Contains(model.LastName));

                if (!string.IsNullOrEmpty(model.NationalCode))
                    users = users.Where(x => x.NationalCode == model.NationalCode);

                if (model.BirthCertificatId is > 0)
                    users = users.Where(x => x.BirthCertificatId == model.BirthCertificatId);

                if (model.CityOrVillageId > 0)
                    users = users.Where(x => x.CityOrVilageId == model.CityOrVillageId);

                if (model.CountyId > 0)
                    users = users.Where(x => x.CityOrVilage.Part.CountyId == model.CountyId);

                if (model.ProvinceId > 0)
                    users = users.Where(x => x.CityOrVilage.Part.County.ProvinceId == model.ProvinceId);

                if (model.Status != null)
                    users = users.Where(x => x.Status == model.Status);

                var userItems = users.ProjectTo<GetRealUserItemViewModel>(_mapper.ConfigurationProvider)
                    .AsEnumerable().ToPaged(model.Page, model.PageSize, out var rowCount);

                var result = new ResponseGetAllRealUserListViewModel()
                {
                    Count = rowCount,
                    CurrentPage = model.Page,
                    TotalCount = users.Count(),
                    Items = userItems.ToList()
                };

                return await SuccessServiceResultAsync(result);
            }
            catch (Exception e)
            {
                return await ErrorServiceResultAsync<ResponseGetAllRealUserListViewModel>(
                    response: null,
                    message: MessageId.Exception,
                    loggerMessage: $"error while getting all real user list | {e.Message}"
                );
            }
        }

        public async Task<IBusinessLogicResult<ResponseGetAllLegalUserListViewModel>> GetAllLegalUserWithFilter(RequestGetAllLegalUserListViewModel model)
        {
            try
            {
                var users = _userManager.Users.Where(x => x.NatureTypeUser == NatureTypeUserEnum.Legal)
                    .Include(x => x.CityOrVilage)
                    .Select(x => (UserLegal) x)
                    .AsQueryable();

                if (!string.IsNullOrEmpty(model.Name))
                    users = users.Where(x => x.Name.Contains(model.Name));

                if (!string.IsNullOrEmpty(model.NationalId))
                    users = users.Where(x => x.NationalId == model.NationalId);

                if (model.NatureTypeUser != null)
                    users = users.Where(x => x.NatureTypeUser == model.NatureTypeUser);

                if (model.CityOrVillageId > 0)
                    users = users.Where(x => x.CityOrVilageId == model.CityOrVillageId);

                if (model.CountyId > 0)
                    users = users.Where(x => x.CityOrVilage.Part.CountyId == model.CountyId);

                if (model.ProvinceId > 0)
                    users = users.Where(x => x.CityOrVilage.Part.County.ProvinceId == model.ProvinceId);

                if (model.Status != null)
                    users = users.Where(x => x.Status == model.Status);

                //var userItems = users.ProjectTo<GetLegalUserItemViewModel>(_mapper.ConfigurationProvider)
                //    .AsEnumerable().ToPaged(model.Page, model.PageSize, out var rowCount);

                var userItems = users.Select(x => new GetLegalUserItemViewModel()
                {
                    Address = x.Address,
                    PostalCode = x.PostalCode,
                    CityOrVilageId = x.CityOrVilageId,
                    CityOrVilageTitle = x.CityOrVilage.Title,
                    CompanyRegistrationDate = x.CompanyRegistrationDate,
                    CompanyRegistrationPlace = x.CompanyRegistrationPlace,
                    CountyId = x.CityOrVilage.Part.CountyId,
                    CountyTitle = x.CityOrVilage.Part.County.Title,
                    EconomicCode = x.EconomicCode,
                    Email = x.Email,
                    EstablishedYear = x.EstablishedYear,
                    Id = x.Id,
                    Instagram = x.Instagram,
                    Lat = x.Lat,
                    Lng = x.Lng,
                    LinkIn = x.LinkIn,
                    MobileNumber = x.MobileNumber,
                    PhoneNumber = x.PhoneNumber,
                    Name = x.Name,
                    NationalId = x.UserName,
                    PicProfile = x.PicProfile,
                    ProvinceId = x.CityOrVilage.Part.County.ProvinceId,
                    ProvinceTitle = x.CityOrVilage.Part.County.Province.Title,
                    RegistrationNumber = x.RegistrationNumber,
                    Status = x.Status,
                    Telegram = x.Telegram,
                    TellNumber = x.TellNumber,
                    UserName = x.UserName,
                    WebSite = x.WebSite,
                }).AsEnumerable().ToPaged(model.Page, model.PageSize, out var rowCount);

                var result = new ResponseGetAllLegalUserListViewModel
                {
                    Count = rowCount,
                    CurrentPage = model.Page,
                    TotalCount = users.Count(),
                    Items = userItems.ToList()
                };

                return await SuccessServiceResultAsync(result);
            }
            catch (Exception e)
            {
                return await ErrorServiceResultAsync<ResponseGetAllLegalUserListViewModel>(
                    response: null,
                    message: MessageId.Exception,
                    loggerMessage: $"error while getting all real user list | {e.Message}"
                );
            }
        }

        public async Task<IBusinessLogicResult<int>> RegisterLegalUser(string userName, string name, string mobileNumber)
        {
            try
            {
                var user = new UserLegal
                {
                    NatureTypeUser = NatureTypeUserEnum.Legal,
                    Name = name,
                    PhoneNumberConfirmed = true,
                    NationalId = userName,
                    UserName = userName,
                    PhoneNumber = mobileNumber,
                };

                return await ErrorServiceResultAsync<int>(0,MessageId.EntityDoesNotExist,"");// await FindOrRegisterUser(user);
            }
            catch (Exception ex)
            {
                return await ExceptionServiceResultAsync(0,
                    "error while register legal user");
            }
        }

        public async Task<IBusinessLogicResult<UserRealViewModel>> RegisterRealUser(string userName, string firstName, string lastName, string mobileNumber)
        {
            try
            {
                var user = new UserReal
                {
                    NatureTypeUser = NatureTypeUserEnum.Real,
                    Name = firstName,
                    LastName = lastName,
                    PhoneNumberConfirmed = true,
                    NationalCode = userName,
                    UserName = userName,
                    MobileNumber = mobileNumber,
                };

                var _resultRegister = await FindOrRegisterUser(null);
                var _dataMapp= _mapper.Map<UserRealViewModel>(user);
                return await SuccessServiceResultAsync(_dataMapp);
            }
            catch (Exception ex)
            {
                return await ExceptionServiceResultAsync<UserRealViewModel>(null,"error while register real user");
            }
        }

        public async Task<IBusinessLogicResult<ApplicationUser>> FindOrRegisterUser(ApplicationUserViewModel user)
        {
            var currentUser = _userManager.FindByNameAsync(user.UserName).Result;
            if (currentUser != null)
                return await SuccessServiceResultAsync(currentUser);
            else
            {
                var _mappUser = _mapper.Map<ApplicationUser>(user);
                _mappUser.PhoneNumberConfirmed = true;
                _mappUser.Email = $"{user.UserName}@domain.ir";
                _mappUser.EmailConfirmed = true;

                var _registerUser = await _userManager.CreateAsync(_mappUser);
                if (_registerUser.Succeeded)
                {
                    var currentRegisterdUser = _userManager.FindByNameAsync(user.UserName).Result;
                    if (currentRegisterdUser != null)
                    {
                        var _addRealRoleToUser = await _userManager.AddToRoleAsync(currentRegisterdUser, nameof(UserRolesEnum.UserReal));
                        return await SuccessServiceResultAsync(_mappUser);
                    }
                }
                return await ErrorServiceResultAsync<ApplicationUser>(null, MessageId.Exception, "Error Create User");
            }
        }
        private async Task<IBusinessLogicResult<int>> RegisterUser0(ApplicationUser user)
        {
            try
            {
                var currentUser = _userManager.FindByNameAsync(user.Name).Result;
                if (currentUser != null)
                {
                    return await ErrorServiceResultAsync(
                        response: 0,
                        message: BusinessLogic.Message.MessageId.UserNameAlreadyExisted,
                        loggerMessage: "error while register user",
                        viewMessagesPlaceHolder: user.Name
                    );
                }

                if (string.IsNullOrEmpty(user.Email))
                    user.Email = string.Join("atlas_", user.UserName, "@atlaspro.org");
                try
                {
                    user.Status = StatusEnum.Notctive;
                    var identityUserId = await _identityService.AddUserToIdentity(user);
                    if (identityUserId != 0)
                    {
                        return await SuccessServiceResultAsync(identityUserId);
                    }

                    return await ErrorServiceResultAsync(
                        response: 0,
                        message: BusinessLogic.Message.MessageId.Exception,
                        loggerMessage: "Unable to register because user dose not insert in identity."
                    );
                }
                catch (Exception exception)
                {
                    return await ErrorServiceResultAsync(
                        response: 0,
                        message: BusinessLogic.Message.MessageId.Exception,
                        loggerMessage: "Error while adding sso user to database."
                    );
                }
            }
            catch (Exception ex)
            {
                return await ExceptionServiceResultAsync(
                    response: 0,
                    loggerMessage: "Error while adding sso user to database."
                );
            }
        }
    }
}