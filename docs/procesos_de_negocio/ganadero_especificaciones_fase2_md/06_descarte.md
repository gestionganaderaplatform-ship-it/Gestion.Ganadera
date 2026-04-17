# Proceso · Descarte

## 1. Objetivo
Registrar la salida del animal por criterio productivo u operativo distinto de venta o muerte, manteniendo trazabilidad del motivo.

## 2. Alcance
Cubre:
- descarte individual
- motivo de descarte
- fecha
- destino, valor y observación como datos opcionales
- salida del inventario activo
- historial del evento

No cubre:
- venta
- muerte
- traslado entre fincas
- lógica financiera detallada

## 3. Roles que intervienen
- dueño titular
- administrador de finca

## 4. Disparador del proceso
Se inicia cuando se decide retirar un animal de la operación por descarte.

## 5. Precondiciones
- finca activa
- animal existente
- animal activo
- usuario con permiso
- motivo disponible

## 6. Datos de entrada
- animal
- motivo_descarte
- fecha_descarte
- destino
- valor
- observacion

## 7. Campos exactos
- animal
- motivo_descarte
- fecha_descarte
- destino
- valor
- observacion
- usuario_registro
- fecha_hora_registro
- tipo_evento = descarte

## 8. Obligatorios y opcionales
### Obligatorios
- animal
- motivo_descarte
- fecha_descarte

### Opcionales
- destino
- valor
- observacion

## 9. Valores por defecto
- fecha_descarte: hoy
- destino: vacío
- valor: vacío
- observacion: vacía

## 10. Reglas de validación
1. El animal debe existir y estar activo.
2. El motivo de descarte es obligatorio.
3. La fecha es obligatoria.
4. No se permite descartar animales ya vendidos.
5. No se permite descartar animales ya muertos.
6. No se permite descartar animales inactivos.
7. El proceso debe cerrar con confirmación final.
8. El valor, si se registra, debe cumplir formato válido.

## 11. Bloqueos
- no hay animal
- no hay motivo de descarte
- no hay fecha
- animal inexistente
- animal inactivo
- animal ya vendido
- animal ya muerto
- usuario sin permiso

## 12. Advertencias
- se registra descarte sin destino
- se registra descarte con valor económico
- fecha muy antigua
- el caso amerita revisión posterior

## 13. Mensajes funcionales
- Debe registrar un motivo de descarte.
- La fecha de descarte es obligatoria.
- No puede descartar un animal inactivo.
- El animal ya presenta una salida incompatible.
- No tiene permiso para registrar descarte.

## 14. Flujo principal paso a paso
1. Entrar a Registrar.
2. Elegir Descarte.
3. Seleccionar animal.
4. Registrar motivo.
5. Registrar fecha.
6. Registrar datos opcionales.
7. Mostrar resumen final.
8. Confirmar.
9. Guardar y sacar del inventario activo.

## 15. Escenarios alternos
- si el animal ya está inactivo, se bloquea
- si el animal tiene salida incompatible, se bloquea
- si el usuario solo quiere dejar constancia operativa, puede omitir destino, valor y observación

## 16. Correcciones y anulaciones
- corrección auditada
- anulación trazable
- si existen eventos posteriores incompatibles, la anulación debe evaluarse con mayor control
- operario no anula

## 17. Resultado esperado
El animal sale del inventario activo y queda trazado el motivo de descarte.

## 18. Impacto en historial
- tipo_evento = descarte
- fecha_evento
- fecha_registro
- usuario_registro
- motivo
- destino, si existe
- valor, si existe
- observacion, si existe

## 19. Impacto en estados derivados del animal
- condicion_activo = inactivo
- causa_salida = descarte
- bloquea procesos que exigen animal activo

## 20. Observaciones de diseño funcional
- descarte no debe mezclarse con venta ni muerte
- motivo debe ser catálogo controlado
