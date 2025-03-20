
using _2_Services.Exceptions;
using _2_Services.Interfaces;

namespace _2_Services.Services.Console_Services
{
    public class SumSparePartsPriceToConsoleById
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly ILogger _logger;

        public SumSparePartsPriceToConsoleById(IUnitOfWork unitOfWork,
            ILogger logger)
        {
            _unitOfWork = unitOfWork;
            _logger = logger;
        }

        public async Task ExecuteAsync(int idConsole, decimal sparePartsPrice) 
        {
            try
            {
                var console = await _unitOfWork.ConsoleRepository.GetByIdAsync(idConsole);

                if (sparePartsPrice < 0) { throw new ProductValidationException("El precio de los recambios no puede ser negativo."); }

                if (console == null) { throw new KeyNotFoundException($"No se ha encontrado ningún elemento con Id {idConsole} en la tabla 'Console'."); }

                console.SumToSparePartsPrice(sparePartsPrice);

                _unitOfWork.ConsoleRepository.Update(console);

                string logEntry = $"SUMADO PRECIO DE RECAMBIOS. Id: {idConsole}, Ref: {console.Reference}, Nombre: {console.Name.ToUpper()}, " +
                    $"Precio añadido: {sparePartsPrice}€";
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
