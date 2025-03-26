
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

        public RevertPurchaseSparePartsService(IUnitOfWork unitOfWork,
            IAccountingSystem accountingSystem,
            ILogger logger)
        {
            _unitOfWork = unitOfWork;
            _accountingSystem = accountingSystem;
            _logger = logger;
        }

        public async Task ExecuteAsync(SparePartsPurchase sparePartsPurchase)
        {
            try
            {
                if (sparePartsPurchase == null) { throw new Exception("Error: La compra de recambios que intenta revertirse tiene un valor nulo."); }

                await _unitOfWork.SparePartsPurchaseRepository.Delete(sparePartsPurchase);

                await _accountingSystem.WithdrawPurchasePriceFromExpensesAsync(sparePartsPurchase.PurchaseDate, sparePartsPurchase.PurchasePrice);

                string logEntry = $"REVERTIDA COMPRA: Recambios. Tipo: {sparePartsPurchase.Name}, Concepto: {sparePartsPurchase.Concept}, " +
                    $"Fecha de compra: {sparePartsPurchase.PurchaseDate.ToString("yyyy-MM-dd")}, Precio de compra: {sparePartsPurchase.PurchasePrice}€";
                await _logger.WriteLogEntryAsync(logEntry);

                await _unitOfWork.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
    }
}
