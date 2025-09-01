using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TruckStore.Application.SignalR;
using TruckStore.Domain.Trucks;

namespace TruckStore.Test.CRUDforTrucks
{
    public static class MatchTruck
    {
        public static bool MatchTruckToDto(ChangedNotification change, Truck expected, KindOfChanges expectKind)
        {
            return change.Data is TruckDto dto &&
                   dto.Id == expected.Id &&
                   dto.Model == expected.Model &&
                   dto.BrandId == expected.BrandId &&
                   dto.maxSpeed == expected.maxSpeed &&
                   dto.maxLiftingCapacity == expected.maxLiftingCapacity &&
                   dto.Price == expected.Price &&
                   dto.ReleaseDate == expected.ReleaseDate &&
                   change.Kind == expectKind;
        }

    }
}
