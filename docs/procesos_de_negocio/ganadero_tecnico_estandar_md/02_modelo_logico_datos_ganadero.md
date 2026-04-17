# Modelo lógico de datos ganadero

## Objetivo
Definir el modelo lógico del dominio ganadero usando la convención real del proyecto, acercándolo a implementación.

## Esquema de trabajo propuesto
- `Ganaderia`

> Nota: este esquema no fue observado todavía en el repositorio compartido, pero se propone para separar el nuevo dominio.

## Entidades maestras y operativas

### Finca
Tabla:
- `Ganaderia.Finca`

PK:
- `Finca_Codigo`

Columnas principales:
- `Finca_Codigo`
- `Finca_Codigo_Publico`
- `Cuenta_Codigo`
- `Finca_Nombre`
- `Finca_Codigo_Interno` opcional
- `Finca_Esta_Activa`
- `Finca_Observacion` opcional
- `Finca_Fecha_Registro`
- `Finca_Fecha_Ultima_Actualizacion` opcional
- `Finca_Registrado_Por` opcional
- `Finca_Modificado_Por` opcional

### Participacion_Finca
Tabla:
- `Ganaderia.Participacion_Finca`

PK:
- `Participacion_Finca_Codigo`

Columnas principales:
- `Participacion_Finca_Codigo`
- `Participacion_Finca_Codigo_Publico`
- `Finca_Codigo`
- `Usuario_Codigo`
- `Participacion_Finca_Rol`
- `Participacion_Finca_Esta_Activa`
- `Participacion_Finca_Fecha_Inicio`
- `Participacion_Finca_Fecha_Fin` opcional
- `Participacion_Finca_Observacion` opcional

### Potrero
Tabla:
- `Ganaderia.Potrero`

PK:
- `Potrero_Codigo`

Columnas principales:
- `Potrero_Codigo`
- `Potrero_Codigo_Publico`
- `Finca_Codigo`
- `Potrero_Nombre`
- `Potrero_Codigo_Interno` opcional
- `Potrero_Esta_Activo`
- `Potrero_Observacion` opcional
- `Potrero_Fecha_Registro`
- `Potrero_Fecha_Ultima_Actualizacion` opcional
- `Potrero_Registrado_Por` opcional
- `Potrero_Modificado_Por` opcional

Regla:
- nombre único por finca

### Categoria_Animal
Tabla:
- `Ganaderia.Categoria_Animal`

PK:
- `Categoria_Animal_Codigo`

Columnas:
- `Categoria_Animal_Codigo`
- `Categoria_Animal_Codigo_Publico`
- `Cuenta_Codigo`
- `Categoria_Animal_Nombre`
- `Categoria_Animal_Codigo_Interno` opcional
- `Categoria_Animal_Sexo_Esperado` opcional
- `Categoria_Animal_Orden`
- `Categoria_Animal_Esta_Activa`

### Rango_Edad
Tabla:
- `Ganaderia.Rango_Edad`

PK:
- `Rango_Edad_Codigo`

Columnas:
- `Rango_Edad_Codigo`
- `Rango_Edad_Codigo_Publico`
- `Cuenta_Codigo`
- `Rango_Edad_Nombre`
- `Rango_Edad_Edad_Minima_Meses` opcional
- `Rango_Edad_Edad_Maxima_Meses` opcional
- `Rango_Edad_Orden`
- `Rango_Edad_Esta_Activo`

### Tipo_Identificador
Tabla:
- `Ganaderia.Tipo_Identificador`

PK:
- `Tipo_Identificador_Codigo`

Columnas:
- `Tipo_Identificador_Codigo`
- `Tipo_Identificador_Codigo_Publico`
- `Cuenta_Codigo`
- `Tipo_Identificador_Nombre`
- `Tipo_Identificador_Codigo_Interno`
- `Tipo_Identificador_Es_Operativo`
- `Tipo_Identificador_Permite_Busqueda`
- `Tipo_Identificador_Permite_Principal`
- `Tipo_Identificador_Esta_Activo`

### Lote
Tabla:
- `Ganaderia.Lote`

PK:
- `Lote_Codigo`

