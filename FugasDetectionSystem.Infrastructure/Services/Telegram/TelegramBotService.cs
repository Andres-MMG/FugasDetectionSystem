using Telegram.Bot;
using Telegram.Bot.Polling;
using Telegram.Bot.Types.Enums;
using FugasDetectionSystem.Infrastructure.Services.Telegram.Handlers;
using FugasDetectionSystem.Infrastructure.Services.Telegram.Interfaces;

namespace FugasDetectionSystem.Infrastructure.Services.Telegram
{
    public class TelegramBotService(string token) : ITelegramBotService
    {
        private readonly TelegramBotClient _botClient = new(token);
        private readonly CancellationTokenSource _cts = new();

        public void StartReceiving(UpdateHandler updateHandler, ErrorHandler errorHandler)
        {
            var receiverOptions = new ReceiverOptions
            {
                AllowedUpdates = [] // Recibe todos los tipos de actualizaciones
            };

            _botClient.StartReceiving(
                updateHandler: (botClient, update, ct) => updateHandler.Invoke(botClient, update, ct),
                pollingErrorHandler: (botClient, exception, ct) => errorHandler.Invoke(botClient, exception, ct),
                receiverOptions: receiverOptions,
                cancellationToken: _cts.Token
            );

        }

        public void StopReceiving()
        {
            _cts.Cancel();
        }
    }
}
