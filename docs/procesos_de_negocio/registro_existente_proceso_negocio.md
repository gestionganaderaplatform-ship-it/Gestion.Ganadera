# Registro de existente · proceso de negocio

## Proposito

`Registro de existente` permite incorporar al inventario animales que ya estaban en la operacion antes de empezar a usar la plataforma.

No representa un nacimiento, una compra ni un movimiento nuevo. Representa una carga inicial controlada para dejar la finca operando con inventario real desde el primer dia.

## Resultado de negocio esperado

Al terminar el proceso:

- los animales quedan creados en el inventario activo de la finca
- cada animal queda asociado a un potrero inicial
- cada animal queda clasificado por categoria
- cada animal queda con identificacion principal valida
- el historial operativo refleja que el origen del ingreso fue `Registro de existente`

## Cuando aplica

Este proceso aplica cuando el cliente:

- entra por primera vez a la plataforma con animales ya existentes
- necesita cargar un lote historico que nunca habia sido registrado en el sistema
- requiere ordenar inventario inicial por finca y potrero antes de continuar con otros procesos

## Cuando no aplica

No debe usarse para:

- registrar compras nuevas
- registrar nacimientos
- mover animales entre potreros
- trasladar animales entre fincas
- corregir animales ya existentes en el inventario si el caso real es una edicion o ajuste posterior

## Unidad operativa del proceso

La unidad operativa visible del proceso es el `potrero`.

La agrupacion inicial no parte por sexo.
Parte por cantidad y distribucion por potrero, porque esa es la forma natural en que el ganadero entiende la carga inicial del lote.

## Datos de negocio que el proceso debe dejar resueltos

Cada animal registrado debe quedar, como minimo, con:

- finca
- potrero
- categoria animal
- identificador principal
- fecha de ingreso a la finca
- origen del ingreso

## Regla funcional de clasificacion

La clasificacion operativa visible se hace por `categoria`.

El sexo y la banda esperada de edad se derivan desde la categoria y su metadata entregada por backend.

Eso significa:

- el usuario no decide sexo como paso principal del flujo
- el usuario no decide rango de edad como dato principal del flujo
- la categoria concentra la decision operativa visible

## Modalidades del proceso

El proceso trabaja hoy en dos modalidades:

### 1. Uno a uno

Se usa cuando el volumen es pequeno o cuando el usuario necesita revisar animal por animal.

### 2. Por grupos

Se usa cuando el cliente va a cargar varios animales y necesita velocidad.

En esta modalidad primero se define:

- cuantos animales va a registrar
- si van para el mismo potrero o para distintos potreros
- como se reparte cada grupo por categoria

## Identificacion del animal

Los tipos visibles actuales del proceso son:

- `Generacion automatica`
- `Identificador propio`

### Generacion automatica

La generacion automatica:

- usa una marca ganadera del cliente
- toma el siguiente consecutivo de la finca
- forma el identificador visible con `MARCA + consecutivo`

### Identificador propio

Cuando el usuario elige identificador propio:

- escribe el valor manualmente
- no se conserva un valor automatico previo como si fuera dato manual

## Regla de duplicidad

La validacion de duplicidad de identificador debe mantenerse alineada en todos los niveles del sistema.

La regla operativa vigente es:

- se valida por finca
- se valida por valor de identificador

No debe existir una regla distinta entre:

- validator final
- repositorio
- endpoint batch
- prevalidacion de frontend
- documento vivo

## Regla sobre fechas

La fecha clave del proceso es la `fecha en que entro a la finca`.

En `por grupos`, la fecha de nacimiento no se exige como dato comun del lote.
Si luego se necesita precision por animal, ese ajuste pertenece a una etapa posterior y no a esta carga inicial masiva.

## Relacion con catalogos operativos

El proceso depende de catalogos operativos vivos, especialmente:

- potrero
- categoria animal
- marca ganadera

`Potrero` debe poder resolverse dentro del flujo para no obligar al usuario a salir del proceso si detecta que le falta uno.

## Criterios de calidad del proceso

El proceso de negocio debe sentirse:

- rapido
- guiado
- entendible para el ganadero
- seguro en validaciones
- util para cargas grandes

## Riesgos que el proceso debe evitar

- pedir demasiadas decisiones tecnicas en una carga inicial
- mezclar reglas de negocio distintas entre backend y frontend
- dejar pasar identificadores duplicados
- perder trazabilidad del origen del ingreso
- obligar al usuario a salir del flujo por faltantes operativos basicos como potrero

## Relacion con otros procesos

`Registro de existente` es la base para empezar a operar, pero no reemplaza procesos posteriores como:

- compra
- movimiento de potrero
- traslado entre fincas
- nacimiento

Cada uno de esos procesos representa eventos de negocio distintos aunque compartan piezas de captura.
