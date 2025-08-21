using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TruckStore.Domain.Trucks
{
    public record class TruckDto(Guid Id, string Model, string Brand, Guid BrandId, int maxSpeed, int maxLiftingCapacity, int Price, DateOnly ReleaseDate);
}
