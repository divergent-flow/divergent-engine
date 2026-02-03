using MongoDB.Bson.Serialization.Attributes;

namespace DivergentEngine.Core.Entities;

public interface IEntityRelationships
{
    List<string> CollectionIds { get; set; }
    string? ParentEntityId { get; set; }
    List<string> ChildEntityIds { get; set; }
    List<string> LinkedEntityIds { get; set; }
    List<string> Tags { get; set; }
}
