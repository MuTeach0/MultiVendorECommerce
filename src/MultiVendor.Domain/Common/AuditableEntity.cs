namespace MultiVendor.Domain.Common;

public abstract class AuditableEntity : Entity
{
    protected AuditableEntity() : base() { }

    protected AuditableEntity(Guid id) : base(id) { }

    public DateTime CreatedAt { get; set; }
    public DateTime? UpdatedAt { get; set; }
    public bool IsDeleted { get; set; }

    public string? CreatedBy { get; set; }
    public string? LastModifiedBy { get; set; }
}