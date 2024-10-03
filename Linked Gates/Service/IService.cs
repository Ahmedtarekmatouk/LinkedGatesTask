using Linked_Gates.Models;

namespace Linked_Gates.Service
{
    public interface IService
    {
        List<Device> GetAllDevices();
        Device GetDeviceById(int id);
        List<Property> GetPropertiesByCategoryId(int categoryId);
        void AddDevice(Device device);
        void UpdateDevice(Device device);
        void SaveChanges();
    }
}
