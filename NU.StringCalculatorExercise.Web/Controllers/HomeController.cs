using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using NU.StringCalculatorExercise.Logic.Contracts;
using NU.StringCalculatorExercise.Web.Models;

namespace NU.StringCalculatorExercise.Web.Controllers
{
    public class HomeController : Controller
    {
        private readonly ICalculatorService _calculatorService;

        public HomeController(ICalculatorService calculatorService)
        {
            _calculatorService = calculatorService;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Calculate([FromBody] CalculatorInputViewModel data)
        {
            if (!Regex.IsMatch(data.Values, "[0-9,]", RegexOptions.Compiled))
            {
                return BadRequest("Please enter only a list of numbers separated by commas");
            }

            var total = _calculatorService.Calculate(data.Values);

            return new OkObjectResult(Json(new {sum = total}));
        }

        public IActionResult Error()
        {
            return View(new ErrorViewModel
            {
                RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier
            });
        }
    }
}
