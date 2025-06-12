
using _1_Domain.Product_Entities;
using _2_Services.Interfaces;
using _2_Services.Services.Purchase_Services;
using _3_Mappers.DTOs.Purchase_Dtos;
using _3_Presenters.View_Models;
using AutoMapper;
using FluentValidation;
using FluentValidation.Results;
using Moq;

namespace _2_Services.Tests.Services.Purchase_Services
{
    public class PurchaseConsoleServiceTest
    {
        //[Fact]
        //public async Task When_DtoIsValid_ExecuteAllStepsSuccesfully()
        //{
        //    var mockUnitOfWork = new Mock<IUnitOfWork>();
        //    var mockMapper = new Mock<IMapper>();
        //    var mockReferenceSystem = new Mock<IReferenceSystem>();
        //    var mockStatisticSystem = new Mock<IStatisticsSystem>();
        //    var mockAccountingSystem = new Mock<IAccountingSystem>();
        //    var mockLogger = new Mock<ILogger>();
        //    var mockProductValidator = new Mock<IProductValidator<VideoConsole>>();
        //    var mockDtoValidator = new Mock<IValidator<ConsolePurchaseDto>>();

        //    var id = 1;
        //    var idReference = 1;
        //    var idProductType = 3;
        //    var purchaseDate = DateTime.Now.Date;
        //    var purchasePrice = 50;
        //    var sparePartsPrice = 0;
        //    var totalPrice = 50;
        //    var reference = "Referencia 1";
        //    var name = "Consola 1";

        //    var videoConsole = new VideoConsole(id, idReference, idProductType, purchaseDate, purchasePrice,
        //        sparePartsPrice, totalPrice, name, reference);

        //    var mockConsoleRepository = new Mock<IRepository<VideoConsole>>();
        //    mockUnitOfWork.Setup(u => u.ConsoleRepository).Returns(mockConsoleRepository.Object);
        //    mockDtoValidator.Setup(m => m.Validate(It.IsAny<ConsolePurchaseDto>())).Returns(new ValidationResult());
        //    mockMapper.Setup(m => m.Map<VideoConsole>(It.IsAny<ConsolePurchaseDto>())).Returns(videoConsole);
        //    mockProductValidator.Setup(m => m.ValidateProductAsync(It.IsAny<VideoConsole>())).ReturnsAsync(true);

        //    var consoleDto = new ConsolePurchaseDto() { IdProductType = 1, PurchasePrice = 10, Name = "Consola 1" };


        //    PurchaseConsoleService<ConsolePurchaseDto, ConsolePurchaseViewModel> sut = new(mockUnitOfWork.Object, mockMapper.Object,
        //        mockReferenceSystem.Object, mockStatisticSystem.Object, mockAccountingSystem.Object,
        //        mockLogger.Object, mockProductValidator.Object, mockDtoValidator.Object);
        //    await sut.ExecuteAsync(consoleDto);

        //    mockDtoValidator.Verify(m => m.Validate(It.IsAny<ConsolePurchaseDto>()), Times.Once);
        //    mockMapper.Verify(m => m.Map<VideoConsole>(It.IsAny<ConsolePurchaseDto>()), Times.Once);
        //    mockReferenceSystem.Verify(m => m.AssignReferenceToProductAsync(It.IsAny<VideoConsole>()), Times.Once);
        //    mockProductValidator.Verify(m => m.ValidateProductAsync(It.IsAny<VideoConsole>()), Times.Once);
        //    mockUnitOfWork.Verify(m => m.ConsoleRepository.AddAsync(It.IsAny<VideoConsole>()), Times.Once);
        //    mockStatisticSystem.Verify(m => m.SumOnePurchasedConsoleToStatisticsAsync(It.IsAny<int>()), Times.Once);
        //    mockAccountingSystem.Verify(m => m.SumPurchasePriceToExpensesAsync(It.IsAny<DateTime>(),
        //        It.IsAny<decimal>()), Times.Once);
        //    mockLogger.Verify(m => m.WriteLogEntryAsync(It.IsAny<string>()), Times.Once);
        //    mockUnitOfWork.Verify(m => m.SaveChangesAsync(), Times.Once);
        //}
    }
}
