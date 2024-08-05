using Microsoft.AspNetCore.Mvc;

namespace MyConsoleApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CompEngineController : ControllerBase
    {
        [HttpGet("calculate")]
        public ActionResult<int> Calculate([FromQuery] string operation, [FromQuery] int operand1, [FromQuery] int operand2)
        {
            if (operation.ToUpper()=="DIV" && operand2 == 0)
            {
                return BadRequest("Division by zero is not allowed.");
            }

            OPERATION_INPUT input;
            input.operation_name = operation.ToUpper();
            input.op_a = operand1;
            input.op_b = operand2;

            Operation_Dispatcher dispatcher = new Operation_Dispatcher();
            OPERATION_RESULT result = dispatcher.DoDispatch(input);

            return Ok(result.return_value);
        }
    }

}