using AutoMapper;
using CustomSoftMaqueta.Application.User.DTO;
using CustomSoftMaqueta.Domain.Entities;

namespace CustomSoftMaqueta.Infrastructure.profiles
{
    public class UserProfile : Profile
    {
        public UserProfile() {
            CreateMap<UserModel, UserCleanDTO>();
            CreateMap<UserModel, UserDTO>();
            CreateMap<UserDTO,UserModel>();
        }
    }
}
