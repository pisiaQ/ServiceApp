using ServiceApp.Data.Entities;
using ServiceApp.Data.Repositories;
using ServiceApp.Entities;

namespace ServiceApp.Repositories.Extensions;

public static class RepositoryExtensions
{
    public static void AddBatch<T>(this IRepository<T> repository, IEnumerable<T> items)
        where T : class, IEntity
    {
        foreach (var item in items)
        {
            repository.Add(item);
        }

        repository.Save();
    }
}