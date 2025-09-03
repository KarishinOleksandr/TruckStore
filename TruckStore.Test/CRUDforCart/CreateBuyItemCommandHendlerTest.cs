using MediatR;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TruckStore.Application.Interfaces;

namespace TruckStore.Test.CRUDforCart
{
    public class CreateBuyItemCommandHendlerTest
    {
        private readonly Mock<ICartInterfaces> _mockITruckInteface;
        private readonly Mock<IMediator> _mockMediator;

        public CreateBuyItemCommandHendlerTest() 
        {
            _mockITruckInteface = new();
            _mockMediator = new();
        }

        [Fact]
        public async Task Handle_WhenCalled_ShouldCreateBuyItem()
        {
            //Arrange


            //Act

            //Asserts
        }
    }
}
