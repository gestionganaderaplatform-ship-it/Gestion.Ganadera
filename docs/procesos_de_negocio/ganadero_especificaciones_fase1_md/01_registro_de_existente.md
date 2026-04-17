# GANADERO SaaS · Proceso 01 · Registro de existente

## 1. Objetivo
Registrar animales que ya existían físicamente en la operación antes de empezar a usar el sistema, dejándolos activos, ubicados y trazables desde su incorporación a la plataforma.

## 2. Alcance
Incluye registro individual, registro por lote secuencial, carga masiva cuando aplique, creación contextual de potrero, creación del animal como activo y generación del evento histórico de ingreso por registro de existente.

No incluye compra, nacimiento, salidas del inventario ni edición manual posterior por fuera de proceso.

## 3. Roles que intervienen
- Dueño titular
- Administrador de finca

## 4. Disparador del proceso
Se usa cuando el cliente inicia operación en la plataforma o cuando detecta animales existentes en la finca que todavía no han sido incorporados al sistema.

## 5. Precondiciones
- Existe finca activa.
- Existe al menos una forma de identificación operativa habilitada.
- El usuario tiene permiso para registrar animales existentes.
- Existe al menos un potrero disponible o se permite crearlo en el flujo.

## 6. Datos de entrada
- Modalidad de registro
- Tipo de captura
- Identificación del animal
- Datos biológicos mínimos
- Ubicación actual
- Datos opcionales de contexto
- Confirmación final

## 7. Campos exactos
### Encabezado del proceso
- modalidad_registro
- tipo_carga
- finca_activa_mostrada
- fecha_evento_opcional

### Por animal
- identificador_principal_tipo
- identificador_principal_valor
- identificadores_adicionales
- sexo
- categoria
- rango_edad
- potrero_actual
- observacion_registro

### Campos de sistema no editables
- finca_actual
- fecha_registro
- usuario_registro
- estado_activo_resultante
- origen_ingreso

## 8. Obligatorios y opcionales
### Obligatorios
- modalidad_registro
- identificador_principal_tipo
- identificador_principal_valor
- sexo
- categoria
- rango_edad
- potrero_actual

### Opcionales
- fecha_evento_opcional
- identificadores_adicionales
- observacion_registro

## 9. Valores por defecto
- finca_actual = finca activa de la sesión
- fecha_registro = automática
- fecha_evento_opcional = vacía
- estado_activo_resultante = activo
- origen_ingreso = registro de existente

## 10. Reglas de validación
- Debe existir finca activa.
- Debe existir al menos un identificador operativo por animal.
- El identificador principal no puede venir vacío.
- El identificador principal debe cumplir el formato del tipo configurado.
- No se permite duplicidad según la regla activa de la cuenta.
- Solo se permite un identificador por tipo para un mismo animal.
- Sexo es obligatorio.
- Categoría es obligatoria y debe ser una categoría real, no temporal.
- Rango de edad es obligatorio.
- Potrero actual es obligatorio.
- El potrero debe pertenecer a la finca activa.
- Si el potrero no existe, puede crearse dentro del flujo con solo nombre.
- El sistema puede sugerir sexo según categoría.
- Si la categoría sugiere sexo y el usuario selecciona otro, el sistema advierte y solo bloquea incompatibilidades obvias definidas por catálogo.
- En lote, los datos comunes se heredan, pero cada animal puede ajustarlos antes de guardar.
- En carga masiva, cada fila se valida de forma independiente.
- El proceso siempre exige confirmación final antes de guardar.

## 11. Bloqueos
- No hay finca activa.
- No hay permiso para ejecutar el proceso.
- Identificador principal vacío.
- Identificador duplicado.
- Sexo vacío.
- Categoría vacía.
- Rango de edad vacío.
- Potrero vacío.
- Potrero inválido para la finca activa.
- Archivo de carga masiva con estructura inválida.
- Fila con dato obligatorio faltante.
- Fila con identificador repetido en archivo.
- Fila con identificador ya existente en el sistema.

## 12. Advertencias
- Categoría y sexo no parecen coherentes.
- El rango de edad luce atípico para la categoría.
- En lote, los datos comunes no parecen aplicar a todos los animales.
- La carga masiva tiene filas válidas y filas erradas.

## 13. Mensajes funcionales
### Errores
- No hay una finca activa para registrar.
- Debe seleccionar un tipo de identificación principal.
- Debe ingresar un identificador.
- El identificador ya existe.
- Debe seleccionar el sexo.
- Debe seleccionar la categoría.
- Debe seleccionar el rango de edad.
- Debe seleccionar un potrero.
- El potrero no pertenece a la finca activa.
- No tiene permiso para registrar animales existentes.
- El archivo no tiene una estructura válida.

### Advertencias
- La categoría y el sexo no parecen coherentes. Revise antes de continuar.
- El rango de edad luce atípico para la categoría seleccionada.
- Se encontraron filas con error. Puede continuar con las válidas y corregir las demás.

### Éxito
- Animal registrado correctamente.
- Se registraron {n} animales correctamente.
- {n} registros fueron guardados y {m} quedaron pendientes de corrección.

## 14. Flujo principal paso a paso
1. El usuario entra a Registrar.
2. Selecciona Registro de existente.
3. El sistema valida finca activa y permisos.
4. El usuario elige modalidad: individual o lote.
5. Si elige lote, define si será secuencial o carga masiva.
6. Captura o carga la información requerida.
7. El sistema valida.
8. El sistema muestra resumen final.
9. El usuario confirma.
10. El sistema crea el o los animales.
11. El sistema deja los animales activos en la finca activa y potrero indicado.
12. El sistema registra el evento histórico de ingreso por registro de existente.
13. El sistema muestra confirmación de éxito.

## 15. Escenarios alternos
- Si no existe potrero, se crea dentro del flujo sin perder lo capturado.
- Si el identificador ya existe, ese animal no puede confirmarse hasta corregirlo.
- Si la carga masiva tiene errores parciales, se separan válidos y errados.
- Si se registra fecha del evento, se conserva aparte de la fecha de registro.

## 16. Correcciones y anulaciones
- Se puede corregir según rol y política de cuenta.
- La corrección no borra el evento original.
- Debe quedar trazado qué cambió, cuándo y quién lo corrigió.
- La anulación del evento solo debería permitirse si el animal no tiene eventos posteriores.

## 17. Resultado esperado
El animal queda creado, activo, asociado a la finca activa, ubicado en un potrero actual, visible en Ganado y trazado en Historial como ingreso por registro de existente.

## 18. Impacto en historial
Genera un evento con:
- tipo_evento = registro de existente
- fecha_evento, si fue informada
- fecha_registro
- usuario_registro
- finca
- potrero inicial
- modalidad del proceso

## 19. Impacto en estados derivados del animal
- condicion_activo = activo
- finca_actual = finca activa
- potrero_actual = potrero registrado
- categoria_actual = categoría registrada
- sexo = sexo registrado
- rango_edad_actual = rango registrado
- origen_ingreso = registro de existente

## 20. Observaciones de diseño funcional
- Rango de edad debe manejarse como catálogo controlado.
- Los identificadores adicionales deben mantenerse opcionales en fase 1.
- La anulación del registro inicial debe tratarse con cuidado para no romper trazabilidad posterior.