Columnas:
- `Lote_Codigo`
- `Lote_Codigo_Publico`
- `Cuenta_Codigo`
- `Finca_Codigo` opcional
- `Lote_Tipo`
- `Lote_Nombre`
- `Lote_Codigo_Interno` opcional
- `Lote_Origen_Descripcion` opcional
- `Lote_Esta_Activo`
- `Lote_Fecha_Registro`

## Núcleo del dominio

### Animal
Tabla:
- `Ganaderia.Animal`

PK:
- `Animal_Codigo`

Columnas principales:
- `Animal_Codigo`
- `Animal_Codigo_Publico`
- `Cuenta_Codigo`
- `Finca_Codigo`
- `Potrero_Codigo`
- `Categoria_Animal_Codigo`
- `Lote_Codigo` opcional
- `Animal_Sexo`
- `Animal_Esta_Activo`
- `Animal_Tipo_Origen_Ingreso`
- `Animal_Fecha_Evento_Ingreso_Inicial` opcional
- `Animal_Fecha_Registro_Ingreso_Inicial`
- `Animal_Fecha_Ultimo_Evento` opcional
- `Animal_Fecha_Registro`
- `Animal_Fecha_Ultima_Actualizacion` opcional
- `Animal_Registrado_Por` opcional
- `Animal_Modificado_Por` opcional

Observación:
`Finca_Codigo`, `Potrero_Codigo`, `Categoria_Animal_Codigo` y `Animal_Esta_Activo` son snapshot controlado del estado actual y deben derivarse de eventos.

### Identificador_Animal
Tabla:
- `Ganaderia.Identificador_Animal`

PK:
- `Identificador_Animal_Codigo`

Columnas:
- `Identificador_Animal_Codigo`
- `Identificador_Animal_Codigo_Publico`
- `Animal_Codigo`
- `Tipo_Identificador_Codigo`
- `Identificador_Animal_Valor`
- `Identificador_Animal_Es_Principal`
- `Identificador_Animal_Esta_Activo`
- `Identificador_Animal_Fecha_Registro`
- `Identificador_Animal_Fecha_Ultima_Actualizacion` opcional

Reglas:
- un principal activo por animal
- uno por tipo por animal
- valor sujeto a política de unicidad

### Relacion_Madre_Cria
Tabla:
- `Ganaderia.Relacion_Madre_Cria`

PK:
- `Relacion_Madre_Cria_Codigo`

Columnas:
- `Relacion_Madre_Cria_Codigo`
- `Relacion_Madre_Cria_Codigo_Publico`
- `Madre_Animal_Codigo`
- `Cria_Animal_Codigo`
- `Relacion_Madre_Cria_Estado`
- `Relacion_Madre_Cria_Fecha_Inicio`
- `Relacion_Madre_Cria_Fecha_Fin` opcional
- `Relacion_Madre_Cria_Motivo_Fin` opcional
- `Relacion_Madre_Cria_Observacion` opcional

## Tronco transaccional por eventos

### Evento_Ganadero
Tabla:
- `Ganaderia.Evento_Ganadero`

PK:
- `Evento_Ganadero_Codigo`

Columnas:
- `Evento_Ganadero_Codigo`
- `Evento_Ganadero_Codigo_Publico`
- `Cuenta_Codigo`
- `Finca_Codigo`
- `Evento_Ganadero_Tipo`
- `Evento_Ganadero_Fecha`
- `Evento_Ganadero_Fecha_Registro`
- `Evento_Ganadero_Registrado_Por`
- `Evento_Ganadero_Estado`
- `Evento_Ganadero_Origen_Codigo` opcional
- `Evento_Ganadero_Es_Correccion`
- `Evento_Ganadero_Es_Anulacion`
- `Evento_Ganadero_Motivo_Correccion` opcional
- `Evento_Ganadero_Motivo_Anulacion` opcional
- `Evento_Ganadero_Observacion_General` opcional
- `Evento_Ganadero_Correlation_Id` opcional
- `Evento_Ganadero_Api_Codigo` opcional

### Evento_Ganadero_Animal
Tabla:
- `Ganaderia.Evento_Ganadero_Animal`

PK:
- `Evento_Ganadero_Animal_Codigo`

Columnas:
- `Evento_Ganadero_Animal_Codigo`
- `Evento_Ganadero_Codigo`
- `Animal_Codigo`
- `Evento_Ganadero_Animal_Orden_Secuencia` opcional
- `Evento_Ganadero_Animal_Estado_Afectacion`
- `Evento_Ganadero_Animal_Observacion` opcional

