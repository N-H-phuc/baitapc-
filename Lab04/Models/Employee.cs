using System;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc;

namespace Lab04.Models
{
    public class Employee
    {
        public int Id { get; set; }

        [Display(Name = "Mã nhân viên")]
        [RegularExpression(@"EMP[0-9]{4}", ErrorMessage = "Mã nhân viên có dạng EMPxxxx. Ví dụ: EMP0123")]
        [Remote(controller: "Employee", action: "IsExistedEmployee", ErrorMessage = "Mã nhân viên đã tồn tại")]
        public string EmployeeNo { get; set; }

        [Required]
        [StringLength(150, MinimumLength = 3, ErrorMessage = "Tên phải từ 3 đến 150 ký tự")]
        [Display(Name = "Họ và tên")]
        public string FullName { get; set; }

        [Required]
        [EmailAddress(ErrorMessage = "Email không hợp lệ")]
        public string Email { get; set; }

        [Required]
        [EmailAddress]
        [Compare("Email", ErrorMessage = "Email xác nhận không khớp")]
        [Display(Name = "Xác nhận Email")]
        public string ConfirmEmail { get; set; }

        [Url(ErrorMessage = "Địa chỉ website không hợp lệ")]
        public string? Website { get; set; }

        [Required]
        [DataType(DataType.Date)]
        [BirthDateCheck(ErrorMessage = "Ngày sinh không hợp lệ")] // Custom attribute
        [Display(Name = "Ngày sinh")]
        public DateTime BirthDate { get; set; }

        [Display(Name = "Giới tính")]
        public bool Gender { get; set; } = true;

        [Range(0, double.MaxValue, ErrorMessage = "Lương phải là số không âm")]
        [Display(Name = "Lương")]
        public double Salary { get; set; }

        [Display(Name = "Làm bán thời gian")]
        public bool IsPartTime { get; set; }

        [Required]
        [Display(Name = "Địa chỉ")]
        public string Address { get; set; }

        [Required]
        [RegularExpression(@"0[98753]\d{8}", ErrorMessage = "Số điện thoại không hợp lệ")]
        [Display(Name = "Số di động")]
        public string MobilePhone { get; set; }

        [CreditCard(ErrorMessage = "Số thẻ tín dụng không hợp lệ")]
        [Display(Name = "Thẻ tín dụng")]
        public string? CreditCard { get; set; }

        [MaxLength(255, ErrorMessage = "Mô tả tối đa 255 ký tự")]
        [DataType(DataType.MultilineText)]
        [Display(Name = "Mô tả")]
        public string? Description { get; set; }
    }
}
