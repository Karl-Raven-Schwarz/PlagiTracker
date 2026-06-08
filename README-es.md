# PlagiTracker

Una plataforma web de detección de plagio para la enseñanza de ingeniería de software, similar a Google Classroom pero enfocada en el análisis de plagio de código.

## Tabla de Contenidos

- [Descripción General](#descripción-general)
- [Características](#características)
- [Arquitectura](#arquitectura)
- [Tecnologías](#tecnologías)
- [Prerrequisitos](#prerrequisitos)
- [Instalación](#instalación)
- [Configuración](#configuración)
- [Endpoints de la API](#endpoints-de-la-api)
- [Plataformas Soportadas](#plataformas-soportadas)
- [Base de Datos](#base-de-datos)
- [Contribuir](#contribuir)
- [Licencia](#licencia)

## Descripción General

PlagiTracker es una plataforma integral diseñada para cursos de ingeniería de software que permite a los profesores crear cursos, tareas y detectar automáticamente el plagio en las entregas de los estudiantes. El sistema realiza web scraping en editores de código en línea soportados para extraer el código fuente y aplica algoritmos de detección de plagio.

### Capacidades Principales

- **Gestión de Cursos**: Los profesores pueden crear, archivar y gestionar cursos con enlaces de invitación
- **Sistema de Tareas**: Crear tareas con fechas límite y seguimiento automático de entregas
- **Entrega de Código**: Los estudiantes envían código a través de editores en línea soportados (Codiva, OnlineGDB)
- **Detección de Plagio**: Análisis automatizado usando múltiples métodos (analizador personalizado + Dolos)
- **Web Scraping**: Extracción automática de código desde IDEs en línea usando Selenium
- **Generación de Reportes PDF**: Generar reportes detallados de plagio
- **Notificaciones por Email**: Notificaciones automáticas para entregas y resultados de análisis
- **Acceso Basado en Roles**: Dashboards separados para profesores y estudiantes

## Características

### Para Profesores
- Crear y gestionar cursos
- Generar enlaces de invitación para inscripción de estudiantes
- Crear tareas con fechas límite
- Analizar entregas para detectar plagio
- Generar reportes PDF de plagio
- Integración con Dolos para análisis avanzado
- Archivar/desarchivar cursos
- Calificar entregas

### Para Estudiantes
- Unirse a cursos mediante enlaces de invitación
- Ver tareas y fechas límite
- Entregar código a través de editores en línea soportados
- Historial de entregas
- Ver calificaciones

### Detección de Plagio
- **Analizador Personalizado**: Detección de plagio basada en Python usando web scraping
- **Integración con Dolos**: Detección de plagio avanzada usando [Dolos](https://dolos.ugent.be/)
- **Análisis de Código**: Parsing de código Java usando gramática ANTLR4
- **JCode**: Herramienta personalizada de análisis de código Java

## Arquitectura

```
PlagiTracker/
├── Backend/                    # API Web ASP.NET Core
│   ├── PlagiTracker/
│   │   ├── PlagiTracker.WebAPI/        # Controladores API y Configuración
│   │   ├── PlagiTracker.Data/          # Capa de Acceso a Datos (EF Core)
│   │   ├── PlagiTracker.Services/      # Servicios de Lógica de Negocio
│   │   ├── PlagiTracker.Analyzer/      # Motor de Detección de Plagio
│   │   ├── PlagiTracker.CodeUtils/     # Utilidades de Análisis de Código
│   │   └── PlagiTracker.Tests/         # Pruebas Unitarias
│   └── JCode/                          # Herramienta de Análisis de Código Java
├── Frontend/                   # SPA Vue.js 3
│   └── src/
│       ├── api-client/         # Cliente API Auto-generado
│       ├── views/              # Componentes de Página
│       │   ├── Student/        # Dashboard del Estudiante
│       │   ├── Teacher/        # Dashboard del Profesor
│       │   └── Authentication/ # Páginas de Autenticación
│       ├── components/         # Componentes UI Reutilizables
│       ├── stores/             # Gestión de Estado con Pinia
│       └── router/             # Configuración de Vue Router
└── DataBase/                   # Respaldos de PostgreSQL
```

## Tecnologías

### Backend
| Tecnología | Propósito |
|------------|-----------|
| ASP.NET Core 8 | Framework de API Web |
| Entity Framework Core | ORM y Acceso a Base de Datos |
| PostgreSQL 15 | Base de Datos Relacional |
| Hangfire | Procesamiento de Trabajos en Segundo Plano |
| Selenium WebDriver | Web Scraping |
| ANTLR4 | Parsing de Código Java |
| JWT Bearer | Autenticación |
| Swagger/OpenAPI | Documentación de la API |

### Frontend
| Tecnología | Propósito |
|------------|-----------|
| Vue.js 3 | Framework de Frontend |
| TypeScript | Seguridad de Tipos |
| Vite | Herramienta de Construcción |
| Tailwind CSS | Framework CSS |
| Pinia | Gestión de Estado |
| Vue Router | Enrutamiento del Lado del Cliente |
| Axios | Cliente HTTP |
| ApexCharts | Visualización de Datos |
| Zod | Validación de Esquemas |

### Detección de Plagio
| Tecnología | Propósito |
|------------|-----------|
| Python | Scripts de Análisis de Plagio |
| Selenium | Web Scraping |
| Dolos | Detección de Plagio Avanzada |
| ANTLR4 | Parsing de Gramática Java |
| iText/PdfSharp | Generación de Reportes PDF |

## Prerrequisitos

- [.NET 8 SDK](https://dotnet.microsoft.com/download/dotnet/8.0)
- [Node.js 18+](https://nodejs.org/)
- [PostgreSQL 15](https://www.postgresql.org/)
- [Python 3.x](https://www.python.org/) (para detección de plagio)
- Controladores de navegador (Firefox, Chrome o Edge) para Selenium

## Instalación

### Backend

1. Navegue al directorio del Backend:
   ```bash
   cd Backend/PlagiTracker
   ```

2. Restaure las dependencias:
   ```bash
   dotnet restore
   ```

3. Instale las herramientas CLI de Entity Framework:
   ```bash
   dotnet tool install --global dotnet-ef
   ```

4. Configure la conexión a la base de datos en `PlagiTracker.WebAPI/appsettings.json`

5. Aplique las migraciones de la base de datos:
   ```bash
   dotnet ef database update --project PlagiTracker.Data --startup-project PlagiTracker.WebAPI
   ```

6. Ejecute la API:
   ```bash
   dotnet run --project PlagiTracker.WebAPI
   ```

### Frontend

1. Navegue al directorio del Frontend:
   ```bash
   cd Frontend
   ```

2. Instale las dependencias:
   ```bash
   npm install
   ```

3. Configure las variables de entorno en `.env`

4. Ejecute el servidor de desarrollo:
   ```bash
   npm run dev
   ```

5. Construya para producción:
   ```bash
   npm run build
   ```

## Configuración

### Backend (`appsettings.json`)

```json
{
  "ConnectionStrings": {
    "DatabaseConnection": "Host=localhost;Database=PlagiTracker;Username=postgres;Password=your_password"
  },
  "Jwt": {
    "Key": "your_jwt_secret_key",
    "Issuer": "PlagiTracker",
    "Audience": "PlagiTrackerUsers"
  },
  "EmailSettings": {
    "Password": "your_email_password"
  }
}
```

### Frontend (`.env`)

```env
VITE_API_BASE_URL=http://localhost:5000/api
```

## Endpoints de la API

### Autenticación
| Método | Endpoint | Descripción |
|--------|----------|-------------|
| POST | `/api/Auth/Register` | Registrar nuevo usuario |
| POST | `/api/Auth/Login` | Inicio de sesión |
| POST | `/api/Auth/Verify` | Verificar email |
| POST | `/api/Auth/ResetPassword` | Restablecer contraseña |

### Cursos
| Método | Endpoint | Descripción |
|--------|----------|-------------|
| POST | `/api/Course/Create` | Crear curso |
| GET | `/api/Course/GetById` | Obtener curso por ID |
| GET | `/api/Course/GetByName` | Obtener curso por nombre |
| GET | `/api/Course/GetAll` | Obtener todos los cursos |
| PUT | `/api/Course/Update` | Actualizar curso |
| DELETE | `/api/Course/Delete` | Eliminar curso |
| DELETE | `/api/Course/Archive` | Archivar curso |
| DELETE | `/api/Course/Unarchive` | Desarchivar curso |
| POST | `/api/Course/UpdateInvitationLink` | Generar nuevo enlace de invitación |

### Tareas
| Método | Endpoint | Descripción |
|--------|----------|-------------|
| POST | `/api/Assignment/Create` | Crear tarea |
| GET | `/api/Assignment/GetById` | Obtener tarea por ID |
| GET | `/api/Assignment/GetAllByCourseForTeacher` | Obtener tareas para profesor |
| GET | `/api/Assignment/GetAllByCourseForStudent` | Obtener tareas para estudiante |
| PUT | `/api/Assignment/Update` | Actualizar tarea |
| DELETE | `/api/Assignment/Delete` | Eliminar tarea |
| POST | `/api/Assignment/Analyze` | Analizar para plagio |
| POST | `/api/Assignment/DolosAnalysis` | Análisis de plagio con Dolos |

### Entregas
| Método | Endpoint | Descripción |
|--------|----------|-------------|
| POST | `/api/Submission/Create` | Crear entrega |
| GET | `/api/Submission/Get` | Obtener entrega |
| GET | `/api/Submission/GetAllByStudent` | Obtener entregas del estudiante |
| GET | `/api/Submission/GetAllByAssignment` | Obtener entregas de la tarea |
| PUT | `/api/Submission/Update` | Actualizar entrega |
| DELETE | `/api/Submission/Delete` | Eliminar entrega |

### Estudiantes
| Método | Endpoint | Descripción |
|--------|----------|-------------|
| POST | `/api/Student/Register` | Registrar estudiante |
| POST | `/api/Student/Login` | Inicio de sesión del estudiante |
| GET | `/api/Student/Get` | Obtener información del estudiante |

### Profesores
| Método | Endpoint | Descripción |
|--------|----------|-------------|
| POST | `/api/Teacher/Register` | Registrar profesor |
| POST | `/api/Teacher/Login` | Inicio de sesión del profesor |
| GET | `/api/Teacher/Get` | Obtener información del profesor |

### Inscripciones
| Método | Endpoint | Descripción |
|--------|----------|-------------|
| POST | `/api/Enrollment/Enroll` | Inscribirse en curso |
| GET | `/api/Enrollment/GetByCourse` | Obtener inscripciones del curso |
| DELETE | `/api/Enrollment/Unenroll` | Desinscribirse del curso |

## Plataformas Soportadas

El sistema realiza web scraping en los siguientes editores de código en línea:

| Plataforma | Patrón de URL | Estado |
|------------|---------------|--------|
| **Codiva** | `https://www.codiva.io/p/{uuid}` | Soportado |
| **OnlineGDB** | `https://www.onlinegdb.com/{id}` | Soportado |
| **Replit** | `https://replit.com` | En Desarrollo |

## Base de Datos

PostgreSQL 15 se utiliza como base de datos principal. Los respaldos de la base de datos están disponibles en el directorio `DataBase/`.

### Tablas Principales
- `plagi_tracker.Users` - Tabla base de usuarios
- `plagi_tracker.Teachers` - Perfiles de profesores
- `plagi_tracker.Students` - Perfiles de estudiantes
- `plagi_tracker.Courses` - Información de cursos
- `plagi_tracker.Assignments` - Detalles de tareas
- `plagi_tracker.Submissions` - Entregas de estudiantes
- `plagi_tracker.Codes` - Código fuente extraído
- `plagi_tracker.Enrollments` - Inscripciones a cursos

## Contribuir

1. Haga fork del repositorio
2. Cree una rama de características (`git checkout -b feature/caracteristica-increible`)
3. Haga commit de sus cambios (`git commit -m 'Agregar característica increíble'`)
4. Haga push a la rama (`git push origin feature/caracteristica-increible`)
5. Abra un Pull Request

## Licencia

Este proyecto está bajo la Licencia MIT - vea el archivo [LICENSE](LICENSE) para más detalles.