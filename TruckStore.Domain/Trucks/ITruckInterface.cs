using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TruckStore.Domain.Brands;

namespace TruckStore.Domain.Trucks
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
