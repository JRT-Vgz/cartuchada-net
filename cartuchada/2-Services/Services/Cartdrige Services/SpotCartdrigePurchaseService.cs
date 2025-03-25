using _1_Domain.Product_Entities;
using _2_Services.Exceptions;
using _2_Services.Interfaces;
using AutoMapper;
using FluentValidation;

namespace _2_Services.Services.Cartdrige_Services
{
    public class SpotCartdrigePurchaseService<TDto>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        private readonly IStatisticsSystem _statisticsSystem;
        private readonly ILogger _logger;
        private readonly IProductValidator<Cartdrige> _cartdrigeValidator;
        private readonly IValidator<TDto> _cartdrigePurchaseDtoValidator;
        public SpotCartdrigePurchaseService(IUnitOfWork unitOfWork,
            IMapper mapper,
            IStatisticsSystem statisticsSystem,
            ILogger logger,
            IProductValidator<Cartdrige> cartdrigeValidator,
            IValidator<TDto> cartdrigePurchaseDtoValidator)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
            _statisticsSystem = statisticsSystem;
            _logger = logger;
            _cartdrigeValidator = cartdrigeValidator;
            _cartdrigePurchaseDtoValidator = cartdrigePurchaseDtoValidator;
        }

        public async Task ExecuteAsync(TDto cartdrigeDto)
        {
            try
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
                cartdrige.AssignReference(0, "N/A");

                bool productIsValid = await _cartdrigeValidator.ValidateProductAsync(cartdrige);
                if (!productIsValid) { throw new ProductValidationException(_cartdrigeValidator.Errors); }

                await _unitOfWork.SpotRepository.AddAsync(cartdrige);

                await _statisticsSystem.SumOneSpotGameBoyCartdrigeToStatisticsAsync();

                string logEntry = $"SPOT: Cartucho Game Boy. Id del juego: {cartdrige.IdGame}, Nombre: {cartdrige.Name}, " +
                    $"Precio de spot: {cartdrige.PurchasePrice}€";
                await _logger.WriteLogEntryAsync(logEntry);

                await _unitOfWork.SaveChangesAsync();
            }
            catch (DataValidationException ex)
            {
                Console.WriteLine(ex.Message);
                foreach (var error in ex.Errors) { Console.WriteLine(error); }
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
