using AutoMapper;
using MediatR;
using TruckStore.Domain.Trucks;

namespace TruckStore.Application.Trucks.Get
{
    public class GetTruckHandler : IRequestHandler<GetTruckQuery, List<TruckDto>>
    {
        private readonly ITruckInterface _context;
        private readonly IMapper _mapper;
        public GetTruckHandler(ITruckInterface context, IMapper mapper)
        {
            this._context = context;
            this._mapper = mapper;
        }

        public async Task<List<TruckDto>> Handle(GetTruckQuery request, CancellationToken cancellationToken)
        {
            var trucks = await _context.FindAllTruckAsync(cancellationToken);
            var truckDtos = _mapper.Map<List<TruckDto>>(trucks);

            return truckDtos.ToList();
        }
    }
}
