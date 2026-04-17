# Proceso · Destete

## 1. Objetivo
Registrar la separación formal de la cría respecto de la madre, conservando trazabilidad y ajustando la relación operativa cuando corresponda.

## 2. Alcance
Cubre:
- selección de cría o relación madre-cría
- fecha de destete
- cambio de potrero si aplica
- observación
- responsable
- actualización de relación operativa madre-cría
- evento histórico de destete

No cubre:
- nacimiento
- manejo reproductivo completo
- cálculos productivos avanzados

## 3. Roles que intervienen
- dueño titular
- administrador de finca
- veterinario
- operario autorizado si se permite

## 4. Disparador del proceso
Se inicia cuando la cría deja de estar operativamente asociada a la madre en la lógica de destete.

## 5. Precondiciones
- existe finca activa
- existe cría válida
- la cría está activa
- existe relación madre-cría válida cuando sea requerida
- usuario con permiso

## 6. Datos de entrada
- cria_o_relacion
- fecha_destete
- potrero_destino
- observacion
- responsable

## 7. Campos exactos
- cria
- madre_relacionada_mostrada
- fecha_destete
- potrero_destino
- observacion
- responsable
- usuario_registro
- fecha_hora_registro
- tipo_evento = destete

## 8. Obligatorios y opcionales
### Obligatorios
- cria o relación madre-cría
- fecha_destete

### Opcionales
- potrero_destino
- observacion
- responsable

## 9. Valores por defecto
- fecha_destete: hoy
- potrero_destino: vacío
- observacion: vacía
- responsable: vacío

## 10. Reglas de validación
1. Debe existir una cría válida.
2. La cría debe estar activa.
3. Debe existir relación madre-cría cuando la regla lo exija.
4. La fecha de destete es obligatoria.
5. Si se define potrero destino, debe pertenecer a la finca activa.
6. Si el potrero no existe, puede crearse dentro del flujo según política general.
7. El proceso debe cerrar con confirmación final.

## 11. Bloqueos
- no hay cría o relación seleccionada
- no hay fecha de destete
- la cría no existe
- la cría está inactiva
- no existe relación madre-cría válida cuando se requiera
- usuario sin permiso
- potrero inválido

## 12. Advertencias
- el destete se registra sin cambiar potrero
- la fecha es muy antigua
- el caso amerita revisión posterior
- la cría tiene eventos muy recientes que conviene revisar antes de confirmar

## 13. Mensajes funcionales
- Debe seleccionar una cría válida.
- La fecha de destete es obligatoria.
- No existe una relación madre-cría válida para este caso.
- No puede destetar una cría inactiva.
- El potrero seleccionado no es válido.
- No tiene permiso para registrar destete.

## 14. Flujo principal paso a paso
1. Entrar a Registrar.
2. Elegir Destete.
3. Seleccionar cría o relación madre-cría.
4. Validar elegibilidad y relación.
5. Registrar fecha.
6. Definir potrero destino si aplica.
7. Registrar datos opcionales.
8. Mostrar resumen final.
9. Confirmar.
10. Guardar y actualizar relación operativa.

## 15. Escenarios alternos
- si no existe relación válida y la regla la exige, se bloquea
- si hay cambio de ubicación, este queda incorporado dentro del mismo evento
- si el potrero destino no existe, se crea dentro del flujo

## 16. Correcciones y anulaciones
- corrección auditada
- anulación trazable
- no debe romperse el historial de la relación madre-cría
- operario no anula

## 17. Resultado esperado
Queda formalmente registrado el destete y se actualiza la relación operativa asociada.

## 18. Impacto en historial
- tipo_evento = destete
- fecha_evento
- fecha_registro
- usuario_registro
- cría
- madre relacionada
- potrero destino, si aplica
- observación

## 19. Impacto en estados derivados del animal
- actualiza estado operativo de la relación madre-cría
- puede actualizar potrero actual de la cría
- no cambia estado activo

## 20. Observaciones de diseño funcional
- la relación madre-cría debe poder consultarse fácil desde ficha
- el destete no debe diseñarse como simple edición de vínculo
