using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using MOP.Calculator.API.Services;
using MOP.Calculator.Models;
using System.Threading.Tasks;

namespace MOP.Calculator.API.Controllers
{
    /// <summary>
    /// 
    /// </summary>
    [Route("[controller]")]
    [ApiController]
    public class HomeController : ControllerBase
    {
        private readonly ILogger<HomeController> _logger;
        private ICalculatorService _calculator;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="logger"></param>
        /// <param name="calculator"></param>
        public HomeController(ILogger<HomeController> logger, ICalculatorService calculator)
        {
            _logger = logger;
            _calculator = calculator;
        }

        /// <summary>
        /// Invokes Calculator service and returns the result of the operation
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        [HttpPost, Route("calculator")]
        public IActionResult CalculatorResult(CalculatorInputModel model)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }
            // Load commands from plugins.
            string[] pluginPaths = new string[]
            {
                    // Paths to plugins to load.
                    //@"HelloPlugin\bin\Debug\net5.0\HelloPlugin.dll",
                    @"Plugins\CSharpCalculatorPlugin\bin\Debug\net5.0\CSharpCalculatorPlugin.dll"
                //@"MOP.PythonCalculator\bin\Debug\net5.0\PythonCalculator.dll"
            };

            var result = _calculator.ExecuteCalculator(pluginPaths[0], model);
            return Ok(result);
        }
    }
}
