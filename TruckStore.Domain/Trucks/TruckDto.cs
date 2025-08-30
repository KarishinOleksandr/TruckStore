
namespace TruckStore.Domain.Trucks
{
    public record class TruckDto(Guid Id, string Model, Guid BrandId, int maxSpeed, int maxLiftingCapacity, int Price, DateOnly ReleaseDate);
}
