# Gestión de Oficinas

Un sistema web desarrollado con .NET 8 y Blazor, diseñado para gestionar oficinas de atención en diferentes departamentos del país. Este proyecto ofrece funcionalidades en tiempo real gracias a SignalR, con una interfaz interactiva y gráficos dinámicos utilizando ChartJs.Blazor

## Características

### Registro de Usuarios
- Permite registrar nuevos usuarios en el sistema para registrar atenciones de un tramite.

### Monitor de Atenciones en Tiempo Real
- Visualiza el estado actual de las atenciones en todas las oficinas.
- Actualización automática mediante SignalR.

### Gestión de Calidad
- Página con métricas clave sobre el desempeño de las oficinas:
  - Clientes en espera.
  - Tiempo promedio de espera y finalización de trámites.
- Gráficos dinámicos que muestran:
  - Atenciones por tipo de trámite.
  - Actividad según el día de la semana.
  - Actividad mensual.
- Toda la información se actualiza automáticamente en tiempo real.

### Página del Operario
- Herramientas para gestionar atenciones:
  - Llamar clientes.
  - Atender solicitudes.
  - Finalizar trámites.
- Sincronización en tiempo real con el monitor y la página de gestión de calidad.

### Tecnología en Tiempo Real
- SignalR para garantizar actualizaciones automáticas y comunicación en tiempo real entre las páginas del sistema.

### Gráficas Interactivas
- ChartJs.Blazor para representar datos de manera visual e intuitiva.

### Deploy
El proyecto está disponible en [Azure](https://tallergestion.azurewebsites.net).

## Tecnologías Utilizadas
- **Framework**: .NET 8 con Blazor.
- **Comunicación en Tiempo Real**: SignalR.
- **Gráficos**: ChartJs.
- **Hosting**: Azure App Services.
