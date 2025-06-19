using _1_Domain.Product_Entities;
using _1_Domain.Purchase_Entities;
using _1_Domain.Sold_Product_Entities;
using _2_Services.Interfaces;
using _2_Services.Services.Cartdrige_Services;
using _2_Services.Services.Console_Services;
using _2_Services.Services.Purchase_Services;
using _2_Services.Services.SaleServices;
using _2_Services.Services.Sleeve_Services;
using _2_Services.Services.Spare_Parts_Services;
using _3_AccountingSystem;
using _3_Data;
using _3_Encrypter;
using _3_Loggers;
using _3_Mappers.Automapper;
using _3_Mappers.DTOs.Purchase_Dtos;
using _3_Mappers.DTOs.Sale_Dtos;
using _3_Presenters.Presenters.Purchase_Presenters;
using _3_Presenters.Presenters.Sale_Presenters;
using _3_Presenters.View_Models;
using _3_ReferenceSystem;
using _3_Repository;
using _3_Repository.Query_Objects;
using _3_StatisticSystem;
using _3_Validators.Data_Validators.Purchase_Dto_Validators;
using _3_Validators.Data_Validators.Sale_Dto_Validators;
using _3_Validators.Entity_Validators;
using Cartuchada.Forms;
using Cartuchada.Forms.Miscelanea_Forms;
using Cartuchada.Forms.Purchase_Forms;
using Cartuchada.Forms.Purchase_Forms.Purchase_Cartdrige_Forms;
using Cartuchada.Forms.Purchase_Forms.Purchase_Console_Forms;
using Cartuchada.Forms.Purchase_Forms.Purchase_Spare_Parts_Forms;
using Cartuchada.Forms.Sell_Forms;
using Cartuchada.Forms.Sell_Forms.Sell_Cartdrige_Forms;
using Cartuchada.Forms.Sell_Forms.Sell_Console_Forms;
using Cartuchada.Forms.Sell_Forms.Sell_Sleeves_Forms;
using FluentValidation;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection;

namespace Cartuchada
{
    internal static class Program
    {
        private const string _DATABASE_NAMESPACE = "Cartuchada.Resources.AppSettings";
        private const string _DATABASE_JSON_FILE = "appsettings.prod.json";

        [STAThread]
        static void Main()
        {
            var services = new ServiceCollection();
            ConfigureServices(services);

            var serviceProvider = services.BuildServiceProvider();

            var mainForm = serviceProvider.GetRequiredService<FormCartuchadaMain>();
            Application.Run(mainForm);
        }

