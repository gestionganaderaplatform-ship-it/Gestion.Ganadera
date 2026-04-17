# Base funcional consolidada

## Alcance
Este documento consolida la base funcional ya construida en la documentacion generada. El criterio fue mantener lo repetido y estable, eliminar duplicados y dejar aparte lo todavia abierto.

## Vision funcional
- GANADERO SaaS se define como un sistema gobernado por procesos y eventos, no por mantenimiento libre de entidades.
- `Registrar` es el punto formal de ejecucion.
- El animal es una identidad estable.
- La realidad operativa del animal se deriva de eventos.
- El historial y la trazabilidad son obligatorios.
- La web sale primero como canal completo; la app llega despues para procesos de alta frecuencia y trabajo en terreno.

## Modelo operativo base
- La cuenta representa al cliente.
- Cada cuenta tiene un dueno titular.
- Una cuenta puede tener una o varias fincas.
- La operacion diaria ocurre dentro de una finca activa.
- El ganado es el conjunto de animales gestionados en ese contexto.
- Puede haber participantes por finca con rol y alcance definido.

## Roles base
- Dueno titular
- Administrador de finca
- Operario de campo
- Veterinario

## Reglas funcionales transversales
- El proceso manda.
- Se pide informacion minima util primero.
- Los estados del animal no deben editarse libremente cuando pueden derivarse de eventos.
- No deben existir puntos paralelos de operacion fuera de `Registrar`.
- La ficha del animal es vista de consulta y contexto.
- `Ganado` es vista principal de consulta del inventario activo.
- La fecha anterior puede permitirse segun politica.
- La identificacion minima del animal es obligatoria.
- Potreros y algunos maestros operativos pueden crearse en flujo segun politica.
- Las correcciones y anulaciones no borran trazabilidad.
- La relacion madre-cria existe como pieza funcional del dominio.

## Procesos incluidos

### Fase 1
- Registro de existente
- Compra
- Pesaje
- Movimiento de potrero
- Venta
- Muerte
- Traslado entre fincas

### Fase 2
- Vacunacion
- Tratamiento sanitario
- Palpacion o revision reproductiva
- Destete
- Cambio de categoria
- Descarte
- Nacimiento

## Reglas por naturaleza del proceso
- Los eventos de ingreso son: registro de existente, compra y nacimiento.
- Los eventos de seguimiento son: pesaje, vacunacion, tratamiento sanitario y revision reproductiva.
- Los eventos de movimiento son: movimiento de potrero y traslado entre fincas.
- Los eventos de transformacion funcional son: destete y cambio de categoria.
- Los eventos de salida definitiva son: venta, muerte y descarte.

## Estados derivados del animal
- Condicion de activo
- Finca actual
- Potrero actual
- Categoria actual
- Ultima referencia de peso
- Condicion de salida
- Relacion madre-cria activa
- Origen de ingreso
- Ultimo evento sanitario
- Ultimo evento reproductivo

## Reglas de estados derivados
- Ningun estado derivado debe alterarse por mantenimiento general.
- Prevalece el evento cronologicamente valido mas reciente.
- La correccion o anulacion debe recalcular los estados afectados.
- Los eventos de salida definitiva dejan al animal inactivo.

## Historial y trazabilidad
- Todo evento relevante debe quedar en historial.
- El historial debe mostrar al menos:
  - tipo de evento
  - fecha del evento
  - fecha de registro
  - usuario que registro
  - animal o animales afectados
  - finca asociada
  - datos clave del evento
  - indicador de correccion
  - indicador de anulacion
- Si fecha del evento y fecha de registro difieren, ambas deben verse.
- Los eventos por lote deben verse como evento grupal y tambien por animal afectado.

## Permisos base
- El operario no anula eventos.
- El operario no gobierna configuracion.
- El administrador puede corregir o anular eventos dentro de la politica permitida.
- El dueno titular puede corregir o anular segun la politica superior de la cuenta.
- El veterinario se concentra en procesos sanitarios y reproductivos.

## Base funcional ya suficientemente solida
- Vision del producto orientada por procesos.
- Fases y lista de procesos.
- Regla de `Registrar` como punto formal.
- Estados derivados del animal.
- Historial como requisito obligatorio.
- Roles base y restricciones superiores.
- Web primero y app despues.

## Elementos funcionales que quedaron afinables
- La granularidad exacta por permiso para cada rol y cada proceso.
- La amplitud real de trabajo por grupo o lote en algunos procesos de fase 2.
- El grado exacto de creacion contextual para ciertos catalogos.
