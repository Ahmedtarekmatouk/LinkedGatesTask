namespace Linked_Gates.Models
{
    public class Device
    {
        public int ID { get; set; }
        public string DeviceName { get; set; } 
        public DateTime AcquisitionDate { get; set; } 
        public string Memo { get; set; } 
        public int CategoryID { get; set; }
        public DeviceCategories Category { get; set; }
        public ICollection<DevicePropertyValue> DevicePropertyValues { get; set; }
    }
}
