using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DevInSales.Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DevInSales.Core.Data.Mappings
{
    public class UserRolesMap : IEntityTypeConfiguration<Roles>
    {
        public void Configure(EntityTypeBuilder<Roles> builder)
        {
            builder.HasData(
                new Roles { Id = 1, Name = "administrador", NormalizedName = "ADMINISTRADOR" },
                new Roles { Id = 2, Name = "gerente", NormalizedName = "GERENTE" },
                new Roles { Id = 3, Name = "usuario", NormalizedName = "USUARIO" }
            );
        }
    }
}