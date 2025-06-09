using _1_Domain.Product_Entities;
using _2_Services.Exceptions;
using _2_Services.Interfaces;
using AutoMapper;
using FluentValidation;

namespace _2_Services.Services.Purchase_Services
{
    public class PurchaseCartdrigeService<TDto, TViewModel>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        private readonly IReferenceSystem _referenceSystem;
        private readonly IStatisticsSystem _statisticsSystem;
        private readonly IAccountingSystem _accountingSystem;
        private readonly ILogger _logger;
        private readonly IProductValidator<Cartdrige> _cartdrigeValidator;
        private readonly IValidator<TDto> _cartdrigePurchaseDtoValidator;
        private readonly IPresenter<Cartdrige, TViewModel> _presenter;
        public PurchaseCartdrigeService(IUnitOfWork unitOfWork,
            IMapper mapper,
            IReferenceSystem referenceSystem,
            IStatisticsSystem statisticsSystem,
            IAccountingSystem accountingSystem,
            ILogger logger,
            IProductValidator<Cartdrige> cartdrigeValidator,
            IValidator<TDto> cartdrigePurchaseDtoValidator,
            IPresenter<Cartdrige, TViewModel> presenter)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
            _referenceSystem = referenceSystem;
            _statisticsSystem = statisticsSystem;
            _accountingSystem = accountingSystem;
            _logger = logger;
            _cartdrigeValidator = cartdrigeValidator;
            _cartdrigePurchaseDtoValidator = cartdrigePurchaseDtoValidator;
            _presenter = presenter;
        }

        public async Task<TViewModel> ExecuteAsync(TDto cartdrigeDto)
        {
            var dataValidationResult = _cartdrigePurchaseDtoValidator.Validate(cartdrigeDto);
            if (!dataValidationResult.IsValid)
            {
                var errors = dataValidationResult.Errors
                .Select(e => e.ErrorMessage)
                .ToList();
                 throw new DataValidationException(errors);
            }

            var cartdrige = _mapper.Map<Cartdrige>(cartdrigeDto);

            await _referenceSystem.AssignReferenceToProductAsync(cartdrige);

            bool productIsValid = await _cartdrigeValidator.ValidateProductAsync(cartdrige);
            if (!productIsValid) { throw new ProductValidationException(_cartdrigeValidator.Errors); }

            await _unitOfWork.CartdrigeRepository.AddAsync(cartdrige);

            await _statisticsSystem.SumOnePurchasedGameBoyCartdrigeToStatisticsAsync();
            await _accountingSystem.SumPurchasePriceToExpensesAsync(cartdrige.PurchaseDate, cartdrige.PurchasePrice);

            string logEntry = $"COMPRA: Cartucho Game Boy. Ref: {cartdrige.Reference}, Nombre: {cartdrige.Name}, " +
                $"Precio de compra: {cartdrige.PurchasePrice}€";
            await _logger.WriteLogEntryAsync(logEntry);

            await _unitOfWork.SaveChangesAsync();

            return _presenter.Present(cartdrige);
        }
    }
}
