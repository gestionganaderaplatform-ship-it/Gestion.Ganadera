# Compra - proceso de negocio

## Propósito

`Compra` permite registrar el ingreso de uno o varios animales adquiridos a un tercero.

No representa una carga inicial, un nacimiento ni un movimiento interno. Representa un evento nuevo de ingreso con trazabilidad comercial y operativa.

## Resultado de negocio esperado

Al terminar el proceso:

- el animal queda creado en el inventario activo de la finca
- el animal queda asociado a un potrero destino
- el animal queda clasificado por categoría
- el animal queda con identificación principal válida
- el historial operativo refleja que el origen del ingreso fue `Compra`
- el evento conserva fecha y referencia del origen o vendedor

Cuando la compra contiene varios animales, el registro debe guardarse de forma atómica: si falla un animal, no debe quedar una compra parcial.

## Cuándo aplica

Este proceso aplica cuando el cliente:

- compra animales y necesita dejarlos activos en su inventario
- requiere trazar de dónde vino el animal y en qué fecha ingresó
- necesita separar este ingreso de otros orígenes como nacimiento o carga inicial

## Cuándo no aplica

No debe usarse para:

- cargar animales que ya estaban en la finca antes de usar la plataforma
- registrar nacimientos
- mover animales entre potreros
- trasladar animales entre fincas
- corregir animales ya existentes si el caso real es una edición posterior

## Diferencia frente a Registro de existente

`Registro de existente` resuelve una base inicial del inventario.

`Compra` registra un evento nuevo de ingreso que sí ocurrió durante la operación y por eso exige contexto del origen o vendedor y fecha de compra.

## Unidad operativa visible

La unidad operativa visible sigue siendo el `potrero` destino dentro de la finca activa.

La compra no pide sexo como decisión visible principal. La clasificación visible se concentra en la `categoría`.

## Datos mínimos que el proceso debe dejar resueltos

Cada compra debe dejar, como mínimo:

- finca
- fecha de compra
- origen o vendedor
- potrero destino por animal
- categoría animal por animal
- identificador principal por animal
- origen del ingreso

Si la compra incluye valor comercial, el usuario puede informar un valor total de compra. Cuando no se detalla valor por animal, el backend calcula el valor individual promedio y lo conserva en el detalle de cada animal.

Si una compra tiene animales con valores distintos, el proceso debe permitir informar el valor individual por animal. En ese caso, la suma de los valores individuales debe coincidir con el valor total informado.

## Regla funcional de clasificación

La categoría sigue siendo el dato visible principal.

Sexo y rango de edad esperado se derivan desde la metadata de la categoría entregada por backend.

Eso significa:

- el usuario no decide sexo como paso principal
- el usuario no decide rango de edad como dato principal
- la categoría concentra la clasificación operativa visible

## Alcance actual del proceso

El backend soporta compra individual y compra por lote.

La compra por lote usa un contexto común de fecha, origen o vendedor, observación y valor total opcional. Cada animal conserva su propio potrero destino, categoría, rango, tipo de identificador, identificador principal y valor individual cuando aplique.

La operación por lote se registra con los eventos y detalles existentes del dominio. Actualmente no existe una tabla de encabezado comercial independiente para la compra; la unidad transaccional es el lote guardado de forma atómica.

## Identificación del animal

La compra debe usar la misma lógica de generación automática usada por `Registro de existente`: marca ganadera del cliente y siguiente consecutivo por finca.

La regla de duplicidad del identificador debe mantenerse alineada entre:

- documento vivo
- validator final
- repositorio
- prevalidación de frontend

En lote, no deben repetirse identificadores dentro de la misma compra y tampoco deben existir previamente como identificadores activos de la finca.

## Regla sobre fechas

La fecha clave del proceso es la `fecha de compra`.

Debe validarse por día calendario y no por desfase horario entre cliente, serialización y backend.

## Relación con catálogos operativos

El proceso depende de catálogos operativos vivos, especialmente:

- potrero
- categoría animal
- tipo de identificador

`Potrero` debe poder resolverse dentro del flujo para no obligar al usuario a salir del proceso si detecta que le falta uno.

## Riesgos que el proceso debe evitar

- tratar una compra como si fuera una carga inicial
- pedir decisiones técnicas que ya pueden derivarse por categoría
- dejar pasar identificadores duplicados
- guardar compras parciales cuando falla un animal del lote
- romper la trazabilidad del origen comercial del ingreso
- calcular valores individuales en frontend con una regla distinta a backend

## Relación con otros procesos

`Compra` comparte piezas de captura con otros procesos, pero representa un evento de negocio distinto a:

- registro de existente
- nacimiento
- movimiento de potrero
- traslado entre fincas

La reutilización de componentes no debe borrar esa diferencia funcional.
