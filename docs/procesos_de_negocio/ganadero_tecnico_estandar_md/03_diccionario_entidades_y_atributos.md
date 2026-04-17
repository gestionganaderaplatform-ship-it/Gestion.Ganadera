# Diccionario de entidades y atributos

## Finca
Tabla:
`Ganaderia.Finca`

Clave primaria:
`Finca_Codigo`

Identificador externo:
`Finca_Codigo_Publico`

Campos principales:
- `Cuenta_Codigo`
- `Finca_Nombre`
- `Finca_Codigo_Interno`
- `Finca_Esta_Activa`
- `Finca_Observacion`
- `Finca_Fecha_Registro`

Propósito:
Representar la unidad operativa real donde ocurre la gestión del ganado.

## Potrero
Tabla:
`Ganaderia.Potrero`

Clave primaria:
`Potrero_Codigo`

Campos principales:
- `Finca_Codigo`
- `Potrero_Nombre`
- `Potrero_Codigo_Interno`
- `Potrero_Esta_Activo`
- `Potrero_Observacion`
- `Potrero_Fecha_Registro`

Propósito:
Representar la subdivisión operativa de una finca para ubicar animales.

## Animal
Tabla:
`Ganaderia.Animal`

Clave primaria:
`Animal_Codigo`

Campos principales:
- `Cuenta_Codigo`
- `Finca_Codigo`
- `Potrero_Codigo`
- `Categoria_Animal_Codigo`
- `Lote_Codigo`
- `Animal_Sexo`
- `Animal_Esta_Activo`
- `Animal_Tipo_Origen_Ingreso`
- `Animal_Fecha_Registro_Ingreso_Inicial`
- `Animal_Fecha_Ultimo_Evento`

Propósito:
Ser la identidad estable del ganado dentro del sistema.

Observación:
Los campos actuales del animal no habilitan edición libre de la realidad operativa; son snapshot controlado por eventos.

## Identificador_Animal
Tabla:
`Ganaderia.Identificador_Animal`

Clave primaria:
`Identificador_Animal_Codigo`

Campos principales:
- `Animal_Codigo`
- `Tipo_Identificador_Codigo`
- `Identificador_Animal_Valor`
- `Identificador_Animal_Es_Principal`
- `Identificador_Animal_Esta_Activo`

Propósito:
Permitir múltiples identificaciones operativas del animal.

Reglas:
- uno principal
- uno por tipo
- valor sujeto a política de unicidad

## Categoria_Animal
Tabla:
`Ganaderia.Categoria_Animal`

Clave primaria:
`Categoria_Animal_Codigo`

Campos principales:
- `Cuenta_Codigo`
- `Categoria_Animal_Nombre`
- `Categoria_Animal_Sexo_Esperado`
- `Categoria_Animal_Orden`
- `Categoria_Animal_Esta_Activa`

Propósito:
Clasificar funcionalmente al animal.

## Rango_Edad
Tabla:
`Ganaderia.Rango_Edad`

Clave primaria:
`Rango_Edad_Codigo`

Campos principales:
- `Cuenta_Codigo`
- `Rango_Edad_Nombre`
- `Rango_Edad_Edad_Minima_Meses`
- `Rango_Edad_Edad_Maxima_Meses`
- `Rango_Edad_Orden`
- `Rango_Edad_Esta_Activo`

## Lote
Tabla:
`Ganaderia.Lote`

Clave primaria:
`Lote_Codigo`

Campos principales:
- `Cuenta_Codigo`
- `Finca_Codigo`
- `Lote_Tipo`
- `Lote_Nombre`
- `Lote_Origen_Descripcion`
- `Lote_Esta_Activo`

## Relacion_Madre_Cria
Tabla:
`Ganaderia.Relacion_Madre_Cria`

Clave primaria:
`Relacion_Madre_Cria_Codigo`

Campos principales:
- `Madre_Animal_Codigo`
- `Cria_Animal_Codigo`
- `Relacion_Madre_Cria_Estado`
- `Relacion_Madre_Cria_Fecha_Inicio`
- `Relacion_Madre_Cria_Fecha_Fin`

## Evento_Ganadero
Tabla:
`Ganaderia.Evento_Ganadero`

Clave primaria:
`Evento_Ganadero_Codigo`

Campos principales:
- `Cuenta_Codigo`
- `Finca_Codigo`
- `Evento_Ganadero_Tipo`
- `Evento_Ganadero_Fecha`
- `Evento_Ganadero_Fecha_Registro`
- `Evento_Ganadero_Registrado_Por`
- `Evento_Ganadero_Estado`
- `Evento_Ganadero_Origen_Codigo`
- `Evento_Ganadero_Es_Correccion`
- `Evento_Ganadero_Es_Anulacion`

Propósito:
Ser el tronco transaccional del dominio.

## Evento_Ganadero_Animal
Tabla:
`Ganaderia.Evento_Ganadero_Animal`

Clave primaria:
`Evento_Ganadero_Animal_Codigo`

Campos principales:
- `Evento_Ganadero_Codigo`
- `Animal_Codigo`
- `Evento_Ganadero_Animal_Orden_Secuencia`
- `Evento_Ganadero_Animal_Estado_Afectacion`

## Detalles por evento
Tablas hijas:
- `Evento_Detalle_Registro_Existente`
- `Evento_Detalle_Compra`
- `Evento_Detalle_Pesaje`
- `Evento_Detalle_Movimiento_Potrero`
- `Evento_Detalle_Venta`
- `Evento_Detalle_Muerte`
- `Evento_Detalle_Traslado_Entre_Fincas`
- `Evento_Detalle_Vacunacion`
- `Evento_Detalle_Tratamiento_Sanitario`
- `Evento_Detalle_Palpacion`
- `Evento_Detalle_Destete`
- `Evento_Detalle_Cambio_Categoria`
- `Evento_Detalle_Descarte`
- `Evento_Detalle_Nacimiento`

Regla:
La PK/FK de estas tablas debe ser `Evento_Ganadero_Codigo`.

## Parametro_Cuenta_Ganaderia
Tabla:
`Ganaderia.Parametro_Cuenta_Ganaderia`

Clave primaria:
`Parametro_Cuenta_Ganaderia_Codigo`

Campos principales:
- `Cuenta_Codigo`
- `Parametro_Cuenta_Ganaderia_Clave`
- `Parametro_Cuenta_Ganaderia_Valor`
- `Parametro_Cuenta_Ganaderia_Tipo_Dato`
- `Parametro_Cuenta_Ganaderia_Esta_Activo`

## Resumen operativo
El criterio fuerte que manda en esta capa es:
- no usar `AnimalId`, `FarmId`, `CurrentCategoryId` ni equivalentes genéricos
- sí respetar `Animal_Codigo`, `Finca_Codigo`, `Categoria_Animal_Codigo`
- sí mantener el patrón físico visible del proyecto
