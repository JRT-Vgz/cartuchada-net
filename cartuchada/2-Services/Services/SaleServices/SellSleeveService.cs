
using _1_Domain.Sold_Product_Entities;
using _2_Services.Exceptions;
using _2_Services.Interfaces;
using AutoMapper;
using FluentValidation;

namespace _2_Services.Services.SaleServices
{
    public class SellSleeveService<TDto, TViewModel>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        private readonly IStatisticsSystem _statisticsSystem;
        private readonly IAccountingSystem _accountingSystem;
        private readonly ILogger _logger;
        private readonly IProductValidator<SoldSleeve> _soldSleeveValidator;
        private readonly IValidator<TDto> _sleeveSaleDtoValidator;
        private readonly IPresenter<TDto, TViewModel> _presenter;

        public SellSleeveService(IUnitOfWork unitOfWork,
            IMapper mapper,
            IStatisticsSystem statisticSystem,
            IAccountingSystem accountingSystem,
            ILogger logger,
            IProductValidator<SoldSleeve> soldSleeveValidator,
            IValidator<TDto> sleeveSaleDtoValidator,
            IPresenter<TDto, TViewModel> presenter)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
            _statisticsSystem = statisticSystem;
            _accountingSystem = accountingSystem;
            _logger = logger;
            _soldSleeveValidator = soldSleeveValidator;
            _sleeveSaleDtoValidator = sleeveSaleDtoValidator;
            _presenter = presenter;
        }

        public async Task<TViewModel> ExecuteAsync(TDto sleeveSaleDto)
        {
            var dataValidationResult = _sleeveSaleDtoValidator.Validate(sleeveSaleDto);
            if (!dataValidationResult.IsValid)
            {
                var errors = dataValidationResult.Errors
                .Select(e => e.ErrorMessage)
                .ToList();

                throw new DataValidationException(errors);
            }

            var soldSleeve = _mapper.Map<SoldSleeve>(sleeveSaleDto);

            bool productIsValid = await _soldSleeveValidator.ValidateProductAsync(soldSleeve);
            if (!productIsValid) { throw new ProductValidationException(_soldSleeveValidator.Errors); }

            await _unitOfWork.SoldSleeveRepository.AddAsync(soldSleeve);

            await _statisticsSystem.SumSoldSleevesToStatisticsAsync(soldSleeve.IdSparePartType, soldSleeve.Quantity);
            await _accountingSystem.SumSalePriceToIncomeAsync(soldSleeve.SaleDate, soldSleeve.SalePrice);

            string logEntry = $"VENTA: Fundas. Nombre: {soldSleeve.Name}, Cantidad: {soldSleeve.Quantity}, " +
                $"Precio de venta: {soldSleeve.SalePrice}€";
            await _logger.WriteLogEntryAsync(logEntry);

            await _unitOfWork.SaveChangesAsync();

            return _presenter.Present(sleeveSaleDto);
        }
    }
}
