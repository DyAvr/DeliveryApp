using MediatR;
using Versta.DeliveryApp.Application.DTOs;

namespace Versta.DeliveryApp.Application.UseCases.Queries.GetOrders;

public record GetOrdersQuery : IRequest<IEnumerable<OrderDto>>;