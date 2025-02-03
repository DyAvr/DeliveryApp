using Microsoft.Extensions.Logging;
using Versta.DeliveryApp.Application.DTOs;
using Versta.DeliveryApp.Domain.Entities;
using Versta.DeliveryApp.Domain.Interfaces;
using Versta.DeliveryApp.Infrastructure.Exceptions;
using Versta.DeliveryApp.Infrastructure.Logging;

namespace Versta.DeliveryApp.Application.Services;

public class OrderService(
    IOrderRepository orderRepository,
    ILogger<OrderService> logger
) : IOrderService
{
    public async Task<OrderDto> CreateOrderAsync(CreateOrderDto createOrderDto)
    {
        var order = Order.Create(
            createOrderDto.SenderCity,
            createOrderDto.SenderAddress,
            createOrderDto.ReceiverCity,
            createOrderDto.ReceiverAddress,
            createOrderDto.Weight,
            createOrderDto.PickupDate
        );

        await orderRepository.AddAsync(order);

        Logs.LogOrderCreated(logger, order.OrderNumber);

        return MapToDto(order);
    }

    public async Task<IEnumerable<OrderDto>> GetAllOrdersAsync()
    {
        var orders = await orderRepository.GetAllAsync();
        return orders.Select(MapToDto);
    }

    public async Task<OrderDto?> GetOrderByNumberAsync(string orderNumber)
    {
        var order = await orderRepository.GetByOrderNumberAsync(orderNumber);
        if (order is null)
        {
            Logs.LogOrderNotFound(logger, orderNumber);
            throw new OrderNotFoundException($"Заказ с номером {orderNumber} не найден");
        }

        return MapToDto(order);
    }

    private static OrderDto MapToDto(Order order) =>
        new(
            order.OrderNumber,
            order.SenderCity,
            order.SenderAddress,
            order.ReceiverCity,
            order.ReceiverAddress,
            order.Weight,
            order.PickupDate,
            order.CreatedAt
        );
}