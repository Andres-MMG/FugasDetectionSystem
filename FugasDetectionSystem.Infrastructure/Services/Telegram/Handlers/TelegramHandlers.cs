using Telegram.Bot;
using Telegram.Bot.Types;

namespace FugasDetectionSystem.Infrastructure.Services.Telegram.Handlers
{
    public delegate Task UpdateHandler(ITelegramBotClient botClient, Update update, CancellationToken cancellationToken);
    public delegate Task ErrorHandler(ITelegramBotClient botClient, Exception exception, CancellationToken cancellationToken);
}
