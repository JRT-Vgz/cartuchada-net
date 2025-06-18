
using _3_AccountingSystem;
using _3_Data;
using _3_Loggers;
using _3_Mappers.Automapper;
using _3_ReferenceSystem;
using _3_Repository;
using _3_StatisticSystem;
using _3_Validators.Data_Validators.Purchase_Dto_Validators;
using _3_Validators.Data_Validators.Sale_Dto_Validators;
using _3_Validators.Entity_Validators;
using AutoMapper;
using Microsoft.EntityFrameworkCore;


var connectionString = "Server = localhost; Database = Cartuchada; Trusted_Connection = True; MultipleActiveResultSets = true; TrustServerCertificate = True";
var options = new DbContextOptionsBuilder<AppDbContext>()
    .UseSqlServer(connectionString)
    .Options;
var context = new AppDbContext(options);


var configuration = new MapperConfiguration(cfg =>
{
    cfg.AddProfile(new CartdrigeMappingProfile());
    cfg.AddProfile(new ConsoleMappingProfile());
    cfg.AddProfile(new SparePartsPurchaseMappingProfile());
    cfg.AddProfile(new SpotMappingProfile());
    cfg.AddProfile(new SoldCartdrigeMappingProfile());
    cfg.AddProfile(new SoldConsoleMappingProfile());
    cfg.AddProfile(new SoldSleeveMappingProfile());
});

// Crear el Mapper
IMapper mapper = configuration.CreateMapper();


var unitOfWork = new UnitOfWork(context, mapper);
var referenceSystem = new ReferenceSystem(context);
var statisticSystem = new StatisticSystem(context);
var accountingSystem = new AccountingSystem(context);
var logger = new Logger(context);
var cartdrigeValidator = new PurchasedCartdrigeValidator(context);
var consoleValidator = new PurchasedConsoleValidator(context);
var sparePartsPurchaseValidator = new SparePartsPurchaseValidator(context);
var soldCartdrigeValidator = new SoldCartdrigeValidator(context);
var soldConsoleValidator = new SoldConsoleValidator(context);
var soldSleeveValidator = new SoldSleeveValidator(context);

var cartdrigeDtoValidator = new CartdrigePurchaseDtoValidator();
var consoleDtoValidator = new ConsolePurchaseDtoValidator();
var sparePartsPurchaseDtoValidator = new SparePartsPurchaseDtoValidator();
var sleeveSaleDtoValidator = new SleeveSaleDtoValidator();

