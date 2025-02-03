namespace Versta.DeliveryApp.Infrastructure.Exceptions;

public class OrderNotFoundException(string message) : Exception(message);