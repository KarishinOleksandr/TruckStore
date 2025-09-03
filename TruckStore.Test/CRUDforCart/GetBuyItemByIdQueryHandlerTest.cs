using AppHost.Components.Pages;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TruckStore.Application.Cart.GetById;
using TruckStore.Application.Interfaces;

namespace TruckStore.Test.CRUDforCart
{
    public class GetBuyItemByIdQueryHandlerTest
    {
        private readonly Mock<ICartIdProvider> _mockICartIdProvider;

        public GetBuyItemByIdQueryHandlerTest()
        {
            _mockICartIdProvider = new();
        }

        [Fact]
        public async Task Handle_WhenCarIdExist_ShouldReturnCartId()
        {
            //Arrange
            var cartId = Guid.NewGuid();

            _mockICartIdProvider.Setup(x => x.GetCartId()).Returns(cartId);

            var query = new GetBuyItemByIdQuery();

            var handler = new GetBuyItemByIdHandler(_mockICartIdProvider.Object);

            //Act
            var result = await handler.Handle(query, default);

            //Aserts
            Assert.Equal(cartId, result);

            _mockICartIdProvider.Verify(x=> x.SetCartId(It.IsAny<Guid>()), Times.Never);
        }

        [Fact]
        public async Task Handle_WhenCardIdNotExist_ShoulrCreateCartId()
        {
            //Arrange
            _mockICartIdProvider.Setup(x => x.GetCartId()).Returns((Guid?)null);

            Guid? cartId = null;

            _mockICartIdProvider.Setup(x => x.SetCartId(It.IsAny<Guid>())).Callback<Guid>(id => cartId = id);

            var query = new GetBuyItemByIdQuery();

            var handler = new GetBuyItemByIdHandler(_mockICartIdProvider.Object);
            //Act

            //Asserts
        }
    }
}
