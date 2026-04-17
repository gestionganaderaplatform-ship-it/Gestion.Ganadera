# Matriz de estados derivados del animal

## Objetivo
Definir qué estados del animal se derivan de eventos y cómo impacta cada proceso esos estados.

| Estado derivado | Se deriva por eventos | Evento que lo crea o actualiza | No se edita manualmente | Observación funcional |
|---|---|---|---|---|
| Condición de activo | Sí | Registro de existente, Compra, Nacimiento, Venta, Muerte, Descarte | Sí | Activo hasta que una salida definitiva lo cambie |
| Finca actual | Sí | Registro de existente, Compra, Traslado entre fincas, Nacimiento | Sí | Siempre refleja la ubicación operativa actual |
| Potrero actual | Sí | Registro de existente, Compra, Movimiento de potrero, Traslado entre fincas, Nacimiento, Destete si aplica | Sí | Se deriva del último evento que cambió ubicación |
| Categoría actual | Sí | Registro de existente, Compra, Nacimiento, Cambio de categoría | Sí | No debe cambiarse por edición libre |
| Última referencia de peso | Sí | Pesaje | Sí | Referencia operativa, no reemplaza historial |
| Condición de salida | Sí | Venta, Muerte, Descarte | Sí | Define por qué dejó el inventario activo |
| Relación madre-cría activa | Sí | Nacimiento, Destete | Sí | Debe existir al menos en forma básica desde fase 1 |
| Origen de ingreso | Sí | Registro de existente, Compra, Nacimiento | Sí | Sirve para trazabilidad y reportes |
| Último evento sanitario | Sí | Vacunación, Tratamiento sanitario | Sí | Puede alimentar alertas futuras |
| Último evento reproductivo | Sí | Palpación, Destete | Sí | Base para evolución funcional futura |

## Comportamiento por proceso

| Proceso | Activo | Finca actual | Potrero actual | Categoría actual | Última referencia de peso | Condición de salida | Relación madre-cría |
|---|---|---|---|---|---|---|---|
| Registro de existente | Crea activo | Define | Define | Define | No cambia | No aplica | No cambia o referencia básica opcional |
| Compra | Crea activo | Define | Define | Define | No cambia | No aplica | No cambia |
| Pesaje | No cambia | No cambia | No cambia | No cambia | Actualiza | No cambia | No cambia |
| Movimiento de potrero | No cambia | No cambia | Actualiza | No cambia | No cambia | No cambia | No cambia |
| Venta | Cambia a inactivo | No cambia | No cambia | No cambia | No cambia | Define venta | No cambia |
| Muerte | Cambia a inactivo | No cambia | No cambia | No cambia | No cambia | Define muerte | No cambia |
| Traslado entre fincas | No cambia | Actualiza | Actualiza | No cambia | No cambia | No cambia | No cambia |
| Vacunación | No cambia | No cambia | No cambia | No cambia | No cambia | No cambia | No cambia |
| Tratamiento sanitario | No cambia | No cambia | No cambia | No cambia | No cambia | No cambia | No cambia |
| Palpación o revisión reproductiva | No cambia | No cambia | No cambia | No cambia | No cambia | No cambia | No cambia |
| Destete | No cambia | No cambia | Puede actualizar | No cambia | No cambia | No cambia | Actualiza o cierra según regla |
| Cambio de categoría | No cambia | No cambia | No cambia | Actualiza | No cambia | No cambia | No cambia |
| Descarte | Cambia a inactivo | No cambia | No cambia | No cambia | No cambia | Define descarte | No cambia |
| Nacimiento | Crea activo | Define | Define | Define | No cambia | No aplica | Crea relación |

## Reglas clave
- Ningún estado derivado debe poder alterarse libremente por mantenimiento general.
- Si un evento posterior contradice un estado previo, prevalece el evento cronológicamente válido más reciente.
- La corrección o anulación de eventos debe recalcular los estados derivados afectados.
