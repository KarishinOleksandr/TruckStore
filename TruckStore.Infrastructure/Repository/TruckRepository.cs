using AutoMapper;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TruckStore.Domain.Brands;
using TruckStore.Domain.Trucks;
using TruckStore.Infrastructure.Data;

namespace TruckStore.Infrastructure.Repository
{
    public class TruckRepository : ITruckInterface, IBrandInterface
    {
        private readonly TruckStoreContext _context;
        private readonly IMapper _mapper;
        public TruckRepository(TruckStoreContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }
        public async Task<Truck> AddAsync(Truck truck, CancellationToken cancellationToken)
        {
            await _context.Trucks.AddAsync(truck);
            await _context.SaveChangesAsync(cancellationToken);
            return truck;
        }

        public async Task DeleteAsync(Truck truck, CancellationToken cancellationToken)
        {
            if (truck != null)
            {
                _context.Trucks.Remove(truck);
                await _context.SaveChangesAsync(cancellationToken);
            }
        }

        public async Task<List<BrandDto>> FindAllBrandAsync(CancellationToken cancellationToken)
        {
            var brands = await _context.Brands.ToListAsync(cancellationToken);
            var brandsDto = _mapper.Map<List<BrandDto>>(brands);
            return brandsDto;
        }

        public async Task<List<Truck>> FindAllTruckAsync(CancellationToken cancellationToken)
        {
            var trucks = await _context.Trucks.Include(t => t.BrandName).ToListAsync(cancellationToken);
            return trucks;
        }

        public async Task<Truck?> FindByIdAsync(int id, CancellationToken cancellationToken)
        {
            var truck = await _context.Trucks.FindAsync(id, cancellationToken);
            return truck;
        }

        public async Task<BrandDto?> GetBrandByIdAsync(int id, CancellationToken cancellationToken)
        {
            var brand = await _context.Brands.FindAsync(id, cancellationToken);
            var brandDto = _mapper.Map<BrandDto>(brand);
            return brandDto;
        }

        public async Task<Truck> UpdateAsync(Truck truck, CancellationToken cancellationToken)
        {
            var updatet =_context.Trucks.Update(truck);
            await _context.SaveChangesAsync(cancellationToken);

            return updatet.Entity;

        }
    }
}
