# Backlog de Operacion Ganadera - Business API

Este backlog concentra el trabajo del dominio y backend de Ganaderia.
No intenta repetir Auth ni Web. Se usa junto con los otros dos backlogs para cerrar cada proceso end-to-end.

## Forma de trabajo end-to-end

Cada proceso nuevo se trabaja en este orden:

1. cerrar contratos y validaciones del backend
2. exponer endpoints y permisos requeridos
3. conectar frontend con modelos y servicios
4. construir pantalla o flujo visible
5. probar flujo completo con datos reales
6. ajustar documentacion si algo cambio

La regla es simple:
no abrir el siguiente proceso hasta que el actual tenga backend utilizable y frontend conectado.

## Estado actual del backend

### Base transversal
- [x] Catalogos base por cliente
- [x] Consulta de ganado
- [x] Ficha basica del animal
- [x] Historial basico del animal
- [x] Validacion de registro existente
- [x] Registro existente
- [x] Compra
- [ ] Movimiento de potrero

### Ajustes recientes ya cerrados
- [x] Crear identificador interno del sistema en registro existente
- [x] Crear identificador interno del sistema en compra
- [x] Validar compatibilidad categoria y sexo
- [x] Restringir un solo identificador principal activo por animal

## Procesos Fase 1

### Proceso 1. Registro de existente
- [x] Endpoint de validacion
- [x] Endpoint de registro
- [x] Persistencia atomica de animal, identificadores, evento y detalle
- [x] Actualizacion de snapshot del animal
- [x] Impacto en historial
- [ ] Validacion manual completa con payload real

### Proceso 2. Compra
- [x] Endpoint de validacion
- [x] Endpoint de registro
- [x] Persistencia atomica de animal, identificadores, evento y detalle
- [x] Actualizacion de snapshot del animal
- [x] Impacto en historial
- [ ] Validacion manual completa con payload real

### Proceso 3. Movimiento de potrero
- [ ] Definir request y response
- [ ] Crear validador
- [ ] Crear detalle del proceso
- [ ] Implementar transaccion
- [ ] Actualizar snapshot del animal
- [ ] Impactar historial

## Siguiente bloque recomendado

1. Probar de punta a punta registro existente y compra con payload real
2. Cerrar movimiento de potrero en backend
3. Acompanhar al frontend para que el primer flujo quede operativo completo
