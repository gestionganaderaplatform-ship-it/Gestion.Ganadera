# Estrategia de auditoría y trazabilidad

## Principio rector
En este sistema, auditar no es opcional. La trazabilidad es parte del producto.

## Regla importante de este proyecto
La auditoría real observada en el repositorio es mixta. Por eso no se debe inventar una falsa uniformidad donde todavía no existe.

## Capas de trazabilidad

### 1. Trazabilidad de negocio
Se logra con:
- `Evento_Ganadero`
- `Evento_Ganadero_Animal`
- estados del evento
- referencias a corrección o anulación

Esto responde:
- qué pasó
- sobre qué animal
- cuándo pasó
- cuándo se registró
- quién lo registró
- si después fue corregido o anulado

### 2. Auditoría de cambios de entidades
Se apalanca en la base del template y en las decisiones reales del módulo que se esté implementando.

Esto responde:
- qué entidad cambió
- qué campo cambió
- valor anterior
- valor nuevo
- quién hizo el cambio
- cuándo ocurrió

### 3. Observabilidad técnica
Se apalanca en:
- logs
- correlation id
- métricas
- health checks
- eventos de seguridad

## Qué debe quedar en `Evento_Ganadero`
- `Evento_Ganadero_Tipo`
- `Evento_Ganadero_Fecha`
- `Evento_Ganadero_Fecha_Registro`
- `Evento_Ganadero_Registrado_Por`
- `Finca_Codigo`
- `Evento_Ganadero_Estado`
- `Evento_Ganadero_Observacion_General`
- indicador de corrección
- indicador de anulación
- referencia a evento origen

## Qué debe quedar en historial visible al usuario
- tipo de evento
- fecha del evento
- fecha de registro si difiere
- usuario que registró
- resumen del evento
- estado del evento
- correcciones o anulaciones relacionadas

## Correcciones
Cuando se corrige:
- no se borra la traza original
- debe quedar evidencia de qué cambió
- debe quedar relación entre evento original y evento corregido o versión corregida
- si recalcula estado actual, también debe quedar consistente

## Anulaciones
Cuando se anula:
- no se borra el evento
- cambia su estado funcional
- debe guardar usuario, fecha y motivo
- debe recalcular impacto

## Restricción clave
La anulación simple no debe permitirse cuando ya existen eventos posteriores dependientes, salvo estrategia controlada.

## Auditoría de maestros sensibles
Debe auditarse al menos:
- potreros
- categorías
- tipos de identificador
- vacunas
- tratamientos
- causas de muerte
- motivos de descarte
- parámetros

## Uso del template existente
El template ya aporta:
- actor resuelto desde claims
- correlation id
- `ApiInfo.Codigo`
- logs estructurados
- ProblemDetails
- métricas por request

La estrategia correcta es integrarse a eso, no crear una segunda auditoría paralela innecesaria.

## Regla práctica
No imponer como obligatorio, sin validar antes en el módulo real, que todas las tablas nuevas deban llevar exactamente el mismo bloque de auditoría base teórica. Donde sí debe haber obligatoriedad total es en la trazabilidad funcional del evento.
