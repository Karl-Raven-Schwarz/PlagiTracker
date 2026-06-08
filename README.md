# PlagiTracker

A web-based plagiarism detection platform for software engineering education, similar to Google Classroom but focused on code plagiarism analysis.

## Table of Contents

- [Overview](#overview)
- [Features](#features)
- [Architecture](#architecture)
- [Tech Stack](#tech-stack)
- [Prerequisites](#prerequisites)
- [Installation](#installation)
- [Configuration](#configuration)
- [API Endpoints](#api-endpoints)
- [Supported Platforms](#supported-platforms)
- [Database](#database)
- [Contributing](#contributing)
- [License](#license)

## Overview

PlagiTracker is a comprehensive platform designed for software engineering courses that enables teachers to create courses, assignments, and automatically detect plagiarism in student submissions. The system performs web scraping on supported online code editors to extract source code and applies plagiarism detection algorithms.

### Key Capabilities

- **Course Management**: Teachers can create, archive, and manage courses with invitation links
- **Assignment System**: Create assignments with deadlines and automatic submission tracking
- **Code Submission**: Students submit code via supported online editors (Codiva, OnlineGDB)
- **Plagiarism Detection**: Automated analysis using multiple methods (custom analyzer + Dolos)
- **Web Scraping**: Automatic code extraction from online IDEs using Selenium
- **PDF Report Generation**: Generate detailed plagiarism reports
- **Email Notifications**: Automated notifications for submissions and analysis results
- **Role-Based Access**: Separate dashboards for teachers and students

## Features

### For Teachers
- Create and manage courses
- Generate invitation links for student enrollment
- Create assignments with deadlines
- Analyze submissions for plagiarism
- Generate PDF plagiarism reports
- Dolos integration for advanced analysis
- Archive/unarchive courses
- Grade submissions

### For Students
- Join courses via invitation links
- View assignments and deadlines
- Submit code via supported online editors
- Track submission history
- View grades

### Plagiarism Detection
- **Custom Analyzer**: Python-based plagiarism detection using web scraping
- **Dolos Integration**: Advanced plagiarism detection using [Dolos](https://dolos.ugent.be/)
- **Code Analysis**: Java code parsing using ANTLR4 grammar
- **JCode**: Custom Java code analysis tool

## Architecture

```
PlagiTracker/
├── Backend/                    # ASP.NET Core Web API
│   ├── PlagiTracker/
│   │   ├── PlagiTracker.WebAPI/        # API Controllers & Configuration
│   │   ├── PlagiTracker.Data/          # Data Access Layer (EF Core)
│   │   ├── PlagiTracker.Services/      # Business Logic Services
│   │   ├── PlagiTracker.Analyzer/      # Plagiarism Detection Engine
│   │   ├── PlagiTracker.CodeUtils/     # Code Analysis Utilities
│   │   └── PlagiTracker.Tests/         # Unit Tests
│   └── JCode/                          # Java Code Analysis Tool
├── Frontend/                   # Vue.js 3 SPA
│   └── src/
│       ├── api-client/         # Auto-generated API Client
│       ├── views/              # Page Components
│       │   ├── Student/        # Student Dashboard
│       │   ├── Teacher/        # Teacher Dashboard
│       │   └── Authentication/ # Auth Pages
│       ├── components/         # Reusable UI Components
│       ├── stores/             # Pinia State Management
│       └── router/             # Vue Router Configuration
└── DataBase/                   # PostgreSQL Backups
```

## Tech Stack

### Backend
| Technology | Purpose |
|------------|---------|
| ASP.NET Core 8 | Web API Framework |
| Entity Framework Core | ORM & Database Access |
| PostgreSQL 15 | Relational Database |
| Hangfire | Background Job Processing |
| Selenium WebDriver | Web Scraping |
| ANTLR4 | Java Code Parsing |
| JWT Bearer | Authentication |
| Swagger/OpenAPI | API Documentation |

### Frontend
| Technology | Purpose |
|------------|---------|
| Vue.js 3 | Frontend Framework |
| TypeScript | Type Safety |
| Vite | Build Tool |
| Tailwind CSS | CSS Framework |
| Pinia | State Management |
| Vue Router | Client-Side Routing |
| Axios | HTTP Client |
| ApexCharts | Data Visualization |
| Zod | Schema Validation |

### Plagiarism Detection
| Technology | Purpose |
|------------|---------|
| Python | Plagiarism Analysis Scripts |
| Selenium | Web Scraping |
| Dolos | Advanced Plagiarism Detection |
| ANTLR4 | Java Grammar Parsing |
| iText/PdfSharp | PDF Report Generation |

## Prerequisites

- [.NET 8 SDK](https://dotnet.microsoft.com/download/dotnet/8.0)
- [Node.js 18+](https://nodejs.org/)
- [PostgreSQL 15](https://www.postgresql.org/)
- [Python 3.x](https://www.python.org/) (for plagiarism detection)
- Browser drivers (Firefox, Chrome, or Edge) for Selenium

## Installation

### Backend

1. Navigate to the Backend directory:
   ```bash
   cd Backend/PlagiTracker
   ```

2. Restore dependencies:
   ```bash
   dotnet restore
   ```

3. Install Entity Framework CLI tools:
   ```bash
   dotnet tool install --global dotnet-ef
   ```

4. Configure the database connection in `PlagiTracker.WebAPI/appsettings.json`

5. Apply database migrations:
   ```bash
   dotnet ef database update --project PlagiTracker.Data --startup-project PlagiTracker.WebAPI
   ```

6. Run the API:
   ```bash
   dotnet run --project PlagiTracker.WebAPI
   ```

### Frontend

1. Navigate to the Frontend directory:
   ```bash
   cd Frontend
   ```

2. Install dependencies:
   ```bash
   npm install
   ```

3. Configure environment variables in `.env`

4. Run development server:
   ```bash
   npm run dev
   ```

5. Build for production:
   ```bash
   npm run build
   ```

## Configuration

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

## API Endpoints

### Authentication
| Method | Endpoint | Description |
|--------|----------|-------------|
| POST | `/api/Auth/Register` | Register new user |
| POST | `/api/Auth/Login` | User login |
| POST | `/api/Auth/Verify` | Verify email |
| POST | `/api/Auth/ResetPassword` | Reset password |

### Courses
| Method | Endpoint | Description |
|--------|----------|-------------|
| POST | `/api/Course/Create` | Create course |
| GET | `/api/Course/GetById` | Get course by ID |
| GET | `/api/Course/GetByName` | Get course by name |
| GET | `/api/Course/GetAll` | Get all courses |
| PUT | `/api/Course/Update` | Update course |
| DELETE | `/api/Course/Delete` | Delete course |
| DELETE | `/api/Course/Archive` | Archive course |
| DELETE | `/api/Course/Unarchive` | Unarchive course |
| POST | `/api/Course/UpdateInvitationLink` | Generate new invitation link |

### Assignments
| Method | Endpoint | Description |
|--------|----------|-------------|
| POST | `/api/Assignment/Create` | Create assignment |
| GET | `/api/Assignment/GetById` | Get assignment by ID |
| GET | `/api/Assignment/GetAllByCourseForTeacher` | Get assignments for teacher |
| GET | `/api/Assignment/GetAllByCourseForStudent` | Get assignments for student |
| PUT | `/api/Assignment/Update` | Update assignment |
| DELETE | `/api/Assignment/Delete` | Delete assignment |
| POST | `/api/Assignment/Analyze` | Analyze for plagiarism |
| POST | `/api/Assignment/DolosAnalysis` | Dolos plagiarism analysis |

### Submissions
| Method | Endpoint | Description |
|--------|----------|-------------|
| POST | `/api/Submission/Create` | Create submission |
| GET | `/api/Submission/Get` | Get submission |
| GET | `/api/Submission/GetAllByStudent` | Get student submissions |
| GET | `/api/Submission/GetAllByAssignment` | Get assignment submissions |
| PUT | `/api/Submission/Update` | Update submission |
| DELETE | `/api/Submission/Delete` | Delete submission |

### Students
| Method | Endpoint | Description |
|--------|----------|-------------|
| POST | `/api/Student/Register` | Register student |
| POST | `/api/Student/Login` | Student login |
| GET | `/api/Student/Get` | Get student info |

### Teachers
| Method | Endpoint | Description |
|--------|----------|-------------|
| POST | `/api/Teacher/Register` | Register teacher |
| POST | `/api/Teacher/Login` | Teacher login |
| GET | `/api/Teacher/Get` | Get teacher info |

### Enrollments
| Method | Endpoint | Description |
|--------|----------|-------------|
| POST | `/api/Enrollment/Enroll` | Enroll in course |
| GET | `/api/Enrollment/GetByCourse` | Get course enrollments |
| DELETE | `/api/Enrollment/Unenroll` | Unenroll from course |

## Supported Platforms

The system performs web scraping on the following online code editors:

| Platform | URL Pattern | Status |
|----------|-------------|--------|
| **Codiva** | `https://www.codiva.io/p/{uuid}` | Supported |
| **OnlineGDB** | `https://www.onlinegdb.com/{id}` | Supported |
| **Replit** | `https://replit.com` | In Development |

## Database

PostgreSQL 15 is used as the primary database. Database backups are available in the `DataBase/` directory.

### Key Tables
- `plagi_tracker.Users` - Base user table
- `plagi_tracker.Teachers` - Teacher profiles
- `plagi_tracker.Students` - Student profiles
- `plagi_tracker.Courses` - Course information
- `plagi_tracker.Assignments` - Assignment details
- `plagi_tracker.Submissions` - Student submissions
- `plagi_tracker.Codes` - Extracted source code
- `plagi_tracker.Enrollments` - Course enrollments

## Contributing

1. Fork the repository
2. Create a feature branch (`git checkout -b feature/amazing-feature`)
3. Commit your changes (`git commit -m 'Add amazing feature'`)
4. Push to the branch (`git push origin feature/amazing-feature`)
5. Open a Pull Request

## License

This project is licensed under the MIT License - see the [LICENSE](LICENSE) file for details.