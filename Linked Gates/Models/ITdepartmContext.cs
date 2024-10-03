using Microsoft.EntityFrameworkCore;

namespace Linked_Gates.Models
{
    public class ITdepartmContext:DbContext
    {
        public DbSet<Device>devices { get; set; }
        public DbSet<DeviceCategories> DeviceCategories { get; set; }
        public DbSet<Property>properties { get; set; }
        public DbSet<DevicePropertyValue> devicePropertyValues { get; set; }
        public DbSet<CategoryProperty> categoryProperties { get; set; }
        public ITdepartmContext(DbContextOptions<ITdepartmContext> options) : base(options)
        {
        }
        public ITdepartmContext() : base() { }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<DeviceCategories>().HasData(
         new DeviceCategories { ID = 1, CategoryName = "Printer" },
         new DeviceCategories { ID = 2, CategoryName = "Laptop" }
     );

            // Seed Property Items
            modelBuilder.Entity<Property>().HasData(
                new Property { ID = 1, PropertyDescription = "HD" },
                new Property { ID = 2, PropertyDescription = "Processor" },
                new Property { ID = 3, PropertyDescription = "RAM" },
                new Property { ID = 4, PropertyDescription = "Display" },
                new Property { ID = 5, PropertyDescription = "IP Address" },
                new Property { ID = 6, PropertyDescription = "Brand" },
                new Property { ID = 7, PropertyDescription = "Current User" },
                new Property { ID = 8, PropertyDescription = "Is Color" }
            );
            modelBuilder.Entity<CategoryProperty>().HasData(
                new CategoryProperty { ID = 1, CategoryID = 1, PropertyID = 5 }, // IP Address for Printer
                new CategoryProperty { ID = 2, CategoryID = 1, PropertyID = 8 }, // Is Color for Printer
                new CategoryProperty { ID = 3, CategoryID = 2, PropertyID = 2 }, // Processor for Laptop
                new CategoryProperty { ID = 4, CategoryID = 2, PropertyID = 3 }, // RAM for Laptop
                new CategoryProperty { ID = 5, CategoryID = 2, PropertyID = 4 }, // Display for Laptop
                new CategoryProperty { ID = 6, CategoryID = 2, PropertyID = 5 }, // IP Address for Laptop
                new CategoryProperty { ID = 7, CategoryID = 2, PropertyID = 6 }, // Brand for Laptop
                new CategoryProperty { ID = 8, CategoryID = 2, PropertyID = 7 }  // Current User for Laptop
            );
            modelBuilder.Entity<Device>().HasData(
                new Device { ID = 1, DeviceName = "HP Laptop 1190", AcquisitionDate = new DateTime(2014, 1, 1), Memo = "Office use", CategoryID = 2 },
                new Device { ID = 2, DeviceName = "Canon Printer X", AcquisitionDate = new DateTime(2021, 5, 12), Memo = "Print room", CategoryID = 1 },
                new Device { ID = 3, DeviceName = "Dell Desktop 3000", AcquisitionDate = new DateTime(2020, 3, 15), Memo = "Gaming", CategoryID = 2 }
            );
            modelBuilder.Entity<DevicePropertyValue>().HasData(
                new DevicePropertyValue { ID = 1, DeviceID = 1, PropertyID = 2, PropertyValue = "Core i7" },   // Processor
                new DevicePropertyValue { ID = 2, DeviceID = 1, PropertyID = 3, PropertyValue = "16 GB" },      // RAM
                new DevicePropertyValue { ID = 3, DeviceID = 1, PropertyID = 4, PropertyValue = "15.6 inches" }, // Display
                new DevicePropertyValue { ID = 4, DeviceID = 1, PropertyID = 5, PropertyValue = "192.168.1.5" }, // IP Address
                new DevicePropertyValue { ID = 5, DeviceID = 1, PropertyID = 6, PropertyValue = "HP" },          // Brand
                new DevicePropertyValue { ID = 6, DeviceID = 1, PropertyID = 7, PropertyValue = "Mohamed Mohsen" }, // Current User
                new DevicePropertyValue { ID = 7, DeviceID = 2, PropertyID = 5, PropertyValue = "192.168.1.10" }, // IP Address
                new DevicePropertyValue { ID = 8, DeviceID = 2, PropertyID = 6, PropertyValue = "Canon" },       // Brand
                new DevicePropertyValue { ID = 9, DeviceID = 3, PropertyID = 2, PropertyValue = "AMD Ryzen 5" }, // Processor
                new DevicePropertyValue { ID = 10, DeviceID = 3, PropertyID = 3, PropertyValue = "8 GB" },       // RAM
                new DevicePropertyValue { ID = 11, DeviceID = 3, PropertyID = 6, PropertyValue = "Dell" }        // Brand
            );
            base.OnModelCreating(modelBuilder);
        }
    }
    
   
}
