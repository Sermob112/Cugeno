using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cugeno
{
    internal class Mamdani2
    {
        public double FuzzyLogApproximation(double x)
        {
            
            double low = MembershipFunctionLow(x);
            double medium = MembershipFunctionMedium(x);
            double high = MembershipFunctionHigh(x);

           
            double logLow = MembershipFunctionLogLow(x) ;
            double logMedium = MembershipFunctionLogMedium(x) ;
            double logHigh = MembershipFunctionLogHigh(x) ;

          
            double lowActivation = Math.Min(low, logLow);
            double mediumActivation = Math.Min(medium, logMedium);
            double highActivation = Math.Min(high, logHigh);

            // Дефаззификация (центр тяжести)
            double numerator = lowActivation  +
                               mediumActivation  +
                               highActivation * DefuzzificationMedium(x);

            double denominator = lowActivation + mediumActivation + highActivation;

            double result = numerator / denominator;

            return result;
        }

        // Нечеткая логика для входной переменной x
        static double MembershipFunctionLow(double x)
        {
            return Math.Max(0, Math.Min(1, (x) / 2));
        }

        static double MembershipFunctionMedium(double x)
        {
            return Math.Max(0, Math.Min(1, (x - 2) / 2));
        }

        static double MembershipFunctionHigh(double x)
        {
            return Math.Max(0, Math.Min(1, (x - 6) / 2));
        }

        // Нечеткая логика для выходной переменной Log(x)
        static double MembershipFunctionLogLow(double x)
        {
            return Math.Max(0, Math.Min(1, (2 - Math.Log(x)) / 1));
        }

        static double MembershipFunctionLogMedium(double x)
        {
            return Math.Max(0, Math.Min(1, (Math.Log(x) ) / 1));
        }

        static double MembershipFunctionLogHigh(double x)
        {
            return Math.Max(0, Math.Min(1, (Math.Log(x) ) / 2));
        }

        // Дефаззификация
        static double DefuzzificationLow(double x)
        {
            return 2 - x;
        }

        static double DefuzzificationMedium(double x)
        {
            return x;
        }

        static double DefuzzificationHigh(double x)
        {
            return x + 2;
        }


    }
}
