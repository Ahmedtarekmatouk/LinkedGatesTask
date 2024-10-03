namespace Linked_Gates.Models
{
    public class Property
    {
        public int ID { get; set; }
        public string PropertyDescription { get; set; } 
        public ICollection<CategoryProperty> CategoryProperties { get; set; }

        public ICollection<DevicePropertyValue> DevicePropertyValues { get; set; }
    }
}
