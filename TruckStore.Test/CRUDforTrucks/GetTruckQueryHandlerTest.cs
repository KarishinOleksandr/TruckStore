using MediatR;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TruckStore.Application.Interfaces;
using TruckStore.Application.Trucks.Get;
using TruckStore.Domain.Trucks;

namespace TruckStore.Test.CRUDforTrucks
{
    public class GetTruckQueryHandlerTest
    {
        private readonly Mock<ITruckInterface> _mockITruckInterface;

        public GetTruckQueryHandlerTest() 
        {
            _mockITruckInterface = new();
        }

        [Fact]
        public async Task Handle_WhenCalled_ShouldReturnAllTruck()
        {
            //Arrange
            var ListofTruck = new List<Truck>
            {
                new Truck { Id = Guid.NewGuid(), 
                            Model = "A", 
                            BrandId = Guid.Parse("3001b08e-8ec3-4b01-bacc-3e8dcb463e29"), 
                            maxSpeed = 120, 
                            maxLiftingCapacity = 60, 
                            Price = 10000,
                            ReleaseDate =  DateOnly.Parse("30.08.2025")},
                new Truck { Id = Guid.NewGuid(),
                            Model = "B",
                            BrandId = Guid.Parse("3001b08e-8ec3-4b01-bacc-3e8dcb463e29"),
                            maxSpeed = 150,
                            maxLiftingCapacity = 50,
                            Price = 20000,
                            ReleaseDate =  DateOnly.Parse("30.08.2025")}

            };
            var query = new GetTruckQuery();

            _mockITruckInterface.Setup(x => x.FindAllTruckAsync(It.IsAny<CancellationToken>())).ReturnsAsync(ListofTruck);

            var handler = new GetTruckHandler(_mockITruckInterface.Object);

            //Act
            var result = await handler.Handle(query, default);

            //Assert
            Assert.NotNull(result);
            Assert.Equal(ListofTruck.OrderBy(t => t.Id).Select(t => t.Id),
                result.OrderBy(t => t.Id).Select(t=>t.Id));
            _mockITruckInterface.Verify(x=> x.FindAllTruckAsync(It.IsAny<CancellationToken>()), Times.Once);
        }
    }
}
