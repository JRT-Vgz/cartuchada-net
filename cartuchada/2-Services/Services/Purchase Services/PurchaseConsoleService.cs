using _1_Domain.Product_Entities;
using _2_Services.Exceptions;
using _2_Services.Interfaces;
using AutoMapper;
using FluentValidation;

namespace _2_Services.Services.Purchase_Services
{
    public class PurchaseConsoleService<TDto, TViewModel>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        private readonly IReferenceSystem _referenceSystem;
        private readonly IStatisticsSystem _statisticsSystem;
        private readonly IAccountingSystem _accountingSystem;
        private readonly ILogger _logger;
        private readonly IProductValidator<VideoConsole> _consoleValidator;
        private readonly IValidator<TDto> _consolePurchaseDtoValidator;
        private readonly IPresenter<VideoConsole, TViewModel> _presenter;
        public PurchaseConsoleService(IUnitOfWork unitOfWork,
            IMapper mapper,
            IReferenceSystem referenceSystem,
            IStatisticsSystem statisticsSystem,
            IAccountingSystem accountingSystem,
            ILogger logger,
            IProductValidator<VideoConsole> consoleValidator,
            IValidator<TDto> consolePurchaseDtoValidator,
            IPresenter<VideoConsole, TViewModel> presenter)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
            _referenceSystem = referenceSystem;
            _statisticsSystem = statisticsSystem;
            _accountingSystem = accountingSystem;
            _logger = logger;
            _consoleValidator = consoleValidator;
            _consolePurchaseDtoValidator = consolePurchaseDtoValidator;
            _presenter = presenter;
        }

        public async Task<TViewModel> ExecuteAsync(TDto consoleDto)
        {
            var dataValidationResult = _consolePurchaseDtoValidator.Validate(consoleDto);
            if (!dataValidationResult.IsValid)
            {
                var errors = dataValidationResult.Errors
                .Select(e => e.ErrorMessage)
                .ToList();
                
                throw new DataValidationException(errors);
            }

            var console = _mapper.Map<VideoConsole>(consoleDto);

            await _referenceSystem.AssignReferenceToProductAsync(console);

            bool productIsValid = await _consoleValidator.ValidateProductAsync(console);
            if (!productIsValid) { throw new ProductValidationException(_consoleValidator.Errors); }

            await _unitOfWork.ConsoleRepository.AddAsync(console);

            await _statisticsSystem.SumOnePurchasedConsoleToStatisticsAsync(console.IdProductType);
            await _accountingSystem.SumPurchasePriceToExpensesAsync(console.PurchaseDate, console.PurchasePrice);

            string logEntry = $"COMPRA: Consola. Ref: {console.Reference}, Nombre: {console.Name}, " +
                $"Precio de compra: {console.PurchasePrice}€";
            await _logger.WriteLogEntryAsync(logEntry);

            await _unitOfWork.SaveChangesAsync();

            return _presenter.Present(console);
        }
    }
}
