using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Configuration;
using MainDBContext;
using TokenService;

namespace UserService
{
    public static class ConfigInit
    {

        public static void AddServices()
        {
            ConfigServices.AddScoped<IUsersService, UsersService>();
        }
        public static void AddMappers()
        {
            ConfigMappers.CreateMap<UserEntity, UserService.UserDto>();
            ConfigMappers.CreateMap<UserService.UserDto, UserEntity>();

            ConfigMappers.CreateMap<UserEntity, UserService.AddUserDto>();
            ConfigMappers.CreateMap<UserService.AddUserDto, UserEntity>();

            ConfigMappers.CreateMap<UserEntity, UserService.UserMinDto>();
            ConfigMappers.CreateMap<UserService.UserMinDto, UserEntity>();

            ConfigMappers.CreateMap<UserEntity, UserService.UserAuthDto>();
            ConfigMappers.CreateMap<UserService.UserAuthDto, UserEntity>();

            ConfigMappers.CreateMap<UserService.UserAuthDto, UserService.UserMinDto>();
            ConfigMappers.CreateMap<UserService.UserMinDto, UserService.UserAuthDto>();

            ConfigMappers.CreateMap<UserEntity, TokenService.UserDto>();
            ConfigMappers.CreateMap<TokenService.UserDto, UserEntity>();

            ConfigMappers.CreateMap<UserEntity, UserService.TokenDto>();
            ConfigMappers.CreateMap<UserService.TokenDto, UserEntity>();

            

        }


    }
}
