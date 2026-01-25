using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace DivergentEngine.Core.Entities;

/// <summary>
/// Defines a type of entity and its schema. Acts as a template for entities.
/// </summary>
/// <remarks>
/// EntityTypes are meta-definitions that describe what kinds of entities can exist.
/// Think of them as "schemas" or "classes" for entities.
/// 
/// Examples:
/// - "task" entity type: Has attributes like title, priority, dueDate, status
/// - "note" entity type: Has attributes like title, content, tags
/// - "collection" entity type: Has attributes like name, color, icon
/// 
/// New entity types can be added without code changes - just insert a new EntityType document.
/// See docs/ENTITY-ENGINE-VISION.md for design philosophy.
/// </remarks>
public class EntityType
{
    /// <summary>
    /// MongoDB internal primary key.
    /// </summary>
    [BsonId]
    [BsonRepresentation(BsonType.ObjectId)]
    public ObjectId _id { get; set; }

    /// <summary>
    /// Unique identifier for this entity type (e.g., "task", "note", "collection").
    /// </summary>
    [BsonElement("id")]
    public required string Id { get; set; }

    /// <summary>
    /// Tenant this entity type belongs to. Null for system-wide types.
    /// </summary>
    /// <remarks>
    /// System types (null TenantId): Available to all tenants (e.g., "task", "note")
    /// Custom types (specific TenantId): Only available to that tenant (e.g., "client-project")
    /// </remarks>
    [BsonElement("tenantId")]
    public string? TenantId { get; set; }

    /// <summary>
    /// Human-readable name (e.g., "Task", "Note", "Collection").
    /// </summary>
    [BsonElement("name")]
    public required string Name { get; set; }

    /// <summary>
    /// Plural form of the name (e.g., "Tasks", "Notes", "Collections").
    /// </summary>
    [BsonElement("namePlural")]
    public required string NamePlural { get; set; }

    /// <summary>
    /// Description of this entity type.
    /// </summary>
    [BsonElement("description")]
    public string? Description { get; set; }

    /// <summary>
    /// Icon identifier (e.g., "check-circle", "note", "folder").
    /// Uses Phosphor Icons naming convention.
    /// </summary>
    [BsonElement("icon")]
    public string? Icon { get; set; }

    /// <summary>
    /// Color associated with this entity type (hex code).
    /// </summary>
    [BsonElement("color")]
    public string? Color { get; set; }

    /// <summary>
    /// Schema definition for attributes. Defines expected structure.
    /// </summary>
    /// <remarks>
    /// This is a JSON Schema-like definition that describes:
    /// - What attributes are expected
    /// - Data types for each attribute
    /// - Validation rules
    /// - Default values
    /// 
    /// Example for "task":
    /// {
    ///   "title": { "type": "string", "required": true },
    ///   "priority": { "type": "number", "min": 1, "max": 5, "default": 3 },
    ///   "dueDate": { "type": "date" },
    ///   "status": { "type": "string", "enum": ["todo", "in-progress", "done"] }
    /// }
    /// </remarks>
    [BsonElement("attributeSchema")]
    public Dictionary<string, AttributeDefinition> AttributeSchema { get; set; } = new();

    /// <summary>
    /// Whether this entity type is active and can be used.
    /// </summary>
    [BsonElement("isActive")]
    public bool IsActive { get; set; } = true;

    /// <summary>
    /// System metadata.
    /// </summary>
    [BsonElement("metadata")]
    public EntityMetadata Metadata { get; set; } = new() { CreatedBy = string.Empty };
}
