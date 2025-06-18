

using _1_Domain.Product_Entities;
using _1_Domain.Sold_Product_Entities;
using _2_Services.Services.Cartdrige_Services;
using _2_Services.Services.Console_Services;
using _2_Services.Services.Purchase_Services;
using _2_Services.Services.SaleServices;
using _2_Services.Services.Sleeve_Services;
using _2_Services.Services.Spare_Parts_Services;
using _3_AccountingSystem;
using _3_Data;
using _3_Data.Models;
using _3_Encrypter;
using _3_Loggers;
using _3_Mappers.Automapper;
using _3_Mappers.DTOs;
using _3_Mappers.DTOs.Purchase_Dtos;
using _3_Mappers.DTOs.Sale_Dtos;
using _3_ReferenceSystem;
using _3_Repository;
using _3_StatisticSystem;
using _3_Validators.Data_Validators.Purchase_Dto_Validators;
using _3_Validators.Data_Validators.Sale_Dto_Validators;
using _3_Validators.Entity_Validators;
using AutoMapper;
using Cartuchada_Console;
using FluentValidation;
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

var texto = "Server=tcp:sql-server-cartuchada.database.windows.net,1433;Initial Catalog=sql-db-cartuchada;Persist Security Info=False;User ID=Vargath;Password=Jebimalo666;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;";
string pass = Encrypter.Encrypt(texto);
Console.WriteLine(pass);

////////////////////////////////// SERVICIOS DE CARTDRIGE //////////////////////////////////

//var servicio = new GetAllCartdrigesService(unitOfWork);
//var cartuchos = await servicio.ExecuteAsync();
//foreach (var c in cartuchos)
//{
//    Console.WriteLine($" id:{c.Id}, ref:{c.IdReference}, idproducttype: {c.IdProductType}, idgame: {c.IdGame}, " +
//        $"idregion: {c.IdRegion}, idcondition: {c.IdCondition}, purchasedate: {c.PurchaseDate}, purchaseprice:{c.PurchasePrice}, " +
//        $"name: {c.Name}, reference: {c.Reference}");
//}

//var servicio = new PurchaseGameBoyCartdrigeService<CartdrigePurchaseDto>(unitOfWork, mapper, referenceSystem, statisticSystem, accountingSystem, logger, cartdrigeValidator, cartdrigeDtoValidator);
//var cartuchoDto = new CartdrigePurchaseDto() { IdProductType = 1, IdGame = 1612, IdRegion = 2, IdCondition = 7, PurchasePrice = 50, Name = "Juego 1" };

//await servicio.ExecuteAsync(cartuchoDto);


////////////////////////////////// SERVICIOS DE CONSOLE //////////////////////////////////

//var servicio = new GetAllConsolesService(unitOfWork);
//var consoles = await servicio.ExecuteAsync();
//foreach (var c in consoles)
//{
//    Console.WriteLine($" id:{c.Id}, ref:{c.IdReference}, idproducttype: {c.IdProductType}, " +
//        $"purchasedate: {c.PurchaseDate}, purchaseprice:{c.PurchasePrice}, sparepartsprice: {c.SparePartsPrice}, " +
//        $"totalprice: {c.TotalPrice}, name: {c.Name}, reference: {c.Reference}");
//}



//var servicio = new PurchaseConsoleService<ConsolePurchaseDto>(unitOfWork, mapper, referenceSystem, statisticSystem, accountingSystem, logger, consoleValidator, consoleDtoValidator);
//var consoleDto = new ConsolePurchaseDto() { IdProductType = 4, PurchasePrice = 150, Name = "Videoconsola Game Gear" };

//await servicio.ExecuteAsync(consoleDto);



//var servicio = new SumSparePartsPriceToConsoleById(unitOfWork, logger);
//await servicio.ExecuteAsync(7, 50);



//var servicio = new WithdrawSparePartsPriceFromConsoleById(unitOfWork, logger);
//await servicio.ExecuteAsync(7, 20.25m);



////////////////////////////////// SERVICIOS DE SPARE PARTS //////////////////////////////////

