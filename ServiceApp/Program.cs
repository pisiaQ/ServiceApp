using ServiceApp.Entities;
using ServiceApp.Repositories;
using System;

class ServcieApp
{
    public delegate void NoDataEventHandler();
    public static event NoDataEventHandler NoCustomersDataEvent;
    public static event NoDataEventHandler NoDevicesDataEvent;

    static void Main(string[] args)
    {
        
        NoCustomersDataEvent += HandleNoCustomersDataEvent;
        NoDevicesDataEvent += HandleNoDevicesDataEvent;

        var customerRepository = new CustomerRepositoryInFile<Customer>();
        var deviceRepository = new DeviceRepositoryInFile<Device>();

        Console.WriteLine("\tWelcome to SERVICE APP");
        Console.WriteLine("This program is the service database");

        string input;
        do
        {
            Console.WriteLine("\n================MENU================");
            Console.WriteLine("\n-Customer View-");
            Console.WriteLine("1. Display all customers");
            Console.WriteLine("2. Add customer");
            Console.WriteLine("3. Remove customer");

            Console.WriteLine("\n-Device View-");
            Console.WriteLine("4. Display all devices");
            Console.WriteLine("5. Add device");
            Console.WriteLine("6. Remove device");

            Console.WriteLine("\nPress q to exit program: ");

            input = Console.ReadLine();
            Console.WriteLine();

            switch (input)
            {
                case "1":
                    WriteAllToConsole(customerRepository, NoCustomersDataEvent);
                    break;
                case "2":
                    AddCustomer(customerRepository);
                    break;
                case "3":
                    RemoveCustomer(customerRepository);
                    break;
                case "4":
                    WriteAllToConsole(deviceRepository, NoDevicesDataEvent);
                    break;
                case "5":
                    AddDevice(deviceRepository);
                    break;
                case "6":
                    RemoveDevice(deviceRepository);
                    break;
                default:
                    Console.WriteLine("Invalid input. Please try again.");
                    break;
            }
        } while (input != "q");
    }

    static void HandleNoCustomersDataEvent()
    {
        Console.WriteLine("There are no customers in the database.");
    }

    static void HandleNoDevicesDataEvent()
    {
        Console.WriteLine("There are no devices in the database.");
    }

    static void RemoveDevice(IRepository<Device> deviceRepository)
    {
        Console.WriteLine("Enter the ID of the device to remove: ");
        if (int.TryParse(Console.ReadLine(), out int deviceId))
        {
            var deviceToRemove = deviceRepository.GetById(deviceId);
            if (deviceToRemove != null)
            {
                deviceRepository.Remove(deviceToRemove);
                Console.WriteLine("Device removed successfully");
            }
            else
            {
                Console.WriteLine("Device not found");
            }
        }
        else
        {
            Console.WriteLine("Invalid input. Please enter a valid device ID.");
        }
        deviceRepository.Save();
    }

    static void AddDevice(IRepository<Device> deviceRepository)
    {
        Console.WriteLine("Enter device details:");
        Console.Write("Name: ");
        string name = Console.ReadLine();

        Console.Write("Device Fault: ");
        string deviceFault = Console.ReadLine();

        Console.Write("Serial Number: ");
        string serialNumber = Console.ReadLine();

        Console.Write("Manufacture Year (YYYY): ");
        if (!int.TryParse(Console.ReadLine(), out int manufactureYear) || manufactureYear < 0)
        {
            Console.WriteLine("Invalid year format. Please enter a valid year.");
            return;
        }

        Console.Write("Manufacturer: ");
        string manufacturer = Console.ReadLine();

        Console.Write("Model: ");
        string model = Console.ReadLine();

        var newDevice = new Device
        {
            Name = name,
            DeviceFault = deviceFault,
            SerialNumber = serialNumber,
            ManufactureDate = manufactureYear,
            Manufacturer = manufacturer,
            Model = model
        };

        deviceRepository.Add(newDevice);

        Console.WriteLine("Device added successfully");
        deviceRepository.Save();
    }

    static void WriteAllToConsole(IReadRepository<IEntity> repository, NoDataEventHandler noDataEvent)
    {
        var items = repository.GetAll();
        if (items == null || !items.Any())
        {
            noDataEvent?.Invoke();
            return;
        }

        foreach (var item in items)
        {
            Console.WriteLine(item);
        }
    }

    static void AddCustomer(IRepository<Customer> customerRepository)
    {
        Console.WriteLine("Enter customer details:");
        Console.Write("Name: ");
        string name = Console.ReadLine();
        Console.Write("Last Name: ");
        string lastName = Console.ReadLine();

        var newCustomer = new Customer { Name = name, LastName = lastName };
        customerRepository.Add(newCustomer);

        Console.WriteLine("Customer added successfully");
        customerRepository.Save();
    }

    static void RemoveCustomer(IRepository<Customer> customerRepository)
    {
        Console.WriteLine("Enter the ID of the customer to remove: ");
        if (int.TryParse(Console.ReadLine(), out int customerId))
        {
            var customerToRemove = customerRepository.GetById(customerId);
            if (customerToRemove != null)
            {
                customerRepository.Remove(customerToRemove);
                Console.WriteLine("Customer removed successfully");
            }
            else
            {
                Console.WriteLine("Customer not found");
            }
        }
        else
        {
            Console.WriteLine("Invalid input. Please enter a valid customer ID.");
        }
        customerRepository.Save();
    }
}
