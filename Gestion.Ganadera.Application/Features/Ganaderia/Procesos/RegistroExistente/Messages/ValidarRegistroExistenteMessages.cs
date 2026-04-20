namespace Gestion.Ganadera.Application.Features.Ganaderia.Procesos.RegistroExistente.Messages;

public static class ValidarRegistroExistenteMessages
{
    public const string FincaNoExiste = "La finca indicada no existe.";
    public const string PotreroNoExiste = "El potrero indicado no existe.";
    public const string PotreroNoPerteneceAFinca = "El potrero indicado no pertenece a la finca seleccionada.";
    public const string CategoriaNoExiste = "La categoría indicada no existe.";
    public const string RangoNoExiste = "El rango de edad indicado no existe.";
    public const string TipoIdentificadorNoExiste = "El tipo de identificador indicado no existe.";
    public const string IdentificadorDuplicado = "Ya existe un animal activo con este identificador en la base de datos.";
    public const string SexoInvalido = "El formato del sexo es inválido.";
}
