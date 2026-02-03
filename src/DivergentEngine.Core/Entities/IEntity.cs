using System;
using System.Collections.Generic;

namespace DivergentEngine.Core.Entities
{
    /// <summary>
    /// The core contract for all entities in the Universal Entity Engine.
    /// Represents a snapshot of state at a specific version.
    /// </summary>
    public interface IEntity
    {
        /// <summary>
        /// The stable, unique identifier for the aggregate root.
        /// This GUID remains constant across all versions of the entity.
        /// </summary>
        Guid Id { get; }

        /// <summary>
        /// The GUID of the EntityType (the definition that describes this entity).
        /// </summary>
        Guid EntityTypeId { get; }

        /// <summary>
        /// The optimistic concurrency version. 
        /// 0 = New/Draft. Increments by 1 for every event applied.
        /// </summary>
        long Version { get; }

        /// <summary>
        /// The ID of the Tenant this entity belongs to.
        /// Null implies a Global/System entity (like a base EntityType).
        /// </summary>
        Guid? TenantId { get; }

        /// <summary>
        /// Optional User ID of the owner.
        /// </summary>
        Guid? OwnerId { get; }

        /// <summary>
        /// UTC Timestamp of creation.
        /// </summary>
        DateTimeOffset CreatedAt { get; }

        /// <summary>
        /// User ID who created this version.
        /// </summary>
        Guid CreatedBy { get; }

        /// <summary>
        /// The schema-flexible payload.
        /// </summary>
        IDictionary<string, object> Attributes { get; }

        /// <summary>
        /// System or Plugin metadata (Tags, TTL, Source).
        /// Separate from business data.
        /// </summary>
        IDictionary<string, object> Metadata { get; }
    }
}