using System.ComponentModel.DataAnnotations;
using TruckStore.Domain.Trucks;

namespace TruckStore.Domain.Cart
{
    public class CartItem
    {
        [Key]
        public Guid ItemId {  get; set; }

        public Guid CartId { get; set; }

        public int Quantity { get; set; }

        public DateTime CreatedDate { get; set; }

        public Guid TruckId { get; set; }

        public Truck Truck  { get; set; }
    }
}
