using AutoMapper;
using WebApi.DTOs;
using WebApi.Models;

namespace WebApi.Profiles
{
    public class  PurchaseOrderProfile : Profile
    {
        public PurchaseOrderProfile()
        {
            CreateMap<PurchaseOrder, PurchaseOrderDTO>().ReverseMap();
            CreateMap<PurchaseOrderProduct, PurchaseOrderProductDTO>().ReverseMap();
        }
    }
}
