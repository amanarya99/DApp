using System.Linq;
using AutoMapper;
using DApp.API.Dtos;
using DApp.API.Models;

namespace DApp.API.Helpers
{
  public class AutoMapperProfiles : Profile
  {
    public AutoMapperProfiles()
    {
      CreateMap<User, UserForListDto>()
      .ForMember(dest => dest.PhotoUrl, opt =>
      {
        opt.MapFrom(src => src.Photos.FirstOrDefault(p => p.IsMain).Url);
      })
      .ForMember(dest => dest.Age, opt =>
      {
        opt.ResolveUsing(d => d.DateOfBirth.CalculateAge());
      });
      CreateMap<User, UserFOrDetailedDto>().ForMember(dest => dest.PhotoUrl, opt =>
      {
        opt.MapFrom(src => src.Photos.FirstOrDefault(p => p.IsMain).Url);
      })
      .ForMember(dest => dest.Age, opt =>
      {
        opt.ResolveUsing(d => d.DateOfBirth.CalculateAge());
      });
      CreateMap<Photo, PhotosForDetailedDto>();
      CreateMap<UserForUpdateDto, User>();
      CreateMap<Photo, PhotoForReturnDto>();
      CreateMap<PhotoForCreationDto, Photo>();
      CreateMap<UserForRegisterDto, User>();
    }
  }
}