using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NU.StringCalculatorExercise.Logic.Contracts;
using System.Text.RegularExpressions;

namespace NU.StringCalculatorExercise.Logic.Services
{
    public class CalculatorService : ICalculatorService
    {
        public int Calculate(string input)
        {
            if (string.IsNullOrWhiteSpace(input))
            {
                return 0;
            }

            if (!Regex.IsMatch(input, @"^\d+(,\d+)*$", RegexOptions.Compiled))
            {
                throw new Exception("Input must be a comma seperated list of integers");
            }

            var values = input.Trim().Split(',');  // Split the values out
            var total = values.Sum(int.Parse);  // Parse each as an integer and then add them here

            return total;
        }
    }
}
