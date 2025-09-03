using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TruckStore.Application.Brands.Get;
using TruckStore.Application.Interfaces;
using TruckStore.Domain.Brands;

namespace TruckStore.Test.GetForBrands
{
    public class GetBrandsQueryHandlerTest
    {
        private readonly Mock<IBrandInterface> _mockIBrandInterface;

        public GetBrandsQueryHandlerTest()
        {
            _mockIBrandInterface = new();
        }

        [Fact]
        public async Task Handle_WhenCalled_ShouldReturnAllBrands()
        {
            //Arrange
            List<Brand> ListofBrands = new List<Brand>
            {
                new Brand{Name = "Mercedes", Id = Guid.NewGuid()},
                new Brand{Name = "Volvo", Id= Guid.NewGuid()},
            };

            var query = new GetBrandsQuery();

            _mockIBrandInterface.Setup(x => x.FindAllBrandAsync(It.IsAny<CancellationToken>())).ReturnsAsync(ListofBrands);

            var handler = new GetBrandHandlers(_mockIBrandInterface.Object);

            //Act
            var result = await handler.Handle(query, default);

            //Assert
            Assert.NotNull(result);

            _mockIBrandInterface.Verify(x => x.FindAllBrandAsync(It.IsAny<CancellationToken>()), Times.Once);
        }

    }
}
