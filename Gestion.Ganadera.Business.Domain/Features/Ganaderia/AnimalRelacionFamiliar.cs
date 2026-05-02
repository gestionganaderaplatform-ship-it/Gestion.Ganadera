using Gestion.Ganadera.Business.Domain.Base;

namespace Gestion.Ganadera.Business.Domain.Features.Ganaderia;

public class AnimalRelacionFamiliar : AuditableEntity
{
    public long Animal_Relacion_Familiar_Codigo { get; set; }
    public long Animal_Codigo_Madre { get; set; }
    public long Animal_Codigo_Cria { get; set; }
    public string Animal_Relacion_Familiar_Tipo { get; set; } = string.Empty;
    public DateTime Animal_Relacion_Familiar_Fecha_Inicio { get; set; }
    public bool Animal_Relacion_Familiar_Activa { get; set; } = true;
}
