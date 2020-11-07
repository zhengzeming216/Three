using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Three.Models;
using Three.Servies;

namespace Three.Controllers
{
    public class DepartmentController : Controller
    {
        private readonly IDepartmentService _departmentService;
        private readonly IOptions<ThreeOptions> threeOptions;

        public DepartmentController(IDepartmentService departmentService, IOptions<ThreeOptions> threeOptions)
        {
            _departmentService = departmentService;
            this.threeOptions = threeOptions;
        }

        public async Task<IActionResult> Index()
        {
            ViewBag.Title = "department index";
            var department = await _departmentService.GetAll();
            return View(department);
        }

        [HttpGet]
        public IActionResult Add()
        {
            ViewBag.Title = "add department";
            return View(new Department());
        }

        [HttpPost]
        public async Task<IActionResult> Add(Department department)
        {
            if (ModelState.IsValid)
            {
                await _departmentService.Add(department);
            }

            return RedirectToAction(nameof(Index));
        }
    }
}
