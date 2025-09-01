using MediatR;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TruckStore.Application.Interfaces;
using TruckStore.Application.Trucks.GetbyId;
using TruckStore.Domain.Trucks;

namespace TruckStore.Test.CRUDforTrucks
{
    public class GetTruckByIdQueryHandlerTest
    {
        private readonly Mock<ITruckInterface> _mockITruckInterface;

        public GetTruckByIdQueryHandlerTest() 
        {
            _mockITruckInterface = new();
        }

        [Fact]
        public async Task Handle_WhenCalled_ShouldReturnTruckById()
        {
            //Arrange
            var truckId = Guid.NewGuid();
            var truck = new Truck
            {
                Id = truckId,
                Model = "Model",
                BrandId = Guid.Parse("3001b08e-8ec3-4b01-bacc-3e8dcb463e29"),
                maxSpeed = 120,
                maxLiftingCapacity = 50,
                Price = 10000,
                ReleaseDate = DateOnly.Parse("30.08.2025")
            };

            var query = new GetTruckByIdQuery(truckId);

            _mockITruckInterface.Setup(x=> x.FindByIdAsync(truckId, It.IsAny<CancellationToken>())).ReturnsAsync(truck);

            var handler = new GetTruckByIdHandler(_mockITruckInterface.Object);
            //Act
            var result = await handler.Handle(query, default);

            //Asserts
            Assert.NotNull(result);
            Assert.Equal(truck.Id, result.Id);

            _mockITruckInterface.Verify(x => x.FindByIdAsync(result.Id, It.IsAny<CancellationToken>()), Times.Once);

        }
    }
}
