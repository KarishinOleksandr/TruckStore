
namespace TruckStore.Application.Interfaces
{
    public interface ICartIdProvider
    {
        Guid? GetCartId();
        void SetCartId(Guid cartId);
    }
}
