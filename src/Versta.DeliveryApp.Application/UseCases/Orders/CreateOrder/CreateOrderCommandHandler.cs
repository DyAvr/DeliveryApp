using FluentValidation;
using MediatR;
using Versta.DeliveryApp.Application.DTOs;
using Versta.DeliveryApp.Application.Services;

namespace Versta.DeliveryApp.Application.UseCases.Orders.CreateOrder;

public class CreateOrderCommandHandler(
    IOrderService orderService,
    IValidator<CreateOrderDto> validator
) : IRequestHandler<CreateOrderCommand, OrderDto>
{
    public async Task<OrderDto> Handle(CreateOrderCommand request, CancellationToken cancellationToken)
    {
        var createOrderDto = new CreateOrderDto(
            request.SenderCity,
            request.SenderAddress,
            request.ReceiverCity,
            request.ReceiverAddress,
            request.Weight,
            DateTime.SpecifyKind(request.PickupDate, DateTimeKind.Utc)
        );

        await validator.ValidateAndThrowAsync(createOrderDto, cancellationToken);
        
        return await orderService.CreateOrderAsync(createOrderDto);
    }
}