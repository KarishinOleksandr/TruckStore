using TruckStore.Domain.Trucks;

namespace TruckStore.Domain.Cart
{
    public class OrderDetails
    {
        public Guid Id { get; set; }

        public Guid OrderId { get; set; }

        public Guid TruckId { get; set; }

        public int Price { get; set; }

        public Truck Truck { get; set; }

        public Order Order { get; set; }
    }
}
