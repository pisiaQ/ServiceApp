using ServiceApp.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServiceApp.Repositories
{
    public class DeviceRepository
    {
        private readonly List<Device> _Devices = new();

        public void Add(Device Device)
        {
            Device.Id = _Devices.Count + 1;
            _Devices.Add(Device);
        }

        public void Save()
        {
            foreach (var Device in _Devices)
            {
                Console.WriteLine(Device);
            }
        }
    }
}
