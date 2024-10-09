# ASPWebAPITemplate

ASPWebAPITemplate ASPWebAPITemplate is a template for quickly developing REST APIs with ASP.NET.
It’s built for managing simple To Do tasks but can easily be extended for other purposes.

## Features

- Controllers: Implements RESTful API endpoints for task management.
- CQRS Pattern: Separates read and write operations using MediatR for requests and responses.
- Database Repository: Abstracts data access with a repository pattern.
- Database Support: Utilizes both MS SQL and JSON databases.
- JWT Authentication: Secures endpoints using JSON Web Tokens.
- Health Check: Monitors the application's health status.
- Swagger Documentation: Automatically generated API documentation for testing and development.

## Technologies Used

- ASP.NET Core
- Entity Framework Core
- MediatR
- FluentValidation
- JWT (JSON Web Tokens)
- Swagger
- MS SQL Server

## Getting Started

### Prerequisites

- [.NET SDK](https://dotnet.microsoft.com/download) (version 6.0 or higher)
- [SQL Server](https://www.microsoft.com/en-us/sql-server/sql-server-downloads) (if using MS SQL)

### Clone the Repository

```bash
git clone https://github.com/yourusername/ASPWebAPITemplate.git