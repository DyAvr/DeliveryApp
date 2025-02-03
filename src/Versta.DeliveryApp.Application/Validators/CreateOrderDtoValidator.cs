using FluentValidation;
using Versta.DeliveryApp.Application.DTOs;

namespace Versta.DeliveryApp.Application.Validators;

public class CreateOrderDtoValidator : AbstractValidator<CreateOrderDto>
{
    public CreateOrderDtoValidator()
    {
        RuleFor(x => x.SenderCity)
            .NotEmpty().WithMessage("Город отправителя обязателен")
            .MaximumLength(100).WithMessage("Город отправителя не может быть длиннее 100 символов");

        RuleFor(x => x.SenderAddress)
            .NotEmpty().WithMessage("Адрес отправителя обязателен")
            .MaximumLength(200).WithMessage("Адрес отправителя не может быть длиннее 200 символов");

        RuleFor(x => x.ReceiverCity)
            .NotEmpty().WithMessage("Город получателя обязателен")
            .MaximumLength(100).WithMessage("Город получателя не может быть длиннее 100 символов");

        RuleFor(x => x.ReceiverAddress)
            .NotEmpty().WithMessage("Адрес получателя обязателен")
            .MaximumLength(200).WithMessage("Адрес получателя не может быть длиннее 200 символов");

        RuleFor(x => x.Weight)
            .GreaterThan(0).WithMessage("Вес должен быть больше 0")
            .LessThan(1000).WithMessage("Вес не может быть больше 1000 кг");

        RuleFor(x => x.PickupDate)
            .GreaterThanOrEqualTo(DateTime.Today).WithMessage("Дата забора груза не может быть в прошлом");
    }
}