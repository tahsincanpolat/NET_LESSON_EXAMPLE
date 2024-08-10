using _16_AutoMapper.Dto;
using _16_AutoMapper.Models;
using AutoMapper;

namespace _16_AutoMapper.MappingProfiles
{
    public class UserProfile : Profile
    {
        public UserProfile()
        {
            // User => UserDto ya dönüşümünü tanımlıycaz
            // Burada FirstName ve LastName i FullName e mapliyoruz.

            CreateMap<User, UserDto>()
                .ForMember(dest => dest.FullName, opt => opt.MapFrom(src => $"{src.FirstName}  {src.LastName}"));

            // UserDto => User dönüşümü tanımlıyoruz. (Opsiyonel)
            // İki taraflı dönüşüm olabilir.
            CreateMap<UserDto, User>();
        }
    }
}
