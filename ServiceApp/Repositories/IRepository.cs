﻿using ServiceApp.Data.Entities;
using ServiceApp.Entities;
using ServiceApp.Repositories;

namespace ServiceApp.Data.Repositories;

public interface IRepository<T> : IReadRepository<T>, IWriteRepository<T>
    where T : class, IEntity
{
    public event EventHandler<T>? ItemAdded;

    public event EventHandler<T>? ItemRemoved;
}