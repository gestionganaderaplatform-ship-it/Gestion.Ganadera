# Proceso · Vacunación

## 1. Objetivo
Registrar la aplicación de una vacuna a uno o varios animales para dejar trazabilidad sanitaria, soportar seguimiento operativo y mantener historial confiable.

## 2. Alcance
Este proceso cubre:
- vacunación individual
- vacunación por grupo
- selección de vacuna
- fecha de aplicación
- registro de aplicador cuando aplique
- registro de dosis, lote del producto y observación como datos complementarios
- creación contextual de vacuna si la política lo permite
- registro histórico del evento sanitario

No cubre:
- tratamiento sanitario no preventivo
- programación compleja de esquemas sanitarios
- inventario de medicamentos
- lógica clínica avanzada

## 3. Roles que intervienen
Pueden ejecutar:
- dueño titular
- administrador de finca
- operario autorizado
- veterinario

Pueden corregir o anular según política:
- administrador de finca
- dueño titular
- veterinario si se le otorga permiso especial

## 4. Disparador del proceso
El proceso inicia cuando se aplica una vacuna en la operación y debe quedar registro formal del evento.

## 5. Precondiciones
- existe una finca activa
- el animal existe
- el animal está activo
- el usuario tiene permiso para registrar vacunación
- la vacuna existe o puede crearse dentro del flujo según política
- si se registra por grupo, todos los animales deben estar activos y seleccionables

## 6. Datos de entrada
- modalidad de registro
- animal o grupo
- vacuna
- fecha de aplicación
- aplicador, si aplica
- dosis, si aplica
- lote del producto, si aplica
- observación, si aplica

## 7. Campos exactos
### Encabezado del proceso
- modalidad_registro
- finca_activa_mostrada

### Datos del evento
- fecha_aplicacion
- vacuna
- aplicador
- dosis
- lote_producto
- observacion

### Selección de animales
- animal, en individual
- grupo_animales, en grupo

### Campos de sistema
- usuario_registro
- fecha_hora_registro
- tipo_evento = vacunacion

## 8. Obligatorios y opcionales
### Obligatorios
- modalidad_registro
- animal o grupo
- vacuna
- fecha_aplicacion

### Opcionales
- aplicador
- dosis
- lote_producto
- observacion

### Automáticos
- usuario_registro
- fecha_hora_registro
- finca_activa

## 9. Valores por defecto
- modalidad_registro: individual
- fecha_aplicacion: hoy
- aplicador: vacío
- dosis: vacío
- lote_producto: vacío
- observacion: vacío

## 10. Reglas de validación
1. No se permite registrar vacunación sin animal o grupo seleccionado.
2. No se permite registrar vacunación sin vacuna.
3. La fecha de aplicación es obligatoria.
4. No se permite vacunar animales inactivos.
5. No se permite vacunar animales inexistentes.
6. En grupo, todos los animales deben ser válidos al confirmar.
7. Si la vacuna no existe, solo podrá crearse si la política lo permite.
8. La dosis, si se registra, debe cumplir formato válido.
9. El lote del producto, si se registra, debe cumplir longitud máxima definida.
10. El registro debe cerrarse siempre con confirmación final.
11. La fecha debe respetar la política de fecha anterior permitida por cuenta y rol.

## 11. Bloqueos
- no hay finca activa
- no hay animal ni grupo seleccionado
- no hay vacuna seleccionada
- no hay fecha de aplicación
- el animal no existe
- el animal está inactivo
- algún animal del grupo está inactivo
- usuario sin permiso
- vacuna inexistente cuando no se permita creación contextual

## 12. Advertencias
- falta dosis
- falta lote del producto
- la fecha es muy antigua según la política
- el animal tiene antecedentes sanitarios recientes del mismo tipo
- el grupo es muy grande y conviene revisar antes de confirmar

## 13. Mensajes funcionales
### Errores
- Debe seleccionar una vacuna.
- La fecha de aplicación es obligatoria.
- Debe seleccionar al menos un animal.
- No puede vacunar un animal inactivo.
- El animal no existe en el sistema.
- No tiene permiso para registrar vacunación.

### Advertencias
- La vacuna se registrará sin dosis.
- La vacuna se registrará sin lote del producto.
- La fecha de aplicación supera la ventana habitual de registro.

### Confirmación
- Va a registrar vacunación para {n} animal(es).
- ¿Confirma guardar el evento?

### Éxito
- Vacunación registrada correctamente.
- Se registró la vacunación para {n} animal(es).

## 14. Flujo principal paso a paso
1. El usuario entra a Registrar.
2. Selecciona el proceso Vacunación.
3. El sistema valida finca activa y permisos.
4. El usuario elige modalidad individual o grupo.
5. Selecciona animal o grupo.
6. Selecciona vacuna.
7. Registra fecha de aplicación.
8. Registra datos opcionales.
9. El sistema muestra resumen final.
10. El usuario confirma.
11. El sistema guarda el evento y actualiza historial.

## 15. Escenarios alternos
1. Si la vacuna no existe, se permite creación contextual si la política lo autoriza.
2. Si un animal del grupo está inactivo, el sistema excluye o bloquea según configuración; por defecto debe bloquear la confirmación hasta corregir.
3. Si no se conoce el aplicador, el campo puede quedar vacío.
4. Si se registra desde ficha del animal, el animal llega preseleccionado.

## 16. Correcciones y anulaciones
- la corrección debe dejar trazabilidad del valor anterior y nuevo
- la anulación no borra el evento original
- operario no anula
- administrador, dueño y veterinario autorizado pueden corregir o anular según política
- si el evento ya disparó seguimientos futuros, la corrección debe reflejarse en esos pendientes

## 17. Resultado esperado
Queda un evento sanitario válido asociado al animal o grupo, visible en historial y utilizable para seguimiento.

## 18. Impacto en historial
Debe registrar:
- tipo_evento = vacunacion
- fecha_evento
- fecha_registro
- usuario_registro
- vacuna
- aplicador, si existe
- dosis, si existe
- lote_producto, si existe
- observacion, si existe

## 19. Impacto en estados derivados del animal
No cambia estado activo ni ubicación.
Puede impactar:
- ultimo_evento_sanitario
- alertas o seguimiento futuro, si luego se parametriza
- trazabilidad sanitaria consolidada

## 20. Observaciones de diseño funcional
- conviene manejar vacuna como catálogo controlado
- la modalidad grupo debe priorizar rapidez
- los campos complementarios no deben bloquear fase 2
