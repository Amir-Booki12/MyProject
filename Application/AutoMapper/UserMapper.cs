using Application.ViewModels.User.RolesClaims;
using AutoMapper;
using Domain.Entities.UserAgg;

public class UserMapper : Profile
{
    public UserMapper()
    {
        CreateMap<UserRealViewModel, UserReal>().ReverseMap();
        CreateMap<ApplicationUserViewModel, ApplicationUser>().ReverseMap();
        

    }
}