## Detalles por proceso

### Evento_Detalle_Registro_Existente
Tabla:
- `Ganaderia.Evento_Detalle_Registro_Existente`

Columnas:
- `Evento_Ganadero_Codigo`
- `Categoria_Animal_Codigo`
- `Rango_Edad_Codigo`
- `Potrero_Codigo`
- `Evento_Detalle_Registro_Existente_Sexo_Confirmado`
- `Evento_Detalle_Registro_Existente_Fecha_Informada` opcional

### Evento_Detalle_Compra
Tabla:
- `Ganaderia.Evento_Detalle_Compra`

Columnas:
- `Evento_Ganadero_Codigo`
- `Evento_Detalle_Compra_Fecha`
- `Evento_Detalle_Compra_Origen_O_Vendedor`
- `Potrero_Codigo`
- `Evento_Detalle_Compra_Valor_Total` opcional
- `Evento_Detalle_Compra_Tipo_Valor` opcional
- `Lote_Codigo` opcional

### Evento_Detalle_Pesaje
Tabla:
- `Ganaderia.Evento_Detalle_Pesaje`

Columnas:
- `Evento_Ganadero_Codigo`
- `Evento_Detalle_Pesaje_Peso`
- `Evento_Detalle_Pesaje_Unidad_Peso`
- `Evento_Detalle_Pesaje_Es_Ultima_Referencia`

### Evento_Detalle_Movimiento_Potrero
Tabla:
- `Ganaderia.Evento_Detalle_Movimiento_Potrero`

Columnas:
- `Evento_Ganadero_Codigo`
- `Potrero_Origen_Codigo`
- `Potrero_Destino_Codigo`

### Evento_Detalle_Venta
Tabla:
- `Ganaderia.Evento_Detalle_Venta`

Columnas:
- `Evento_Ganadero_Codigo`
- `Evento_Detalle_Venta_Fecha`
- `Evento_Detalle_Venta_Comprador_O_Destino`
- `Evento_Detalle_Venta_Valor` opcional
- `Evento_Detalle_Venta_Tipo_Valor` opcional
- `Evento_Detalle_Venta_Observacion` opcional

### Evento_Detalle_Muerte
Tabla:
- `Ganaderia.Evento_Detalle_Muerte`

Columnas:
- `Evento_Ganadero_Codigo`
- `Evento_Detalle_Muerte_Fecha`
- `Causa_Muerte_Codigo` o `Evento_Detalle_Muerte_Causa_Texto`
- `Evento_Detalle_Muerte_Reportado_Por` opcional

### Evento_Detalle_Traslado_Entre_Fincas
Tabla:
- `Ganaderia.Evento_Detalle_Traslado_Entre_Fincas`

Columnas:
- `Evento_Ganadero_Codigo`
- `Finca_Origen_Codigo`
- `Finca_Destino_Codigo`
- `Potrero_Destino_Codigo`

### Evento_Detalle_Vacunacion
Tabla:
- `Ganaderia.Evento_Detalle_Vacunacion`

Columnas:
- `Evento_Ganadero_Codigo`
- `Vacuna_Codigo`
- `Evento_Detalle_Vacunacion_Dosis` opcional
- `Evento_Detalle_Vacunacion_Lote_Producto` opcional
- `Evento_Detalle_Vacunacion_Aplicado_Por` opcional

### Evento_Detalle_Tratamiento_Sanitario
Tabla:
- `Ganaderia.Evento_Detalle_Tratamiento_Sanitario`

Columnas:
- `Evento_Ganadero_Codigo`
- `Tratamiento_Codigo`
- `Evento_Detalle_Tratamiento_Sanitario_Dosis` opcional
- `Evento_Detalle_Tratamiento_Sanitario_Duracion_Indicacion` opcional
- `Evento_Detalle_Tratamiento_Sanitario_Aplicado_Por` opcional
- `Evento_Detalle_Tratamiento_Sanitario_Observacion_Clinica` opcional

### Evento_Detalle_Palpacion
Tabla:
- `Ganaderia.Evento_Detalle_Palpacion`

Columnas:
- `Evento_Ganadero_Codigo`
- `Resultado_Reproductivo_Codigo`
- `Evento_Detalle_Palpacion_Responsable_Revision` opcional
- `Evento_Detalle_Palpacion_Observacion` opcional