//var servicio = new GetAllSparePartsPurchases(unitOfWork);
//var sparePartPurchases = await servicio.ExecuteAsync();
//foreach (var c in sparePartPurchases)
//{
//    Console.WriteLine($" id: {c.Id}, idSparePartType:{c.IdSparePartType}, purchasedate: {c.PurchaseDate}, concept: {c.Concept}, " +
//        $"purchaseprice:{c.PurchasePrice}, name: {c.Name}");
//}

//var servicio = new PurchaseSparePartsService<SparePartsPurchaseDto>(unitOfWork, mapper, sparePartsPurchaseValidator, accountingSystem, logger, sparePartsPurchaseDtoValidator);
//var sparePartsPurchaseDto = new SparePartsPurchaseDto() { IdSparePartType = 1, Concept = "concepto", PurchasePrice = 100, Name = "Recambios game boy" };

//await servicio.ExecuteAsync(sparePartsPurchaseDto);




// SERVICIOS DE SPOT

//var spots = await unitOfWork.SpotRepository.GetAllAsync();

//foreach (var c in spots)
//{
//    Console.WriteLine($" id:{c.Id}, idproducttype: {c.IdProductType}, idgame: {c.IdGame}, " +
//        $"idregion: {c.IdRegion}, idcondition: {c.IdCondition}, purchasedate: {c.PurchaseDate}, purchaseprice:{c.PurchasePrice}, " +
//        $"name: {c.Name}");
//}


//var servicio = new SpotCartdrigePurchaseService<CartdrigePurchaseDto>(unitOfWork, mapper, statisticSystem, logger, cartdrigeValidator, cartdrigeDtoValidator);
//var cartuchoDto = new CartdrigePurchaseDto() { IdProductType = 1, IdGame = 1, IdRegion = 1, IdCondition = 7, PurchasePrice = 50, Name = "Juego 1" };

//await servicio.ExecuteAsync(cartuchoDto);




// VENTA DE CARTUCHO


//var servicio = new GetAllSoldCartdrigesService(unitOfWork);
//var cartuchos = await servicio.ExecuteAsync();
//foreach (var c in cartuchos)
//{
//    Console.WriteLine($" id:{c.Id}, idproducttype: {c.IdProductType}, idgame: {c.IdGame}, " +
//        $"idregion: {c.IdRegion}, idcondition: {c.IdCondition}, purchasedate: {c.PurchaseDate}, purchaseprice:{c.PurchasePrice}, " +
//        $"saledate: {c.SaleDate}, saleprice: {c.SalePrice}, benefit: {c.Benefit}, name: {c.Name}");
//}


//var servicio = new SellGameBoyCartdrigeService(unitOfWork, mapper, referenceSystem, statisticSystem, accountingSystem, logger, cartdrigeValidator, soldCartdrigeValidator);

//var cartucho = await unitOfWork.CartdrigeRepository.GetByIdAsync(14);

//await servicio.ExecuteAsync(cartucho, 100);



// VENTA DE CONSOLA

//var servicio = new GetAllSoldConsolesService(unitOfWork);
//var consolas = await servicio.ExecuteAsync();
//foreach (var c in consolas)
//{
//    Console.WriteLine($" id:{c.Id}, idproducttype: {c.IdProductType}, purchasedate: {c.PurchaseDate}, purchaseprice:{c.PurchasePrice}, " +
//        $"sparepartsprice: {c.SparePartsPrice}, totalprice: {c.TotalPrice}, saledate: {c.SaleDate}, saleprice: {c.SalePrice}, benefit: {c.Benefit}, " +
//        $"name: {c.Name}");
//}


//var servicio = new SellConsoleService(unitOfWork, mapper, referenceSystem, statisticSystem, accountingSystem, logger, consoleValidator, soldConsoleValidator);

//var consola = await unitOfWork.ConsoleRepository.GetByIdAsync(7);

//await servicio.ExecuteAsync(consola, 200);



// VENTA DE FUNDAS

