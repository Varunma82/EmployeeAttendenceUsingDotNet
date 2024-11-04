    using Application.Interfaces;
    using Application.Services;
    using Core.Entities;
    using Microsoft.AspNetCore.Mvc;

    namespace EmployeeAttendence.Controllers
    {
        public class EmployeeController : Controller
        {
            private readonly IEmployeeService _employeeService;
            private readonly IEmployeeAttendanceService _employeeAttendanceService;

            public EmployeeController(IEmployeeService employeeService, IEmployeeAttendanceService employeeAttendanceService)
            {
                _employeeService = employeeService;
                _employeeAttendanceService = employeeAttendanceService;
            }

            public IActionResult Index()
            {
                var employees = _employeeService.GetAllEmployees();
                return View(employees);
            }

            
            [HttpGet]
            public IActionResult MarkAttendance(int id)
            {
                var employee = _employeeService.GetEmployeeById(id);
                if (employee == null) return NotFound();

                var attendance = new EmployeeAttendance { EmployeeId = id };
                return View(attendance);
            }

            [HttpPost]
            public IActionResult MarkAttendance(EmployeeAttendance attendance)
            {
                if (ModelState.IsValid)
                {
                    attendance.Attendance_Date = DateTime.Now;
                    _employeeAttendanceService.MarkAttendance(attendance);
                    return RedirectToAction("Index");
                }
                return View(attendance);
            }

            
            public IActionResult ViewAttendance(int id)
            {
                var attendanceRecords = _employeeAttendanceService.GetAttendanceByEmployeeId(id);
                return View(attendanceRecords);
            }

            

            public IActionResult Create()
            {
                return View();
            }

            [HttpPost]
            public IActionResult Create(Employee employee)
            {
                if (ModelState.IsValid)
                {
                    _employeeService.CreateEmployee(employee);
                    return RedirectToAction(nameof(Index));
                }
                return View(employee);
            }

            public IActionResult Edit(int id)
            {
                var employee = _employeeService.GetEmployeeById(id);
                return View(employee);
            }

            [HttpPost]
            public IActionResult Edit(Employee employee)
            {
                if (ModelState.IsValid)
                {
                    _employeeService.UpdateEmployee(employee);
                    return RedirectToAction(nameof(Index));
                }
                return View(employee);
            }

        public IActionResult Delete(int id)
        {
            var employee = _employeeService.GetEmployeeById(id);
            if (employee == null) return NotFound();
            return View(employee); 
        }
        [ValidateAntiForgeryToken]
        [HttpPost, ActionName("Delete")]
        public IActionResult DeleteConfirmed(int id)
        {
            _employeeService.DeleteEmployee(id);
            return RedirectToAction(nameof(Index)); 
        }


        public IActionResult Details(int id)
            {
                var employee = _employeeService.GetEmployeeById(id);
                return View(employee);
            }
        }
    }
