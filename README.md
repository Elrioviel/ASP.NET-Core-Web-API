# Product Management API

## Overview
**Product Management API** built with **ASP.NET Core** and **Entity Framework** using a **code-first** approach fr database management.
This API provides **CRUD** operation, using a **layered architecture** with **asynchronous** methods for improved performance and scalability.

## Features
- **ASP.NET Core 8 Web API**
- **Entity Framework Core** using **code-first** migrations
- **DTOs (Data Transfer Objects)**
- **Repository and Service layers**
- **Async methods** for all operations
- **Tests** written in `ProductManagement.http`
- **Docker** support with `Dockerfile`, `Dockerfile.ef`, and `docker-compose.yml`

## Project Structure
- **Controllers:** Handle HTTP requests and responses
- **Services:** Business logic and interaction with repositories
- **Repositories:** Data access layer, interacting with **DB** using **EF**
- **DTOs:** Simplified objects for data transfer between layers
- **Data:** Contains the **DbContext** and **migration** configuration

## Prerequisites
- **.NET SDK 8.0**
- **Docker**
- **SQL Server (configured in Docker setup)**

## Testing
API tests are provided in `ProductManagement.http`
