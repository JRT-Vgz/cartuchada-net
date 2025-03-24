
using _1_Domain.Product_Entities;
using _1_Domain.Sold_Product_Entities;
using _2_Services.Exceptions;
using _2_Services.Interfaces;
using AutoMapper;

namespace _2_Services.Services.SaleServices
{
    public class SellGameBoyCartdrigeService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        private readonly IReferenceSystem _referenceSystem;
        private readonly IStatisticsSystem _statisticsSystem;
        private readonly IAccountingSystem _accountingSystem;
        private readonly ILogger _logger;
        private readonly IProductValidator<SoldCartdrige> _soldCartdrigeValidator;
        public SellGameBoyCartdrigeService(IUnitOfWork unitOfWork,
            IMapper mapper,
            IReferenceSystem referenceSystem,
            IStatisticsSystem statisticsSystem,
            IAccountingSystem accountingSystem,
            ILogger logger,
            IProductValidator<SoldCartdrige> soldCartdrigeValidator)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
            _referenceSystem = referenceSystem;
            _statisticsSystem = statisticsSystem;
            _accountingSystem = accountingSystem;
            _logger = logger;
            _soldCartdrigeValidator = soldCartdrigeValidator;
        }

        public async Task ExecuteAsync(Cartdrige cartdrige, decimal salePrice)
        {
            try
            {
                var soldCartdrige = _mapper.Map<SoldCartdrige>(cartdrige);
                soldCartdrige.AssignSalePrice(salePrice);

                bool productIsValid = await _soldCartdrigeValidator.ValidateProductAsync(soldCartdrige);
                if (!productIsValid) { throw new ProductValidationException(_soldCartdrigeValidator.Errors); }

                await _referenceSystem.ReleaseReferenceByIdAsync(cartdrige.IdReference);

                await _unitOfWork.CartdrigeRepository.Delete(cartdrige);
                await _unitOfWork.SoldCartdrigeRepository.AddAsync(soldCartdrige);

                await _statisticsSystem.SumOneSoldGameBoyCartdrigeToStatisticsAsync();
                await _accountingSystem.SumSalePriceToIncomeAsync(soldCartdrige.SaleDate, salePrice);

                string logEntry = $"VENTA: Cartucho Game Boy. Ref: {cartdrige.Reference}, Nombre: {cartdrige.Name}, " +
                    $"Precio de venta: {salePrice}€";
                await _logger.WriteLogEntryAsync(logEntry);

                await _unitOfWork.SaveChangesAsync();
            }
            catch (ProductValidationException ex)
            {
                Console.WriteLine(ex.Message);
                foreach (var error in ex.Errors) { Console.WriteLine(error); }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

        }
    }
}
