using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

using PetStore.Common;
using PetStore.Models;

namespace PetStore.Data.Configurations
{
    public class ClientEntityConfiguration :
        IEntityTypeConfiguration<Client>
    {
        public void Configure(EntityTypeBuilder<Client> builder)
        {
            builder
                .Property(c => c.Username)
                .HasMaxLength(GlobalConstants.UsernameMaxLength)
                .IsUnicode(false);

            builder
                .Property(c => c.Email)
                .HasMaxLength(GlobalConstants.EmailMaxLength)
                .IsUnicode(false);

            builder
                .Property(c => c.FirstName)
                .HasMaxLength(GlobalConstants.ClientNameMaxLength)
                .IsUnicode(true);

            builder
                .Property(c => c.LastName)
                .HasMaxLength(GlobalConstants.ClientNameMaxLength)
                .IsUnicode(true);
        }
    }
}
