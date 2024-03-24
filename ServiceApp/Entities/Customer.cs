namespace ServiceApp.Entities;

public class Customer : EntityBase
{
    public string Name { get; set; }
    public override string ToString() => $"Id: {Id} -> Name: {Name}";
}