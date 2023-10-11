using APITemplate.Controllers.UserController.Data;
using Configuration;
using UserService;
using TokenService;

namespace APITemplate.Controllers.UserController
{
    /// <summary>
    /// This class and its methods adds  class mappers for services with request and response models.
    /// </summary>
    public class ConfigInit
    {
        public static void AddMappers()
        {
            ConfigMappers.CreateMap<AddUserApiRequest, AddUserDto>();
            ConfigMappers.CreateMap<UserService.UserDto, AddUserApiResponse>();

            ConfigMappers.CreateMap<UserService.UserDto, TokenService.UserDto>();
            ConfigMappers.CreateMap< TokenService.UserDto, UserService.UserDto>();

            ConfigMappers.CreateMap<LoginUserApiRequest, UserService.LoginDto>();
            ConfigMappers.CreateMap<UserService.LoginDto, LoginUserApiRequest>();

            ConfigMappers.CreateMap<LoginUserApiResponse, UserService.TokenDto>();
            ConfigMappers.CreateMap<UserService.TokenDto, LoginUserApiResponse>();

        }
    }
}
