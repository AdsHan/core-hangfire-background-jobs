using BackgroundJobs.API.Data.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ZZApp.Attendance.Infrastructure.Data.Mappings;

public class ProductMapping : IEntityTypeConfiguration<ProductModel>
{
    public void Configure(EntityTypeBuilder<ProductModel> builder)
    {
        builder.HasKey(r => r.Id);

        builder.Property(p => p.Quantity).HasDefaultValue(1).IsRequired();
        builder.Property(p => p.Price).HasDefaultValue(0).IsRequired();
        builder.Property(p => p.Status).HasConversion<int>();
        //builder.Property(p => p.Title).HasColumnType("VARCHAR(30)");
        builder.Property(p => p.Title).HasMaxLength(30);

        builder.ToTable("Products");
    }
}
