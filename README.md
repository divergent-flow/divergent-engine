# Divergent Engine 🧠

**The Open Source "Anti-Paralysis" Engine powering [Divergent Flow](https://getdivergentflow.com).**

This repository contains the core backend logic for a new type of productivity system. Unlike traditional "List Managers" that optimize for *storage* (hoarding tasks), Divergent Engine optimizes for *execution* (blocking noise).

It is currently the "Client Zero" implementation of our **Universal Entity Engine** vision—a plugin-driven architecture designed to manage life's data without the context-switching tax.

## 🛠 The Stack
We are building on the absolute bleeding edge. High performance, low latency.

* **Framework:** **.NET 10** (Clean Architecture)
* **Data:** **MongoDB** (Flexible Entity Storage)
* **Cache/Bus:** **Redis** (Upstash) for Hot State & SignalR Backplane
* **Pattern:** CQRS (Command Query Responsibility Segregation) with MediatR
* **API:** REST + OpenAPI (Swagger)

## 🏗 Architecture

### Universal Entity Engine (UEE)
The UEE is the cornerstone of Divergent Engine. Instead of creating separate tables/collections for tasks, notes, collections, and other content types, everything is represented as a flexible **Entity** with:

* **Type-based Schema**: `EntityType` definitions act as templates, defining what attributes each entity type can have
* **Dynamic Attributes**: A key-value store allowing entities to have flexible, schema-validated properties
* **Relationships**: First-class support for entity relationships (parent/child, collections, links)
* **Multi-tenancy**: Built-in tenant isolation for security and team workspaces

#### Core Entity Model
```csharp
Entity
├── Id (GUID - stable public identifier)
├── EntityTypeId (e.g., "task", "note", "collection")
├── TenantId (data isolation boundary)
├── OwnerId (creator/owner)
├── Attributes (flexible key-value data)
├── Metadata (created, modified timestamps)
└── Relationships (links to other entities)
```

### Clean Architecture Layers
We follow a strict **Clean Architecture** approach to keep the core logic independent of frameworks and UI.

* **`DivergentEngine.Core`**: Pure domain models (Entity, EntityType, etc.). No external dependencies except MongoDB.Bson for serialization attributes.
* **`DivergentFlow.Application`** *(Future)*: Use cases, CQRS handlers, and interfaces.
* **`DivergentFlow.Infrastructure`** *(Future)*: Implementation of interfaces (Mongo repositories, Redis caching, Auth0).
* **`DivergentFlow.Api`** *(Future)*: The API entry point.

### Interface Extraction Goals
To maintain a clean domain layer, we are committed to:

1. **Minimizing Framework Dependencies**: The Core domain should have minimal external dependencies. Currently uses `MongoDB.Bson` for serialization - future work may extract this behind interfaces.
2. **Repository Pattern**: All data access will be abstracted behind repository interfaces defined in the Application layer.
3. **Dependency Inversion**: Infrastructure depends on Application/Core, never the reverse.
4. **Testability**: Pure domain logic should be testable without infrastructure concerns.

## 🤝 Contributing & Retroactive Bounties
We are bootstrapping this as a community of engineers.

* **The Deal:** We run a **Retroactive Bounty System**.
* **The Rewards:** Specific issues are tagged with cash values (e.g., `Bounty: $200`).
* **The Payout:** Bounties are paid out when the project hits its first funding milestone or revenue target.

See [CONTRIBUTING.md](CONTRIBUTING.md) for details on how to claim a ticket and our coding standards.

## 🚀 Getting Started

### Prerequisites
* .NET 10 SDK
* Docker (for local infrastructure)

### Run Locally
1.  **Spin up Infrastructure:**
    ```bash
    docker-compose up -d
    ```
    *(This starts local instances of MongoDB and Redis)*

2.  **Run the API:**
    ```bash
    dotnet run --project DivergentFlow.Api
    ```

3.  **Explore:**
    Open `http://localhost:5000/swagger` to interact with the Universal Entity Engine API.

## 📄 License
This Core Engine is licensed under the **MIT License**.
