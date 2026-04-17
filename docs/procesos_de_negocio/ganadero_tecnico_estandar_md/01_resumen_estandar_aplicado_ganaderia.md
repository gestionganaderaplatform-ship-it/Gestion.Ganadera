# Resumen del estándar aplicado a Ganadería

## Regla general de nombres
Para Ganadería se debe respetar el patrón real observado en el proyecto:

- tabla en singular
- nombre compuesto con guion bajo cuando aplica
- PK `<Entidad>_Codigo`
- `bigint` identidad para PK
- identificador externo adicional `<Entidad>_Codigo_Publico` cuando aporte integración o exposición
- columnas prefijadas por la entidad
- FK `<EntidadReferenciada>_Codigo`
- propiedades EF Core con el mismo nombre final de columna
- `IEntityTypeConfiguration` con `ToTable("Tabla", "Esquema")`

## Qué sí se toma como estándar real
Ejemplos del proyecto:
- `Cliente_Codigo`
- `Sesion_Codigo`
- `Suscripcion_Cliente_Codigo`
- `Cliente_Fecha_Registro`
- `Sesion_Fecha_Inicio`
- `Auditoria_Modificado_Por`

## Qué no se debe forzar como regla absoluta
No se debe asumir como regla totalmente cerrada que todas las tablas lleven exactamente:
- `Fecha_Creado`
- `Fecha_Modificado`
- `Creado_Por`
- `Modificado_Por`

Eso existe como base teórica, pero en el repositorio real la auditoría todavía es mixta.

## Esquema para Ganadería
En el repositorio compartido no aparece aún un esquema real ya consolidado para Ganadería.

### Decisión de trabajo propuesta
Usar esquema:
- `Ganaderia`

### Razón
- mantiene separación por dominio
- es consistente con el uso explícito de esquemas del proyecto
- evita mezclar operación ganadera con `Seguridad`, `Aplicacion` o `Suscripcion`

## Regla funcional que sigue mandando
Aunque los nombres físicos se bajen al estándar real del repositorio, el dominio sigue siendo gobernado por procesos y eventos:
- el animal es identidad estable
- la realidad operativa se deriva de eventos
- historial y trazabilidad son obligatorios
