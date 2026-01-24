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
We follow a strict **Clean Architecture** approach to keep the core logic independent of frameworks and UI.

* `DivergentFlow.Domain`: Pure business logic and entities. No dependencies.
* `DivergentFlow.Application`: Use cases, CQRS handlers, and interfaces.
* `DivergentFlow.Infrastructure`: Implementation of interfaces (Mongo, Redis, Auth0).
* `DivergentFlow.Api`: The entry point.

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
