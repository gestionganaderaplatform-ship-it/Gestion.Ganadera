# Matriz de corrección y anulación

## Objetivo
Definir el comportamiento funcional esperado cuando un evento debe corregirse o anularse.

## Reglas generales
- Corregir o anular no borra trazabilidad.
- Toda corrección o anulación debe dejar usuario, fecha y justificación cuando aplique.
- Si un evento impacta estados derivados, la corrección o anulación debe recalcularlos.
- No toda anulación debe permitirse cuando ya existen eventos posteriores dependientes.

## Matriz por proceso

| Proceso | Puede corregirse | Puede anularse | Restricción principal de anulación | Requiere recalcular estados |
|---|---|---|---|---|
| Registro de existente | Sí | Sí, con fuerte restricción | No si ya tiene eventos posteriores dependientes | Sí |
| Compra | Sí | Sí, con fuerte restricción | No si ya tiene eventos posteriores dependientes | Sí |
| Pesaje | Sí | Sí | No si existen análisis o cierres que dependan de él en una versión futura | Sí, sobre última referencia de peso |
| Movimiento de potrero | Sí | Sí | No si hay movimientos posteriores que dependen de la secuencia | Sí |
| Venta | Sí | Sí, excepcionalmente | Muy restringida si ya disparó cierres, reportes o flujo económico | Sí |
| Muerte | Sí | Sí, excepcionalmente | Muy restringida por tratarse de salida definitiva | Sí |
| Traslado entre fincas | Sí | Sí | No si existen eventos posteriores ya ocurridos en la finca destino | Sí |
| Vacunación | Sí | Sí | Restringida si ya generó alertas o seguimiento | Sí |
| Tratamiento sanitario | Sí | Sí | Restringida si ya generó restricciones o seguimientos | Sí |
| Palpación o revisión reproductiva | Sí | Sí | Restringida si ya generó decisiones posteriores | Sí |
| Destete | Sí | Sí | Restringida si ya alteró relación madre-cría y ubicación posterior | Sí |
| Cambio de categoría | Sí | Sí | Restringida si ya hay eventos basados en la nueva categoría | Sí |
| Descarte | Sí | Sí, excepcionalmente | Muy restringida por salida definitiva | Sí |
| Nacimiento | Sí | Sí, con fuerte restricción | No si la cría ya tiene eventos posteriores | Sí |

## Tipos de corrección
1. Corrección de dato simple  
   Ejemplo: observación, causa, valor, responsable.

2. Corrección de dato estructural  
   Ejemplo: potrero destino, categoría, fecha del evento, identificador.

3. Anulación del evento  
   El evento queda sin efecto funcional, pero sigue trazado en historial.

## Regla recomendada
Cuando exista evento posterior dependiente, debe preferirse:
- corrección compensada
- anulación encadenada controlada
- regularización supervisada

y no una anulación simple.

## Auditoría mínima
Toda corrección o anulación debe guardar:
- evento afectado
- tipo de acción
- usuario
- fecha y hora
- motivo o justificación
- valor anterior y valor nuevo cuando aplique
