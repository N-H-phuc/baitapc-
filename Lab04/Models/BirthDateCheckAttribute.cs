using System;
using System.ComponentModel.DataAnnotations;

namespace Lab04.Models
{
    public class BirthDateCheckAttribute : ValidationAttribute
    {
        protected override ValidationResult? IsValid(object? value, ValidationContext validationContext)
        {
            // Kiểm tra null trước khi ép kiểu
            if (value == null)
            {
                return new ValidationResult("Vui lòng nhập ngày sinh.");
            }

            if (value is DateTime birthDate)
            {
                var today = DateTime.Today;
                var age = today.Year - birthDate.Year;

                // Trừ thêm 1 nếu chưa đến ngày sinh trong năm
                if (birthDate > today.AddYears(-age)) age--;

                if (age < 16 || age > 65)
                {
                    return new ValidationResult("Tuổi phải nằm trong khoảng từ 16 đến 65.");
                }

                return ValidationResult.Success;
            }

            return new ValidationResult("Định dạng ngày sinh không hợp lệ.");
        }
    }
}
