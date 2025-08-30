using System.ComponentModel.DataAnnotations;

namespace TruckStore.Domain.Cart
{
    public class Order
    {
        public Guid Id { get; set; }

        [Required]
        [StringLength(15)]
        public string Name { get; set; }

        [Required]
        [StringLength(20)]
        public string SecondName { get; set; }

        [Required]
        [StringLength(20)]
        public string Adress { get; set; }

        [Required]
        [StringLength(12)]
        [DataType(DataType.PhoneNumber)]
        public string PhoneNumber { get; set; }

        [Required]
        [StringLength(25)]
        [DataType(DataType.EmailAddress)]
        public string EmailAdress { get; set; }

        public DateTime OrderTime { get; set; }

        public List<OrderDetails> OrderDetails { get; set; }
    }
}
