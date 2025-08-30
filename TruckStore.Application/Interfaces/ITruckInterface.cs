using TruckStore.Domain.Trucks;

namespace TruckStore.Application.Interfaces
{
    public interface ITruckInterface
    {
        Task<List<Truck>> FindAllTruckAsync(CancellationToken cancellationToken);
        Task<Truck?> FindByIdAsync(Guid id, CancellationToken cancellationToken);
        Task<Truck> AddAsync(Truck truck, CancellationToken cancellationToken);
        Task<Truck> UpdateAsync(Truck truck, CancellationToken cancellationToken);
        Task DeleteAsync(Truck truck, CancellationToken cancellationToken);
    }
}
