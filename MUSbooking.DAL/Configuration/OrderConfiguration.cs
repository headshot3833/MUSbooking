using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MUSbooking.Domain.Entity;

namespace MUSbooking.DAL.Configuration;

public class OrderConfiguration : IEntityTypeConfiguration<Order>
{
    public void Configure(EntityTypeBuilder<Order> builder)
    {
        builder.Property(x => x.Id).ValueGeneratedOnAdd();

        builder.HasMany(x => x.Equipments)
        .WithMany(x => x.Orders)
        .UsingEntity<EquipmentOrder>(
        l => l.HasOne<Equipment>().WithMany().HasForeignKey(x => x.EquipmentId),
        l => l.HasOne<Order>().WithMany().HasForeignKey(x => x.OrderId)
        );
    }
}
