using AutoMapper;
using WebApi.DTOs;
using WebApi.Models;

namespace WebApi.Profiles
{
    public class StorageProfile : Profile
    {
        public StorageProfile()
        {
            CreateMap<StorageDTO, Storage>().ReverseMap();
        }
    }
}
