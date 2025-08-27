using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TruckStore.Domain.Brands;

namespace TruckStore.Application.Interfaces
{
    public interface IBrandInterface
    {
        Task<Brand?> GetBrandByIdAsync(Guid id, CancellationToken cancellationToken);
        Task<List<Brand>> FindAllBrandAsync(CancellationToken cancellationToken);
    }
}
