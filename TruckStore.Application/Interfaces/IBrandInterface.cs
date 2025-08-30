using TruckStore.Domain.Brands;

namespace TruckStore.Application.Interfaces
{
    public interface IBrandInterface
    {
        Task<Brand?> GetBrandByIdAsync(Guid id, CancellationToken cancellationToken);
        Task<List<Brand>> FindAllBrandAsync(CancellationToken cancellationToken);
    }
}
