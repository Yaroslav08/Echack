using Ereceipt.Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Ereceipt.Infrastructure.Data.Configurations
{
    public class BugdetConfiguration : IEntityTypeConfiguration<Budget>
    {
        public void Configure(EntityTypeBuilder<Budget> builder)
        {
            builder.HasKey(x => x.Id);
            builder.HasIndex(x => new
            {
                x.Name,
                x.CreatedAt,
                x.Currency,
                x.StartPeriod,
                x.EndPeriod,
                x.GroupId
            });
        }
    }
}