        private static void ConfigureServices(ServiceCollection services)
        {
            var configuration = BuildConfiguration();

            // INYECCION DE DEPENDENCIAS.          
            // ENTITY FRAMEWORK
            string connectionString = Encrypter.Decrypt(configuration.GetConnectionString("DB"));

            services.AddDbContext<AppDbContext>(options =>
                options.UseSqlServer(connectionString));


            // UNIT OF WORK
            services.AddTransient<IUnitOfWork, UnitOfWork>();


            // QUERY OBJECTS
            services.AddTransient(typeof(IGetAllQuery<>), typeof(GetAllQuery<>));
            services.AddTransient<GetAllConsoleProductTypesQuery>();
            services.AddTransient<GetAllSleevesQuery>();
            services.AddTransient<FilterGameCatalogueQuery>();
            services.AddTransient<FilterCartdrigeQuery>();
            services.AddTransient<FilterConsoleQuery>();
            services.AddTransient<FilterSoldCartdrigeQuery>();
            services.AddTransient<FilterSpotedCartdrigeQuery>();
            services.AddTransient<GetAllSoldOrSpottedUniqueGameIdsQuery>();


            // PRESENTERS
            services.AddTransient<IPresenter<Cartdrige, CartdrigePurchaseViewModel>, CartdrigePurchasePresenter>();
            services.AddTransient<IPresenter<Cartdrige, SpotCartdrigeViewModel>, SpotCartdrigePresenter>();
            services.AddTransient<IPresenter<VideoConsole, ConsolePurchaseViewModel>, ConsolePurchasePresenter>();
            services.AddTransient<IPresenter<SparePartsPurchase, SparePartsPurchaseViewModel>, SparePartsPurchasePresenter>();
            services.AddTransient<IPresenter<SoldSleeve, SleeveSaleViewModel>, SleeveSalePresenter>();


            // MAPPERS
            services.AddAutoMapper(
                typeof(CartdrigeMappingProfile)
                );


            // LOGGERS
            services.AddTransient<ILogger, Logger>();


            // VALIDATORS:
            services.AddTransient<IValidator<CartdrigePurchaseDto>, CartdrigePurchaseDtoValidator>();
            services.AddTransient<IProductValidator<Cartdrige>, PurchasedCartdrigeValidator>();
            services.AddTransient<INonReferencedProductValidator<Cartdrige>, SpotedCartdrigeValidator>();
            services.AddTransient<IValidator<ConsolePurchaseDto>, ConsolePurchaseDtoValidator>();
            services.AddTransient<IProductValidator<VideoConsole>, PurchasedConsoleValidator>();
            services.AddTransient<IValidator<SparePartsPurchaseDto>, SparePartsPurchaseDtoValidator>();
            services.AddTransient<IProductValidator<SparePartsPurchase>, SparePartsPurchaseValidator>();
            services.AddTransient<IProductValidator<SoldCartdrige>, SoldCartdrigeValidator>();
            services.AddTransient<IProductValidator<SoldVideoConsole>, SoldConsoleValidator>();
            services.AddTransient<IValidator<SleeveSaleDto>, SleeveSaleDtoValidator>();
            services.AddTransient<IProductValidator<SoldSleeve>, SoldSleeveValidator>();


            // INYECCI�N DE SISTEMAS
            services.AddTransient<IReferenceSystem, ReferenceSystem>();
            services.AddTransient<IStatisticsSystem, StatisticSystem>();
            services.AddTransient<IAccountingSystem, AccountingSystem>();


            // INYECCI�N DE SERVICIOS
            services.AddTransient<PurchaseCartdrigeService<CartdrigePurchaseDto, CartdrigePurchaseViewModel>>();
            services.AddTransient<PurchaseConsoleService<ConsolePurchaseDto, ConsolePurchaseViewModel>>();
            services.AddTransient<PurchaseSparePartsService<SparePartsPurchaseDto, SparePartsPurchaseViewModel>>();
            services.AddTransient<GetAllCartdrigesService>();
            services.AddTransient<GetAllConsolesService>();
            services.AddTransient<SellCartdrigeService>();
            services.AddTransient<SellConsoleService>();
            services.AddTransient<RevertPurchaseCartdrigeService>();
            services.AddTransient<RevertPurchaseConsoleService>();
            services.AddTransient<SumSparePartsPriceToConsoleById>();
            services.AddTransient<WithdrawSparePartsPriceFromConsoleById>();
            services.AddTransient<SellSleeveService<SleeveSaleDto, SleeveSaleViewModel>>();
            services.AddTransient<GetAllSoldCartdrigesService>();
            services.AddTransient<GetAllSoldConsolesService>();
            services.AddTransient<GetAllSoldSleevesService>();
            services.AddTransient<RevertSellCartdrigeService<CartdrigePurchaseViewModel>>();
            services.AddTransient<RevertSellConsoleService<ConsolePurchaseViewModel>>();
            services.AddTransient<RevertSellSleeveService>();
            services.AddTransient<GetAllSparePartsPurchasesService>();
            services.AddTransient<RevertPurchaseSparePartsService>();
            services.AddTransient<SpotCartdrigePurchaseService<CartdrigePurchaseDto, SpotCartdrigeViewModel>>();
            services.AddTransient<RevertSpotCartdrigePurchaseService>();
            services.AddTransient<GetAllSpotCartdrigesService>();


            // INYECCI�N DE FORMULARIOS
            services.AddTransient<FormCartuchadaMain>();

            services.AddTransient<FormPurchaseMain>();
            services.AddTransient<FormGameCatalogue>();
            services.AddTransient<FormPurchaseSpotCartdrige>();
            services.AddTransient<FormPurchaseConsole>();
            services.AddTransient<FormPurchaseSpareParts>();
            services.AddTransient<FormSellMain>();
            services.AddTransient<FormSellCartdrige>();
            services.AddTransient<FormManageSellCartdrige>();
            services.AddTransient<FormSellConsole>();
            services.AddTransient<FormManageSellConsole>();
            services.AddTransient<FormSellSleeves>();
            services.AddTransient<FormSalesHistory>();
            services.AddTransient<FormPurchasesHistory>();
            services.AddTransient<FormConfirmRevertInput>();
            services.AddTransient<FormStatistics>();
            services.AddTransient<FormLog>();
            services.AddTransient<FormAccounting>();
            services.AddTransient<FormRecommendedCartdrigePrice>();
        }

        private static IConfiguration BuildConfiguration()
        {
            var assembly = Assembly.GetExecutingAssembly();

            // Leer el archivo JSON como recurso incrustado
            using (var stream = assembly.GetManifestResourceStream($"{_DATABASE_NAMESPACE}.{_DATABASE_JSON_FILE}"))
            {
                if (stream == null)
                {
                    throw new FileNotFoundException("El archivo de configuraci�n no se encuentra como recurso incrustado.");
                }

                var configuration = new ConfigurationBuilder()
                    .AddJsonStream(stream)
                    .Build();

                return configuration;
            }
        }
    }
}