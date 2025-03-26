
using _1_Domain.Product_Entities;
using _1_Domain.Purchase_Entities;
using _2_Services.Exceptions;
using _2_Services.Interfaces;
using AutoMapper;
using FluentValidation;

namespace _2_Services.Services.Purchase_Services
{
    public class RevertPurchaseSparePartsService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IAccountingSystem _accountingSystem;
        private readonly ILogger _logger;
        private readonly IProductValidator<SparePartsPurchase> _sparePartsPurchaseValidator;

        public RevertPurchaseSparePartsService(IUnitOfWork unitOfWork,
            IAccountingSystem accountingSystem,
            ILogger logger,
            IProductValidator<SparePartsPurchase> sparePartsPurchaseValidator)
        {
            _unitOfWork = unitOfWork;
            _accountingSystem = accountingSystem;
            _logger = logger;
            _sparePartsPurchaseValidator = sparePartsPurchaseValidator;
        }

        public async Task ExecuteAsync(SparePartsPurchase sparePartsPurchase)
        {
            try
            {
                if (sparePartsPurchase == null) { throw new Exception("Error: La compra de recambios que intenta revertirse tiene un valor nulo."); }

                bool productIsValid = await _sparePartsPurchaseValidator.ValidateProductAsync(sparePartsPurchase);
                if (!productIsValid) { throw new ProductValidationException(_sparePartsPurchaseValidator.Errors); }

                await _unitOfWork.SparePartsPurchaseRepository.Delete(sparePartsPurchase);

                await _accountingSystem.WithdrawPurchasePriceFromExpensesAsync(sparePartsPurchase.PurchaseDate, sparePartsPurchase.PurchasePrice);

                string logEntry = $"REVERTIR COMPRA: Recambios. Tipo: {sparePartsPurchase.Name}, Concepto: {sparePartsPurchase.Concept}, " +
                    $"Fecha de compra: {sparePartsPurchase.PurchaseDate.ToString("yyyy-MM-dd")}, Precio de compra: {sparePartsPurchase.PurchasePrice}€";
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
