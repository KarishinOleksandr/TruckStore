using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TruckStore.Domain.Trucks
{
    public record class TruckDto(int Id, string Model, string Brand, int BrandId, int maxSpeed, int maxLiftingCapacity, int Price, DateOnly ReleaseDate);
}
