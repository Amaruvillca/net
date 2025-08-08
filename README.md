# 🏭 Sistema de Gestión de Almacén - CRUD Productos

## 👨‍💻 Información del Estudiante
**Nombre completo:**  
`Amaru Lino Villca Alanez`  

**Código de estudiante:**  
`17145`  

**Carrera profesional:**  
`Ingeniería de Sistemas`  

**Asignatura:**  
`Taller de Sistemas`  

**Universidad:**  
`Universidad Loyola` 

**Año académico:**  
`2025`  
## 📋 Descripción
Sistema completo para la gestión de inventario con funcionalidades CRUD (Crear, Leer, Actualizar, Eliminar) desarrollado en ASP.NET Core. Permite administrar productos, categorías, almacenes y movimientos de stock con una interfaz intuitiva y moderna.

## ✨ Características Principales
- ✅ Gestión completa de productos con imágenes
- 📦 Administración de categorías y almacenes
- 🔄 Registro de movimientos de stock (entradas/salidas)
- 🚀 Optimizado para .NET 8

## 🛠 Stack Tecnológico

### Backend
| Componente | Versión | Uso |
|------------|---------|-----|
| ![.NET Core](https://img.shields.io/badge/.NET-8.0-blue) | 8.0 | Framework principal |
| ![EF Core](https://img.shields.io/badge/EF%20Core-9.0.8-red) | 9.0.8 | ORM para base de datos |
| ![SQL Server](https://img.shields.io/badge/SQL%20Server-2019+-blue) | 9.0.8 | Sistema de base de datos |

### Frontend
| Tecnología | Uso |
|------------|-----|
| ![Bootstrap](https://img.shields.io/badge/Bootstrap-5.3-purple) | Diseño responsive |
| ![Font Awesome](https://img.shields.io/badge/Font%20Awesome-6.4-orange) | Iconos modernos |
| ![jQuery](https://img.shields.io/badge/jQuery-3.6-blue) | Interacciones JS |

## 📦 Estructura del Proyecto
    CrudProductos/
    ├── Controllers/
    ├── Models/
    ├── Views/
    ├── wwwroot/
    ├── appsettings.Development.json
    ├── appsettings.json
    └── Program.cs


## 🚀 Instalación
1. Clonar repositorio:
   ```bash
   git clone https://github.com/Amaruvillca/net.git

2. Migración de la base de Datos
   ```bash
   dotnet restore

   dotnet ef migrations add Inicial

   dotnet ef database update
3. Iniciar Proyecto
   ```bash
    dotnet run
## Configuracion de la base de datos
1. Nombre 
   ```bash
   AlmacenDb
2. Configuracion de la Conexion appsettings.json
   ```bash
    "ConnectionStrings": {
    "DefaultConnection": "Server=localhost;Database=AlmacenDB;User Id=sa;Password=7068081977574524Amaru@;Encrypt=False;TrustServerCertificate=True;"
    },

  Cambia los datos de la conexion o nombre de la base de datos si es nesesario

  en el archivo appsettings.Development.json copia la misma configuracion