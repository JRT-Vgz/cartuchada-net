
using _1_Domain.Product_Entities;
using _1_Domain.Sold_Product_Entities;
using _2_Services.Exceptions;
using _2_Services.Interfaces;
using AutoMapper;

namespace _2_Services.Services.SaleServices
{
    public class SellCartdrigeService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        private readonly IReferenceSystem _referenceSystem;
        private readonly IStatisticsSystem _statisticsSystem;
        private readonly IAccountingSystem _accountingSystem;
        private readonly ILogger _logger;
        private readonly IProductValidator<Cartdrige> _cartdrigeValidator;
        private readonly IProductValidator<SoldCartdrige> _soldCartdrigeValidator;       

        public SellCartdrigeService(IUnitOfWork unitOfWork,
            IMapper mapper,
            IReferenceSystem referenceSystem,
            IStatisticsSystem statisticsSystem,
            IAccountingSystem accountingSystem,
            ILogger logger,
            IProductValidator<Cartdrige> cartdrigeValidator,
            IProductValidator<SoldCartdrige> soldCartdrigeValidator)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
            _referenceSystem = referenceSystem;
            _statisticsSystem = statisticsSystem;
            _accountingSystem = accountingSystem;
            _logger = logger;
            _cartdrigeValidator = cartdrigeValidator;
            _soldCartdrigeValidator = soldCartdrigeValidator;
        }

        public async Task ExecuteAsync(Cartdrige cartdrige, decimal salePrice)
        {
            if (cartdrige == null) { throw new Exception("Error: El cartucho que intenta venderse tiene un valor nulo."); }

            bool productIsValid = await _cartdrigeValidator.ValidateProductAsync(cartdrige);
            if (!productIsValid) { throw new ProductValidationException(_cartdrigeValidator.Errors); }

            var soldCartdrige = _mapper.Map<SoldCartdrige>(cartdrige);
            soldCartdrige.AssignSalePrice(salePrice);

            bool soldProductIsValid = await _soldCartdrigeValidator.ValidateProductAsync(soldCartdrige);
            if (!soldProductIsValid) { throw new ProductValidationException(_soldCartdrigeValidator.Errors); }

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
    }
}
