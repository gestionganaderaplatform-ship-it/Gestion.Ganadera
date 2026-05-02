using Gestion.Ganadera.Business.Domain.Features.Ganaderia;
using Gestion.Ganadera.Business.Infrastructure.Persistence.Extensions;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Gestion.Ganadera.Business.Infrastructure.Persistence.Configurations;

public sealed class AnimalRelacionFamiliarConfiguration : IEntityTypeConfiguration<AnimalRelacionFamiliar>
{
    public void Configure(EntityTypeBuilder<AnimalRelacionFamiliar> entity)
    {
        entity.ToTable("Animal_Relacion_Familiar", "Ganaderia");

        entity.ConfigureAuditableGanaderia();

        entity.HasKey(x => x.Animal_Relacion_Familiar_Codigo);

        entity.Property(x => x.Animal_Relacion_Familiar_Codigo)
            .ValueGeneratedOnAdd();

        entity.Property(x => x.Animal_Relacion_Familiar_Tipo)
            .HasMaxLength(40)
            .IsRequired();

        entity.HasIndex(x => new { x.Cliente_Codigo, x.Animal_Codigo_Madre, x.Animal_Codigo_Cria })
            .IsUnique()
            .HasFilter("[Cliente_Codigo] IS NOT NULL");

        entity.HasIndex(x => new { x.Animal_Codigo_Madre, x.Animal_Relacion_Familiar_Activa });
        entity.HasIndex(x => x.Animal_Codigo_Cria);

        entity.HasOne<Animal>()
            .WithMany()
            .HasForeignKey(x => x.Animal_Codigo_Madre)
            .OnDelete(DeleteBehavior.Restrict);

        entity.HasOne<Animal>()
            .WithMany()
            .HasForeignKey(x => x.Animal_Codigo_Cria)
            .OnDelete(DeleteBehavior.Restrict);
    }
}
