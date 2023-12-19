using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cugeno
{
    public enum Intensity
    {
        Low,
        Medium,
        High
    }

    public class RGBColor
    {
        public Intensity Red { get; set; }
        public Intensity Green { get; set; }
        public Intensity Blue { get; set; }

        public RGBColor(Intensity red, Intensity green, Intensity blue)
        {
            Red = red;
            Green = green;
            Blue = blue;
        }
    }
    public class MembershipFunctionslarsen
    {
        // Функции принадлежности для переменной "Красный"
        public static double RedLow(double value)
        {
     
            return Math.Max(0, 1 - Math.Abs(value - 0.5));
        }

        public static double RedMedium(double value)
        {
           
            return Math.Max(0, Math.Min(Math.Min(value - 0.2, 0.8 - value), 1));
        }

        public static double RedHigh(double value)
        {
           
            return Math.Max(0, Math.Min(2 - value, 1));
        }

        public static double BlueLow(double value)
        {

            return Math.Max(0, 1 - Math.Abs(value - 0.5));
        }

        public static double BlueMedium(double value)
        {

            return Math.Max(0, Math.Min(Math.Min(value - 0.2, 0.8 - value), 1));
        }

        public static double BlueHigh(double value)
        {

            return Math.Max(0, Math.Min(2 - value, 1));
        }

        public static double GreenLow(double value)
        {

            return Math.Max(0, 1 - Math.Abs(value - 0.5));
        }

        public static double GreenMedium(double value)
        {

            return Math.Max(0, Math.Min(Math.Min(value - 0.2, 0.8 - value), 1));
        }

        public static double GreenHigh(double value)
        {

            return Math.Max(0, Math.Min(2 - value, 1));
        }
    }

    public class RuleLarsen
    {
        public Intensity Red { get; set; }
        public Intensity Green { get; set; }
        public Intensity Blue { get; set; }
        public Shade OutputShade { get; set; }

        public RuleLarsen(Intensity red, Intensity green, Intensity blue, Shade outputShade)
        {
            Red = red;
            Green = green;
            Blue = blue;
            OutputShade = outputShade;
        }
    }

    public enum Shade
    {
        Dark,
        Medium,
        Light
    }

    public class FuzzyLogicEngine
    {
        public Shade DetermineShade(RGBColor color, List<RuleLarsen> rules)
        {
            List<double> ruleOutputs = new List<double>();
            double averageFuzzyOutput = 0;
            foreach (var rule in rules)
            {
                // Вычисление степени принадлежности каждого условия правила
                double redMembership = MembershipFunctionslarsen.RedLow((int)color.Red);
                double greenMembership = MembershipFunctionslarsen.GreenLow((int)color.Green);
                double blueMembership = MembershipFunctionslarsen.BlueLow((int)color.Blue);

                double redMembershipMedium = MembershipFunctionslarsen.RedMedium((int)color.Red);
                double greenMembershipMedium = MembershipFunctionslarsen.GreenMedium((int)color.Green);
                double blueMembershipMedium = MembershipFunctionslarsen.BlueMedium((int)color.Blue);

                double redMembershipHigh = MembershipFunctionslarsen.RedHigh((int)color.Red);
                double greenMembershipHigh = MembershipFunctionslarsen.GreenHigh((int)color.Green);
                double blueMembershipHigh = MembershipFunctionslarsen.BlueHigh((int)color.Blue);
                double ruleOutput = Math.Min(redMembership, Math.Min(greenMembership, blueMembership));
                double ruleOutput2 = Math.Min(redMembershipMedium, Math.Min(greenMembershipMedium, blueMembershipMedium));
                double ruleOutput3 = Math.Min(redMembershipHigh, Math.Min(greenMembershipHigh, blueMembershipHigh));
                ruleOutputs.Add(ruleOutput);
                ruleOutputs.Add((double)ruleOutput2);
                ruleOutputs.Add((double)ruleOutput3);
                averageFuzzyOutput = ruleOutputs.Average();
       
            }


            double finalOutput = averageFuzzyOutput;


            Shade finalShade = Defuzzification(finalOutput);

            return finalShade;
        }

        private Shade Defuzzification(double fuzzyOutput)
        {
            // Реализация дефаззификации, например, выбор "среднего" значения для простоты
            if (fuzzyOutput < 0.22)
                return Shade.Dark;
            else if (fuzzyOutput < 0.33)
                return Shade.Medium;
            else
                return Shade.Light;
        }
    }
}
