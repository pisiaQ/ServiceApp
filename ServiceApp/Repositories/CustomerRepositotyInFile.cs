using ServiceApp.Entities;
using ServiceApp.Repositories;
using System.Text.Json;

namespace ServiceApp.Repositories;

public class CustomerRepositoryInFile<T> : IRepository<T> where T : class, IEntity
{
    private List<T>? items = new List<T>();
    public event EventHandler<T> ItemAdded;
    public event EventHandler<T> ItemDeleted;
    public void Add(T item)
    {
        items.Add(item);
        item.Id = items.Count();
        ItemAdded?.Invoke(this, item);
    }

    public IEnumerable<T> GetAll()
    {
        if (File.Exists("customers.json"))
        {
            using (var reader = File.OpenText("customers.json"))
            {
                var line = reader.ReadLine();
                items = JsonSerializer.Deserialize<List<T>>(line);
            }

        }
        return items;
    }

    public T GetById(int id)
    {
        return items[id - 1];
    }

    public void Remove(T item)
    {
        items.RemoveAt(item.Id - 1);
        for (int i = 0; i < items.Count; i++)
        {
            items[i].Id = i + 1;
        }
        ItemDeleted?.Invoke(this, item);
    }

    public void Save()
    {
        using (StreamWriter writer = new StreamWriter($"customers.json", false))
        {
            var json = JsonSerializer.Serialize(items);
            writer.WriteLine(json);
        }

    }
}