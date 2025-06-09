
using _1_Domain.Product_Entities;
using _1_Domain.Sold_Product_Entities;
using _2_Services.Exceptions;
using _2_Services.Interfaces;
using AutoMapper;

namespace _2_Services.Services.SaleServices
{
    public class RevertSellConsoleService<TViewModel>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        private readonly IReferenceSystem _referenceSystem;
        private readonly IStatisticsSystem _statisticsSystem;
        private readonly IAccountingSystem _accountingSystem;
        private readonly ILogger _logger;
        private readonly IProductValidator<VideoConsole> _consoleValidator;
        private readonly IPresenter<VideoConsole, TViewModel> _presenter;
        public RevertSellConsoleService(IUnitOfWork unitOfWork,
            IMapper mapper,
            IReferenceSystem referenceSystem,
            IStatisticsSystem statisticsSystem,
            IAccountingSystem accountingSystem,
            ILogger logger,
            IProductValidator<VideoConsole> consoleValidator,
            IPresenter<VideoConsole, TViewModel> presenter)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
            _referenceSystem = referenceSystem;
            _statisticsSystem = statisticsSystem;
            _accountingSystem = accountingSystem;
            _logger = logger;
            _consoleValidator = consoleValidator;
            _presenter = presenter;
        }

        public async Task<TViewModel> ExecuteAsync(SoldVideoConsole soldVideoConsole)
        {
            if (soldVideoConsole == null) { throw new Exception("Error: La venta de consola que intenta revertirse tiene un valor nulo."); }

            var console = _mapper.Map<VideoConsole>(soldVideoConsole);
            await _referenceSystem.AssignReferenceToProductAsync(console);

            bool productIsValid = await _consoleValidator.ValidateProductAsync(console);
            if (!productIsValid) { throw new ProductValidationException(_consoleValidator.Errors); }

            await _unitOfWork.SoldConsoleRepository.Delete(soldVideoConsole);
            await _unitOfWork.ConsoleRepository.AddAsync(console);

            await _statisticsSystem.WithdrawOneSoldConsoleFromStatisticsAsync(soldVideoConsole.IdProductType);
            await _accountingSystem.WithdrawSalePriceFromIncomeAsync(soldVideoConsole.SaleDate, soldVideoConsole.SalePrice);

            string logEntry = $"REVERTIR VENTA: Consola. Nueva ref: {console.Reference}, Nombre: {console.Name}, " +
                $"Fecha de venta: {soldVideoConsole.SaleDate.ToString("yyyy-MM-dd")}, Precio de venta: {soldVideoConsole.SalePrice}€";
            await _logger.WriteLogEntryAsync(logEntry);

            await _unitOfWork.SaveChangesAsync();

            return _presenter.Present(console);
        }
    }
}
