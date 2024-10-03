namespace Linked_Gates.Models
{
    public class DevicePropertyValue
    {
        public int ID { get; set; }
        public int DeviceID { get; set; }
        public Device Device { get; set; }
        public int PropertyID { get; set; }
        public Property Property { get; set; }
        public string PropertyValue { get; set; }
    }
}
