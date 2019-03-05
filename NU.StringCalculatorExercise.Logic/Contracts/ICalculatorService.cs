using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NU.StringCalculatorExercise.Logic.Contracts
{
    public interface ICalculatorService
    {
        int Calculate(string input);
    }
}
