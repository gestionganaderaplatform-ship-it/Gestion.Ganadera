# Reglas de validación frontend y backend

## Regla madre
- El frontend orienta y previene.
- El backend decide y garantiza.

## Qué valida el frontend

### Presencia y formato básico
- campo obligatorio vacío
- formato numérico
- selección requerida
- archivo cargado

### Experiencia
- habilitar o deshabilitar confirmación
- mostrar resumen antes de confirmar
- advertir cambios sin guardar
- mostrar incoherencias visibles

### Ayuda al usuario
- categoría sugiere sexo
- lote vacío
- advertencias previas de consistencia

## Qué valida el backend

### Integridad del negocio
- animal existe
- animal está activo
- identificador no duplicado
- potrero pertenece a la finca activa
- no vender animal ya vendido
- no mover animal a mismo potrero
- no trasladar a misma finca

### Permisos reales
- rol puede ejecutar proceso
- rol puede corregir
- rol puede anular
- rol puede usar fecha anterior
- rol puede operar la finca activa

### Reglas parametrizadas
- ventana máxima de fecha anterior
- política de unicidad
- bloqueos por incompatibilidad sexo-categoría
- política de creación contextual
- requisito de justificación

### Trazabilidad y consistencia
- generar evento
- actualizar snapshot del animal
- recalcular estados derivados
- dejar auditoría

## Reparto recomendado de implementación

### Frontend
- validaciones ligeras y rápidas
- mensajes claros
- no asumir verdad final de negocio

### Backend
- FluentValidation para requests/comandos
- validadores de aplicación por proceso
- reglas de negocio en servicios o casos de uso
- ProblemDetails para errores consistentes

## Tipos de respuesta recomendados
- bloqueo
- advertencia
- confirmación
- resultado

## Regla importante
Nunca debe quedar una regla crítica solo en frontend.

## Nota técnica
El hecho de que la base use columnas tipo `Animal_Codigo` o `Evento_Ganadero_Codigo` no obliga a que todo el mensaje visual al usuario use esos nombres, pero sí conviene que backend y aplicación mantengan claridad suficiente para no perder trazabilidad.
