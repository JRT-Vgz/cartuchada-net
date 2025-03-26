
using _1_Domain.Product_Entities;
using _1_Domain.Sold_Product_Entities;
using _2_Services.Exceptions;
using _2_Services.Interfaces;
using AutoMapper;

namespace _2_Services.Services.SaleServices
{
    public class RevertSellGameBoyCartdrigeService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        private readonly IReferenceSystem _referenceSystem;
        private readonly IStatisticsSystem _statisticsSystem;
        private readonly IAccountingSystem _accountingSystem;
        private readonly ILogger _logger;
        private readonly IProductValidator<Cartdrige> _cartdrigeValidator;
        public RevertSellGameBoyCartdrigeService(IUnitOfWork unitOfWork,
            IMapper mapper,
            IReferenceSystem referenceSystem,
            IStatisticsSystem statisticsSystem,
            IAccountingSystem accountingSystem,
            ILogger logger,
            IProductValidator<Cartdrige> cartdrigeValidator)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
            _referenceSystem = referenceSystem;
            _statisticsSystem = statisticsSystem;
            _accountingSystem = accountingSystem;
            _logger = logger;
            _cartdrigeValidator = cartdrigeValidator;
        }

        public async Task ExecuteAsync(SoldCartdrige soldCartdrige)
        {
            try
            {
                if (soldCartdrige == null) { throw new Exception("Error: La venta de cartucho que intenta revertirse tiene un valor nulo."); }

                var cartdrige = _mapper.Map<Cartdrige>(soldCartdrige);
                await _referenceSystem.AssignReferenceToProductAsync(cartdrige);

                bool productIsValid = await _cartdrigeValidator.ValidateProductAsync(cartdrige);
                if (!productIsValid) { throw new ProductValidationException(_cartdrigeValidator.Errors); }

                await _unitOfWork.SoldCartdrigeRepository.Delete(soldCartdrige);
                await _unitOfWork.CartdrigeRepository.AddAsync(cartdrige);

                await _statisticsSystem.WithdrawOneSoldGameBoyCartdrigeFromStatisticsAsync();
                await _accountingSystem.WithdrawSalePriceFromIncomeAsync(soldCartdrige.SaleDate, soldCartdrige.SalePrice);

                string logEntry = $"REVERTIR VENTA: Cartucho Game Boy. Nueva ref: {cartdrige.Reference}, Nombre: {cartdrige.Name}, " +
                    $"Fecha de venta: {soldCartdrige.SaleDate.ToString("yyyy-MM-dd")}, Precio de venta: {soldCartdrige.SalePrice}€";
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
