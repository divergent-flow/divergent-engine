using System;
namespace DivergentEngine.Core.Entities;
public interface IEntity : IEntityRelationships
{
    ObjectId _id { get; set; }
    string EntityId { get; set; }
    string EntityTypeId { get; set; }
    string TenantId { get; set; }
    string OwnerId { get; set; }
    Dictionary<string, object> Attributes { get; set; }
    int Version { get; set; }
    DateTime CreatedAt { get; set; }
   
}