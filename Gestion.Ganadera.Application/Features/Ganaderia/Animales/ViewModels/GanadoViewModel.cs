namespace Gestion.Ganadera.Application.Features.Ganaderia.Animales.ViewModels;

public class GanadoViewModel
{
    public long Animal_Codigo { get; set; }
    public string Animal_Identificador_Principal { get; set; } = string.Empty;
    public string Animal_Sexo { get; set; } = string.Empty;
    public string Categoria_Animal_Nombre { get; set; } = string.Empty;
    public string Finca_Nombre { get; set; } = string.Empty;
    public string Potrero_Nombre { get; set; } = string.Empty;
    public bool Animal_Activo { get; set; }
}
