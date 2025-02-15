using MediatR;
using Versta.DeliveryApp.Application.DTOs;

namespace Versta.DeliveryApp.Application.UseCases.Orders.GetOrderByNumber;

public record GetOrderByNumberQuery(string OrderNumber) : IRequest<OrderDto>;