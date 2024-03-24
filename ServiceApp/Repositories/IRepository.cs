using ServiceApp.Entities;

namespace ServiceApp.Repositories;

public interface IRepository<T> : IReadRepository<T>, IWriteRepository<T>
    where T : class, IEntity
{
}