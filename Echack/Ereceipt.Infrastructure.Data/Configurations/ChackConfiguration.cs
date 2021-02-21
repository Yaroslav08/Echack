using Ereceipt.Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace Ereceipt.Infrastructure.Data.Configurations
{
    public class ChackConfiguration : IEntityTypeConfiguration<Chack>
    {
        public void Configure(EntityTypeBuilder<Chack> builder)
        {
            builder.HasKey(d => d.Id);
            builder.HasIndex(d => new
            {
                d.ChackType,
                d.ShopName,
                d.CreatedAt,
                d.TotalPrice
            });
        }
    }
}