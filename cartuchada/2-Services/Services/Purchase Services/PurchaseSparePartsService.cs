using _1_Domain.Purchase_Entities;
using _2_Services.Exceptions;
using _2_Services.Interfaces;
using AutoMapper;
using FluentValidation;

namespace _2_Services.Services.Purchase_Services
{
    public class PurchaseSparePartsService<TDto, TViewModel>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        private readonly IProductValidator<SparePartsPurchase> _sparePartsPurchaseValidator;
        private readonly IAccountingSystem _accountingSystem;
        private readonly ILogger _logger;
        private readonly IValidator<TDto> _sparePartsPurchaseDtoValidator;
        private readonly IPresenter<SparePartsPurchase, TViewModel> _presenter;

        public PurchaseSparePartsService(IUnitOfWork unitOfWork,
            IMapper mapper,
            IProductValidator<SparePartsPurchase> sparePartsPurchaseValidator,
            IAccountingSystem accountingSystem,
            ILogger logger,
            IValidator<TDto> sparePartsPurchaseDtoValidator,
            IPresenter<SparePartsPurchase, TViewModel> presenter)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
            _sparePartsPurchaseValidator = sparePartsPurchaseValidator;
            _accountingSystem = accountingSystem;
            _logger = logger;
            _sparePartsPurchaseDtoValidator = sparePartsPurchaseDtoValidator;
            _presenter = presenter;
        }

        public async Task<TViewModel> ExecuteAsync(TDto sparePartsPurchaseDto)
        {
            var dataValidationResult = _sparePartsPurchaseDtoValidator.Validate(sparePartsPurchaseDto);
            if (!dataValidationResult.IsValid)
            {
                var errors = dataValidationResult.Errors
                .Select(e => e.ErrorMessage)
                .ToList();

                throw new DataValidationException(errors);
            }

            var sparePartsPurchase = _mapper.Map<SparePartsPurchase>(sparePartsPurchaseDto);

            bool productIsValid = await _sparePartsPurchaseValidator.ValidateProductAsync(sparePartsPurchase);
            if (!productIsValid) { throw new ProductValidationException(_sparePartsPurchaseValidator.Errors); }

            await _unitOfWork.SparePartsPurchaseRepository.AddAsync(sparePartsPurchase);

            await _accountingSystem.SumPurchasePriceToExpensesAsync(sparePartsPurchase.PurchaseDate, sparePartsPurchase.PurchasePrice);

            string logEntry = $"COMPRA: Recambios. Tipo: {sparePartsPurchase.Name}, Concepto: {sparePartsPurchase.Concept}, " +
                $"Precio de compra: {sparePartsPurchase.PurchasePrice}€";
            await _logger.WriteLogEntryAsync(logEntry);

            await _unitOfWork.SaveChangesAsync();

            return _presenter.Present(sparePartsPurchase);
        }
    }
}
