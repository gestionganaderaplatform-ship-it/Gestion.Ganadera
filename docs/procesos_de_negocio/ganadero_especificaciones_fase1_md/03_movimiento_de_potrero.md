# GANADERO SaaS · Proceso 03 · Movimiento de potrero

## 1. Objetivo
Registrar el cambio de ubicación de uno o varios animales dentro de la misma finca.

## 2. Alcance
Incluye movimiento individual o grupal, selección por origen, creación contextual de potrero destino y actualización del potrero actual del animal.

## 3. Roles que intervienen
- Dueño titular
- Administrador de finca
- Operario autorizado

## 4. Disparador del proceso
Se usa cuando uno o varios animales pasan de un potrero a otro dentro de la finca activa.

## 5. Precondiciones
- Existe finca activa.
- Los animales existen y están activos.
- Hay permiso para ejecutar el proceso.

## 6. Datos de entrada
- Modalidad
- Animal o grupo
- Potrero origen inferido o usado como base de selección
- Potrero destino
- Fecha del movimiento
- Observación opcional

## 7. Campos exactos
- modalidad_movimiento
- criterio_seleccion_grupo
- animales_seleccionados
- potrero_origen_mostrado
- potrero_destino
- fecha_movimiento
- observacion
- usuario_registro
- fecha_registro

## 8. Obligatorios y opcionales
### Obligatorios
- modalidad_movimiento
- al menos un animal seleccionado
- potrero_destino
- fecha_movimiento

### Opcionales
- observacion
- criterio de exclusión cuando el movimiento es grupal

## 9. Valores por defecto
- fecha_movimiento = hoy
- fecha_registro = automática
- potrero_origen = tomado del estado actual

## 10. Reglas de validación
- No se permite mover animales inactivos.
- El potrero origen en modalidad individual no se captura manualmente.
- En grupo, el origen puede servir como base de selección.
- El destino no puede ser igual al potrero actual.
- Si el potrero destino no existe, puede crearse con solo nombre.
- Todos los animales seleccionados reciben el evento cuando se confirma.
- Si un animal del grupo está inactivo, el movimiento debe bloquearse hasta excluirlo.

## 11. Bloqueos
- No hay finca activa.
- No hay animal ni grupo seleccionado.
- No hay potrero destino.
- No hay fecha.
- El destino es igual al potrero actual.
- El animal está inactivo.
- Algún animal del grupo está inactivo.
- El destino no existe y no se permite crearlo.

## 12. Advertencias
- El movimiento involucra un grupo muy grande.
- Se están excluyendo pocos animales de un grupo casi completo.
- La fecha del movimiento es muy antigua según política.

## 13. Mensajes funcionales
- Debe seleccionar un potrero destino.
- Debe seleccionar al menos un animal.
- No puede mover un animal inactivo.
- El potrero destino no puede ser el mismo actual.
- No hay una finca activa para registrar.
- Movimiento registrado correctamente.

## 14. Flujo principal paso a paso
1. El usuario entra a Registrar.
2. Selecciona Movimiento de potrero.
3. Elige modalidad individual o grupo.
4. Selecciona animal o base de selección grupal.
5. El sistema muestra origen.
6. El usuario define potrero destino.
7. Registra fecha.
8. El sistema muestra resumen final.
9. El usuario confirma.
10. El sistema registra el evento.
11. El sistema actualiza el potrero actual.

## 15. Escenarios alternos
- Si el destino no existe, se crea dentro del flujo.
- Si el usuario quiere mover casi todos los animales de un potrero, usa selección grupal con exclusiones.
- Si el destino es igual al origen, se impide confirmar.

## 16. Correcciones y anulaciones
- Se corrige o anula según rol y política.
- Debe quedar trazabilidad del origen, destino y justificación.
- Si existen movimientos posteriores, la anulación debe controlarse con cuidado.

## 17. Resultado esperado
La ubicación actual del animal cambia y queda historial del movimiento.

## 18. Impacto en historial
Genera evento de movimiento con origen, destino, fecha del evento, fecha de registro y usuario.

## 19. Impacto en estados derivados del animal
- potrero_actual = potrero destino
- finca_actual = sin cambio
- condicion_activo = sin cambio

## 20. Observaciones de diseño funcional
- El proceso debe ser muy ágil en modalidad grupo.
- Conviene soportar filtros rápidos por potrero origen.
- No debe permitirse edición manual del potrero actual por fuera de este proceso.
