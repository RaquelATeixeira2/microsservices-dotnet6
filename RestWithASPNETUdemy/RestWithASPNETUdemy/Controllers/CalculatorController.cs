using Microsoft.AspNetCore.Mvc;

namespace RestWithASPNETUdemy.Controllers;

[ApiController]
[Route("[controller]")]
public class CalculatorController : ControllerBase
{

    private readonly ILogger<CalculatorController> _logger;

    public CalculatorController(ILogger<CalculatorController> logger)
    {
        _logger = logger;
    }

    [HttpGet("{firstNumber}/{type}/{secondNumber}")]
    public IActionResult Get(String firstNumber, String type, String secondNumber)
    {
        if(isNumeric(firstNumber) && isNumeric(secondNumber)){
            if(type.Equals("+")){
            var sum = ConvertToDecimal(firstNumber) + ConvertToDecimal(secondNumber);
            return Ok(sum.ToString());
            } else if(type.Equals("-")){
            var min = ConvertToDecimal(firstNumber) - ConvertToDecimal(secondNumber);
            return Ok(min.ToString());
            } else if(type.Equals("*")){
            var mul = ConvertToDecimal(firstNumber) * ConvertToDecimal(secondNumber);
            return Ok(mul.ToString());
            } else if (type.Equals("d")){
            var div = ConvertToDecimal(firstNumber) / ConvertToDecimal(secondNumber);
            return Ok(div.ToString());
            }
        }
       return BadRequest("invalid input");
    }

    public bool isNumeric(String strNumber){
       double number;
       bool isNumber = double.TryParse(strNumber, System.Globalization.NumberStyles.Any, System.Globalization.NumberFormatInfo.InvariantInfo, out number);
        return isNumber;
    }

    public decimal ConvertToDecimal(String strNumber){
        decimal decimalValue;
        if(decimal.TryParse(strNumber, out decimalValue)){
            return decimalValue;
        }
        return 0;
    }
}
