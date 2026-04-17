# Matriz de catálogos y parámetros

## Objetivo
Consolidar los catálogos y parámetros transversales necesarios para operar los procesos.

## Catálogos base

| Catálogo | Tipo | Alcance | Se usa en | Puede crearse en flujo | Observación |
|---|---|---|---|---|---|
| Tipos de identificador operativo | Catálogo | Cuenta | Ingresos, búsquedas, identidad animal | No normalmente | Debe quedar desde onboarding y configuración |
| Categorías de animal | Catálogo | Cuenta | Registro, compra, nacimiento, cambio de categoría | No normalmente | Base para validaciones |
| Rangos de edad | Catálogo | Cuenta | Registro de existente, compra | No normalmente | Mejor catálogo controlado que texto libre |
| Potreros | Maestro operativo | Finca | Registro, compra, movimiento, traslado, nacimiento, destete | Sí | Alta contextual mínima |
| Fincas | Maestro operativo | Cuenta | Traslado, contexto de operación | No en flujo normal | Nacen en onboarding o administración |
| Causas de muerte | Catálogo | Cuenta | Muerte | Sí, según política futura | Puede admitir genérica o pendiente |
| Motivos de descarte | Catálogo | Cuenta | Descarte | Sí, según política futura | Catálogo de salida operativa |
| Vacunas | Catálogo | Cuenta | Vacunación | Sí, según política | Debe permitir crecimiento futuro |
| Tratamientos / productos | Catálogo | Cuenta | Tratamiento sanitario | Sí, según política | Puede luego diferenciar producto vs tipo |
| Resultados reproductivos | Catálogo | Cuenta | Palpación | Sí, según política | Define la salida del proceso |
| Categorías sugeridas por transición | Regla/catálogo | Cuenta | Cambio de categoría | No libremente | Debe estar controlado por negocio |
| Compradores / destinos | Referencia operativa | Cuenta o finca | Venta | Sí | No necesariamente maestro rígido |
| Origen / vendedor | Referencia operativa | Cuenta o finca | Compra | Sí | Conviene permitir alta contextual |

## Parámetros funcionales

| Parámetro | Alcance | Impacta | Ejemplo |
|---|---|---|---|
| Ventana máxima para registrar fecha anterior | Cuenta | Todos los procesos con fecha | 30 días |
| Permiso por rol para registrar fecha anterior | Cuenta/rol | Todos los procesos con fecha | Dueño 90 días, administrador 30 |
| Tipos de identificador habilitados | Cuenta | Ingresos, búsqueda | Arete, hierro, RFID |
| Reglas de unicidad por identificador | Cuenta | Registro, compra, nacimiento | Unicidad global o por tipo |
| Política de creación contextual de catálogos | Cuenta | Potreros, vacunas, tratamientos, orígenes | Permitido / restringido |
| Umbrales de advertencia para peso | Cuenta | Pesaje | Peso atípico por categoría |
| Incompatibilidades obvias categoría-sexo | Cuenta | Registro, compra, nacimiento, cambio de categoría | Bloqueos fuertes |
| Política de corrección/anulación | Cuenta | Todos | Quién puede, hasta cuándo |
| Requiere justificación en anulación | Cuenta | Todos | Sí / No |
| Manejo de causa genérica o pendiente | Cuenta | Muerte | Permitido / obligatorio catálogo cerrado |

## Observaciones
- Todo lo que sea transversal y reusable debería parametrizarse por cuenta, no por finca, salvo excepción muy justificada.
- Potrero es el mejor ejemplo de maestro operativo con creación contextual.
