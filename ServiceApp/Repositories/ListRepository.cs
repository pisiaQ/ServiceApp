﻿using ServiceApp.Entities;

namespace ServiceApp.Repositories;

public class ListRepository<T> where T : class, IEntity, new()
{
    private readonly List<T> _items = new();

    public IEnumerable<T> GetAll()
    {
        return _items.ToList();
    }
    public void Add(T item)
    {
        item.Id = _items.Count + 1;
        _items.Add(item);
    }

    public void Remove(T item)
    {
        _items.Remove(item);
    }
    public T GetById(int id)
    {
        return _items.Single(item => item.Id == id);
    }
}