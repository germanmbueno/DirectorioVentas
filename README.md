# Directorio de Personas - WPF Client

Proyecto que demuestra análisis, diseño y desarrollo de un cliente WPF integrado con un API REST.

## Tecnologías y herramientas

- Backend: .NET 6, Repository Design Pattern
- Frontend: WPF (Windows Presentation Framework)
- Base de datos embebida: SQLite
- Postman para pruebas de la API

## Estructura del proyecto

- **DirectorioRestService**: Servicio REST que expone la API
- **Directorio**: Servicio de negocio para gestión de personas
- **Ventas**: Servicio de negocio para gestión de facturación
- **Persona / Factura**: Clases de dominio
- **PersonaRepository / FacturaRepository**: Repositorios que manejan la persistencia de datos usando SQLite embebida

## Funcionalidades

- Registrar personas con todos los atributos obligatorios (excepto apellido materno)
- Validación de campos obligatorios (nombre, apellido paterno, identificación)
- Crear y listar facturas asociadas a una persona
- Integración completa entre cliente WPF y API REST

## Cómo ejecutar

1. Clonar el repositorio
2. Abrir la solución en Visual Studio
3. Ejecutar primero la API (DirectorioRestService)
4. Ejecutar la aplicación WPF (Cliente)
5. Usar la aplicación para crear y listar personas.

Nota: La base de datos SQLite es embebida y no requiere configuración adicional.