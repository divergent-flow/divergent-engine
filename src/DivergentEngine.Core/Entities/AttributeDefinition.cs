using MongoDB.Bson.Serialization.Attributes;

namespace DivergentEngine.Core.Entities;

/// <summary>
/// Defines the schema for a single attribute in an entity type.
/// </summary>
public class AttributeDefinition
{
    /// <summary>
    /// Data type (e.g., "string", "number", "boolean", "date", "array", "object").
    /// </summary>
    [BsonElement("type")]
    public required string Type { get; set; }

    /// <summary>
    /// Human-readable label for this attribute.
    /// </summary>
    [BsonElement("label")]
    public string? Label { get; set; }

    /// <summary>
    /// Description of this attribute.
    /// </summary>
    [BsonElement("description")]
    public string? Description { get; set; }

    /// <summary>
    /// Whether this attribute is required.
    /// </summary>
    [BsonElement("required")]
    public bool Required { get; set; } = false;

    /// <summary>
    /// Default value for this attribute.
    /// </summary>
    [BsonElement("default")]
    public object? Default { get; set; }

    /// <summary>
    /// Validation rules (min, max, pattern, enum, etc.).
    /// </summary>
    [BsonElement("validation")]
    public Dictionary<string, object>? Validation { get; set; }
}
