namespace Versta.DeliveryApp.Domain.Entities;

public class Order
{
    public required Guid Id { get; init; }
    public required string OrderNumber { get; init; }
    public required string SenderCity { get; init; }
    public required string SenderAddress { get; init; }
    public required string ReceiverCity { get; init; }
    public required string ReceiverAddress { get; init; }
    public required decimal Weight { get; init; }
    public required DateTime PickupDate { get; init; }
    public required DateTime CreatedAt { get; init; }

    private Order()
    {
    }

    public static Order Create(
        string senderCity,
        string senderAddress,
        string receiverCity,
        string receiverAddress,
        decimal weight,
        DateTime pickupDate)
    {
        if (string.IsNullOrWhiteSpace(senderCity))
            throw new ArgumentException("Город отправителя не может быть пустым", nameof(senderCity));

        if (string.IsNullOrWhiteSpace(senderAddress))
            throw new ArgumentException("Адрес отправителя не может быть пустым", nameof(senderAddress));

        if (string.IsNullOrWhiteSpace(receiverCity))
            throw new ArgumentException("Город получателя не может быть пустым", nameof(receiverCity));

        if (string.IsNullOrWhiteSpace(receiverAddress))
            throw new ArgumentException("Адрес получателя не может быть пустым", nameof(receiverAddress));

        if (weight <= 0)
            throw new ArgumentException("Вес должен быть больше 0", nameof(weight));
        
        var currentDateTime = DateTime.UtcNow;
        if (pickupDate < currentDateTime)
            throw new ArgumentException("Дата забора груза не может быть в прошлом", nameof(pickupDate));

        var guid = Guid.NewGuid();
        var orderNumber = GenerateOrderNumber(guid, currentDateTime);
        return new Order
        {
            Id = guid,
            OrderNumber = orderNumber,
            SenderCity = senderCity,
            SenderAddress = senderAddress,
            ReceiverCity = receiverCity,
            ReceiverAddress = receiverAddress,
            Weight = weight,
            PickupDate = pickupDate,
            CreatedAt = currentDateTime
        };
    }

    private static string GenerateOrderNumber(Guid guid, DateTime currentDateTime)
    {
        return $"ORDER-{currentDateTime:yyyyMMdd}-{guid.ToString()[..8].ToUpper()}";
    }
}