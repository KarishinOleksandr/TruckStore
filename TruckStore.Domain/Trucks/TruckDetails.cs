using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace TruckStore.Domain.Trucks
{
    public class TruckDetails
    {
        public Guid Id { get; set; }

        [Required]
        [StringLength(50)]
        public required string Model { get; set; }

        [Required(ErrorMessage = "Brand's name is required")]
        public Guid? BrandId { get; set; }
        public string Brand { get; set; } = string.Empty;

        [Required]
        [Range(60, 180)]
        public int maxSpeed { get; set; }

        [Required]
        [Range(10, 60)]
        public int maxLiftingCapacity { get; set; }

        [Required]
        [Range(10000, 9999999999)]
        public int Price { get; set; }

        [Required]
        public DateOnly ReleaseDate { get; set; }
    }
}
    