using TruckStore.Domain.Brands;

namespace TruckStore.Domain.Trucks
{
    public class Truck
    {
        public Guid Id { get; set; }

        public required string Model { get; set; }

        public int maxSpeed { get; set; }

        public int maxLiftingCapacity { get; set; }

        public int Price { get; set; }

        public DateOnly ReleaseDate { get; set; }

        public Guid BrandId { get; set; }

        public Brand? BrandName { get; set; }
    }
}
