using AutoMapper;
using TruckStore.Domain.Brands;
using TruckStore.Domain.Trucks;

namespace TruckStore.Infrastracture.Modules
{
    public class TruckProfile : Profile
    {
        public TruckProfile()
        {
            CreateMap<TruckDto, Truck>();
            CreateMap<Truck, TruckDto>();
            CreateMap<TruckDto, TruckDetails>();
            CreateMap<TruckDetails, TruckDto>();
            CreateMap<BrandDto, Brand>();
            CreateMap<Brand, BrandDto>();
        }
    }
}
