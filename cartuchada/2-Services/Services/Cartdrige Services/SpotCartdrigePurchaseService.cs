using _1_Domain.Product_Entities;
using _2_Services.Exceptions;
using _2_Services.Interfaces;
using AutoMapper;
using FluentValidation;

namespace _2_Services.Services.Cartdrige_Services
{
    public class SpotCartdrigePurchaseService<TDto, TViewModel>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        private readonly IStatisticsSystem _statisticsSystem;
        private readonly ILogger _logger;
        private readonly INonReferencedProductValidator<Cartdrige> _spottedCartdrigeValidator;
        private readonly IValidator<TDto> _cartdrigePurchaseDtoValidator;
        private readonly IPresenter<Cartdrige, TViewModel> _presenter;
        public SpotCartdrigePurchaseService(IUnitOfWork unitOfWork,
            IMapper mapper,
            IStatisticsSystem statisticsSystem,
            ILogger logger,
            INonReferencedProductValidator<Cartdrige> spottedCartdrigeValidator,
            IValidator<TDto> cartdrigePurchaseDtoValidator,
            IPresenter<Cartdrige, TViewModel> presenter)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
            _statisticsSystem = statisticsSystem;
            _logger = logger;
            _spottedCartdrigeValidator = spottedCartdrigeValidator;
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

            bool productIsValid = await _spottedCartdrigeValidator.ValidateProductAsync(cartdrige);
            if (!productIsValid) { throw new ProductValidationException(_spottedCartdrigeValidator.Errors); }

            await _unitOfWork.SpotRepository.AddAsync(cartdrige);

            await _statisticsSystem.SumOneSpotGameBoyCartdrigeToStatisticsAsync();

            string logEntry = $"SPOT: Cartucho Game Boy. Id del juego: {cartdrige.IdGame}, Nombre: {cartdrige.Name}, " +
                $"Precio de spot: {cartdrige.PurchasePrice}€";
            await _logger.WriteLogEntryAsync(logEntry);

            await _unitOfWork.SaveChangesAsync();

            return _presenter.Present(cartdrige);
        }
    }
}
