namespace DivergentEngine.Core.Entities;
public interface IEntity
{
    ObjectId _id { get; set; }
    string Id { get; set; }
    string EntityTypeId { get; set; }
    string TenantId { get; set; }
    string OwnerId { get; set; }
    Dictionary<string, object> Attributes { get; set; }
    EntityMetadata Metadata { get; set; }
    EntityRelationships Relationships { get; set; }
}