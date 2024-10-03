using Linked_Gates.Models;
using Linked_Gates.Repository;

namespace Linked_Gates.Service
{

    public class DeviceService : IService
    {
        IDeviceRepository repository;
        public DeviceService(IDeviceRepository repository)
        {
            this.repository = repository;
        }
        public void AddDevice(Device device)
        {
            repository.AddDevice(device);
        }

        public List<Device> GetAllDevices()
        {
            return repository.GetAllDevices();
        }

        public Device GetDeviceById(int id)
        {
           return repository.GetDeviceById(id);
        }

        public List<Property> GetPropertiesByCategoryId(int categoryId)
        {
            return repository.GetPropertiesByCategoryId(categoryId);
        }

        public void SaveChanges()
        {
            repository.SaveChanges();
        }

        public void UpdateDevice(Device device)
        {
            repository.UpdateDevice(device);
        }
    }
}
