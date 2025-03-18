﻿
using _1_Entities;
using _2_Services.Services.Cartdrige_Services;
using _2_Services.Services.ConsoleServices;
using _2_Services.Services.Purchase_Services;
using _3_AccountingSystem;
using _3_Data;
using _3_Loggers;
using _3_Mappers.Automapper;
using _3_Mappers.DTOs;
using _3_Mappers.DTOs.Purchase_Dtos;
using _3_ReferenceSystem;
using _3_Repository;
using _3_StatisticSystem;
using _3_Validators;
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
});

// Crear el Mapper
IMapper mapper = configuration.CreateMapper();


var unitOfWork = new UnitOfWork(context, mapper);
var referenceSystem = new ReferenceSystem(context);
var statisticSystem = new StatisticSystem(context);
var accountingSystem = new AccountingSystem(context);
var logger = new Logger(context);
var cartdrigeValidator = new CartdrigeValidator(context);
var consoleValidator = new ConsoleValidator(context);

////////////////////////////////// SERVICIOS DE CARTDRIGE //////////////////////////////////

//var servicio = new GetAllCartdrigesService(unitOfWork);
//var cartuchos = await servicio.ExecuteAsync();
//foreach (var c in cartuchos)
//{
//    Console.WriteLine($" id:{c.Id}, ref:{c.IdReference}, idproducttype: {c.IdProductType}, idgame: {c.IdGame}, idsystem: quitado, " +
//        $"idregion: {c.IdRegion}, idcondition: {c.IdCondition}, purchasedate: {c.PurchaseDate}, purchaseprice:{c.PurchasePrice}, " +
//        $"name: {c.Name}, reference: {c.Reference}");
//}

//var servicio = new PurchaseGameBoyCartdrigeService<CartdrigePurchaseDto>(unitOfWork, mapper, referenceSystem, statisticSystem, accountingSystem, logger, cartdrigeValidator);
//var cartuchoDto = new CartdrigePurchaseDto() { IdProductType = 1, IdGame = 1, IdRegion = 1, IdCondition = 7, PurchasePrice = 50, Name = "Juego 1" };

//await servicio.ExecuteAsync(cartuchoDto);



////////////////////////////////// SERVICIOS DE CONSOLE //////////////////////////////////

//var servicio = new GetAllConsolesService(unitOfWork);
//var consoles = await servicio.ExecuteAsync();
//foreach (var c in consoles)
//{
//    Console.WriteLine($" id:{c.Id}, ref:{c.IdReference}, idproducttype: {c.IdProductType}, idsystem: {c.IdSystem}, " +
//        $"purchasedate: {c.PurchaseDate}, purchaseprice:{c.PurchasePrice}, sparepartsprice: {c.SparePartsPrice}, " +
//        $"totalprice: {c.TotalPrice}, name: {c.Name}, reference: {c.Reference}");
//}

var servicio = new PurchaseGameBoyConsoleService<ConsolePurchaseDto>(unitOfWork, mapper, referenceSystem, statisticSystem, accountingSystem, logger, consoleValidator);
var consoleDto = new ConsolePurchaseDto() { IdProductType = 2, IdSystem = 1, PurchasePrice = 100, Name = "Consola 1" };

await servicio.ExecuteAsync(consoleDto);




