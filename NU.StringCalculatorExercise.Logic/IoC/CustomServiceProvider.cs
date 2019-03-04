using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using Microsoft.Extensions.DependencyInjection;
using System.Text;
using System.Threading.Tasks;

namespace NU.StringCalculatorExercise.Logic.IoC
{
    public class CustomServiceProvider
    {
        public static IServiceCollection AddServices(IServiceCollection services)
        {
            var serviceContracts = Assembly.Load("NU.StringCalculatorExercise.Logic").GetTypes()
                .Where(t => t.Namespace != null
                            && (t.Namespace.Contains("NU.StringCalculatorExercise.Logic.Contracts")
                                || t.Namespace.Contains("NU.StringCalculatorExercise.Logic.Services")));

            foreach (var myInterface in serviceContracts.Where(t => t.IsInterface))
            {
                var myImplementation = serviceContracts.FirstOrDefault(c => c.IsClass && myInterface.Name.Substring(1) == c.Name);

                if (myImplementation != null)
                {
                    services.AddTransient(myInterface, myImplementation);
                }
            }

            return services;
        }
    }
}
