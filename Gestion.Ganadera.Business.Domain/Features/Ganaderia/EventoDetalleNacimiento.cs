using Gestion.Ganadera.Business.Domain.Base;

namespace Gestion.Ganadera.Business.Domain.Features.Ganaderia;

public class EventoDetalleNacimiento : AuditableEntity
{
    public long Evento_Ganadero_Codigo { get; set; }
    public long Animal_Codigo_Madre { get; set; }
    public long Animal_Codigo_Cria { get; set; }
    public long Tipo_Identificador_Codigo { get; set; }
    public string Evento_Detalle_Nacimiento_Identificador_Valor { get; set; } = string.Empty;
    public long Categoria_Animal_Codigo { get; set; }
    public long Potrero_Codigo { get; set; }
    public string Evento_Detalle_Nacimiento_Sexo { get; set; } = string.Empty;
    public DateTime Evento_Detalle_Nacimiento_Fecha_Nacimiento { get; set; }
    public decimal? Evento_Detalle_Nacimiento_Peso_Nacer { get; set; }
    public string? Evento_Detalle_Nacimiento_Observacion { get; set; }
}
