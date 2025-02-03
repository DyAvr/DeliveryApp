using Microsoft.EntityFrameworkCore;
using Versta.DeliveryApp.Domain.Entities;
using Versta.DeliveryApp.Domain.Interfaces;
using Versta.DeliveryApp.Infrastructure.Data;

namespace Versta.DeliveryApp.Infrastructure.Persistence.Repositories;

public class OrderRepository(ApplicationDbContext context) : IOrderRepository
{
    public async Task AddAsync(Order order)
    {
        context.Orders.Add(order);
        await context.SaveChangesAsync();
    }

    public async Task<IEnumerable<Order>> GetAllAsync()
    {
        return await context.Orders
            .OrderByDescending(o => o.CreatedAt)
            .ToListAsync();
    }

    public async Task<Order?> GetByOrderNumberAsync(string orderNumber)
    {
        return await context.Orders
            .FirstOrDefaultAsync(o => o.OrderNumber == orderNumber);
    }
}