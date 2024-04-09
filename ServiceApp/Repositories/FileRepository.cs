using ServiceApp.Data.Entities;
using ServiceApp.Data.Repositories;
using System.Text.Json;

public class FileRepository<T> : IRepository<T>
        where T : class, IEntity, new()
{
    public event EventHandler<T>? ItemAdded;
    public event EventHandler<T>? ItemRemoved;
    private readonly List<T> _items;
    private readonly string path;

    public FileRepository()
    {
        _items = new List<T>();
        path = $"{typeof(T).Name}_save.json";
        Read();
    }

    public IEnumerable<T> GetAll()
    {
        return _items.ToList();
    }

    public void Add(T item)
    {
        item.Id = GenerateUniqueId();
        _items.Add(item);
        ItemAdded?.Invoke(this, item);
        Save();
    }

    public T? GetById(int id)
    {
        return _items.FirstOrDefault(item => item.Id == id);
    }

    public void Remove(T item)
    {
        _items.Remove(item);
        ItemRemoved?.Invoke(this, item);
        Save();
    }

    public void Save()
    {
        var options = new JsonSerializerOptions { WriteIndented = true };
        var objectsSerialized = JsonSerializer.Serialize(_items, options);
        File.WriteAllText(path, objectsSerialized);
    }

    private void Read()
    {
        if (File.Exists(path))
        {
            var objectsSerialized = File.ReadAllText(path);
            _items.AddRange(JsonSerializer.Deserialize<List<T>>(objectsSerialized));
        }
    }

    private int GenerateUniqueId()
    {
        return _items.Count > 0 ? _items.Max(item => item.Id) + 1 : 1;
    }
}
