using Linked_Gates.Models;

namespace Linked_Gates.ViewModel
{
    public class DeviceViewModel
    {
        public int ID { get; set; }
        public string DeviceName { get; set; }
        public DateTime AcquisitionDate { get; set; }
        public string Memo { get; set; }
        public int CategoryID { get; set; }
        public int PropertyID { get; set; }
        public List<DeviceCategories>? Categories { get; set; }
        public List<Property>? Properties { get; set; }
    }
}
