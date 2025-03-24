using _1_Domain.Purchase_Entities;
using _2_Services.Exceptions;
using _2_Services.Interfaces;
using AutoMapper;

namespace _2_Services.Services.Purchase_Services
{
    public class PurchaseSparePartsService<TDto>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        private readonly IProductValidator<SparePartsPurchase> _sparePartsPurchaseValdiator;
        private readonly IAccountingSystem _accountingSystem;
        private readonly ILogger _logger;

        public PurchaseSparePartsService(IUnitOfWork unitOfWork,
            IMapper mapper,
            IProductValidator<SparePartsPurchase> sparePartsPurchaseValdiator,
            IAccountingSystem accountingSystem,
            ILogger logger)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
            _sparePartsPurchaseValdiator = sparePartsPurchaseValdiator;
            _accountingSystem = accountingSystem;
            _logger = logger;
        }

        public async Task ExecuteAsync(TDto sparePartsPurchaseDto)
        {
            try
            {
                var sparePartsPurchase = _mapper.Map<SparePartsPurchase>(sparePartsPurchaseDto);

                bool productIsValid = await _sparePartsPurchaseValdiator.ValidateProductAsync(sparePartsPurchase);
                if (!productIsValid) { throw new ProductValidationException(_sparePartsPurchaseValdiator.Errors); }

                await _unitOfWork.SparePartsPurchaseRepository.AddAsync(sparePartsPurchase);

                await _accountingSystem.SumPurchasePriceToExpensesAsync(sparePartsPurchase.PurchaseDate, sparePartsPurchase.PurchasePrice);

                string logEntry = $"COMPRA: Recambios. Tipo: {sparePartsPurchase.Name}, Concepto: {sparePartsPurchase.Concept}, " +
                    $"Precio de compra: {sparePartsPurchase.PurchasePrice}€";
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
