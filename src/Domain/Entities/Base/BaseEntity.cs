using CleanApi.Domain.Events.Base;
using System.ComponentModel.DataAnnotations.Schema;

namespace CleanApi.Domain.Entities.Base;

public abstract class BaseEntity
{
    public string Id { get; set; } = Guid.NewGuid().ToString();

    private readonly List<BaseEvent> _domainEvents = [];

    [NotMapped]
    public IReadOnlyCollection<BaseEvent> DomainEvents => _domainEvents.AsReadOnly();

    public void AddDomainEvent(BaseEvent domainEvent)
    {
        _domainEvents.Add(domainEvent);
    }

    public void RemoveDomainEvent(BaseEvent domainEvent)
    {
        _domainEvents.Remove(domainEvent);
    }

    public void ClearDomainEvents()
    {
        _domainEvents.Clear();
    }
}
