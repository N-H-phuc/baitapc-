using Microsoft.AspNetCore.Http;
using System.Collections.Generic;

namespace Lab03.Models
{
    // Model cho upload một file
    public class FileInputModel
    {
        public IFormFile FileToUpload { get; set; }
    }

    // Thông tin chi tiết về file đã upload
    public class FileDetails
    {
        public string Name { get; set; }     // Tên hiển thị
        public string Path { get; set; }     // Đường dẫn truy cập file
    }

    // ViewModel chứa danh sách các file đã upload
    public class FilesViewModel
    {
        public List<FileDetails> Files { get; set; } = new List<FileDetails>();
    }
}
