using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

using PetStore.Common;
using PetStore.Models;

namespace PetStore.Data.Configurations
{
    public class OrderEntityConfiguration
        : IEntityTypeConfiguration<Order>
    {
        public void Configure(EntityTypeBuilder<Order> builder)
        {

            builder
                .Property(o => o.Town)
                .HasMaxLength(GlobalConstants.TownNameMaxLength)
                .IsUnicode(true);

            builder
                .Property(o => o.Address)
                .HasMaxLength(GlobalConstants.AddressTextMaxLength)
                .IsUnicode(true);

            builder
                .Ignore(o => o.TotalPrice);
        }
    }
}
