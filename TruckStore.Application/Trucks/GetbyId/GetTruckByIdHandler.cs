using AutoMapper;
using MediatR;
using TruckStore.Domain.Trucks;

namespace TruckStore.Application.Trucks.GetbyId
{
    public class GetTruckByIdHandler : IRequestHandler<GetTruckByIdQuery, TruckDto?>
    {
        private readonly ITruckInterface _context;
        private readonly IMapper _mapper;

        public GetTruckByIdHandler(ITruckInterface context, IMapper mapper)
        {
            this._context = context;
            this._mapper = mapper;
        }

        public async Task<TruckDto?> Handle(GetTruckByIdQuery request, CancellationToken cancellationToken)
        {
            var truck = await _context.FindByIdAsync(request.Id, cancellationToken);
            var truckDto = _mapper.Map<TruckDto?>(truck);

            return truckDto;
        }
    }
}
