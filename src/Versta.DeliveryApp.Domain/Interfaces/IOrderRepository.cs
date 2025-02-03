using Versta.DeliveryApp.Domain.Entities;

namespace Versta.DeliveryApp.Domain.Interfaces;

public interface IOrderRepository
{
    Task AddAsync(Order order);
    Task<IEnumerable<Order>> GetAllAsync();
    Task<Order?> GetByOrderNumberAsync(string orderNumber);
}