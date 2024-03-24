using ServiceApp.Data;
using ServiceApp.Entities;
using ServiceApp.Repositories;

var customerRepository = new SqlRepository<Customer>(new ServiceAppDbContext());
AddCustomer(customerRepository);
AddDevice(customerRepository);
WriteAllToConsole(customerRepository);
static void AddCustomer(IRepository<Customer> customerRepository)
{
    customerRepository.Add(new Customer { Name = "Amelia" });
    customerRepository.Add(new Customer { Name = "Agnieszka" });
    customerRepository.Add(new Customer { Name = "Alina" });
    customerRepository.Save();
}

static void AddDevice(IWriteRepository<Device> deviceRepository)
{
    deviceRepository.Add(new Device { Name = "Laptop", DeviceFault = "Display Fault", SerialNumber = "123D", ManufactureDate = 2021 , Manufacturer = "Acer" , Model = "Aspire 3" }); 
    deviceRepository.Add(new Device { Name = "Printer", DeviceFault = "Display Fault", SerialNumber = "321F", ManufactureDate = 2019, Manufacturer = "EPSON", Model = "EcoTank L3256" });
    deviceRepository.Add(new Device { Name = "Oscilloscope", DeviceFault = "Display Fault", SerialNumber = "850X", ManufactureDate = 2017, Manufacturer = "UNI-T", Model = "UDT2052CL+" });
    deviceRepository.Save();
}

static void WriteAllToConsole(IReadRepository<IEntity> repository)
{
    var items = repository.GetAll();
    foreach (var item in items)
    {
        Console.WriteLine(item);
    }
}