using MediatR;
using Versta.DeliveryApp.Application.DTOs;
using Versta.DeliveryApp.Application.Services;
using Versta.DeliveryApp.Infrastructure.Exceptions;

namespace Versta.DeliveryApp.Application.UseCases.Orders.GetOrderByNumber;

public class GetOrderByNumberQueryHandler(
    IOrderService orderService
) : IRequestHandler<GetOrderByNumberQuery, OrderDto>
{
    public async Task<OrderDto> Handle(GetOrderByNumberQuery request, CancellationToken cancellationToken)
    {
        var order = await orderService.GetOrderByNumberAsync(request.OrderNumber);
        if (order == null)
        {
            throw new OrderNotFoundException($"Заказ с номером {request.OrderNumber} не найден");
        }

        return order;
    }
}