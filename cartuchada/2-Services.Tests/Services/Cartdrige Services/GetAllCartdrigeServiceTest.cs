
using _1_Domain.Product_Entities;
using _2_Services.Interfaces;
using _2_Services.Services.Cartdrige_Services;
using Moq;

namespace _2_Services.Tests.Services.Cartdrige_Services
{
    public class GetAllCartdrigeServiceTest
    {
        [Fact]
        public async Task When_ExistingCartdriges_Expect_ReturnsFullList()
        {
            var mockUnitOfWork = new Mock<IUnitOfWork>();

            var cartdriges = new List<Cartdrige>
            {
                new Cartdrige(),
                new Cartdrige(),
                new Cartdrige() 
            };

            mockUnitOfWork.Setup(u => u.CartdrigeRepository.GetAllAsync())
                .ReturnsAsync(cartdriges);


            var sut = new GetAllCartdrigesService(mockUnitOfWork.Object);

            var result = await sut.ExecuteAsync();

            Assert.NotEmpty(result);
            Assert.Equal(3, result.Count());

            mockUnitOfWork.Verify(m => m.CartdrigeRepository.GetAllAsync(), Times.Once());
        }
    }
}
