namespace Gestion.Ganadera.Business.Domain.Features.Ganaderia;

public static class AnimalOrigenIngreso
{
    public const string RegistroExistente = "REGISTRO_EXISTENTE";
    public const string Compra = "COMPRA";
    public const string Nacimiento = "NACIMIENTO";
}

public static class EventoGanaderoTipo
{
    public const string RegistroExistente = "REGISTRO_EXISTENTE";
    public const string Compra = "COMPRA";
    public const string Nacimiento = "NACIMIENTO";
}

public static class EventoGanaderoEstado
{
    public const string Completado = "COMPLETADO";
}

public static class EventoGanaderoAnimalEstadoAfectacion
{
    public const string Procesado = "PROCESADO";
}

public static class AnimalRelacionFamiliarTipo
{
    public const string MadreCria = "MADRE_CRIA";
}
