using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace DivergentEngine.Core.Entities;

/// <summary>
/// Represents the universal entity model. All content types (tasks, notes, collections, etc.)
/// are stored as entities with flexible attributes.
/// </summary>
/// <remarks>
/// This is the foundation of the Universal Entity Engine. Instead of separate tables for
/// tasks, notes, reminders, etc., everything is an entity with a type and dynamic attributes.
/// See docs/ENTITY-ENGINE-VISION.md for design rationale.
/// </remarks>
public class Entity : IEntity
{
    /// <summary>
    /// MongoDB internal primary key. Used for database-level operations and indexing.
    /// Do not expose this in the public API.
    /// </summary>
    [BsonId]
    [BsonRepresentation(BsonType.ObjectId)]
    public ObjectId _id { get; set; }

    /// <summary>
    /// Application-level unique identifier (GUID). Use this in all public APIs.
    /// </summary>
    /// <remarks>
    /// This is the stable public ID for entities. GUIDs are generated on creation and never change.
    /// See docs/ADR-ID-STRATEGY.md for dual-ID rationale.
    /// </remarks>
    [BsonElement("id")]
    public required string Id { get; set; }

    /// <summary>
    /// The type of entity (e.g., "task", "note", "collection", "capture").
    /// References an EntityType definition.
    /// </summary>
    [BsonElement("entityTypeId")]
    public required string EntityTypeId { get; set; }

    /// <summary>
    /// Tenant identifier. For individual users, this equals OwnerId.
    /// For team users, multiple users share the same TenantId.
    /// </summary>
    /// <remarks>
    /// Multi-tenancy strategy:
    /// - Single user: TenantId = UserId (data isolation)
    /// - Team: TenantId = TeamId (shared workspace)
    /// All queries MUST filter by TenantId for security.
    /// </remarks>
    [BsonElement("tenantId")]
    public required string TenantId { get; set; }

    /// <summary>
    /// User who owns/created this entity. Used for attribution and permissions.
    /// </summary>
    [BsonElement("ownerId")]
    public required string OwnerId { get; set; }

    /// <summary>
    /// Flexible key-value store for entity-specific data.
    /// Different entity types have different attributes.
    /// </summary>
    /// <example>
    /// Task: { "title": "Finish report", "priority": 5, "dueDate": "2026-01-20" }
    /// Note: { "title": "Meeting notes", "content": "Discussed Q1 goals" }
    /// Collection: { "name": "Work", "color": "#3B82F6", "icon": "briefcase" }
    /// </example>
    [BsonElement("attributes")]
    public Dictionary<string, object> Attributes { get; set; } = new();

    /// <summary>
    /// Legacy metadata container.
    /// </summary>
    [BsonElement("metadata")]
    public EntityMetadata Metadata { get; set; } = new();

    /// <summary>
    /// Version number for optimistic concurrency and event sourcing.
    /// Incremented on every update.
    /// </summary>
    [BsonElement("version")]
    public int Version { get; set; } = 1;

    /// <summary>
    /// When the entity was created (UTC).
    /// </summary>
    [BsonElement("createdAt")]
    public DateTime CreatedAt { get; set; } = DateTime.UtcNow;

    /// <summary>
    /// Relationships to other entities (collections, parent/child, links, etc.)
    /// </summary>
    [BsonElement("relationships")]
    public EntityRelationships Relationships { get; set; } = new();

    // IEntity Implementation
    string IEntity.EntityId 
    { 
        get => Id; 
        set => Id = value; 
    }
    
    DateTime IEntity.Created 
    { 
        get => CreatedAt; 
        set => CreatedAt = value; 
    }

    // IEntityRelationships Implementation
    List<string> IEntityRelationships.CollectionIds 
    { 
        get => Relationships.CollectionIds; 
        set => Relationships.CollectionIds = value; 
    }

    string? IEntityRelationships.ParentEntityId 
    { 
        get => Relationships.ParentEntityId; 
        set => Relationships.ParentEntityId = value; 
    }

    List<string> IEntityRelationships.ChildEntityIds 
    { 
        get => Relationships.ChildEntityIds; 
        set => Relationships.ChildEntityIds = value; 
    }

    List<string> IEntityRelationships.LinkedEntityIds 
    { 
        get => Relationships.LinkedEntityIds; 
        set => Relationships.LinkedEntityIds = value; 
    }

    List<string> IEntityRelationships.Tags 
    { 
        get => Relationships.Tags; 
        set => Relationships.Tags = value; 
    }
}
