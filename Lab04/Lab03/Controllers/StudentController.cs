using Microsoft.AspNetCore.Mvc;
using System;
using System.IO;
using Lab03.Models; // Đảm bảo bạn có lớp Student trong thư mục Models

namespace Lab03.Controllers
{
    public class StudentController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Manage(Student model, string command)
        {
            var path = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "Student.txt");

            if (command == "Lưu")
            {
                string[] lines = { model.Id, model.Name, model.Marks.ToString() };
                System.IO.File.WriteAllLines(path, lines);
                ViewBag.Message = "Đã ghi vào file!";
            }
            else if (command == "Mở")
            {
                if (System.IO.File.Exists(path))
                {
                    string[] lines = System.IO.File.ReadAllLines(path);
                    ViewBag.Id = lines[0];
                    ViewBag.Name = lines[1];
                    ViewBag.Marks = Convert.ToDouble(lines[2]);
                    ViewBag.Message = "Đã đọc từ file!";
                }
                else
                {
                    ViewBag.Message = "File không tồn tại!";
                }
            }

            return View("Index");
        }
    }
}
