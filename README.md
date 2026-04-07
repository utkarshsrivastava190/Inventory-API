# Elmex Inventory API 🏭

## Project Overview
The Elmex Inventory API is a robust, RESTful Web API built with **ASP.NET Core**. It was designed to act as the backend engine for a manufacturing factory floor, managing the relational data between Products, Suppliers, and Purchase Orders. 

This project demonstrates modern, enterprise-grade backend development, transitioning from legacy desktop reporting systems to highly scalable, asynchronous web services.

## Technical Stack
* **Framework:** .NET 8 / ASP.NET Core Web API
* **Language:** C#
* **Database Engine:** Entity Framework Core (Code-First)
* **Database:** Microsoft SQL Server
* **Documentation/Testing:** Swagger UI (Swashbuckle)

## Architectural Highlights
This application was engineered using industry-standard design patterns to ensure scalability, security, and maintainability:

* **Controller-Service-Interface (CSI) Architecture:** Strictly decouples HTTP routing (Controllers) from business logic (Services), using Interfaces to establish firm contracts and utilize Dependency Injection.
* **Fully Asynchronous Pipeline:** Implements `async`/`await` and `Task<T>` across all network and database calls to prevent thread-blocking during high-volume factory traffic.
* **Data Transfer Objects (DTOs):** Utilizes isolated DTO records to map incoming requests. This ensures raw database entities are never directly exposed to the client, preventing over-posting vulnerabilities.
* **Relational Data Modeling:** Leverages Entity Framework Core to build complex relational bridges using Foreign Keys and Navigation Properties, utilizing `.Include()` for optimized SQL JOIN queries.

## Key Features & Endpoints
The API provides full Asynchronous CRUD (Create, Read, Update, Delete) functionality across multiple domains:

**📦 Products Module**
* `GET /Inventory` - Retrieves a list of factory products.
* `POST /Inventory` - Adds a new product to the catalog.
* `PUT /Inventory/{id}` - Updates pricing and stock quantities.
* `DELETE /Inventory/{id}` - Removes a product from the system.

**🚚 Suppliers Module**
* Relational endpoints connecting external vendors to specific factory products.

**📋 Purchase Orders Module**
* `GET /PurchaseOrder` - Retrieves factory purchase orders, dynamically joining the related Product data into a single JSON response using EF Core Navigation routing.
* `POST /PurchaseOrder` - Submits a new inventory replenishment order.
* `PUT /PurchaseOrder/{id}` - Modifies existing order quantities.
* `DELETE /PurchaseOrder/{id}` - Cancels a purchase order.

## Getting Started (Local Development)
To run this project locally:
1. Clone the repository to your local machine.
2. Open the solution `.slnx` in Visual Studio.
3. Open the Package Manager Console and run `Update-Database` to generate the SQL Server tables.
4. Press `F5` to build the project and launch the Swagger UI testing environment.
