
namespace TruckStore.Domain.Trucks
{
    public record class TruckChangedMessage(Guid id, TruckDto? Data, KindOfChanges Kind);
}
