# GANADERO SaaS · Mapa de procesos fase 1

## Base documental
Este paquete toma como fuente principal el documento funcional base oficial del producto GANADERO SaaS v3.0 y lo aterriza a especificaciones funcionales detalladas por proceso de fase 1.

## Procesos incluidos
1. Registro de existente
2. Compra
3. Movimiento de potrero
4. Pesaje
5. Venta
6. Muerte
7. Traslado entre fincas

## Objetivo de esta capa
Dejar cada proceso en un nivel suficientemente detallado para servir como insumo de:
- análisis funcional
- definición de reglas transversales
- matriz de eventos e impactos
- modelo funcional de entidades
- modelo lógico de datos posterior

## Estructura homogénea usada en cada proceso
1. objetivo
2. alcance
3. roles que intervienen
4. disparador del proceso
5. precondiciones
6. datos de entrada
7. campos exactos
8. obligatorios y opcionales
9. valores por defecto
10. reglas de validación
11. bloqueos
12. advertencias
13. mensajes funcionales
14. flujo principal paso a paso
15. escenarios alternos
16. correcciones y anulaciones
17. resultado esperado
18. impacto en historial
19. impacto en estados derivados del animal
20. observaciones de diseño funcional

## Criterios aplicados
- No se replantea la fase conceptual general.
- Se toma el documento base como definición oficial.
- Lo ya definido en el documento base se trata como aprobado.
- Se aterrizan reglas finas solo cuando aportan a construcción.
- Se favorecen decisiones simples y sólidas para fase 1.

## Siguiente capa recomendada después de estos documentos
1. Matriz de eventos del animal
2. Matriz de estados derivados
3. Matriz de permisos por rol
4. Matriz de corrección y anulación
5. Matriz de catálogos y parámetros
6. Modelo funcional de entidades
7. Modelo lógico de datos
