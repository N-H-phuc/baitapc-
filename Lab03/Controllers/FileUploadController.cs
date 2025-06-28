using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Lab03.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace Lab03.Controllers
{
    [Route("[controller]")]
    public class FileUploadController : Controller
    {
       

        public IActionResult Index()
        {
            return View();
        }

        

        [HttpPost]
        public async Task<IActionResult> UploadFile(IFormFile file)
        {
            if (file == null || file.Length == 0)
                return Content("File not selected");

            var folderPath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "UploadFiles");
            if (!Directory.Exists(folderPath))
            {
                Directory.CreateDirectory(folderPath);
            }

            var uniqueFileName = GenerateUniqueFileName(file.FileName);
            var filePath = Path.Combine(folderPath, uniqueFileName);

            using (var stream = new FileStream(filePath, FileMode.Create))
            {
                await file.CopyToAsync(stream);
            }

            return RedirectToAction("ListFiles");
        }

        [HttpPost]
        public async Task<IActionResult> UploadFiles(List<IFormFile> files)
        {
            if (files == null || files.Count == 0)
                return Content("Files not selected");

            var folderPath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "UploadFiles");
            if (!Directory.Exists(folderPath))
            {
                Directory.CreateDirectory(folderPath);
            }

            foreach (var file in files)
            {
                var uniqueFileName = GenerateUniqueFileName(file.FileName);
                var filePath = Path.Combine(folderPath, uniqueFileName);

                using (var stream = new FileStream(filePath, FileMode.Create))
                {
                    await file.CopyToAsync(stream);
                }
            }

            return RedirectToAction("ListFiles");
        }

        [HttpGet]
        public IActionResult ListFiles()
        {
            var model = new FilesViewModel();
            var folderPath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "UploadFiles");

            if (!Directory.Exists(folderPath))
            {
                Directory.CreateDirectory(folderPath);
            }

            string[] filePaths = Directory.GetFiles(folderPath);
            foreach (var item in filePaths)
            {
                model.Files.Add(new FileDetails
                {
                    Name = Path.GetFileName(item),
                    Path = "/UploadFiles/" + Path.GetFileName(item)
                });
            }

            return View(model);
        }

        private string GenerateUniqueFileName(string originalFileName)
        {
            var fileName = Path.GetFileNameWithoutExtension(originalFileName);
            var extension = Path.GetExtension(originalFileName);
            var uniqueName = $"{fileName}_{Guid.NewGuid().ToString().Substring(0, 8)}{extension}";
            return uniqueName;
        }
    }
}
