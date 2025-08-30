using MediatR;
using System.ComponentModel.DataAnnotations;
namespace TruckStore.Application.Cart.CreateOrder
{
    public record class CreateOrderCommand(
        [Required][StringLength(15)]string Name,
        [Required][StringLength(20)]string SecondName,
        [Required][StringLength(20)]string Adress,
        [Required][StringLength(12)][DataType(DataType.PhoneNumber)]string PhoneNumber,
        [Required][StringLength(25)][DataType(DataType.EmailAddress)]string EmailAdress,
        DateTime OrderTime) : IRequest;
}
