using MediatR;
using Versta.DeliveryApp.Application.DTOs;

namespace Versta.DeliveryApp.Application.UseCases.Commands.CreateOrder;

public record CreateOrderCommand(
    string SenderCity,
    string SenderAddress,
    string ReceiverCity,
    string ReceiverAddress,
    decimal Weight,
    DateTime PickupDate
) : IRequest<OrderDto>;