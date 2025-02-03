namespace Versta.DeliveryApp.Application.DTOs;

public record OrderDto(
    string OrderNumber,
    string SenderCity,
    string SenderAddress,
    string ReceiverCity,
    string ReceiverAddress,
    decimal Weight,
    DateTime PickupDate,
    DateTime CreatedAt
);