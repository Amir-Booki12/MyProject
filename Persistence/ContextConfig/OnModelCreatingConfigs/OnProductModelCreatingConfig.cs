using Domain.Entities.ProductAgg;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistence.ContextConfig.OnModelCreatingConfigs
{
    public class OnProductModelCreatingConfig : IEntityTypeConfiguration<Product>
    {
        public void Configure(EntityTypeBuilder<Product> builder)
        {
            builder.ToTable("Products");
            builder.HasKey(x => x.Id);

            builder.Property(x=>x.Title).HasMaxLength(100).IsRequired();
            builder.Property(x=>x.Description).HasMaxLength(800).IsRequired();
            builder.Property(x=>x.Price).IsRequired();
            builder.Property(x=>x.SeoData);
            

            builder.HasOne(x=>x.Category).WithMany(x=>x.Products).HasForeignKey(x=>x.CategoryId);


            builder.OwnsOne(x => x.SeoData, option =>
            {
                option.ToTable("SeoData");
                option.Property(x => x.Slug).HasMaxLength(300);
                option.Property(x => x.Keywords).HasMaxLength(80);
                option.Property(x => x.MetaDescription).HasMaxLength(800);
                option.Property(x => x.MetaTitle).HasMaxLength(300);
                option.Property(x => x.Canonical).HasMaxLength(500);
            });
        }
    }
}
