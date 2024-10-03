using Linked_Gates.Models;

namespace Linked_Gates.Repository
{
    public interface IDeviceRepository
    {
            List<Device> GetAllDevices();
            Device GetDeviceById(int id);
            List<Property> GetPropertiesByCategoryId(int categoryId);
            void AddDevice(Device device);
            void UpdateDevice(Device device);
            void SaveChanges();
    }
}
