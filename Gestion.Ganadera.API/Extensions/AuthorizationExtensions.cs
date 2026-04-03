using Microsoft.AspNetCore.Authorization;
using Gestion.Ganadera.API.Security.Permissions;

namespace Gestion.Ganadera.API.Extensions;

/// <summary>
/// Registra autorizacion basada en permisos para proteger controllers y acciones.
/// </summary>
public static class AuthorizationExtensions
{
    public static WebApplicationBuilder AddAuthorizationServices(this WebApplicationBuilder builder)
    {
        builder.Services.AddAuthorization(options =>
        {
            foreach (var permission in Enum.GetValues<ControllerPermission>())
            {
                if (permission is ControllerPermission.None
                    or ControllerPermission.All
                    or ControllerPermission.Standard)
                {
                    continue;
                }

                options.AddPolicy(
                    PermissionPolicy.BuildPolicyName(permission),
                    policy =>
                    {
                        policy.RequireAuthenticatedUser();
                        policy.AddRequirements(new PermissionAuthorizationRequirement(permission));
                    });
            }
        });

        builder.Services.AddSingleton<IAuthorizationHandler, PermissionAuthorizationHandler>();
        return builder;
    }
}
