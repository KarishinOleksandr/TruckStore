using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TruckStore.Domain.Trucks
{
    public record class TruckChangedMessage(Guid id, TruckDto? Data, KindOfChanges Kind);
}
