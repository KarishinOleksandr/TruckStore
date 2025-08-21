using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TruckStore.Domain.Brands
{
    public static class BrandsBaseData
    {
        private static readonly Guid VolvoId = Guid.NewGuid();
        private static readonly Guid MercedesId = Guid.NewGuid();
        private static readonly Guid IvecoId = Guid.NewGuid();
        private static readonly Guid ScaniaId = Guid.NewGuid();
        private static readonly Guid RenaultId = Guid.NewGuid();

        public static List<Brand> BrandsData = new List<Brand> 
        {
            new Brand { Id = VolvoId, Name = "Volvo" },
            new Brand { Id= MercedesId, Name = "Mercedes" },
            new Brand {Id = IvecoId, Name = "Iveco"},
            new Brand {Id = ScaniaId, Name = "Scania"},
            new Brand {Id = RenaultId, Name = "Renault"},
        };
    }
}
