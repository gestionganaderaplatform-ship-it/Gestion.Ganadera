using Gestion.Ganadera.Business.Domain.Features.Ganaderia;
using Gestion.Ganadera.Business.Infrastructure.Persistence.Extensions;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Gestion.Ganadera.Business.Infrastructure.Persistence.Configurations;

public sealed class EventoDetalleNacimientoConfiguration : IEntityTypeConfiguration<EventoDetalleNacimiento>
{
    public void Configure(EntityTypeBuilder<EventoDetalleNacimiento> entity)
    {
        entity.ToTable("Evento_Detalle_Nacimiento", "Ganaderia");

        entity.ConfigureAuditableGanaderia();

        entity.HasKey(x => x.Evento_Ganadero_Codigo);

        entity.Property(x => x.Evento_Detalle_Nacimiento_Identificador_Valor)
            .HasMaxLength(120)
            .IsRequired();

        entity.Property(x => x.Evento_Detalle_Nacimiento_Sexo)
            .HasMaxLength(20)
            .IsRequired();

        entity.Property(x => x.Evento_Detalle_Nacimiento_Peso_Nacer)
            .HasPrecision(10, 2);

        entity.Property(x => x.Evento_Detalle_Nacimiento_Observacion)
            .HasMaxLength(500);

        entity.HasOne<EventoGanadero>()
            .WithMany()
            .HasForeignKey(x => x.Evento_Ganadero_Codigo)
            .OnDelete(DeleteBehavior.Restrict);

        entity.HasOne<Animal>()
            .WithMany()
            .HasForeignKey(x => x.Animal_Codigo_Madre)
            .OnDelete(DeleteBehavior.Restrict);

        entity.HasOne<Animal>()
            .WithMany()
            .HasForeignKey(x => x.Animal_Codigo_Cria)
            .OnDelete(DeleteBehavior.Restrict);

        entity.HasOne<TipoIdentificador>()
            .WithMany()
            .HasForeignKey(x => x.Tipo_Identificador_Codigo)
            .OnDelete(DeleteBehavior.Restrict);

        entity.HasOne<CategoriaAnimal>()
            .WithMany()
            .HasForeignKey(x => x.Categoria_Animal_Codigo)
            .OnDelete(DeleteBehavior.Restrict);

        entity.HasOne<Potrero>()
            .WithMany()
            .HasForeignKey(x => x.Potrero_Codigo)
            .OnDelete(DeleteBehavior.Restrict);
    }
}
