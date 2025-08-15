using AppHost.Models;
using AutoMapper;
using Modules.Brands.Domain.Dtos;
using Modules.Brands.Domain.Models;
using Modules.Trucks.Domain.Dtos;
using Modules.Trucks.Domain.Models;

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