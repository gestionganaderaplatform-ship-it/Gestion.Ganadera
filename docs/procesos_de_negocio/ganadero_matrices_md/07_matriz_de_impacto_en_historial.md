# Matriz de impacto en historial

## Objetivo
Definir qué debe quedar en historial por cada proceso para sostener trazabilidad completa.

## Campos mínimos transversales de historial
- tipo de evento
- fecha del evento
- fecha de registro
- usuario que registró
- animal o animales afectados
- finca asociada
- datos clave del evento
- indicador de corrección
- indicador de anulación

## Matriz por proceso

| Proceso | Debe quedar en historial | Datos mínimos específicos |
|---|---|---|
| Registro de existente | Sí | identificador, sexo, categoría, rango de edad, finca, potrero, origen de ingreso |
| Compra | Sí | identificador, fecha de compra, origen o vendedor, potrero destino, valor si existe, lote de compra si aplica |
| Pesaje | Sí | animal, fecha, peso |
| Movimiento de potrero | Sí | animal o grupo, fecha, potrero origen, potrero destino |
| Venta | Sí | animal o lote, fecha, comprador o destino, valor si existe |
| Muerte | Sí | animal, fecha, causa, observación si existe |
| Traslado entre fincas | Sí | animal o lote, fecha, finca origen, finca destino, potrero destino |
| Vacunación | Sí | animal, vacuna, fecha, aplicador si existe, dosis si existe |
| Tratamiento sanitario | Sí | animal, tratamiento o producto, fecha, responsable si existe, observación clínica si existe |
| Palpación o revisión reproductiva | Sí | animal, fecha, resultado, responsable si existe |
| Destete | Sí | cría, madre si aplica, fecha, potrero destino si aplica |
| Cambio de categoría | Sí | animal, categoría anterior, nueva categoría, fecha |
| Descarte | Sí | animal, motivo, fecha, destino o valor si existe |
| Nacimiento | Sí | madre, cría, fecha, sexo, categoría inicial, potrero inicial |

## Reglas
- Historial general y por animal deben mostrar también correcciones y anulaciones.
- Cuando fecha del evento y fecha de registro difieren, ambas deben verse.
- Los eventos por lote deben poder verse tanto como evento grupal como en la traza de cada animal afectado.
