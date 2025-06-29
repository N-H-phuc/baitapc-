using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.ComponentModel.DataAnnotations;

namespace Lab04.Models
{
    public class StudentInfo
    {
        [Required(ErrorMessage = "Mã SV bắt buộc")]
        [MinLength(6, ErrorMessage = "Mã SV phải có ít nhất 6 ký tự")]
        [Display(Name = "Mã SV")]
        public string MaSV { get; set; }

        [Required(ErrorMessage = "Họ tên bắt buộc")]
        [Display(Name = "Họ tên SV")]
        public string HoTen { get; set; }

        [Required(ErrorMessage = "Ngày sinh bắt buộc")]
        [DataType(DataType.Date, ErrorMessage = "Ngày sinh không hợp lệ")]
        [Display(Name = "Ngày sinh")]
        public DateTime NgaySinh { get; set; }

        [Required(ErrorMessage = "Email bắt buộc")]
        [EmailAddress(ErrorMessage = "Email không hợp lệ")]
        [RegularExpression(@"^[\w\.-]+@gmail\.com$", ErrorMessage = "Chỉ chấp nhận Gmail")]
        [Display(Name = "Email")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Xác nhận email bắt buộc")]
        [Compare("Email", ErrorMessage = "Xác nhận email không khớp")]
        [Display(Name = "Xác nhận email")]
        public string XacNhanEmail { get; set; }

        [CreditCard(ErrorMessage = "Credit Card không hợp lệ")]
        [Display(Name = "Số thẻ tín dụng")]
        public string CreditCard { get; set; }

        [Required(ErrorMessage = "Hình ảnh bắt buộc")]
        [Display(Name = "Hình ảnh")]
        public IFormFile Hinh { get; set; }

        [Range(0.0, 10.0, ErrorMessage = "Điểm số phải trong khoảng 0 - 10")]
        [Display(Name = "Điểm số")]
        public double Diem { get; set; }

        [Range(1, int.MaxValue, ErrorMessage = "Hệ số phải lớn hơn 0")]
        [Display(Name = "Hệ số")]
        public int HeSo { get; set; }

        [Required(ErrorMessage = "Mã bảo mật bắt buộc")]
        [Remote("IsValidMaBaoMat", "Student", ErrorMessage = "Sai mã bảo mật!")]
        [Display(Name = "Mã bảo mật")]
        public string MaBaoMat { get; set; }

        [MaxLength(255, ErrorMessage = "Không quá 255 ký tự")]
        [Display(Name = "Thông tin thêm")]
        public string GhiChu { get; set; }
    }
}
