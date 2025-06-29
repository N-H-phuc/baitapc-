using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Lab04.Models;

namespace Lab04.Controllers
{
    [Route("[controller]")]
    public class EmployeeController : Controller
    {
        // Kiểm tra mã nhân viên đã tồn tại (sử dụng cho [Remote])
        [AcceptVerbs("Get", "Post")]
        public IActionResult IsExistedEmployee(string EmployeeNo)
        {
            var emps = new List<string> { "admin", "employee", "EMP0000" };
            if (emps.Contains(EmployeeNo?.Trim(), StringComparer.OrdinalIgnoreCase))
            {
                return Json($"Mã {EmployeeNo} đã tồn tại");
            }
            return Json(true);
        }

        // GET: /Employee/Create
        [HttpGet("Create")]
        public IActionResult Create()
        {
            return View();
        }

        // POST: /Employee/Create
        [HttpPost("Create")]
        public IActionResult Create(Employee emp)
        {
            if (ModelState.IsValid)
            {
                // Giả lập xử lý lưu thông tin nhân viên (ở thực tế sẽ lưu vào DB)
                ViewBag.Success = "Tạo nhân viên thành công!";
                return View("Create", emp);
            }

            // Nếu không hợp lệ, trả lại view cùng thông tin lỗi
            return View(emp);
        }

     [HttpGet("jQueryValidate")]
public IActionResult jQueryValidate()
{
    return View(new EmployeeInfo());
}

    
    }
}
