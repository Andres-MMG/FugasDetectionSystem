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

            // Agregar configuraci�n
            builder.Configuration.AddJsonFile("appsettings.json", optional: false, reloadOnChange: true);

            // Configurar la inyecci�n de dependencias
            builder.Services.AddSingleton<ITelegramBotService>(provider =>
            {
                // Aseg�rate de que tu token de la API de Telegram est� en tu archivo appsettings.json
                var token = builder.Configuration["TelegramApiToken"];

                // Si el token es nulo, lanzar una excepci�n clara para indicar que falta la configuraci�n
                if (string.IsNullOrEmpty(token))
                {
                    throw new ArgumentNullException(nameof(token), "El token de la API de Telegram no puede ser nulo o vac�o. Aseg�rate de configurarlo en appsettings.json o en las variables de entorno.");
                }

                return new TelegramBotService(token);
            });

            // Registro de la cadena de conexi�n y repositorios
            var connectionString = builder.Configuration.GetConnectionString("dbOkFugasConnection");

            if (connectionString == null)
            {
                throw new ArgumentNullException(nameof(connectionString), "La cadena de conexi�n no puede ser nula. Aseg�rate de configurarla en appsettings.json o en las variables de entorno.");
            }

            // Registro de DatabaseSettings con la cadena de conexi�n.
           // var databaseSettings = new DatabaseSettings(connectionString);
           // builder.Services.AddSingleton<IDatabaseSettings>(databaseSettings);



            
            //builder.Services.AddSingleton<ITecnicoRepository>( provider => { 
            //    return new TecnicoRepository(databaseSettings);
            //});

            builder.Services.AddHostedService<Worker>();

            // Construir y ejecutar la aplicaci�n
            var host = builder.Build();
            host.Run();
        }
    }
}
