namespace Versta.DeliveryApp.Web.Middlewares;

/// <summary>
/// Унифицированный формат ответа об ошибке.
/// </summary>
public class ErrorResponse
{
    /// <summary>
    /// Сообщение об ошибке.
    /// </summary>
    public string Message { get; set; } = string.Empty;

    /// <summary>
    /// Стек вызовов (заполняется только в режиме разработки).
    /// </summary>
    public string? StackTrace { get; set; }
}