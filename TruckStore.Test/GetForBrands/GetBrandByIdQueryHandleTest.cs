using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TruckStore.Application.Brands.GetbyId;
using TruckStore.Application.Interfaces;
using TruckStore.Domain.Brands;

namespace TruckStore.Test.GetForBrands
{
    public class GetBrandByIdQueryHandleTest
    {
        private readonly Mock<IBrandInterface> _mockIBrandInterface;

        public GetBrandByIdQueryHandleTest()
        {
            _mockIBrandInterface = new();
        }

        [Fact]
        public async Task Handle_WhenCalled_ShouldReturnBrandsById()
        {
            //Arrange 
            var brandid = Guid.NewGuid();
            var brand = new Brand { Id = brandid, Name = "Mercedes" };

            var query = new GetBrandByIdQuery(brandid);

            _mockIBrandInterface.Setup(x => x.GetBrandByIdAsync(brandid, It.IsAny<CancellationToken>())).ReturnsAsync(brand);

            var handler = new GetBrandByIdHandlers(_mockIBrandInterface.Object);

            //Act
            var result = await handler.Handle(query, default);

            //Assert
            Assert.NotNull(result);

            _mockIBrandInterface.Verify(x => x.GetBrandByIdAsync(result.Id, It.IsAny<CancellationToken>()), Times.Once);
        }
    }
}
