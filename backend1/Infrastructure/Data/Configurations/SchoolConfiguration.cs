using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using backend.Core.Entities;

namespace backend.Infrastructure.Data.Configurations
{
    public class SchoolConfiguration : IEntityTypeConfiguration<School>
    {
        public void Configure(EntityTypeBuilder<School> builder)
        {
            builder.ToTable("Schools");

            builder.HasKey(e => e.Id);

            builder.Property(e => e.Id)
                .HasColumnName("Id");

            builder.Property(e => e.Name)
                .IsRequired()
                .HasColumnName("Name");

            builder.Property(e => e.Description)
                .HasColumnName("Description")
                .IsRequired()
                .HasMaxLength(1000)
                .IsUnicode(false);

            builder.Property(e => e.Logo)
                .HasColumnName("Logo")
                .HasMaxLength(1000)
                .IsUnicode(false);

            builder.Property(e => e.Status)
                .HasColumnName("Status");
        }
    }
}
