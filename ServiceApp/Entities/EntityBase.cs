using ServiceApp.Repositories;

namespace ServiceApp.Data.Entities;

public abstract class EntityBase : IEntity
{
    public int Id { get; set; }
}