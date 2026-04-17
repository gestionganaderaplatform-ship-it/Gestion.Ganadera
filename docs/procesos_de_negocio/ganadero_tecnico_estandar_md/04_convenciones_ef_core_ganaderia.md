# Convenciones EF Core para Ganadería

## 1. Clases de entidad
Las clases deben ir en singular, `PascalCase` y sin guion bajo.

Ejemplos:
- `Finca`
- `Potrero`
- `Animal`
- `IdentificadorAnimal`
- `EventoGanadero`
- `EventoGanaderoAnimal`

## 2. Propiedades
Las propiedades deben reflejar directamente el nombre físico de la columna, incluyendo guion bajo.

Ejemplos:
- `Animal_Codigo`
- `Animal_Codigo_Publico`
- `Categoria_Animal_Codigo`
- `Evento_Ganadero_Fecha`
- `Potrero_Nombre`

## 3. Mapeo de tabla y esquema
Cada configuración debe definir explícitamente tabla y esquema.

Ejemplos:
- `ToTable("Animal", "Ganaderia")`
- `ToTable("Evento_Ganadero", "Ganaderia")`
- `ToTable("Categoria_Animal", "Ganaderia")`

## 4. Llave primaria
La PK debe configurarse sobre `<Entidad>_Codigo`.

Ejemplos:
- `HasKey(x => x.Animal_Codigo)`
- `HasKey(x => x.Evento_Ganadero_Codigo)`

Debe usar:
- `ValueGeneratedOnAdd()`

## 5. Llaves foráneas
Las FKs deben llamarse como la entidad referenciada.

Ejemplos:
- `Finca_Codigo`
- `Potrero_Codigo`
- `Categoria_Animal_Codigo`
- `Animal_Codigo`

## 6. DeleteBehavior
Tomando como referencia el proyecto actual, el comportamiento dominante a respetar es:
- `DeleteBehavior.Restrict`

## 7. Defaults SQL
Donde aplique, usar `SYSDATETIME()` para fechas de registro o actividad.

## 8. Índices recomendados
### Animal
- `Cuenta_Codigo`
- `Finca_Codigo`
- `Potrero_Codigo`
- `Categoria_Animal_Codigo`
- `Animal_Esta_Activo`

### Identificador_Animal
- único por `Animal_Codigo + Tipo_Identificador_Codigo`
- búsqueda por `Identificador_Animal_Valor`

### Evento_Ganadero
- `Cuenta_Codigo`
- `Finca_Codigo`
- `Evento_Ganadero_Tipo`
- `Evento_Ganadero_Fecha`
- `Evento_Ganadero_Estado`

### Evento_Ganadero_Animal
- `Animal_Codigo`
- `Evento_Ganadero_Codigo`

## 9. DbSet
Los `DbSet` pueden mantenerse en plural C#.

Ejemplos:
- `DbSet<Animal> Animales`
- `DbSet<Potrero> Potreros`
- `DbSet<EventoGanadero> EventosGanaderos`

## 10. Regla práctica
Para Ganadería conviene que:
- nombre de clase = C# limpio
- nombre de propiedad = nombre real de columna
- nombre de tabla = patrón real del proyecto
- esquema explícito = separación clara por dominio
