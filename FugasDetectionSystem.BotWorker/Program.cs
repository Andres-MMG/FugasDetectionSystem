using FugasDetectionSystem.Domain.Interfaces;
using FugasDetectionSystem.Infrastructure.Services.Telegram;
using FugasDetectionSystem.Infrastructure.Data;
using FugasDetectionSystem.Infrastructure.Repositories;
using FugasDetectionSystem.Infrastructure.Services.Telegram.Interfaces;

namespace FugasDetectionSystem.BotWorker
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = Host.CreateApplicationBuilder(args);

            // Agregar configuración
            builder.Configuration.AddJsonFile("appsettings.json", optional: false, reloadOnChange: true);

            // Configurar la inyección de dependencias
            builder.Services.AddSingleton<ITelegramBotService>(provider =>
            {
                // Asegúrate de que tu token de la API de Telegram esté en tu archivo appsettings.json
                var token = builder.Configuration["TelegramApiToken"];

                // Si el token es nulo, lanzar una excepción clara para indicar que falta la configuración
                if (string.IsNullOrEmpty(token))
                {
                    throw new ArgumentNullException(nameof(token), "El token de la API de Telegram no puede ser nulo o vacío. Asegúrate de configurarlo en appsettings.json o en las variables de entorno.");
                }

                return new TelegramBotService(token);
            });

            // Registro de la cadena de conexión y repositorios
            var connectionString = builder.Configuration.GetConnectionString("dbOkFugasConnection");

            if (connectionString == null)
            {
                throw new ArgumentNullException(nameof(connectionString), "La cadena de conexión no puede ser nula. Asegúrate de configurarla en appsettings.json o en las variables de entorno.");
            }

            // Registro de DatabaseSettings con la cadena de conexión.
           // var databaseSettings = new DatabaseSettings(connectionString);
           // builder.Services.AddSingleton<IDatabaseSettings>(databaseSettings);



            
            //builder.Services.AddSingleton<ITecnicoRepository>( provider => { 
            //    return new TecnicoRepository(databaseSettings);
            //});

            builder.Services.AddHostedService<Worker>();

            // Construir y ejecutar la aplicación
            var host = builder.Build();
            host.Run();
        }
    }
}
