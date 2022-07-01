using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using DevInSales.Core.Entities;
using Microsoft.AspNetCore.Identity;

namespace DevInSales.Core.Data.Mappings
{

    public class UserMap : IEntityTypeConfiguration<User>
    {

        public void Configure(EntityTypeBuilder<User> builder)
        {
            PasswordHasher<User> passwordHasher = new PasswordHasher<User>();

            builder.ToTable("Users");

            builder.HasKey(u => u.Id);

            builder.Property(u => u.Name)
                .HasColumnType("varchar(255)")
                .IsRequired();

            builder.Property(u => u.BirthDate)
                .HasColumnType("date")
                .IsRequired();
        }
    }

}
