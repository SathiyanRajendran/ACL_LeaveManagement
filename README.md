# ACL Leave Management - Project Explanation & Interview Guide

## 1. Project Overview
**ACL Leave Management** is a robust backend API built with **.NET Core** for managing employee leave allocations and requests. It is designed to be scalable, maintainable, and testable by adhering to industry-standard architectural principles.

### Technology Stack
-   **Framework**: .NET 8 / .NET 9 (Core)
-   **Language**: C#
-   **Database**: SQL Server (accessed via Entity Framework Core)
-   **ORM**: Entity Framework Core (Code-First Approach)
-   **API**: ASP.NET Core Web API
-   **Documentation**: Swagger / OpenAPI

---

## 2. Architecture & Design Patterns

The project follows **Clean Architecture** combined with several key design patterns.

### A. Clean Architecture (Onion Architecture)
The solution is organized into concentric layers, ensuring the "Dependency Rule" is always obeyed: **Inner layers should have NO knowledge of outer layers.**

1.  **Domain Layer (`ACL.LeaveManagement.Domain`)**
    *   **Role**: The core. Contains Enterprise Logic and Entities.
    *   **Dependencies**: None.
    *   **Content**: Entities like `LeaveType`, `LeaveAllocation`, `LeaveRequest`.

2.  **Application Layer (`ACL.LeaveManagement.Application`)**
    *   **Role**: Contains Application Business Logic. It orchestrates the flow of data.
    *   **Dependencies**: Domain Layer.
    *   **Content**: DTOs, Interfaces (Repositories, Services), CQRS Handlers (Features), Validators, AutoMapper Profiles.

3.  **Infrastructure Layer (`ACL.LeaveManagement.Infrastructure`)**
    *   **Role**: Implements interfaces defined in the Application layer. Handles external concerns.
    *   **Dependencies**: Application Layer, Domain Layer.
    *   **Content**: `LeaveManagementDbContext`, Repository Implementations (`LeaveTypeRepository`), Email Services.

4.  **API Layer (`ACL.LeaveManagement.Api`)**
    *   **Role**: The Entry Point (Presentation). Accepts HTTP requests and returns responses.
    *   **Dependencies**: Application Layer, Infrastructure Layer (for DI registration).
    *   **Content**: Controllers, Middleware, `Program.cs`.

### B. Specific Design Patterns

#### 1. CQRS (Command Query Responsibility Segregation)
*   **Concept**: Segregates operations into **Commands** (Write: Create, Update, Delete) and **Queries** (Read: Get).
*   **Implementation**: We use **MediatR**.
*   **Benefit**: Allows optimizing read and write sides independently. Keeps handlers small and focused (Single Responsibility Principle).

#### 2. Mediator Pattern
*   **Concept**: Object that encapsulates how a set of objects interact.
*   **Implementation**: **MediatR** library.
*   **Benefit**: Decouples Controllers from Services. The Controller sends a "Message" (Request), and the Mediator routes it to the correct "Handler".

#### 3. Repository Pattern
*   **Concept**: Mediates between the domain and data mapping layers.
*   **Implementation**: `IGenericRepository<T>` and specific repositories like `ILeaveTypeRepository`.
*   **Benefit**: Decouples the Application from the ORM (EF Core). Makes it easier to mock data access for unit testing.

#### 4. DTO (Data Transfer Object) Pattern
*   **Concept**: Objects that carry data between processes.
*   **Implementation**: `LeaveTypeDto`, `CreateLeaveAllocationDto`, etc.
*   **Benefit**: Hides (encapsulates) the Domain Entities. Allows shaping data specifically for the client (e.g., flattening complex objects) and prevents over-posting attacks.

#### 5. Dependency Injection (DI)
*   **Concept**: Inversion of Control technique where dependencies are "injected" rather than created internally.
*   **Implementation**: .NET Core built-in IoC Container (`IServiceCollection`).

---

## 3. Interview Questions & Answers

### Q1: Why did you choose Clean Architecture?
**A:** Clean Architecture ensures the core business logic (Domain) is independent of frameworks, databases, and UIs. This makes the application:
1.  **Testable**: Business rules can be tested without a database or API.
2.  **Maintainable**: Layers are loosely coupled.
3.  **Flexible**: We can swap the database (e.g., SQL Server to PostgreSQL) or UI without touching the core business logic.

### Q2: What is the purpose of MediatR in this project?
**A:** MediatR implements the Mediator pattern to facilitate CQRS. It decouples the API Controllers from the business logic. Instead of injecting a heavy Service class into the Controller, we inject `IMediator`. The Controller sends a request, and MediatR dynamically locates and executes the appropriate Handler.

### Q3: Why use DTOs instead of returning Domain Entities directly?
**A:**
1.  **Security**: Prevents "Over-posting" (mass assignment) vulnerabilities where a user might maliciously update fields they shouldn't (e.g., `IsAdmin`).
2.  **Decoupling**: Validations for API requests (e.g., "Password is required") might differ from Domain rules.
3.  **Versioning**: Database schema changes don't immediately break the API contract.
4.  **Performance**: We can return only the data the client needs, not the entire object graph.

### Q4: Explain the difference between `AddScoped`, `AddTransient`, and `AddSingleton`.
**A:**
*   **Transient**: Created every time they are requested. Lightweight, stateless services.
*   **Scoped**: Created once per Client Request (HTTP Request). Used for `DbContext` and Repositories to ensure data consistency within a single web request.
*   **Singleton**: Created the first time they are requested and live for the application's lifetime. Used for caching services or configuration.

### Q5: How do you handle Validation?
**A:** We use **FluentValidation** in the Application layer.
*   Validation logic is separated from DTOs into specific Validator classes (e.g., `CreateLeaveTypeDtoValidator`).
*   This keeps DTOs clean (POCOs) and allows complex validation rules (e.g., checking database for duplicates) that Data Annotations can't easily handle.

### Q6: What is the "Generic Repository" and why use it?
**A:** The Generic Repository (`GenericRepository<T>`) implements standard CRUD operations (`Get`, `Add`, `Update`, `Delete`) once for all entities. This reduces code duplication. Specific repositories (`LeaveTypeRepository`) inherit from it and only implement methods unique to that entity.

### Q7: Using AutoMapper seems like "magic". Why use it?
**A:** While it can hide mapping logic, manual mapping (e.g., `dto.Name = entity.Name`) is tedious and error-prone boilerplate. AutoMapper automates this copy-paste work. We configure it in `MappingProfile` to ensure specific mapping rules are explicit and centrally managed.
