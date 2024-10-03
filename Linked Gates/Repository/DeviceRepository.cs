using Linked_Gates.Models;

namespace Linked_Gates.Repository
{
    public class DeviceRepository : IDeviceRepository
    {
        ITdepartmContext context;
        public DeviceRepository(ITdepartmContext context)
        {
            this.context = context; 
        }
        public void AddDevice(Device device)
        {
            context.devices.Add(device);
        }

        public List<Device> GetAllDevices()
        {
            return context.devices.ToList();
        }

        public Device GetDeviceById(int id)
        {
            return context.devices.Where(p => p.ID == id).FirstOrDefault();
        }

        public List<Property> GetPropertiesByCategoryId(int categoryId)
        {
           return context.categoryProperties.Where(p=>p.CategoryID== categoryId).Select(p=>p.Property).ToList();
        }

        public void SaveChanges()
        {
            context.SaveChanges();
        }

        public void UpdateDevice(Device device)
        {
           context.Update(device);
        }
    }
}
