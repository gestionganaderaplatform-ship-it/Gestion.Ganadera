# Contratos funcionales API por módulo

## Objetivo
Definir qué operaciones funcionales debería exponer la API ganadera por módulo, sin congelar todavía el contrato HTTP final.

## Regla importante
El estándar de base de datos y EF Core no obliga automáticamente el nombre del JSON público. Este documento define operaciones y estructuras funcionales; los DTOs HTTP finales se pueden cerrar después sin romper el estándar físico de datos.

## 1. Contexto operativo

### Operaciones
- obtener fincas permitidas del usuario
- obtener finca activa
- cambiar finca activa
- obtener roles y alcance del usuario en la finca activa

### Respuesta base sugerida
- finca activa
- lista de fincas disponibles
- permisos resueltos
- alcance funcional

## 2. Ganado

### Operaciones
- consultar ganado activo
- buscar animal por identificador
- filtrar animales
- consultar resumen de inventario
- consultar animales por potrero
- consultar animales por categoría

### Filtros base sugeridos
- finca
- categoria
- sexo
- potrero
- condicionActivo
- textoBusqueda
- pagina
- tamanioPagina
- orden

### Respuesta base sugerida
- listado de animales resumidos
- total
- resumen de filtros aplicados

## 3. Ficha del animal

### Operaciones
- obtener ficha completa de un animal
- obtener identificadores del animal
- obtener resumen de historial
- obtener contexto madre-cría
- obtener accesos rápidos a procesos permitidos

### Request base sugerido
- `Animal_Codigo` o identificador resuelto

### Response base sugerida
- datos base
- estado actual
- identificadores
- últimos eventos
- relación madre-cría
- acciones habilitadas

## 4. Registrar procesos fase 1

### 4.1 Registro de existente
Operaciones:
- validar borrador individual
- validar lote secuencial
- validar archivo masivo
- confirmar registro
- descargar plantilla masiva

Datos funcionales:
- fechaEvento opcional
- animales
- categoria
- rangoEdad
- potrero
- confirmacionFinal

Resultado:
- animales creados
- eventos creados
- advertencias
- errores por fila si aplica

### 4.2 Compra
Operaciones:
- validar compra
- validar archivo masivo
- confirmar compra

Datos funcionales:
- fechaCompra
- origenOVendedor
- potreroDestino
- animales
- valor opcional

### 4.3 Pesaje
Operaciones:
- validar pesaje
- registrar pesaje individual
- registrar pesaje grupal

Datos funcionales:
- fechaPesaje
- animales
- pesos

### 4.4 Movimiento de potrero
Operaciones:
- validar selección
- registrar movimiento individual
- registrar movimiento grupal

Datos funcionales:
- fechaMovimiento
- animales
- potreroDestino

### 4.5 Venta
Operaciones:
- validar venta
- registrar venta individual
- registrar venta por lote

Datos funcionales:
- fechaVenta
- animales
- compradorODestino
- valor opcional

### 4.6 Muerte
Operaciones:
- validar muerte
- registrar muerte

Datos funcionales:
- animal
- fechaMuerte
- causa
- observacion opcional
- reportadoPor opcional

### 4.7 Traslado entre fincas
Operaciones:
- validar traslado
- registrar traslado individual
- registrar traslado por lote

Datos funcionales:
- fechaTraslado
- animales
- fincaDestino
- potreroDestino

## 5. Registrar procesos fase 2
- validar y registrar vacunación
- validar y registrar tratamiento sanitario
- validar elegibilidad y registrar palpación
- validar y registrar destete
- obtener sugerencia y confirmar cambio de categoría
- validar y registrar descarte
- validar madre y registrar nacimiento

## 6. Historial

### Operaciones
- consultar historial general
- consultar historial por animal
- consultar historial por proceso
- consultar detalle de evento
- consultar trazas de corrección o anulación

### Filtros base
- fechaDesde
- fechaHasta
- tipoEvento
- animal
- finca
- usuarioRegistro
- estadoEvento

## 7. Corrección y anulación

### Operaciones
- prevalidar corrección
- corregir evento
- prevalidar anulación
- anular evento
- consultar dependencias del evento
- consultar impacto de la acción

### Request base sugerido
- `Evento_Ganadero_Codigo`
- tipoAccion
- motivo
- cambiosPropuestos

### Response base sugerida
- permitido
- bloqueos
- advertencias
- estadosAfectados
- eventoResultante si aplica

## 8. Configuración operativa

### Operaciones principales
- consultar potreros
- crear potrero
- editar potrero
- consultar categorías
- consultar rangos de edad
- consultar tipos de identificador
- consultar y administrar vacunas
- consultar y administrar tratamientos
- consultar y administrar causas y motivos
- consultar y administrar parámetros de negocio

## 9. Reportes

### Operaciones iniciales
- reporte de estado actual del ganado
- reporte de entradas y salidas por período
- historial consolidado de un animal

## 10. Convención útil para DTOs internos
Aunque el HTTP público puede definirse después, para comandos internos y mapeos cercanos a persistencia conviene que los nombres críticos no se alejen innecesariamente del dominio:
- `Animal_Codigo`
- `Finca_Codigo`
- `Potrero_Codigo`
- `Categoria_Animal_Codigo`
- `Evento_Ganadero_Codigo`

Eso reduce fricción entre aplicación, persistencia y trazabilidad.
