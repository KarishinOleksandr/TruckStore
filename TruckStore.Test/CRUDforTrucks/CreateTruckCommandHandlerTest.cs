using MediatR;
using Moq;
using TruckStore.Application.Interfaces;
using TruckStore.Application.SignalR;
using TruckStore.Application.Trucks.Create;
using TruckStore.Domain.Trucks;

namespace TruckStore.Test.CRUDforTrucks
{
    public class CreateTruckCommandHandlerTest
    {
        private readonly Mock<ITruckInterface> _truckInterfaceMock;
        private readonly Mock<IMediator> _mediatorMock;

        public CreateTruckCommandHandlerTest()
        {
            _truckInterfaceMock = new();
            _mediatorMock = new();
        }

        [Fact]
        public async Task Handle_WhenCalled_ShouldAddTruckAndPublishCreatedNotification()
        {
            //Arrange
            var command = new CreateTruckCommand("Masa", Guid.Parse("3001b08e-8ec3-4b01-bacc-3e8dcb463e29"), 120, 60, 10000, DateOnly.Parse("30.08.2025"));

            var expectedtruck = new Truck
            {
                Id = Guid.NewGuid(),
                Model = command.Model,
                BrandId = command.BrandId,
                maxSpeed = command.maxSpeed,
                maxLiftingCapacity = command.maxLiftingCapacity,
                Price = command.Price,
                ReleaseDate = command.ReleaseDate
            };

            _truckInterfaceMock.Setup(x => 
                x.AddAsync(It.Is<Truck>(t => t.Model == command.Model), It.IsAny<CancellationToken>()))
                .ReturnsAsync(expectedtruck);

            var handler = new CreateTruckHandler(_truckInterfaceMock.Object, _mediatorMock.Object);

            //Act
            Truck truck = await handler.Handle(command, default);

            //Assert
            Assert.Equal(expectedtruck.Id, truck.Id);

            _truckInterfaceMock.Verify(x => x.AddAsync(It.IsAny<Truck>(), It.IsAny<CancellationToken>()), Times.Once);

            _mediatorMock.Verify(x => x.Publish(It.Is<ChangedNotification>(n =>
                MatchTruck.MatchTruckToDto(n, expectedtruck, KindOfChanges.Created)), It.IsAny<CancellationToken>()), Times.Once);
        }
    }
}