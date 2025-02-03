using Versta.DeliveryApp.Application.DTOs;

namespace Versta.DeliveryApp.Application.Services;

public interface IOrderService
{
    Task<OrderDto> CreateOrderAsync(CreateOrderDto createOrderDto);
    Task<IEnumerable<OrderDto>> GetAllOrdersAsync();
    Task<OrderDto?> GetOrderByNumberAsync(string orderNumber);
}