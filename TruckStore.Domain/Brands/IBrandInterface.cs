using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TruckStore.Domain.Brands
{
    public interface IBrandInterface
    {
        Task<BrandDto?> GetBrandByIdAsync(int id, CancellationToken cancellationToken);
        Task<List<BrandDto>> FindAllBrandAsync(CancellationToken cancellationToken);
    }
}
