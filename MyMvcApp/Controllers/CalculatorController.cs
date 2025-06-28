using Microsoft.AspNetCore.Mvc;

namespace MyMvcApp.Controllers
{
    [Route("Calculator")]
    public class CalculatorController : Controller
    {
        [HttpGet("")]
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost("Calculate")]
        public IActionResult Calculate(double a = 0, double b = 0, char op = '+')
        {
            switch (op)
            {
                case '+':
                    ViewBag.KetQua = a + b;
                    break;
                case '-':
                    ViewBag.KetQua = a - b;
                    break;
                case 'x':
                    ViewBag.KetQua = a * b;
                    break;
                case ':':
                case '/':
                    ViewBag.KetQua = b != 0 ? a / b : double.NaN;
                    break;
                default:
                    ViewBag.KetQua = "Phép toán không hợp lệ";
                    break;
            }

            return View("Index");
        }
    }
}
