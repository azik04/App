using System;
using System.Collections.Generic;
using System.Text;
using App.Domain.Entities.Acc;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace App.Infrastructure.Configuration.Acc;

public class ClientConfiguration : IEntityTypeConfiguration<Clients>
{
    public void Configure(EntityTypeBuilder<Clients> builder)
    {
        builder.HasKey(x => x.Id);
    }
}
