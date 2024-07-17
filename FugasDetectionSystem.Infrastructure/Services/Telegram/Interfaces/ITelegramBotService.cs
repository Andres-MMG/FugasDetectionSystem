using FugasDetectionSystem.Infrastructure.Services.Telegram.Handlers;

namespace FugasDetectionSystem.Infrastructure.Services.Telegram.Interfaces
{
    public interface ITelegramBotService
    {
        void StartReceiving(UpdateHandler updateHandler, ErrorHandler errorHandler);
        void StopReceiving();
    }
}
