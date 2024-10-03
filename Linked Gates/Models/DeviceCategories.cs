using Microsoft.EntityFrameworkCore;

namespace Linked_Gates.Models
{
    public class DeviceCategories
    {
        
        public int ID { get; set; }
        public string CategoryName { get; set; } 
        public ICollection<CategoryProperty> CategoryProperties { get; set; } 
        public ICollection<Device> Devices { get; set; }
    }
}
