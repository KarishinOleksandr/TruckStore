using MediatR;
using System.ComponentModel.DataAnnotations;
using TruckStore.Domain.Trucks;

namespace TruckStore.Application.Trucks.Create
{
    public record class CreateTruckCommand(
        [Required][StringLength(50)] string Model,
        [Required] int BrandId,
        [Required][Range(60, 180)] int maxSpeed,
        [Required][Range(10, 60)] int maxLiftingCapacity,
        [Required][Range(10000, 9999999999)] int Price,
        [Required] DateOnly ReleaseDate) : IRequest<Truck>;
}
