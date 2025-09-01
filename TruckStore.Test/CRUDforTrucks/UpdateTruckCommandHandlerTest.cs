using MediatR;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TruckStore.Application.Interfaces;
using TruckStore.Application.SignalR;
using TruckStore.Application.Trucks.Update;
using TruckStore.Domain.Trucks;

namespace TruckStore.Test.CRUDforTrucks
{
    public class UpdateTruckCommandHandlerTest
    {
        private readonly Mock<ITruckInterface> _mockITruckInteface;

        private readonly Mock<IMediator> _mockMediator;

        public UpdateTruckCommandHandlerTest() 
        {
            _mockITruckInteface = new();
            _mockMediator = new();
        }

        [Fact]
        public async Task Handle_WhenCalled_ShouldUpdateTruckAndPublishCreatedNotification()
        {
            // Arrange
            var truckId = Guid.NewGuid();
            var command = new UpdateTruckCommand(truckId, "Model" ,Guid.Parse("3001b08e-8ec3-4b01-bacc-3e8dcb463e29"), 120, 60, 10000, DateOnly.Parse("30.08.2025"));

            var expectedtruck = new Truck
            {
                Id = command.Id,
                Model = "NewModel",
                BrandId = command.BrandId,
                maxSpeed = 180,
                maxLiftingCapacity = 50,
                Price = 20000,
                ReleaseDate = command.ReleaseDate
            };

            _mockITruckInteface.Setup(x => x.FindByIdAsync(truckId, It.IsAny<CancellationToken>())).ReturnsAsync(expectedtruck);

            _mockITruckInteface.Setup(x =>
                x.UpdateAsync(It.Is<Truck>(t => t.Id == command.Id), It.IsAny<CancellationToken>()))
                .ReturnsAsync(expectedtruck);

            var handler = new UpdateTruckHandler(_mockITruckInteface.Object, _mockMediator.Object);

            //Act
            Truck truck = await handler.Handle(command, default);

            //Assert
            Assert.Equal(truck.Id, expectedtruck.Id);

            _mockITruckInteface.Verify(x => x.UpdateAsync(It.IsAny<Truck>(), It.IsAny<CancellationToken>()), Times.Once);

            _mockMediator.Verify(x =>
            x.Publish(It.Is<ChangedNotification>
            (n => MatchTruck.MatchTruckToDto(n, expectedtruck, KindOfChanges.Updated)), It.IsAny<CancellationToken>()), Times.Once);
        }
    }
}
