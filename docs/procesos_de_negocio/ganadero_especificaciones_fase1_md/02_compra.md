# GANADERO SaaS · Proceso 02 · Compra

## 1. Objetivo
Registrar el ingreso de animales adquiridos a terceros, dejándolos activos, ubicados y asociados a un evento de compra trazable.

## 2. Alcance
Incluye compra individual, compra por lote, carga masiva cuando aplique, creación contextual de potrero destino y asociación del ingreso a origen o vendedor.

## 3. Roles que intervienen
- Dueño titular
- Administrador de finca

## 4. Disparador del proceso
Se usa cuando uno o varios animales entran a la operación como consecuencia de una compra.

## 5. Precondiciones
- Existe finca activa.
- Existen identificadores habilitados.
- El usuario tiene permiso.

## 6. Datos de entrada
- Modalidad
- Origen o vendedor
- Fecha de compra
- Animales
- Potrero destino
- Valor económico opcional
- Confirmación final

## 7. Campos exactos
### Encabezado
- modalidad_registro
- origen_o_vendedor
- fecha_compra
- valor_total_opcional
- observacion_compra

### Por animal
- identificador_principal_tipo
- identificador_principal_valor
- identificadores_adicionales
- sexo
- categoria
- rango_edad
- potrero_destino
- valor_individual_opcional
- observacion_individual

### Campos de sistema
- finca_actual
- fecha_registro
- usuario_registro
- origen_ingreso
- estado_activo_resultante
- lote_compra_generado_si_aplica

## 8. Obligatorios y opcionales
### Obligatorios
- origen_o_vendedor
- fecha_compra
- identificador_principal_tipo
- identificador_principal_valor
- sexo
- categoria
- rango_edad
- potrero_destino

### Opcionales
- valor_total_opcional
- valor_individual_opcional
- identificadores_adicionales
- observacion_compra
- observacion_individual

## 9. Valores por defecto
- finca_actual = finca activa
- fecha_compra = hoy
- fecha_registro = automática
- origen_ingreso = compra
- estado_activo_resultante = activo

## 10. Reglas de validación
- Debe existir finca activa.
- Origen o vendedor es obligatorio.
- Fecha de compra obligatoria.
- Debe existir al menos un identificador operativo por animal.
- No se permite identificador duplicado.
- Se permite un identificador principal y adicionales opcionales, uno por tipo.
- Sexo, categoría, rango de edad y potrero destino son obligatorios.
- El animal no puede crearse sin potrero destino dentro de la finca activa.
- Si el potrero destino no existe, puede crearse dentro del flujo con solo nombre.
- En compra por lote, se permiten datos comunes y ajustes por animal.
- En carga masiva, cada fila se valida por separado.
- El valor económico es opcional y no bloquea el proceso.
- Si la compra es por lote, el sistema crea o asocia un lote de compra/origen.

## 11. Bloqueos
- No hay finca activa.
- No hay origen o vendedor.
- No hay fecha de compra.
- Identificador vacío o duplicado.
- Sexo vacío.
- Categoría vacía.
- Rango de edad vacío.
- Potrero destino vacío.
- Potrero destino inválido.
- Usuario sin permiso.

## 12. Advertencias
- Categoría y sexo no parecen coherentes.
- El rango de edad luce atípico para la categoría.
- El valor económico luce atípico.
- El lote contiene animales con diferencias relevantes.

## 13. Mensajes funcionales
- Debe registrar el origen o vendedor.
- La fecha de compra es obligatoria.
- Debe seleccionar un potrero destino.
- El identificador ya existe.
- El archivo tiene filas con error. Puede continuar con las válidas y corregir las demás.
- Compra registrada correctamente.

## 14. Flujo principal paso a paso
1. El usuario entra a Registrar.
2. Selecciona Compra.
3. El sistema valida contexto y permisos.
4. El usuario elige individual o lote.
5. Registra origen o vendedor.
6. Registra fecha de compra.
7. Captura animales.
8. Define potrero destino.
9. Registra valor económico si aplica.
10. El sistema muestra resumen final.
11. El usuario confirma.
12. El sistema crea los animales y el evento de compra.
13. El sistema deja los animales activos y visibles.

## 15. Escenarios alternos
- Si todos comparten origen y fecha, se usan datos comunes del lote.
- Si algunos datos cambian, se ajustan por animal.
- Si la carga masiva tiene errores parciales, se guardan válidos y se reportan errados.
- Si no existe potrero destino, se crea dentro del flujo.

## 16. Correcciones y anulaciones
- Se permiten según rol y política.
- La corrección no elimina el evento original.
- La anulación del evento debe restringirse si ya existen eventos posteriores sobre los animales.

## 17. Resultado esperado
Los animales quedan activos, ubicados y asociados a un evento de compra trazable.

## 18. Impacto en historial
Genera evento de compra con:
- fecha_compra
- fecha_registro
- usuario_registro
- origen_o_vendedor
- potrero_destino
- valor económico, si aplica
- lote de compra, si aplica

## 19. Impacto en estados derivados del animal
- condicion_activo = activo
- finca_actual = finca activa
- potrero_actual = potrero destino
- categoria_actual = categoría registrada
- origen_ingreso = compra
- lote_actual = lote de compra/origen, si aplica

## 20. Observaciones de diseño funcional
- El valor económico debe mantenerse opcional en fase 1.
- Conviene separar valor total y valor por animal cuando la compra sea por lote.
- El evento de compra debe conservar siempre trazabilidad del origen o vendedor.
