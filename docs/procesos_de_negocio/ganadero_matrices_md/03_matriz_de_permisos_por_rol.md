# Matriz de permisos por rol

## Objetivo
Consolidar qué roles pueden ejecutar, corregir o anular procesos, con base en las reglas ya definidas.

## Roles base
- Dueño titular
- Administrador de finca
- Operario de campo
- Veterinario

## Reglas superiores ya definidas
- El operario no anula eventos.
- El operario no gobierna configuración.
- El administrador puede corregir o anular eventos dentro de la política permitida.
- El dueño titular puede corregir o anular eventos según la política superior definida para la cuenta.

## Permisos operativos sugeridos por proceso

| Proceso | Dueño titular | Administrador de finca | Operario de campo | Veterinario |
|---|---|---|---|---|
| Registro de existente | Sí | Sí | No | No |
| Compra | Sí | Sí | No | No |
| Pesaje | Sí | Sí | Sí, si está autorizado | No |
| Movimiento de potrero | Sí | Sí | Sí, si está autorizado | No |
| Venta | Sí | Sí | No | No |
| Muerte | Sí | Sí | Reporte opcional si política lo permite | No |
| Traslado entre fincas | Sí | Sí, con permiso suficiente | No | No |
| Vacunación | Sí | Sí | Sí, si está autorizado | Sí |
| Tratamiento sanitario | Sí | Sí | Sí, si está autorizado | Sí |
| Palpación o revisión reproductiva | Sí | Sí | No, salvo regla futura | Sí |
| Destete | Sí | Sí | Sí, si está autorizado | Sí |
| Cambio de categoría | Sí | Sí | No | No |
| Descarte | Sí | Sí | No | No |
| Nacimiento | Sí | Sí | Sí, si está autorizado para captura | Sí, si participa en el proceso |

## Permisos de corrección y anulación

| Acción | Dueño titular | Administrador de finca | Operario de campo | Veterinario |
|---|---|---|---|---|
| Corregir eventos de fase 1 | Sí | Sí, según política | No | No |
| Anular eventos de fase 1 | Sí | Sí, según política | No | No |
| Corregir eventos sanitarios | Sí | Sí | No | Sí, si la política lo permite |
| Anular eventos sanitarios | Sí | Sí | No | No o solo bajo política excepcional |
| Gobernar catálogos | Sí | Sí, según alcance | No | No |
| Configurar parámetros de cuenta | Sí | No o muy limitado | No | No |

## Observaciones
- El veterinario debería concentrarse en procesos sanitarios y reproductivos, no en ingresos, ventas o traslados.
- El operario puede ser fuerte en captura operativa, pero no en acciones de gobierno funcional ni anulación.
- La matriz exacta podrá refinarse después por permiso granular, pero esta versión ya sirve para construir la seguridad base.
