namespace Gestion.Ganadera.Business.Application.Features.Ganaderia.Procesos.Compra.Models;

public class RegistrarCompraRequest : ValidarCompraRequest
{
    public DateTime Fecha_Compra { get; set; }
    public string Origen_Vendedor { get; set; } = string.Empty;
    public decimal? Valor_Individual { get; set; }
    public string? Observacion { get; set; }
}

public class RegistrarCompraLoteRequest
{
    public long Finca_Codigo { get; set; }
    public DateTime Fecha_Compra { get; set; }
    public string Origen_Vendedor { get; set; } = string.Empty;
    public decimal? Valor_Total { get; set; }
    public string? Observacion { get; set; }
    public List<CompraAnimalRequest> Animales { get; set; } = new();
}

public class CompraAnimalRequest
{
    public long Potrero_Codigo { get; set; }
    public long Categoria_Animal_Codigo { get; set; }
    public long Rango_Edad_Codigo { get; set; }
    public long Tipo_Identificador_Codigo { get; set; }
    public string Identificador_Principal { get; set; } = string.Empty;
    public string Animal_Sexo { get; set; } = string.Empty;
    public decimal? Valor_Individual { get; set; }
}
