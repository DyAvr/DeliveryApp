using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Versta.DeliveryApp.Domain.Entities;

namespace Versta.DeliveryApp.Infrastructure.Data.Configurations;

public class OrderConfiguration : IEntityTypeConfiguration<Order>
{
    public void Configure(EntityTypeBuilder<Order> builder)
    {
        builder.HasKey(e => e.Id);

        builder.Property(e => e.OrderNumber)
            .IsRequired();

        builder.Property(e => e.SenderCity)
            .IsRequired();

        builder.Property(e => e.SenderAddress)
            .IsRequired();

        builder.Property(e => e.ReceiverCity)
            .IsRequired();

        builder.Property(e => e.ReceiverAddress)
            .IsRequired();

        builder.Property(e => e.Weight)
            .IsRequired();

        builder.Property(e => e.PickupDate)
            .IsRequired();

        builder.Property(e => e.CreatedAt)
            .IsRequired();

        builder.HasIndex(e => e.OrderNumber)
            .IsUnique();
    }
}