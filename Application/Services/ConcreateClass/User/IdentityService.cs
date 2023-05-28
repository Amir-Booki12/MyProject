using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Application.BusinessLogic;
using Application.BusinessLogic.Message;
using Application.IRepositories;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Application.Services.InterfaceClass.User;
using Domain.Entities.UserAgg;

namespace Application.Services.ConcreateClass.User
{
    public class IdentityApplicationDataBaseContext :
        IdentityDbContext<ApplicationUser, ApplicationRole, int>,
        IUnitOfWork
    {
        public IdentityApplicationDataBaseContext(DbContextOptions<IdentityApplicationDataBaseContext> options) :
            base(options)
        {
        }

        public IRepository<TEntity> GetRepository<TEntity>() where TEntity : class
        {
            throw new NotImplementedException();
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
        }
    }

    public class IdentityService : IIdentityService
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly RoleManager<ApplicationRole> _roleManager;
        private readonly ILogger<IdentityService> _logger;
        private readonly IConfiguration _configuration;

        private ServiceCollection services;

        public IdentityService(UserManager<ApplicationUser> userManager,
            RoleManager<ApplicationRole> roleManager,
            IConfiguration configuration,
            ILogger<IdentityService> logger)
        {
            _userManager = userManager;
            _roleManager = roleManager;
            _logger = logger;
            _configuration = configuration;

            #region identity

            var connectionString = _configuration.GetConnectionString("IdentityConnection");

            services = new ServiceCollection();
            services.AddLogging();
            services.AddDbContext<IdentityApplicationDataBaseContext>(options =>
                options.UseSqlServer(connectionString));

            services.AddIdentity<ApplicationUser, ApplicationRole>()
                .AddEntityFrameworkStores<IdentityApplicationDataBaseContext>()
                .AddDefaultTokenProviders();

            #endregion identity
        }


        public int addUserToIdentity(string username, string pass, string email, string phoneNumber)
        {
            using (var serviceProvider = services.BuildServiceProvider())
            {
                using (var scope = serviceProvider.GetRequiredService<IServiceScopeFactory>().CreateScope())
                {
                    var _userManager = scope.ServiceProvider.GetRequiredService<UserManager<ApplicationUser>>();
                    var roleMgr = scope.ServiceProvider.GetRequiredService<RoleManager<ApplicationRole>>();

                    var user = _userManager.FindByNameAsync(username).Result;
                    if (user == null)
                    {
                        user = new ApplicationUser
                        {
                            UserName = username,
                            Email = email,
                            EmailConfirmed = true,
                        };
                        var result = _userManager.CreateAsync(user, pass).Result;
                        var phoneResult = _userManager.SetPhoneNumberAsync(user, phoneNumber).Result;
                        if (!result.Succeeded || !phoneResult.Succeeded)
                        {
                            return 0;
                        }

                        user = _userManager.FindByNameAsync(username).Result;
                        return user.Id;
                    }

                    return 0;
                }
            }
        }

        public async Task<int> AddRoleToUserIdentity(ApplicationUser user, string roleName)
        {
            var role = _roleManager.FindByNameAsync(roleName).Result;
            if (role == null)
            {
                role = new ApplicationRole();
                role.Name = roleName;
                var roleResult = _roleManager.CreateAsync(role).Result;
            }

            var result = _userManager.AddToRoleAsync(user, roleName).Result;
            if (!result.Succeeded)
            {
                throw new Exception(result.Errors.First().Description);
            }

            return user.Id;
        }

        public async Task<int> AddUserToIdentity(ApplicationUser initApplicationUser, string password = null)
        {
            var currentUser = _userManager.FindByNameAsync(initApplicationUser.UserName).Result;
            if (currentUser == null)
            {
                initApplicationUser.EmailConfirmed = true;
                IdentityResult result;
                if (!string.IsNullOrEmpty(password))
                    result = _userManager.CreateAsync(initApplicationUser, password).Result;
                else
                    result = _userManager.CreateAsync(initApplicationUser).Result;

                var phoneResult = _userManager
                    .SetPhoneNumberAsync(initApplicationUser, initApplicationUser.PhoneNumber)
                    .Result;
                if (!result.Succeeded || !phoneResult.Succeeded)
                {
                    return 0;
                }

                initApplicationUser = _userManager.FindByNameAsync(initApplicationUser.UserName).Result;
                return initApplicationUser.Id;
            }

            return 0;
        }

        public async Task<int> AddClaimToUser(ApplicationUser user, Claim[] claims)
        {
            var result = _userManager.AddClaimsAsync(user, claims).Result;

            if (!result.Succeeded)
            {
                throw new Exception(result.Errors.First().Description);
            }

            return user.Id;
        }

        public async Task<List<Claim>> GetUserClaims(string userName)
        {
            var result = new List<Claim>();
            try
            {
                var user = _userManager.FindByNameAsync(userName).Result;
                if (user == null)
                {
                    _logger.LogError($"user {userName} not exists");
                    return result;
                }

                return _userManager.GetClaimsAsync(user).Result.ToList();
            }
            catch (Exception exception)
            {
                _logger.LogError($"exception occured {exception.Message}");
                // ignored
            }

            return result;
        }

    }
}