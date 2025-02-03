using MediatR;
using Versta.DeliveryApp.Application.DTOs;

namespace Versta.DeliveryApp.Application.UseCases.Orders.GetOrders;

public record GetOrdersQuery : IRequest<IEnumerable<OrderDto>>;