### Evento_Detalle_Destete
Tabla:
- `Ganaderia.Evento_Detalle_Destete`

Columnas:
- `Evento_Ganadero_Codigo`
- `Cria_Animal_Codigo`
- `Madre_Animal_Codigo` opcional
- `Potrero_Destino_Codigo` opcional

### Evento_Detalle_Cambio_Categoria
Tabla:
- `Ganaderia.Evento_Detalle_Cambio_Categoria`

Columnas:
- `Evento_Ganadero_Codigo`
- `Categoria_Animal_Anterior_Codigo`
- `Categoria_Animal_Nueva_Codigo`
- `Evento_Detalle_Cambio_Categoria_Sugerido_Por_Sistema`

### Evento_Detalle_Descarte
Tabla:
- `Ganaderia.Evento_Detalle_Descarte`

Columnas:
- `Evento_Ganadero_Codigo`
- `Motivo_Descarte_Codigo`
- `Evento_Detalle_Descarte_Destino` opcional
- `Evento_Detalle_Descarte_Valor` opcional

### Evento_Detalle_Nacimiento
Tabla:
- `Ganaderia.Evento_Detalle_Nacimiento`

Columnas:
- `Evento_Ganadero_Codigo`
- `Madre_Animal_Codigo`
- `Cria_Animal_Codigo`
- `Evento_Detalle_Nacimiento_Sexo_Cria`
- `Categoria_Animal_Codigo`
- `Potrero_Codigo`
- `Evento_Detalle_Nacimiento_Peso` opcional

## Catálogos operativos

### Causa_Muerte
- `Causa_Muerte_Codigo`
- `Causa_Muerte_Codigo_Publico`
- `Cuenta_Codigo`
- `Causa_Muerte_Nombre`
- `Causa_Muerte_Codigo_Interno` opcional
- `Causa_Muerte_Es_Generica`
- `Causa_Muerte_Esta_Activa`

### Motivo_Descarte
- `Motivo_Descarte_Codigo`
- `Motivo_Descarte_Codigo_Publico`
- `Cuenta_Codigo`
- `Motivo_Descarte_Nombre`
- `Motivo_Descarte_Codigo_Interno` opcional
- `Motivo_Descarte_Esta_Activo`

### Vacuna
- `Vacuna_Codigo`
- `Vacuna_Codigo_Publico`
- `Cuenta_Codigo`
- `Vacuna_Nombre`
- `Vacuna_Codigo_Interno` opcional
- `Vacuna_Esta_Activa`

### Tratamiento
- `Tratamiento_Codigo`
- `Tratamiento_Codigo_Publico`
- `Cuenta_Codigo`
- `Tratamiento_Nombre`
- `Tratamiento_Codigo_Interno` opcional
- `Tratamiento_Esta_Activo`

### Resultado_Reproductivo
- `Resultado_Reproductivo_Codigo`
- `Resultado_Reproductivo_Codigo_Publico`
- `Cuenta_Codigo`
- `Resultado_Reproductivo_Nombre`
- `Resultado_Reproductivo_Codigo_Interno`
- `Resultado_Reproductivo_Esta_Activo`

## Parámetros
Tabla:
- `Ganaderia.Parametro_Cuenta_Ganaderia`

Columnas:
- `Parametro_Cuenta_Ganaderia_Codigo`
- `Parametro_Cuenta_Ganaderia_Codigo_Publico`
- `Cuenta_Codigo`
- `Parametro_Cuenta_Ganaderia_Clave`
- `Parametro_Cuenta_Ganaderia_Valor`
- `Parametro_Cuenta_Ganaderia_Tipo_Dato`
- `Parametro_Cuenta_Ganaderia_Esta_Activo`
- `Parametro_Cuenta_Ganaderia_Observacion` opcional

## Reglas lógicas clave
- una tabla por entidad en singular
- PK `<Entidad>_Codigo`
- FKs `<EntidadReferenciada>_Codigo`
- columnas prefijadas por entidad
- snapshot de estado actual en `Animal`, gobernado por eventos
- trazabilidad completa en `Evento_Ganadero`
- `Evento_Ganadero_Animal` obligatorio incluso para procesos individuales, por consistencia
