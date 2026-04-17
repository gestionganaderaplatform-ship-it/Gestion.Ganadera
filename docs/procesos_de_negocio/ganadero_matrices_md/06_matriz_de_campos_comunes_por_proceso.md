# Matriz de campos comunes por proceso

## Objetivo
Identificar campos transversales reutilizables para estandarizar diseño funcional, UX, validación y futuro modelo lógico.

| Campo funcional | Registro existente | Compra | Pesaje | Movimiento | Venta | Muerte | Traslado | Vacunación | Tratamiento | Palpación | Destete | Cambio categoría | Descarte | Nacimiento |
|---|---|---|---|---|---|---|---|---|---|---|---|---|---|---|
| Animal | Sí | Sí | Sí | Sí | Sí | Sí | Sí | Sí | Sí | Sí | Sí | Sí | Sí | Madre / Cría |
| Grupo / lote | Sí | Sí | Sí | Sí | Sí | No | Sí | Potencial | Potencial | No | Potencial | Potencial | Potencial | No |
| Fecha del evento | Opcional | Sí | Sí | Sí | Sí | Sí | Sí | Sí | Sí | Sí | Sí | Sí | Sí | Sí |
| Fecha de registro automática | Sí | Sí | Sí | Sí | Sí | Sí | Sí | Sí | Sí | Sí | Sí | Sí | Sí | Sí |
| Finca activa | Sí | Sí | Implícita | Implícita | Implícita | Implícita | Origen implícito | Implícita | Implícita | Implícita | Implícita | Implícita | Implícita | De madre / activa |
| Potrero destino / actual | Sí | Sí | No | Sí | No | No | Sí | No | No | No | Opcional | No | No | Sí |
| Sexo | Sí | Sí | No | No | No | No | No | No | No | Elegibilidad | No | Compatibilidad | No | Sí |
| Categoría | Sí | Sí | No | No | No | No | No | No | No | Elegibilidad | No | Sí | No | Sí |
| Rango de edad | Sí | Sí | No | No | No | No | No | No | No | No | No | No | No | No |
| Observación | Opcional | Opcional | Opcional futura | Opcional futura | Opcional | Opcional | Opcional futura | Opcional | Opcional | Opcional | Opcional | Opcional | Opcional | Opcional |
| Responsable distinto del registrador | No | No | Futuro | Futuro | No | Sí, si aplica | No | Sí | Sí | Sí | Sí | Sí | No | Sí |
| Valor económico | No | Opcional | No | No | Opcional | No | No | No | No | No | No | No | Opcional | No |
| Origen / destino / tercero | No | Sí | No | No | Sí | No | Sí, finca destino | No | No | No | No | No | Opcional | Madre obligatoria |

## Campos transversales recomendados para diseño
- fecha_evento
- fecha_registro
- usuario_registro
- observacion
- responsable_ejecucion, cuando aplique
- justificacion_correccion, cuando aplique
- justificacion_anulacion, cuando aplique

## Observación
Esta matriz ayuda a no diseñar cada proceso desde cero y permite detectar componentes reutilizables de interfaz y validación.
