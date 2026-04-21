# Modelo de experiencia de Registrar

## Proposito
Concentrar en un solo punto la regla funcional sobre `Registrar` como entrada unica, guiada y amigable para los procesos de negocio.

## Regla madre
- `Registrar` es el unico punto formal de ejecucion de procesos.
- No deben existir puntos paralelos de operacion en `Ganado`, `Ficha`, `Inicio` o alertas.

## Que significa en la experiencia
- El usuario entra a un flujo de proceso desde un lugar claro y consistente.
- El sistema debe guiar al usuario segun contexto, no exponerle modulos tecnicos.
- El lenguaje visible debe hablar de procesos y acciones de negocio.
- La experiencia debe ayudar a decidir que proceso usar sin obligar a navegar por tablas o mantenimiento.

## Rol de cada vista
### Inicio
- Muestra contexto, alertas, actividad reciente y accesos rapidos.
- Debe conducir al flujo correcto en `Registrar`.

### Ganado
- Sirve para consultar, ubicar y entender animales.
- Puede conducir a `Registrar` con el contexto del animal o del proceso.
- No debe ejecutar procesos directamente.

### Ficha del animal
- Sirve para consultar estado actual e historial del animal.
- Puede abrir `Registrar` con el animal preseleccionado.
- No debe convertirse en un punto alterno de ejecucion.

### Alertas
- Deben mostrar que requiere atencion.
- Deben conducir al flujo correcto en `Registrar`.

### Registrar
- Organiza procesos por naturaleza de negocio.
- Debe sentirse como un hub guiado y no como una lista de formularios sueltos.
- Debe permitir entrar con contexto previo cuando el usuario venga desde `Inicio`, `Ganado`, `Ficha` o alertas.

## Agrupacion sugerida
- Ingreso de animales
- Movimientos
- Seguimiento
- Transformaciones
- Salidas

## Implicacion para web y app
- La web es el primer canal completo y debe resolver este modelo de experiencia.
- La app llega despues como canal especializado para procesos de alta frecuencia en terreno.
- La existencia futura de app no cambia la regla de `Registrar` como entrada funcional del proceso.

## Conclusion operativa
El sistema debe sentirse guiado por procesos. `Inicio`, `Ganado`, `Ficha` y alertas orientan; `Registrar` ejecuta.
