
using _1_Entities;
using _2_Services.Exceptions;
using _2_Services.Interfaces;
using AutoMapper;

namespace _2_Services.Services.Purchase_Services
{
    public class PurchaseGameBoyCartdrigeService<TDto>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        private readonly IReferenceSystem _referenceSystem;
        private readonly IStatisticsSystem _statisticsSystem;
        private readonly IAccountingSystem _accountingSystem;
        private readonly ILogger _logger;
        private readonly IProductValidator<Cartdrige> _cartdrigeValidator;
        public PurchaseGameBoyCartdrigeService(IUnitOfWork unitOfWork,
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

        public async Task ExecuteAsync(TDto cartdrigeDto)
        {
            try
            {
                //ola
                var cartdrige = _mapper.Map<Cartdrige>(cartdrigeDto);

                await _referenceSystem.AssignReferenceToProductAsync(cartdrige);
                
                bool productIsValid = await _cartdrigeValidator.ValidateProductAsync(cartdrige);
                if (!productIsValid) { throw new ProductValidationException(_cartdrigeValidator.Errors); }

                await _unitOfWork.CartdrigeRepository.AddAsync(cartdrige);

                await _statisticsSystem.SumOnePurchasedGameBoyCartdrigeToStatistics();
                await _accountingSystem.SumPurchasePriceToExpenses(cartdrige.PurchaseDate, cartdrige.PurchasePrice);

                string logEntry = $"COMPRA: Cartucho Game Boy. Ref: {cartdrige.Reference}, Nombre: {cartdrige.Name}, " +
                    $"Precio de compra: {cartdrige.PurchasePrice}€";
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
