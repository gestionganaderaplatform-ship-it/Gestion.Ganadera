# Proceso · Cambio de categoría

## 1. Objetivo
Registrar el cambio formal de categoría del animal como evento de negocio controlado y trazable.

## 2. Alcance
Cubre:
- identificación del animal
- visualización de categoría actual
- sugerencia de nueva categoría
- confirmación del usuario autorizado
- fecha del cambio
- observación y responsable
- actualización de categoría actual
- historial del cambio

No cubre:
- edición libre de categoría
- reclasificaciones masivas complejas no aprobadas
- automatización total del cambio por reglas avanzadas

## 3. Roles que intervienen
- dueño titular
- administrador de finca
- operario no debería ejecutar este proceso salvo autorización expresa
- veterinario solo si la operación lo requiere

## 4. Disparador del proceso
Se inicia cuando un animal debe cambiar de categoría según su evolución operativa y el cambio debe formalizarse en el sistema.

## 5. Precondiciones
- finca activa
- animal existente y activo
- usuario con permiso
- nueva categoría válida y compatible

## 6. Datos de entrada
- animal
- categoria_actual_mostrada
- nueva_categoria_sugerida
- nueva_categoria_confirmada
- fecha_cambio
- observacion
- responsable

## 7. Campos exactos
- animal
- categoria_actual
- nueva_categoria_sugerida
- nueva_categoria_confirmada
- fecha_cambio
- observacion
- responsable
- usuario_registro
- fecha_hora_registro
- tipo_evento = cambio_categoria

## 8. Obligatorios y opcionales
### Obligatorios
- animal
- nueva_categoria_confirmada
- fecha_cambio

### Opcionales
- observacion
- responsable

## 9. Valores por defecto
- fecha_cambio: hoy
- observacion: vacía
- responsable: vacío

## 10. Reglas de validación
1. El animal debe existir y estar activo.
2. La nueva categoría debe ser compatible con el animal.
3. No se permite aplicar la misma categoría actual como nueva categoría.
4. La fecha es obligatoria.
5. La nueva categoría debe confirmarse explícitamente.
6. El proceso debe cerrar con confirmación final.
7. La categoría actual solo cambia por este proceso o equivalente aprobado.

## 11. Bloqueos
- no hay animal
- no hay nueva categoría
- la nueva categoría es igual a la actual
- no hay fecha
- animal inexistente
- animal inactivo
- categoría incompatible
- usuario sin permiso

## 12. Advertencias
- la sugerencia se basa en información parcial
- la fecha es muy antigua
- el cambio se registra sin observación
- el caso podría requerir revisión posterior

## 13. Mensajes funcionales
- Debe seleccionar una nueva categoría.
- La fecha del cambio es obligatoria.
- La categoría nueva no puede ser igual a la actual.
- La categoría seleccionada no es compatible con este animal.
- No puede cambiar la categoría de un animal inactivo.
- No tiene permiso para registrar cambio de categoría.

## 14. Flujo principal paso a paso
1. Entrar a Registrar.
2. Elegir Cambio de categoría.
3. Seleccionar animal.
4. Mostrar categoría actual y sugerencia.
5. Confirmar nueva categoría.
6. Registrar fecha.
7. Registrar observación o responsable si aplica.
8. Mostrar resumen final.
9. Confirmar.
10. Guardar y actualizar categoría actual.

## 15. Escenarios alternos
- si la sugerencia no aplica, el usuario autorizado selecciona otra válida
- si la categoría es incompatible, se bloquea
- si el animal está inactivo, se bloquea

## 16. Correcciones y anulaciones
- corrección auditada
- anulación con trazabilidad
- no debe permitirse anular si existen eventos posteriores que dependan críticamente de la categoría sin evaluación de impacto
- operario no anula

## 17. Resultado esperado
El animal queda con nueva categoría actual y con historial trazable del cambio.

## 18. Impacto en historial
- tipo_evento = cambio_categoria
- fecha_evento
- fecha_registro
- usuario_registro
- categoria_anterior
- categoria_nueva
- observacion

## 19. Impacto en estados derivados del animal
- actualiza categoria_actual
- puede afectar elegibilidad en otros procesos
- no cambia estado activo ni ubicación

## 20. Observaciones de diseño funcional
- la compatibilidad categoría-sexo debe centralizarse por catálogo
- la sugerencia del sistema no reemplaza la confirmación del usuario autorizado
