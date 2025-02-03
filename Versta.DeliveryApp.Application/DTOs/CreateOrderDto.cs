namespace Versta.DeliveryApp.Application.DTOs;

public record CreateOrderDto(
    string SenderCity,
    string SenderAddress,
    string ReceiverCity,
    string ReceiverAddress,
    decimal Weight,
    DateTime PickupDate
);