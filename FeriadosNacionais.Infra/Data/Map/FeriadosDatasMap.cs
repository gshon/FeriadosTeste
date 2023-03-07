using FeriadosNacionais.Infra.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace FeriadosNacionais.Infra.Data.Map
{
    public class FeriadosDatasMap : IEntityTypeConfiguration<FeriadosDatasEntity>
    {
        public void Configure(EntityTypeBuilder<FeriadosDatasEntity> builder)
        {
            builder.HasKey(x => x.Id);

            builder.Property(x => x.Date).HasMaxLength(10).IsRequired(false);
            builder.Property(x => x.Title).HasMaxLength(200).IsRequired();
            builder.Property(x => x.Description).HasMaxLength(250).IsRequired();
            builder.Property(x => x.Legislation).HasMaxLength(250).IsRequired();
            builder.Property(x => x.Type).HasMaxLength(10).IsRequired();
            builder.Property(x => x.StartTime).HasColumnType("DateTime").IsRequired(false);
            builder.Property(x => x.EndTime).HasColumnType("DateTime").IsRequired(false);
        }
    }
}
