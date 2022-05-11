using AutoMapper;
using WebApi.DTOs;
using WebApi.Models;

namespace WebApi.Profiles
{
    public class SupplierProfile : Profile
    {
        public SupplierProfile()
        {
            CreateMap<Supplier, SupplierDTO>().ReverseMap();
            CreateMap<SupplyOrder, SupplyOrderDTO>().ReverseMap();
            CreateMap<SupplyOrderProduct, SupplyOrderProductDTO>().ReverseMap();
            CreateMap<SupplyOrderState, SupplyOrderStateDTO>().ReverseMap();
        }
    }
}
