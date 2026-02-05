using MediatR;

namespace MultiVendor.Domain.Common;

public abstract class DomainEvent : INotification
{
    public DateTime OccurredOn { get; protected set; } = DateTime.UtcNow;
}
