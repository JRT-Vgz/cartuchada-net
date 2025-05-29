using _1_Domain.Product_Entities;
using _2_Services.Interfaces;
using _2_Services.Services.Purchase_Services;
using _3_AccountingSystem;
using _3_Data;
using _3_Loggers;
using _3_Mappers.Automapper;
using _3_Mappers.DTOs;
using _3_Presenters.Presenters.Purchase_Presenters;
using _3_Presenters.View_Models;
using _3_ReferenceSystem;
using _3_Repository;
using _3_Repository.Query_Objects;
using _3_StatisticSystem;
using _3_Validators.Data_Validators.Purchase_Dto_Validators;
using _3_Validators.Entity_Validators;
using Cartuchada.Forms;
using Cartuchada.Forms.Purchase_Forms;
using Cartuchada.Forms.Purchase_Forms.Purchase_Cartdrige_Forms;
using FluentValidation;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection;

namespace Cartuchada
{
    internal static class Program
    {
        public const string DATABASE_NAMESPACE = "Cartuchada.Resources.AppSettings";
        public const string DATABASE_JSON_FILE = "appsettings.dev.json";

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
            //string connectionString = DBEncrypter.Decrypt(configuration.GetConnectionString("DB"));
            string connectionString = configuration.GetConnectionString("DB");
            //string connectionString = "Server = localhost; Database = Cartuchada; Trusted_Connection = True; MultipleActiveResultSets = true; TrustServerCertificate = True";
            services.AddDbContext<AppDbContext>(options =>
                options.UseSqlServer(connectionString));

            // REPOSITORIOS


            // UNIT OF WORK
            services.AddTransient<IUnitOfWork, UnitOfWork>();


            // QUERY OBJECTS
            services.AddTransient<FilterGameCatalogueQuery>();
            services.AddTransient<GetAllRegionsQuery>();
            services.AddTransient<GetAllConditionsQuery>();

            // PRESENTERS
            services.AddTransient<IPresenterWithReference<CartdrigePurchaseDto, PurchaseGameBoyCartdrigeViewModel>, PurchaseGameBoyCartdrigePresenter>();

            // MANUAL MAPPERS


            // MAPPERS
            services.AddAutoMapper(
                typeof(CartdrigeMappingProfile)
                );

            // LOGGERS
            services.AddTransient<ILogger, Logger>();

            // VALIDATORS:
            services.AddTransient<IValidator<CartdrigePurchaseDto>, CartdrigePurchaseDtoValidator>();
            services.AddTransient<IProductValidator<Cartdrige>, PurchasedCartdrigeValidator>();

            // INYECCION DE ARCHIVO DE CONSTANTES
            //services.AddSingleton<ConstantsConfigurationService>();

            // INYECCIÓN DE SISTEMAS
            services.AddTransient<IReferenceSystem, ReferenceSystem>();
            services.AddTransient<IStatisticsSystem, StatisticSystem>();
            services.AddTransient<IAccountingSystem, AccountingSystem>();


            // INYECCIÓN DE SERVICIOS
            services.AddTransient<PurchaseGameBoyCartdrigeService<CartdrigePurchaseDto, PurchaseGameBoyCartdrigeViewModel>>();


            // INYECCIÓN DE FORMULARIOS
            services.AddTransient<FormCartuchadaMain>();

            services.AddTransient<FormPurchaseMain>();
            services.AddTransient<FormGameCatalogue>();
            services.AddTransient<FormPurchaseCartdrige>();
        }

        private static IConfiguration BuildConfiguration()
        {
            var assembly = Assembly.GetExecutingAssembly();

            // Leer el archivo JSON como recurso incrustado
            using (var stream = assembly.GetManifestResourceStream($"{DATABASE_NAMESPACE}.{DATABASE_JSON_FILE}"))
            {
                if (stream == null)
                {
                    throw new FileNotFoundException("El archivo de configuración no se encuentra como recurso incrustado.");
                }

                var configuration = new ConfigurationBuilder()
                    .AddJsonStream(stream)
                    .Build();

                return configuration;
            }
        }
    }
}