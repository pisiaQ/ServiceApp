using ServiceApp.Entities;

namespace ServiceApp.Repositories
{
    public class CustomerRepository
    {
        private readonly List<Customer> _Customers = new();

        public void Add(Customer customer)
        {
            customer.Id = _Customers.Count + 1;
            _Customers.Add(customer);
        }

        public Customer GetById(int id)
        {
            return _Customers.Single(item=> item.Id == id);
        }

        public void Save()
        {
            foreach (var customer in _Customers)
            {
                Console.WriteLine(customer);
            }
        }
    }
}
