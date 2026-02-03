using System;

namespace DivergentEngine.Core.Entities;

// Temporary class to support legacy application code during refactor
public class EntityMetadata
{
    public string CreatedBy { get; set; } = string.Empty;
    public DateTime CreatedDate { get; set; } = DateTime.UtcNow;
    public string? ModifiedBy { get; set; }
    public DateTime? ModifiedDate { get; set; }
    public string? DeletedBy { get; set; }
    public DateTime? DeletedDate { get; set; }
    public bool IsArchived { get; set; }
    public int Version { get; set; } = 1;
}
