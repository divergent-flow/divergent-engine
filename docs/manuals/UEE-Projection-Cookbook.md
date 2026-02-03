# UEE Projection Cookbook

## 📽️ Building Read Models

Projections turn your event stream into queryable documents.

### Concept: The "Projector"

A Projector is a class (or function) that listens to specific events and updates a Mongo collection.

### Recipe 1: The "Entity Current State" (Standard)

**Goal:** Maintain a document mirroring the latest version of an entity.

```csharp
public class TaskProjector : IProjector
{
    public async Task Handle(EventEnvelope<TaskCreated> evt)
    {
        var doc = new TaskReadModel { 
            Id = evt.EntityId, 
            Title = evt.Data.Title,
            Status = "New"
        };
        await _mongo.InsertOneAsync(doc);
    }

    public async Task Handle(EventEnvelope<TaskCompleted> evt)
    {
        var update = Builders<TaskReadModel>.Update
            .Set(x => x.Status, "Completed")
            .Set(x => x.CompletedAt, evt.Timestamp);
        
        await _mongo.UpdateOneAsync(x => x.Id == evt.EntityId, update);
    }
}
```

### Recipe 2: The "Aggregation" (Dashboard Stats)

**Goal:** Keep a running count of open tasks per user.

```csharp
public async Task Handle(EventEnvelope<TaskCreated> evt)
{
    // Increment specific counter atomically
    var filter = Builders<UserStats>.Filter.Eq(x => x.UserId, evt.UserId);
    var update = Builders<UserStats>.Update.Inc(x => x.OpenTasks, 1);
    
    await _mongo.UpdateOneAsync(filter, update, new UpdateOptions { IsUpsert = true });
}
```

### Recipe 3: The "Lookup Table" (Search)

**Goal:** Optimize search by keyword.

Projections can write to Elasticsearch or a specialized "Search" collection that flattens complex data structures into searchable strings.

### Recipe 4: The Type Registry (System Metadata)

**Goal:** Maintain a fast lookup of `Code` -> `EntityId` for all EntityTypes in the system.

This projection listens specifically for changes to entities of type `uee:entityType`.

```csharp
public class TypeRegistryProjector : IProjector
{
    // In-Memory cache for super fast resolution
    private static ConcurrentDictionary<string, Guid> _typeCache; 

    public async Task Handle(EventEnvelope<EntityCreated> evt)
    {
        // Check if this is a Type Definition
        if (evt.Data.EntityTypeId == SystemTypes.EntityType) 
        {
             var code = evt.Data.Attributes["code"].ToString();
             
             // Update Mongo Index
             await _mongo.TypeIndex.UpsertAsync(code, evt.EntityId);
             
             // Update Local Cache
             _typeCache[code] = evt.EntityId;
        }
    }
}
```
