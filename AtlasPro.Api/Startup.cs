using Application.AutoMapper;
using Application.IRepositories;
using Common.Enums;
using Domain.Entities.UserAgg;
using Infrastructure.IOC;
using Infrastructure.IOC.IdentityContextConfigs;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.OpenApi.Models;
using Persistence.Contexts;
using SOP.Api.Swagger;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace SOP.Api
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {

            services.AddControllers();

            //Cors Config
            services.AddCors(options =>
            {
                options.AddPolicy("CorsPolicy",
                    builder => builder.AllowAnyOrigin()
                        .AllowAnyMethod()
                        .AllowAnyHeader()
                        .WithHeaders()
                        .WithExposedHeaders("AccessToken", "RefreshToken"));
            });
            //Identity DataBaseContext Config
            services
                .AddIdentityContext<ApplicationDataBaseContext, ApplicationUser, ApplicationRole, int, IUnitOfWork>(
                    Configuration,
                    Configuration.GetConnectionString("Application"));


            services.AddUsersServices();
            services.AddLocationService();
            services.AddCommonService();
            services.AddProductService();


            services.AddAutoMapper(AutoMapperConfig.RegisterMappings());


            //Token Autorize
            services.AddAuthentication(options =>
            {
                options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            }).AddJwtBearer(options =>
            {
                options.Audience = GetSSOValue("Audience");
                options.Authority = GetSSOValue("Authority");

                options.Events = new JwtBearerEvents
                {
                    OnTokenValidated = context =>
                    {
                        const string Client_Id = "localhost7250";
                        string UserName = context.Principal.Claims
                            .FirstOrDefault(x => x.Type == nameof(ClaimUserEnum.preferred_username)).Value;
                        //Get EF context
                        var db = context.HttpContext.RequestServices.GetRequiredService<ApplicationDataBaseContext>();
                        //Check if this app can read confidential items
                        var _userId = db.Users.FirstOrDefault(x => x.UserName == UserName)?.Id;
                        var listUserRole = db.UserRoles.Where(x => x.UserId == _userId);
                        var listUserClaim = db.UserClaims.Where(x => x.UserId == _userId);
                        var listRoles = db.Roles;
                        //Add claim if they are
                        var claims = new List<Claim>();
                        foreach (var userrole in listUserRole)
                        {
                            var _RoleName = listRoles.FirstOrDefault(x => x.Id == userrole.RoleId)?.Name;
                            if (!string.IsNullOrEmpty(_RoleName))
                            {
                                claims.Add(new Claim(ClaimTypes.Role, _RoleName));
                            }
                        }
                        foreach (var userclaim in listUserClaim)
                        {
                            claims.Add(new Claim(userclaim.ClaimType, userclaim.ClaimValue));
                        }
                        var appIdentity = new ClaimsIdentity(claims);
                        context.Principal.AddIdentity(appIdentity);

                        return Task.CompletedTask;
                    }
                };
            });


            //services.AddSwaggerGen(c =>
            //{
            //    c.SwaggerDoc("v1", new OpenApiInfo
            //    {
            //        Version = "v1",
            //        Title = "Web Portal APIs",
            //        Description = "Core Web API",
            //        TermsOfService = new Uri("http://Koroo.com/terms"),
            //        Contact = new OpenApiContact
            //        {
            //            Name = "Team",
            //            Email = "saberbazrafshan41@gmail.com",
            //        },
            //        License = new OpenApiLicense
            //        {
            //            Name = "Use Under Mit",
            //            Url = new Uri("https://Koroo.com/license"),
            //        }
            //    });
            //    c.AddSecurityDefinition("oauth2", new OpenApiSecurityScheme
            //    {
            //        Type = SecuritySchemeType.OAuth2,
            //        Flows = new OpenApiOAuthFlows
            //        {
            //            AuthorizationCode = new OpenApiOAuthFlow
            //            {
            //                AuthorizationUrl = new Uri(GetSSOValue("AuthorizationUrl")),
            //                TokenUrl = new Uri(GetSSOValue("TokenUrl")),
            //                Scopes = new Dictionary<string, string>
            //                {
            //                    {"api1", "Demo API - full access"},
            //                }
            //            }
            //        }
            //    });
            //    c.OperationFilter<AuthorizationHeaderParameterOperationFilter>();
            //});
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            //if (env.IsDevelopment())
            //{
            //    app.UseDeveloperExceptionPage();
            //    app.UseSwagger();
            //    app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "WebApplication1 v1"));
            //}

            // if (env.IsDevelopment())
            // {
            app.UseDeveloperExceptionPage();
            app.UseSwagger();
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "CMS.Api v1");
                c.RoutePrefix = string.Empty;
                c.OAuthUsePkce();
            });
            // }

            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseCors("CorsPolicy");


            app.UseRouting();

            app.UseAuthentication();
            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }

        private string GetSSOValue(string key)
        {
            return Configuration.GetSection("SSO").GetSection(key).Value;
        }
    }
}
