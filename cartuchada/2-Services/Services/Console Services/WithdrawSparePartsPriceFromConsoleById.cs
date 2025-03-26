
using _2_Services.Exceptions;
using _2_Services.Interfaces;

namespace _2_Services.Services.Console_Services
{
    public class WithdrawSparePartsPriceFromConsoleById
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly ILogger _logger;

        public WithdrawSparePartsPriceFromConsoleById(IUnitOfWork unitOfWork,
            ILogger logger)
        {
            _unitOfWork = unitOfWork;
            _logger = logger;
        }

        public async Task ExecuteAsync(int idConsole, decimal sparePartsPriceToWithdraw)
        {
            try
            {
                var console = await _unitOfWork.ConsoleRepository.GetByIdAsync(idConsole);

                if (sparePartsPriceToWithdraw < 0) { throw new ProductValidationException("El precio a quitar de la consola por los recambios no puede ser negativo."); }

                if (console == null) { throw new KeyNotFoundException($"No se ha encontrado ningún elemento con Id {idConsole} en la tabla 'Console'."); }

                console.WithdrawFromSparePartsPrice(sparePartsPriceToWithdraw);

                _unitOfWork.ConsoleRepositoryUpdate.Update(console);

                string logEntry = $"RESTADO PRECIO DE RECAMBIOS. Id: {idConsole}, Ref: {console.Reference}, Nombre: {console.Name.ToUpper()}, " +
                    $"Precio restado: {sparePartsPriceToWithdraw}€";
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