//var servicio = new GetAllSoldSleevesService(unitOfWork);
//var fundas = await servicio.ExecuteAsync();
//foreach (var f in fundas)
//{
//    Console.WriteLine($" id:{f.Id}, idspareparttype: {f.IdSparePartType}, quantity; {f.Quantity}, saledate: {f.SaleDate}, " +
//        $"saleprice: {f.SalePrice}, name: {f.Name}");
//}


//var servicio = new SellSleeveService<SleeveSaleDto>(unitOfWork, mapper, statisticSystem, accountingSystem, logger, soldSleeveValidator, sleeveSaleDtoValidator);

//var fundaDto = new SleeveSaleDto() { IdSparePartType = 3, Quantity = 30, SalePrice = 30, Name = "Funda" };

//await servicio.ExecuteAsync(fundaDto);



// PRUEBAS DELETE EN CASCADA
//var refModel = new ReferenceModel() { Id = 1, IdProductType = 1, Name = "GB-1", Assigned = true };
////var refModel = new ReferenceModel() { Id = 4, IdProductType = 1, Name = "GB-1", Assigned = true };

//context.References.Remove(refModel);
//context.SaveChanges();


//var regionModel = new RegionModel() { Id = 2, Name = "Cartucho Game Boy" };
//context.Regions.Remove(regionModel);
//context.SaveChanges();


//var cartdrige = await context.Cartdriges.FindAsync(1);

//context.Cartdriges.Remove(cartdrige);
//context.SaveChanges();





////////////////////////////////// REVERT COMPRA CARTUCHO //////////////////////////////////

//var servicio = new RevertPurchaseGameBoyCartdrigeService(unitOfWork, referenceSystem, statisticSystem, accountingSystem, logger, cartdrigeValidator);
//var cartucho = await unitOfWork.CartdrigeRepository.GetByIdAsync(15);

//await servicio.ExecuteAsync(cartucho);


////////////////////////////////// REVERT COMPRA CONSOLA //////////////////////////////////

//var servicio = new RevertPurchaseConsoleService(unitOfWork, referenceSystem, statisticSystem, accountingSystem, logger, consoleValidator);
//var consola = await unitOfWork.ConsoleRepository.GetByIdAsync(8);

//await servicio.ExecuteAsync(consola);


////////////////////////////////// REVERT COMPRA SPARE PARTS //////////////////////////////////

//var servicio = new RevertPurchaseSparePartsService(unitOfWork, accountingSystem, logger, sparePartsPurchaseValidator);
//var sparePartsPurchase = await unitOfWork.SparePartsPurchaseRepository.GetByIdAsync(5);

//await servicio.ExecuteAsync(sparePartsPurchase);


////////////////////////////////// REVERT SPOT CARTUCHO //////////////////////////////////

//var servicio = new RevertSpotCartdrigePurchaseService(unitOfWork, statisticSystem, logger);
//var cartdrige = await unitOfWork.SpotRepository.GetByIdAsync(6);

//await servicio.ExecuteAsync(cartdrige);


////////////////////////////////// REVERT VENTA CARTUCHO //////////////////////////////////

//var servicio = new RevertSellGameBoyCartdrigeService(unitOfWork, mapper, referenceSystem, statisticSystem, accountingSystem, logger, cartdrigeValidator);
//var soldCartdrige = await unitOfWork.SoldCartdrigeRepository.GetByIdAsync(5);

//await servicio.ExecuteAsync(soldCartdrige);


////////////////////////////////// REVERT VENTA CONSOLA //////////////////////////////////

//var servicio = new RevertSellConsoleService(unitOfWork, mapper, referenceSystem, statisticSystem, accountingSystem, logger, consoleValidator);
//var soldConsole = await unitOfWork.SoldConsoleRepository.GetByIdAsync(8);

//await servicio.ExecuteAsync(soldConsole);


////////////////////////////////// REVERT SOLD SLEEVE //////////////////////////////////

//var servicio = new RevertSellSleeveService(unitOfWork, mapper, statisticSystem, accountingSystem, logger, soldSleeveValidator);
//var soldSleeve = await unitOfWork.SoldSleeveRepository.GetByIdAsync(4);

//await servicio.ExecuteAsync(soldSleeve);

