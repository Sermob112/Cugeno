using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cugeno
{
    internal class Larsen2
    {
        double EvaluateMembership(double x, double a, double b, double c)
        {
            double result = 0;
            if (x <= a || x >= c)
                result = 0;
            else if (x > a && x <= b)
                result = (x - a) / (b - a);
            else if (x > b && x < c)
                result = (c - x) / (c - b);
            return result;
        }
        public double CalculateOverallRating(double serviceRating, double foodQualityRating)
        {

            double poor = EvaluateMembership(serviceRating, 0, 3, 5);
            double medium = EvaluateMembership(serviceRating, 3, 5, 8) * EvaluateMembership(foodQualityRating, 3, 5, 8);
            double good = EvaluateMembership(serviceRating, 5, 8, 10) * EvaluateMembership(foodQualityRating, 5, 8, 10);
            double excellent = EvaluateMembership(serviceRating, 8, 10, 10) * EvaluateMembership(foodQualityRating, 8, 9, 10);

            
            double overallRating = (poor * 2 + medium * 5 + good * 8 + excellent * 10) / (poor + medium + good + excellent);

         
            return overallRating;
        }
        public double CalculateTipAmount(double overallRating)
        {
            
            double tipAmount = 2 * overallRating;

            tipAmount = Math.Min(tipAmount, 15);

            return tipAmount;
        }
    }
}
