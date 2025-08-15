using Modules.Brands.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Modules.Trucks.Domain.Models
{
    public class Truck
    {
        public int Id { get; set; }

        public required string Model { get; set; }

        public int maxSpeed { get; set; }

        public int maxLiftingCapacity { get; set; }

        public int Price { get; set; }

        public DateOnly ReleaseDate { get; set; }

        public int BrandId { get; set; }

        public Brand? BrandName { get; set; }

    }
}
