using AutoMapper;
using Blog.Domain.DataTransferObjects;
using Blog.Domain.Entities;

namespace Blog.Application.AutoMapper
{
    public class UserMappingProfiles : Profile
    {
        public UserMappingProfiles()
        {
            CreateMap<User, ProfilDto>();

            CreateMap<User, UserListDto>();

            CreateMap<User, PasswordResetUserDto>();
            CreateMap<PasswordResetUserDto, User>();
        }
    }
}