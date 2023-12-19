using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cugeno
{
    public class Cukomoto
    {
        public double CalculateTips(double service, double foodQuality)
        {
            double poorService = FuzzyMembership(service, 0, 3, 5);
            double mediumService = FuzzyMembership(service, 3, 5, 8);
            double goodService = FuzzyMembership(service, 5, 8, 10);
            double excellentService = FuzzyMembership(service, 7, 9, 10);

            double poorFood = FuzzyMembership(foodQuality, 0, 3, 5);
            double mediumFood = FuzzyMembership(foodQuality, 3, 5, 8);
            double goodFood = FuzzyMembership(foodQuality, 5, 8, 10);
            double excellentFood = FuzzyMembership(foodQuality, 7, 9, 10);

            // Применение нечетких правил
            double poorTips = Math.Min(poorService, poorFood);
            double mediumTips = Math.Min(mediumService, mediumFood);
            double goodTips = Math.Min(goodService, goodFood);
            double excellentTips = Math.Min(excellentService, excellentFood);

            // Агрегация
            double aggregatedTips = Math.Max(poorTips, Math.Max(mediumTips, Math.Max(goodTips, excellentTips)));

            // Дефаззификация
            double defuzzifiedTips = Defuzzification(poorTips, mediumTips, goodTips, excellentTips);

            return defuzzifiedTips;
        }

        static double FuzzyMembership(double x, double a, double b, double c)
        {
            if (x <= a || x >= c) return 0;
            else if (a < x && x <= b) return (x - a) / (b - a);
            else return (c - x) / (c - b);
        }

        // Дефаззификация: вычисление среднего значения
        static double Defuzzification(double poor, double medium, double good, double excellent)
        {
            double numerator = (poor * 2.5) + (medium * 5.0) + (good * 7.5) + (excellent * 10.0);
            double denominator = poor + medium + good + excellent;

            // Избегаем деления на ноль
            if (denominator == 0)
                return 0;

            return numerator / denominator;
        }
    }
}
