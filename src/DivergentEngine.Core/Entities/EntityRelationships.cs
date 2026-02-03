using MongoDB.Bson.Serialization.Attributes;

namespace DivergentEngine.Core.Entities;

/// <summary>
/// Defines relationships between entities. Supports collections, hierarchies, and links.
/// </summary>
public class EntityRelationships : IEntityRelationships
{
    /// <summary>
    /// Collections this entity belongs to. Many-to-many relationship.
    /// </summary>
    /// <example>
    /// ["work-collection-guid", "urgent-collection-guid", "personal-collection-guid"]
    /// </example>
    [BsonElement("collectionIds")]
    public List<string> CollectionIds { get; set; } = new();

    /// <summary>
    /// Parent entity ID. Used for hierarchical relationships (e.g., nested collections, subtasks).
    /// </summary>
    /// <remarks>
    /// Examples:
    /// - Collection hierarchy: "Projects" → "2026 Projects" → "Q1 Planning"
    /// - Task hierarchy: "Finish report" → "Write executive summary"
    /// Null for root-level entities.
    /// </remarks>
    [BsonElement("parentEntityId")]
    public string? ParentEntityId { get; set; }

    /// <summary>
    /// Child entity IDs. Inverse of ParentEntityId for efficient lookups.
    /// </summary>
    /// <remarks>
    /// This is denormalized for performance. When ParentEntityId changes,
    /// both parent and child must be updated.
    /// </remarks>
    [BsonElement("childEntityIds")]
    public List<string> ChildEntityIds { get; set; } = new();

    /// <summary>
    /// Arbitrary links to other entities (references, related items, etc.).
    /// </summary>
    /// <example>
    /// Task links to a note: ["note-entity-guid"]
    /// Collection links to a project: ["project-entity-guid"]
    /// </example>
    [BsonElement("linkedEntityIds")]
    public List<string> LinkedEntityIds { get; set; } = new();

    /// <summary>
    /// Tags for this entity. Tags are lightweight, non-hierarchical groupings.
    /// </summary>
    /// <remarks>
    /// Tags vs. Collections:
    /// - Tags: Lightweight, ad-hoc, many per entity (e.g., "urgent", "waiting-on-review")
    /// - Collections: Structured, curated, used for organization (e.g., "Work", "Personal")
    /// </remarks>
    [BsonElement("tags")]
    public List<string> Tags { get; set; } = new();
}
