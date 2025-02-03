using MediatR;
using Versta.DeliveryApp.Application.DTOs;
using Versta.DeliveryApp.Application.Services;

namespace Versta.DeliveryApp.Application.UseCases.Orders.GetOrders;

public class GetOrdersQueryHandler(
    IOrderService orderService
) : IRequestHandler<GetOrdersQuery, IEnumerable<OrderDto>>
{
    public async Task<IEnumerable<OrderDto>> Handle(GetOrdersQuery request, CancellationToken cancellationToken)
    {
        return await orderService.GetAllOrdersAsync();
    }
}