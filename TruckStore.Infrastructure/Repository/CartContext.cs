using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TruckStore.Application.Interfaces;

namespace TruckStore.Infrastructure.Repository
{
    public sealed class CartContext : ICartContext
    {
        public Guid? CartId { get; set; }
    }
}
