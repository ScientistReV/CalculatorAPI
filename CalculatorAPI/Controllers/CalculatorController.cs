using Microsoft.AspNetCore.Mvc;

namespace CalculatorAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CalculatorController : ControllerBase
    {
        private readonly ILogger<CalculatorController> _logger;

        public CalculatorController(ILogger<CalculatorController> logger)
        {
            _logger = logger;
        }

        [HttpGet("sum/{firstNumber}/{secondNumber}")]
        public IActionResult GetSum(string firstNumber, string secondNumber)
        {
            if (IsNumeric(firstNumber) && IsNumeric(secondNumber))
            {
                var sum = ConvertToDecimal(firstNumber) + ConvertToDecimal(secondNumber);

                return Ok(sum.ToString());
            }
            return BadRequest("Invalid input");
        }


        [HttpGet("subtract/{firstNumber}/{secondNumber}")]
        public IActionResult GetSubtract(string firstNumber, string secondNumber)
        {
            if (IsNumeric(firstNumber) && IsNumeric(secondNumber))
            {
                var subtract = ConvertToDecimal(firstNumber) - ConvertToDecimal(secondNumber);

                return Ok(subtract.ToString());
            }
            return BadRequest("Invalid input");
        }

        [HttpGet("division/{firstNumber}/{secondNumber}")]
        public IActionResult GetDivision(string firstNumber, string secondNumber)
        {
            if (IsNumeric(firstNumber) && IsNumeric(secondNumber))
            {
                var division = ConvertToDecimal(firstNumber) / ConvertToDecimal(secondNumber);

                return Ok(division.ToString());
            }
            return BadRequest("Invalid input");
        }

        [HttpGet("multiple/{firstNumber}/{secondNumber}")]
        public IActionResult GetMultiple(string firstNumber, string secondNumber)
        {
            if (IsNumeric(firstNumber) && IsNumeric(secondNumber))
            {
                var multiple = ConvertToDecimal(firstNumber) * ConvertToDecimal(secondNumber);

                return Ok(multiple.ToString());
            }
            return BadRequest("Invalid input");
        }

        [HttpGet("square-root/{number}")]
        public IActionResult GetSquareRoot(string number)
        {
            if (IsNumeric(number))
            {
                var square = Math.Sqrt((double)ConvertToDecimal(number));

                return Ok(square.ToString());
            }
            return BadRequest("Invalid input");
        }


        [HttpGet("medium/{firstNumber}/{secondNumber}")]
        public IActionResult GetMedium(string firstNumber, string secondNumber)
        {
            if (IsNumeric(firstNumber) && IsNumeric(secondNumber))
            {
                var sum = ConvertToDecimal(firstNumber) + ConvertToDecimal(secondNumber);
                var medium = sum / 2;

                return Ok(medium.ToString());
            }
            return BadRequest("Invalid input");
        }

        private bool IsNumeric(string strNumber)
        {
            double number;
            bool isNumber = double.TryParse(strNumber, System.Globalization.NumberStyles.Any, System.Globalization.NumberFormatInfo.InvariantInfo, out number);
            return isNumber;
        }

        private decimal ConvertToDecimal(string number)
        {
            decimal decimalValue;

            if(decimal.TryParse(number, out decimalValue))
            {
                return decimalValue;
            }

            return 0;
        }
    }
}