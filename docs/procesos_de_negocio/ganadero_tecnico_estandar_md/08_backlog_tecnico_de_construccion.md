# Backlog técnico de construcción

## Secuencia recomendada global

### Etapa 1. Base de datos y dominio
1. definir entidades EF Core base del esquema `Ganaderia`
2. definir catálogos y parámetros
3. definir snapshot del animal
4. definir tronco de eventos y detalle por tipo
5. definir migraciones iniciales

### Etapa 2. Backend de consulta
6. contexto operativo
7. inventario de ganado
8. ficha del animal
9. historial base

### Etapa 3. Backend de procesos fase 1
10. registro de existente
11. compra
12. pesaje
13. movimiento de potrero
14. venta
15. muerte
16. traslado entre fincas

### Etapa 4. Frontend de consulta
17. selector de finca activa
18. inicio ganadero
19. ganado
20. ficha del animal
21. historial base

### Etapa 5. Frontend de procesos fase 1
22. registrar shell
23. flujo registro de existente
24. flujo compra
25. flujo pesaje
26. flujo movimiento de potrero
27. flujo venta
28. flujo muerte
29. flujo traslado entre fincas

### Etapa 6. Fase 2
30. vacunación
31. tratamiento sanitario
32. palpación
33. destete
34. cambio de categoría
35. descarte
36. nacimiento

### Etapa 7. Fortalecimiento transversal
37. corrección y anulación
38. reportes base
39. importaciones masivas
40. optimización y endurecimiento de validaciones
41. auditoría funcional visible
42. pruebas y soporte productivo

## Prioridad alta inmediata
- `Finca`
- `Potrero`
- `Animal`
- `Identificador_Animal`
- `Evento_Ganadero`
- `Evento_Ganadero_Animal`
- detalles de fase 1
- ganado
- ficha animal
- historial

## Dependencias críticas
- no construir procesos sin tronco de eventos
- no construir ficha animal sin snapshot actual confiable
- no construir historial sin convención de evento
- no construir frontend registrar sin contratos de validación claros
- no construir reportes sin definición estable de estados derivados

## Riesgos a controlar
- volver a CRUDs de animal
- duplicar puntos de ejecución fuera de registrar
- mezclar Auth con negocio
- no modelar bien `Evento_Ganadero`
- subestimar corrección/anulación
- dejar historial para el final

## Recomendación práctica
Para construir rápido sin perder orden:
1. tronco de datos y eventos
2. consulta de inventario y ficha
3. procesos fase 1
4. historial
5. correcciones
6. fase 2
