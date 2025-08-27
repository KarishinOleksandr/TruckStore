using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TruckStore.Application.Interfaces
{
    public interface ICartContext
    {
        Guid? CartId { get; set; }
    }
}
