# UEE Visual Architecture Poster

```mermaid
graph TD
    subgraph Clients
        Web[Web UI]
        Mob[Mobile]
        AI[AI Agents]
        CLI[UEE CLI]
    end

    subgraph "API Gateway (ASP.NET Core)"
        Auth[Auth Middleware]
        Ten[Tenant Resolution]
        GQL[GraphQL endpoint]
        Rest[REST Endpoint]
    end

    subgraph "Core Engine"
        Cmd[Command Bus]
        Qry[Query Bus]
        
        subgraph "Write Side (Domain)"
            Agg[Aggregates]
            Rules[Domain Rules]
            WASM[WASM Host (Validation)]
        end
        
        subgraph "Persistence"
            ES[(MongoDB EventStore)]
            Snap[(Snapshot Store)]
            Outbox[Transactional Outbox]
        end
    end

    subgraph "The Nervous System"
        Redis[Redis Streams]
        DLQ[Dead Letter Queue]
    end

    subgraph "Reactors & Projections"
        Proj_Mongo[Read Model Builder]
        Proj_Vector[Vector Embedder]
        React_WASM[WASM Reactors]
        React_Notifications[Notification Service]
    end

    subgraph "Read Side"
        ReadDB[(MongoDB ReadModels)]
        VecDB[(Qdrant VectorStore)]
        Cache[Redis L2 Cache]
    end

    Clients --> Auth
    Auth --> Ten --> GQL & Rest
    
    GQL & Rest -- Command --> Cmd
    Cmd --> Agg
    Agg -- Validate --> WASM
    Agg --> ES & Outbox
    
    Outbox -- Publish --> Redis
    Redis --> Proj_Mongo & Proj_Vector & React_WASM & React_Notifications
    
    Proj_Mongo --> ReadDB
    Proj_Vector --> VecDB
    
    RunTime_Queries -- Query --> Qry
    Qry --> Cache
    Cache -- Miss --> ReadDB & VecDB
```

### Key Flows
1.  **Command Flow:** Client -> API -> CommandBus -> Aggregate -> EventStore.
2.  **Projection Flow:** EventStore -> Redis -> Projector -> ReadModel.
3.  **Query Flow:** Client -> API -> Cache -> ReadModel.
