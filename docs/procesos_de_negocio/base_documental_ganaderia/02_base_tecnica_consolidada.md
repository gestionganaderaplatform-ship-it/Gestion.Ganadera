# Base tecnica consolidada

## Alcance
Este documento consolida lo tecnico que si aparece en la documentacion generada y separa lo que quedo definido, lo que fue propuesto y lo que sigue pendiente de validar.

## Definido en esta base documental

### Modelo funcional-tecnico
- El dominio debe conservar una identidad estable del animal.
- La operacion debe quedar sostenida por un tronco de eventos.
- El estado actual del animal se maneja como snapshot controlado por eventos.
- El historial visible y la trazabilidad funcional son obligatorios.

### Modulos funcionales
- Contexto operativo
- Ganado
- Ficha del animal
- Registrar procesos fase 1
- Registrar procesos fase 2
- Historial
- Correccion y anulacion
- Configuracion operativa
- Reportes

### Validaciones
- El frontend orienta y previene.
- El backend decide y garantiza.
- Ninguna regla critica debe quedar solo en frontend.

### Auditoria y trazabilidad
- Debe existir trazabilidad de negocio.
- Debe existir auditoria de cambios en piezas sensibles.
- Debe existir observabilidad tecnica.
- Corregir o anular no borra la traza original.

### Backlog tecnico
- Primero base de datos y dominio.
- Luego backend de consulta.
- Luego backend de procesos fase 1.
- Luego frontend de consulta.
- Luego frontend de procesos fase 1.
- Luego fase 2.
- Luego fortalecimiento transversal.

## Propuesto en esta base documental

### Estandar aplicado para Ganaderia
- Usar esquema `Ganaderia`.
- Bajar las entidades del dominio ganadero a tablas con naming alineado al patron definido en la documentacion tecnica.
- Mantener EF Core con clases limpias en C# y nombres fisicos alineados al modelo propuesto.

### Modelo logico
- Entidades maestras y operativas:
  - `Finca`
  - `Participacion_Finca`
  - `Potrero`
  - `Categoria_Animal`
  - `Rango_Edad`
  - `Tipo_Identificador`
  - `Lote`
- Nucleo del dominio:
  - `Animal`
  - `Identificador_Animal`
  - `Relacion_Madre_Cria`
- Tronco transaccional:
  - `Evento_Ganadero`
  - `Evento_Ganadero_Animal`
- Detalles por proceso:
  - tablas `Evento_Detalle_*`
- Parametros:
  - `Parametro_Cuenta_Ganaderia`

### Convenciones EF Core
- Clases en singular y `PascalCase`.
- Propiedades con el nombre final de columna.
- `ToTable("Tabla", "Ganaderia")`.
- PK en `<Entidad>_Codigo`.
- FKs con nombre de entidad referenciada.
- `DeleteBehavior.Restrict`.
- `SYSDATETIME()` donde aplique.
- Indices por entidades criticas como `Animal`, `Identificador_Animal`, `Evento_Ganadero` y `Evento_Ganadero_Animal`.

### Contratos funcionales API
- Operaciones por modulo.
- Requests y responses base sugeridos.
- Filtros base sugeridos.
- Flujos de validacion y confirmacion por proceso.

## Pendiente de validar

### Modelo fisico final
- El esquema `Ganaderia` esta planteado como propuesta de trabajo, no como decision cerrada dentro de esta base documental.
- Las tablas, columnas e indices del modelo logico todavia no equivalen a un fisico validado.

### EF Core real
- Las convenciones EF Core estan documentadas como guia de implementacion.
- No equivalen todavia a configuraciones reales validadas.

### Contratos finales
- Los contratos API estan en nivel funcional.
- El contrato HTTP final, el JSON final y los DTOs finales quedaron abiertos.

### Auditoria exacta
- La base funcional exige trazabilidad total.
- El bloque exacto de auditoria por tabla y por entidad no quedo cerrado al 100 por ciento dentro de esta base documental.

### Naming y estructura
- El naming fisico del modulo ganadero y parte del modelo logico quedaron como propuesta de aterrizaje.
- No debe asumirse todavia como version final cerrada.

## Lectura operativa
- Si se va a contrastar documentacion contra implementacion futura, esta base tecnica debe leerse junto con `03_elementos_pendientes_por_validar.md`.
- Si se va a construir desde documentacion, lo mas firme hoy es el modelo por eventos, el reparto de validaciones, la necesidad de historial y la secuencia del backlog.
