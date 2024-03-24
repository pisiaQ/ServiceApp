namespace ServiceApp.Entities;

public class Device : Customer
{
    public string SerialNumber { get; set; }
    public int ManufactureDate { get; set; }
    public string Manufacturer { get; set; }
    public string Model { get; set; }
    public string DeviceFault { get; set; }

    public override string ToString() => $"Id: {Id}, Name: {Name}, Device Fault: {DeviceFault}, Serial Number: {SerialNumber}, Manufacture Date: {ManufactureDate}, Manufacturer: {Manufacturer}, Model: {Model}";
}