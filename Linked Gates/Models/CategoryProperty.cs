namespace Linked_Gates.Models
{
    public class CategoryProperty
    {
        public int ID { get; set; }

        public int CategoryID { get; set; } 
        public DeviceCategories Category { get; set; }

        public int PropertyID { get; set; } 
        public Property Property { get; set; }
    }
}
