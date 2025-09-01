using MediatR;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TruckStore.Application.Interfaces;
using TruckStore.Application.SignalR;
using TruckStore.Application.Trucks.Delete;
using TruckStore.Domain.Trucks;

namespace TruckStore.Test.CRUDforTrucks
{
    public class DeleteTruckQueryHandlerTest
    {
        private readonly Mock<ITruckInterface> _mockITruckInterface;

        private readonly Mock<IMediator> _mockMediator;

        public DeleteTruckQueryHandlerTest()
        {
            _mockITruckInterface = new();
            _mockMediator = new();
        }

        [Fact]
        public async Task Handle_WhenCalled_ShouldDeleteTruck()
        {
            //Act
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

            var query = new DeleteTruckQuery(truckId);

            _mockITruckInterface.Setup(x => x.FindByIdAsync(truckId, It.IsAny<CancellationToken>())).ReturnsAsync(truck);
            _mockITruckInterface.Setup(x=> x.DeleteAsync(truck, It.IsAny<CancellationToken>())).Returns(Task.CompletedTask);

            var handler = new DeleteTruckHandler(_mockITruckInterface.Object, _mockMediator.Object);

            //Act
            await handler.Handle(query, default);

            //Asserts
            _mockITruckInterface.Verify(x => x.DeleteAsync(truck, It.IsAny<CancellationToken>()), Times.Once());
            _mockMediator.Verify(x => x.Publish(It.Is<ChangedNotification>
                (n => MatchTruck.MatchTruckToDto(n, truck, KindOfChanges.Deleted)), It.IsAny<CancellationToken>()), Times.Once);
        }
    }
}
