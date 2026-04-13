using Gestion.Ganadera.API.Configuration.Providers;
using Gestion.Ganadera.API.Options;
using Gestion.Ganadera.API.Security.Sesiones;
using Gestion.Ganadera.Application.Abstractions.Interfaces;

namespace Gestion.Ganadera.API.Extensions;

/// <summary>
/// Registra servicios transversales del host antes de componer el resto del API.
/// </summary>
public static class ApiServiceExtensions
{
    public static WebApplicationBuilder AddApiServices(this WebApplicationBuilder builder)
    {
        builder.Services.Configure<ApiInfoOptions>(
            builder.Configuration.GetSection(ApiInfoOptions.SectionName));
        builder.Services.Configure<ExcelImportOptions>(
            builder.Configuration.GetSection(ExcelImportOptions.SectionName));
        builder.Services.Configure<OpcionesApiAuth>(
            builder.Configuration.GetSection(OpcionesApiAuth.SectionName));

        builder.Services.AddHttpContextAccessor();
        builder.Services.AddSingleton<IApiInfoProvider, ApiInfoProvider>();
        builder.Services.AddSingleton<IExcelImportSettingsProvider, ExcelImportSettingsProvider>();
        builder.Services.AddHttpClient<IServicioValidacionSesionRemota, ServicioValidacionSesionRemota>((serviceProvider, client) =>
        {
            var opciones = serviceProvider
                .GetRequiredService<Microsoft.Extensions.Options.IOptions<OpcionesApiAuth>>()
                .Value;

            if (Uri.TryCreate(opciones.BaseUrl, UriKind.Absolute, out var baseUri))
            {
                client.BaseAddress = baseUri;
            }

            client.Timeout = TimeSpan.FromSeconds(
                opciones.TimeoutSeconds > 0 ? opciones.TimeoutSeconds : 5);
        });
        builder.Services.AddScoped<ICurrentActorProvider, CurrentActorProvider>();
        builder.Services.AddScoped<ICurrentClientProvider, CurrentClientProvider>();
        return builder;
    }
}
