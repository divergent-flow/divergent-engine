using MongoDB.Bson.Serialization.Attributes;

namespace DivergentEngine.Core.Entities;

/// <summary>
/// System metadata for entities. Tracks creation, modification, and lifecycle information.
/// </summary>
public class EntityMetadata
{
    /// <summary>
    /// When the entity was created (UTC).
    /// </summary>
    [BsonElement("createdDate")]
    public DateTime CreatedDate { get; set; } = DateTime.UtcNow;

    /// <summary>
    /// User who created the entity (GUID).
    /// </summary>
    [BsonElement("createdBy")]
    public string CreatedBy { get; set; } = string.Empty;

    /// <summary>
    /// When the entity was last modified (UTC).
    /// </summary>
    [BsonElement("modifiedDate")]
    public DateTime? ModifiedDate { get; set; }

    /// <summary>
    /// User who last modified the entity (GUID).
    /// </summary>
    [BsonElement("modifiedBy")]
    public string? ModifiedBy { get; set; }

    /// <summary>
    /// When the entity was soft-deleted (UTC). Null if not deleted.
    /// </summary>
    [BsonElement("deletedDate")]
    public DateTime? DeletedDate { get; set; }

    /// <summary>
    /// User who deleted the entity (GUID).
    /// </summary>
    [BsonElement("deletedBy")]
    public string? DeletedBy { get; set; }

    /// <summary>
    /// Whether the entity is archived (hidden from main views but not deleted).
    /// </summary>
    [BsonElement("isArchived")]
    public bool IsArchived { get; set; } = false;

    /// <summary>
    /// Version number for optimistic concurrency control.
    /// Incremented on each update.
    /// </summary>
    [BsonElement("version")]
    public int Version { get; set; } = 1;
}
