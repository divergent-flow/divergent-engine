# UEE Development Roadmap & Bounty List

This document outlines the development tasks (bounties) required to build the **Universal Entity Engine (UEE)** based on the architecture definitions.

## Phase 1: Core Kernel & Primitives

The foundational building blocks for the engine.

### B-001: Core Entity & Event Abstractions

**Goal:** Define the base interfaces and classes for the Domain.
**Requirements:**

- Create `IEntity`, `Entity` base class.
- Create `IEvent` interface and metadata structure (TenantId, CorrelationId, etc.).
- Implement `AggregateRoot` pattern helpers (ApplyEvent mechanisms).
- **Scope:** `DivergentEngine.Core`

### B-002: Result Pattern & Validation Primitives

**Goal:** Standardize operation results and validation.
**Requirements:**

- specific `Result<T>` class to handle Success/Failure without exceptions.
- `Error` record type.
- Integration with basic FluentValidation (or similar) plumbing.
- **Scope:** `DivergentEngine.Core`

## Phase 2: Event Storage & Infrastructure

Persisting the immutable history.

### B-003: MongoDB Event Store Implementation

**Goal:** Implement the append-only log.
**Requirements:**

- Implement `IEventStore`.
- Create MongoDB schema for `EventStreams`.
- Implement Optimistic Concurrency Control (Version check).
- **Scope:** `DivergentEngine.Infrastructure`

### B-004: Snapshotting Strategy

**Goal:** Optimize loading of long-lived entities.
**Requirements:**

- Implement `ISnapshotStore`.
- Logic to create snapshots every N events.
- **Scope:** `DivergentEngine.Infrastructure`

## Phase 3: CQRS Write Model

Handling commands and business logic.

### B-005: Command Dispatcher & Mediator Pipeline

**Goal:** Route commands to handlers.
**Requirements:**

- Implement `ICommand`, `ICommandHandler<T>`.
- Create a Dispatcher/Mediator (or use MediatR).
- Middleware pipeline for Logging, Validation, and Transaction management.
- **Scope:** `DivergentEngine.Application`

### B-006: Generic Event Sourced Repository

**Goal:** Standard way to load/save entities.
**Requirements:**

- `IRepository<T>` where T : Entity.
- `LoadAsync(id)`: Rehydrate from EventStore.
- `SaveAsync(entity)`: Commit uncommitted events to EventStore.
- **Scope:** `DivergentEngine.Infrastructure`

## Phase 4: Read Models & Projections

Converting events into queryable views.

### B-007: Projection Engine (In-Memory & Persistent)

**Goal:** React to events and build read models.
**Requirements:**

- `IProjection` interface.
- Dispatcher to route committed events to interested projections.
- Handler for `IEvent<Created>`, `IEvent<Updated>`, etc.
- **Scope:** `DivergentEngine.Application`

### B-008: MongoDB Read Model Repository

**Goal:** Store queryable side.
**Requirements:**

- Generic Mongo Repository for ReadModels (Documents).
- Idempotency checks.
- **Scope:** `DivergentEngine.Infrastructure`

## Phase 5: API & Multitenancy

The public face of the engine.

### B-009: ASP.NET Core API Shell

**Goal:** Host the engine.
**Requirements:**

- Setup Solution with `DivergentEngine.API`.
- DI Container wiring.
- Swagger/OpenAPI configuration.

### B-010: Multitenancy Middleware

**Goal:** Isolate data per tenant.
**Requirements:**

- Header/Token based Tenant Resolution.
- Inject `TenantContext` into Command Handlers and Repositories.
- Filter MongoDB queries by `TenantId`.

## Phase 6: Plugin System (WASM)

Extensibility without recompilation.

### B-011: WASM Host Integration (Wasmtime/WasmEdge)

**Goal:** Run external code.
**Requirements:**

- Integrate a .NET WASM runtime (e.g., Wasmtime).
- Define the "Host ABI" (functions exposed to plugins).
- **Scope:** `DivergentEngine.Plugins`

### B-012: Plugin Registry & Loader

**Goal:** Manage available plugins.
**Requirements:**

- Store Plugin binaries (Entities).
- Load/Unload mechanisms.
- **Scope:** `DivergentEngine.Plugins`

## Phase 7: Telemetry & Observability

Understanding system behavior.

### B-013: OpenTelemetry Tracing

**Goal:** End-to-end visibility.
**Requirements:**

- Trace Command -> Event -> Projection.
- Export to Jaeger/Zipkin/Aspire.

### B-014: Structured Logging (Serilog)

**Goal:** Queryable logs.
**Requirements:**

- Enrich logs with TenantId, CorrelationId, UserId.
