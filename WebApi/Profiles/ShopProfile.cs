using AutoMapper;
using WebApi.DTOs;
using WebApi.Models;

namespace WebApi.Profiles
{
    public class ShopProfile : Profile
    {
        public ShopProfile()
        {
            CreateMap<Shop, ShopDTO>().ReverseMap();
        }
    }
}
