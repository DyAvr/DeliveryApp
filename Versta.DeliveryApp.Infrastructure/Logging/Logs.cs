using Microsoft.Extensions.Logging;

namespace Versta.DeliveryApp.Infrastructure.Logging;

public static partial class Logs
{
    [LoggerMessage(
        EventId = 2001,
        Level = LogLevel.Information,
        Message = "Создан новый заказ с номером {OrderNumber}")]
    public static partial void LogOrderCreated(ILogger logger, string orderNumber);

    [LoggerMessage(
        EventId = 2002,
        Level = LogLevel.Warning,
        Message = "Заказ с номером {OrderNumber} не найден")]
    public static partial void LogOrderNotFound(ILogger logger, string orderNumber);
}