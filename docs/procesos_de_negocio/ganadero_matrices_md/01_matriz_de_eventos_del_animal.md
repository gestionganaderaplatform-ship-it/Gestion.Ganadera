# Matriz de eventos del animal

## Objetivo
Definir todos los eventos funcionales del animal, su naturaleza y el efecto principal que producen dentro del sistema.

| Evento | Fase | Tipo de evento | Genera ingreso | Genera salida | Requiere animal previo | Puede crear animal | Puede ser lote/grupo | Cambia finca actual | Cambia potrero actual | Cambia categoría actual | Cambia condición de activo | Requiere trazabilidad en historial |
|---|---|---|---|---|---|---|---|---|---|---|---|---|
| Registro de existente | 1 | Ingreso | Sí | No | No | Sí | Sí | Sí, toma finca activa | Sí | Sí, inicial | Sí, deja activo | Sí |
| Compra | 1 | Ingreso | Sí | No | No | Sí | Sí | Sí, toma finca activa | Sí | Sí, inicial | Sí, deja activo | Sí |
| Pesaje | 1 | Seguimiento | No | No | Sí | No | Sí | No | No | No | No | Sí |
| Movimiento de potrero | 1 | Movimiento interno | No | No | Sí | No | Sí | No | Sí | No | No | Sí |
| Venta | 1 | Salida definitiva | No | Sí | Sí | No | Sí | No | No | No | Sí, deja inactivo | Sí |
| Muerte | 1 | Salida definitiva | No | Sí | Sí | No | No* | No | No | No | Sí, deja inactivo | Sí |
| Traslado entre fincas | 1 | Movimiento interno inter-finca | No | No | Sí | No | Sí | Sí | Sí | No | No | Sí |
| Vacunación | 2 | Sanitario | No | No | Sí | No | Potencialmente sí | No | No | No | No | Sí |
| Tratamiento sanitario | 2 | Sanitario | No | No | Sí | No | Potencialmente sí | No | No | No | No | Sí |
| Palpación o revisión reproductiva | 2 | Reproductivo | No | No | Sí | No | Normalmente no | No | No | No | No | Sí |
| Destete | 2 | Reproductivo / transición | No | No | Sí | No | Potencialmente sí | No | Opcionalmente sí | No | No | Sí |
| Cambio de categoría | 2 | Cambio de estado funcional | No | No | Sí | No | Potencialmente sí | No | No | Sí | No | Sí |
| Descarte | 2 | Salida definitiva | No | Sí | Sí | No | Potencialmente sí | No | No | No | Sí, deja inactivo | Sí |
| Nacimiento | 2 | Ingreso | Sí | No | Madre sí, cría no | Sí | No | Sí, finca de la madre | Sí | Sí, inicial | Sí, deja activo | Sí |

## Reglas transversales
- Todo evento relevante debe quedar en historial.
- Los eventos son el mecanismo oficial para construir la realidad operativa del animal.
- Los eventos de salida definitiva no deben permitir nuevas operaciones normales sobre el animal.
- Los eventos internos no deben romper identidad ni continuidad histórica del animal.
- Los eventos que crean animal deben dejar desde el inicio su estado operativo mínimo útil.

## Observaciones
- Muerte podría ampliarse a modalidad lote en el futuro, pero por ahora conviene mantenerla más controlada.
- Vacunación, tratamiento, destete y cambio de categoría podrían admitir grupo/lote según diseño posterior, pero eso debe depender de la seguridad funcional del proceso.
