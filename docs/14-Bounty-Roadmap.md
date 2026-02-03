# UEE Development Roadmap & Bounty List

This document outlines the development tasks (bounties) required to build the **Universal Entity Engine (UEE)**. It is derived from the comprehensive architecture definitions and broken down into executable units of work.

## Phase 1: The Core Kernel (Domain & Primitives)

*The bedrock of the system. No external dependencies.*

### B-01-01: Core Entity & Aggregate Roots

**Goal:** Define the base classes for the Event Sourced domain.
**Requirements:**

- `IEntity`, `Entity` base class with `Id`, `Version`, `TenantId`.
- `IAggregateRoot` interface.
- `ApplyEvent(IEvent)` mechanism for state reconstruction.
- Unit tests for version increments and state application.
- **Scope:** `DivergentEngine.Core`

### B-01-02: Event Abstractions & Metadata

**Goal:** Standardize the event envelope.
**Requirements:**

- `IEvent` interface.
- `EventMetadata` record (Timestamp, UserId, CorrelationId, CausalityId).
- `DomainEvent` base class.
- Serialization attributes (Json/Bson) configuration.

### B-01-03: Result Pattern & Validation

**Goal:** Railway-oriented programming primitives.
**Requirements:**

- `Result<T>` and `Result` (Success/Failure).
- `Error` record (Code, Message).
- `ValidationResult` extensions.
- Reusable `ValueObject` base class.

---

## Phase 2: Persistence & Integrity (The Write Side)

*Reliable storage of the immutable log.*

### B-02-01: MongoDB Event Store & Streams

**Goal:** The primary append-only storage.
**Requirements:**

- `EventStream` document schema.
- `IEventStore` implementation.
- Optimistic Concurrency Control (Version mismatch detection).
- **Scope:** `DivergentEngine.Infrastructure`

### B-02-02: Transactional Outbox Implementation

**Goal:** Ensure "At-Least-Once" delivery to the message bus.
**Requirements:**

- `OutboxMessage` collection in MongoDB.
- Atomicity: Save Events + Save Outbox Message in one Mongo transaction.
- **Scope:** `DivergentEngine.Infrastructure`

### B-02-03: Snapshot Store Strategy

**Goal:** Performance optimization for large streams.
**Requirements:**

- `ISnapshotStore`.
- `SnapshotStrategy` (e.g., every 100 events).
- Background worker to create snapshots async (optional) or inline.

### B-02-04: Generic Event Sourced Repository

**Goal:** The application's interface to storage.
**Requirements:**

- `IRepository<T>` interface.
- `LoadAsync(id)`: Rehydrate from Snapshot + Events.
- `SaveAsync(entity)`: Persist events + Outbox.

---

## Phase 3: The Nervous System (Event Bus & Messaging)

*Moving data from Write to Read/Plugins.*

### B-03-01: Redis Streams Publisher (Outbox Processor)

**Goal:** Publish events to the wider system.
**Requirements:**

- Background Service (Worker) to poll/watch `OutboxMessage` collection.
- Publish to Redis Streams (`XADD`).
- Mark messages as processed (delete or update status).
- **Scope:** `DivergentEngine.Infrastructure`

### B-03-02: Redis Streams Consumer Groups

**Goal:** Reliable event consumption.
**Requirements:**

- Abstract Consumer Host (`IStreamConsumer`).
- Handle `XREADGROUP` for load balancing.
- Acknowledgement (`XACK`) handling.
- Dead Letter Queue (DLQ) logic for failed processing.

### B-03-03: Internal Mediator Pipeline

**Goal:** In-process decoupling.
**Requirements:**

- MediatR (or custom) setup.
- Behaviors: `LoggingBehavior`, `ValidationBehavior`, `PerformanceBehavior`.

---

## Phase 4: The Read Side (Projections & Queries)

*Making data queryable.*

### B-04-01: Projection Engine Core

**Goal:** Framework for building read models.
**Requirements:**

- `IProjection<TModel>` interface.
- `Project(Event)` method definitions.
- Handling `Rebuild` vs `Live` projection modes.

### B-04-02: MongoDB Read Model Repository

**Goal:** Persisting views.
**Requirements:**

- Generic Repository for `ReadModel` documents.
- Idempotent update logic (`$set` operations).
- **Scope:** `DivergentEngine.Infrastructure`

### B-04-03: Distributed Cache (L2) Implementation

**Goal:** High-speed entity access.
**Requirements:**

- Redis-based `IDistributedCache`.
- Look-aside caching pattern for Read Models.
- Cache Invalidation (evict on Event).

---

## Phase 5: The Plugin Runtime (WASM & Extensibility)

*The "Universal" part of the engine.*

### B-05-01: WASM Host Integration (Wasmtime)

**Goal:** Execute foreign code safely.
**Requirements:**

- Integrate `Wasmtime` or `WasmEdge` .NET bindings.
- Load `.wasm` files from storage/registry.
- Simple "Hello World" execution.

### B-05-02: Plugin Host Functions (ABI)

**Goal:** Allow plugins to talk to the Engine.
**Requirements:**

- Define Import functions: `get_entity(id)`, `save_entity(json)`, `log(msg)`.
- Map WASM memory to .NET objects.

### B-05-03: Plugin Event Listener

**Goal:** Plugins reacting to system events.
**Requirements:**

- Mechanism to route Redis Stream events -> Trigger WASM function.
- `PluginContext` to pass event data to WASM.

---

## Phase 6: API & Multitenancy Security

*The gateway to the world.*

### B-06-01: Tenant Resolution Middleware

**Goal:** SaaS isolation.
**Requirements:**

- Resolve Tenant via Header / JWT / Governance API.
- `ITenantContext` accessor.
- Logical isolation enforcement in Repositories.

### B-06-02: Dynamic API Controllers

**Goal:** Expose Entities without writing code.
**Requirements:**

- Generic Controller `EntityController<T>`.
- Or dynamic routing `api/v1/{entityType}/{id}`.
- OpenAPI (Swagger) dynamic generation.

### B-06-03: Authentication & Permissions

**Goal:** RBAC and Auth.
**Requirements:**

- OIDC Integration (Auth0 / IdentityServer).
- Policy-based authorization (`CanReadEntity`, `CanExecuteCommand`).

---

## Phase 7: AI & Telemetry (The Brain)

*Observability and Intelligence.*

### B-07-01: OpenTelemetry Instrumentation

**Goal:** Full system visibility.
**Requirements:**

- Traces for Command -> Event -> Bus -> Projection.
- Metrics (Events/sec, Plugin execution time).

### B-07-02: Vector Store Integration (Memory)

**Goal:** Semantic search for entities.
**Requirements:**

- Connector for Qdrant or Weaviate.
- Projection that embeds text attributes -> Vector Store.

### B-07-03: AI Agent Interface (MCP)

**Goal:** Allow AI to control the engine.
**Requirements:**

- Implement Model Context Protocol (MCP) server endpoints.
- Allow AI to query Schema and Entities.

---

## Phase 8: Developer Experience (DevEx)

*Tools for builders.*

### B-08-01: CLI Tool (`uee`)

**Goal:** Command line management.
**Requirements:**

- `uee init`
- `uee plugin new`
- `uee snapshot run`

### B-08-02: C# Client SDK

**Goal:** Typed access for external apps.
**Requirements:**

- SignalR Client for real-time updates.
- HTTP Client wrapper.
