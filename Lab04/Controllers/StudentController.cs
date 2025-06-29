using Microsoft.AspNetCore.Mvc;
using Lab04.Models;
using Microsoft.AspNetCore.Http;
using System.IO;
using System;

namespace Lab04.Controllers
{
    public class StudentController : Controller
    {
        [HttpGet]
        public IActionResult Register()
        {
            // Sinh mã bảo mật ngẫu nhiên và lưu vào Session
            Random rd = new Random();
            int maBaoMat = rd.Next(1000, 10000); // ví dụ: 1234 - 9999
            ViewBag.Code = maBaoMat;
            HttpContext.Session.SetString("MaBaoMat", maBaoMat.ToString());

            return View();
        }

        [HttpPost]
        public IActionResult Register(StudentInfo model, IFormFile Hinh)
        {
            // Kiểm tra file upload hợp lệ
            if (Hinh != null && Hinh.Length > 0)
            {
                var ext = Path.GetExtension(Hinh.FileName).ToLower();
                var allowed = new[] { ".gif", ".jpg", ".jpeg", ".png" };
                if (!allowed.Contains(ext))
                {
                    ModelState.AddModelError("Hinh", "Chỉ chấp nhận gif, jpg, png");
                }
            }

            // Nếu hợp lệ thì xử lý thành công
            if (ModelState.IsValid)
            {
                ViewBag.Success = "Đăng ký thành công!";
                ViewBag.FileName = Hinh?.FileName;
                return View("Register");
            }

            // Nếu có lỗi, cần hiển thị lại mã bảo mật
            ViewBag.Code = HttpContext.Session.GetString("MaBaoMat");
            return View(model);
        }

        [AcceptVerbs("Get", "Post")]
        public IActionResult IsValidMaBaoMat(string MaBaoMat)
        {
            var sessionCode = HttpContext.Session.GetString("MaBaoMat");
            if (MaBaoMat != sessionCode)
                return Json("Sai mã bảo mật!");

            return Json(true);
        }
    }
}
