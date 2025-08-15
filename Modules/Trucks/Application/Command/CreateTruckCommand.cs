using MediatR;
using Modules.Trucks.Domain.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Modules.Trucks.Application.Command
{
    public record CreateTruckCommand(
        [Required][StringLength(50)] string Model,
        [Required] int BrandId,
        [Required][Range(60, 180)] int maxSpeed,
        [Required][Range(10, 60)] int maxLiftingCapacity,
        [Required][Range(10000, 9999999999)] int Price,
        [Required] DateOnly ReleaseDate) : IRequest<Truck>;
}
