using Linked_Gates.Models;
using Linked_Gates.Service;
using Linked_Gates.ViewModel;
using Microsoft.AspNetCore.Mvc;

namespace Linked_Gates.Controllers
{
    public class DeviceController : Controller
    {
        private readonly IService _deviceService;
        ITdepartmContext context;

        public DeviceController(IService deviceService,ITdepartmContext context)
        {
            _deviceService = deviceService;
            this.context = context;
        }
        [HttpGet]
        public JsonResult GetPropertiesByCategory(int categoryId)
        {
            var properties = _deviceService.GetPropertiesByCategoryId(categoryId);
            return Json(properties);
        }
        public IActionResult Index()
        {
            var devices = _deviceService.GetAllDevices();
            return View("Index",devices);
        }
        public IActionResult Create()
        {
            var model = new DeviceViewModel
            {
                Categories = context.DeviceCategories.ToList(), 
                Properties = new List<Property>()
            };
            return View("Add", model);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(DeviceViewModel model)
        {
            if (ModelState.IsValid)
            {
                var device = new Device
                {
                    DeviceName = model.DeviceName,
                    AcquisitionDate = model.AcquisitionDate,
                    Memo = model.Memo,
                    CategoryID = model.CategoryID,
                };

                _deviceService.AddDevice(device);
                _deviceService.SaveChanges();
                return RedirectToAction(nameof(Index)); 
            }
            model.Categories = context.DeviceCategories.ToList();
            model.Properties = new List<Property>();
            return View("Add",model); 
        }

        public IActionResult Edit(int id)
        {
            var device = _deviceService.GetDeviceById(id);
            if (device == null)
            {
                return NotFound();
            }
            var model = new DeviceViewModel
            {
                ID = device.ID,
                DeviceName = device.DeviceName,
                AcquisitionDate = device.AcquisitionDate,
                Memo = device.Memo,
                CategoryID = device.CategoryID,
                Properties = _deviceService.GetPropertiesByCategoryId(device.CategoryID),
                Categories= context.DeviceCategories.ToList()

            };

            return View("Update",model); 
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(DeviceViewModel model)
        {
            if (ModelState.IsValid)
            {
                var device = new Device
                {
                    ID = model.ID,
                    DeviceName = model.DeviceName,
                    AcquisitionDate = model.AcquisitionDate,
                    Memo = model.Memo,
                    CategoryID = model.CategoryID,
                };

                _deviceService.UpdateDevice(device);
                _deviceService.SaveChanges();
                return RedirectToAction(nameof(Index)); 
            }
            return View(model);
        }

    }
}
