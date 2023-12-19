using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting.Lifetime;
using System.Text;
using System.Threading.Tasks;

namespace Cugeno
{
  
      public  class LinguisticVariable
        {
            public string Name { get; }
            public double MinValue { get; }
            public double MaxValue { get; }
            public List<Term> Terms { get; private set; }

        public LinguisticVariable(string name, double minValue, double maxValue)
            {
                Name = name;
                MinValue = minValue;
                MaxValue = maxValue;
                Terms = new List<Term>();
        }

        public void AddTerm(string name, MembershipFunction membershipFunction)
        {
            Term newTerm = new Term(name, membershipFunction);
            Terms.Add(newTerm);
        }
    }

        // Класс для представления терма в лингвистической переменной
        public class Term
        {
            public string Name { get; }
            public MembershipFunction MembershipFunction { get; }

            public Term(string name, MembershipFunction membershipFunction)
            {
                Name = name;
                MembershipFunction = membershipFunction;
            }

        }

    // Интерфейс для функции принадлежности
    public interface MembershipFunction
        {
        double Slop { get; }

        double CalculateMembership(double x);
         double Defuzzify();
 
    }

        // Треугольная функция принадлежности
       public class TriangularMembershipFunction : MembershipFunction
        {
            private double a;
            public double b;
            private double c;

            public TriangularMembershipFunction(double a, double b, double c)
            {
                this.a = a;
                this.b = b;
                this.c = c;
            }

        public double CalculateMembership(double x)
        {
            if (x >= a && x <= b)
                return (x - a) / (b - a);
            else if (x > b && x < c)
                return (c - x) / (c - b);
            else if (Math.Abs(x - b) < double.Epsilon) 
                return 1;
            else
                return 0;
        }
        public double Defuzzify()
        {
            return (b + c) / 2;
        }
      

        public double Slop   {
            get
            {
                if (a == b)
                    return 0;
                else
                    return (c - a) / (b - a);
            }
}
    }

        // Класс для представления правила
       public class Rule
        {
            public string[] Antecedents { get; }
            public string Consequent { get; }

            public Rule(string[] antecedents, string consequent)
            {
                Antecedents = antecedents;
                Consequent = consequent;
            }
        }

        // Класс для представления нечеткой системы
        class FuzzySystem
        {
            private LinguisticVariable inputVariable;
            private LinguisticVariable outputVariable;
            private Rule[] rules;

            public FuzzySystem(LinguisticVariable inputVariable, LinguisticVariable outputVariable, Rule[] rules)
            {
                this.inputVariable = inputVariable;
                this.outputVariable = outputVariable;
                this.rules = rules;
            }

        public double Evaluate(double inputValue)
        {
            // Вычисляем степени принадлежности для каждого терма входной переменной
            double[] memberships = new double[inputVariable.Terms.Count];
            for (int i = 0; i < inputVariable.Terms.Count; i++)
            {
                memberships[i] = inputVariable.Terms[i].MembershipFunction.CalculateMembership(inputValue);
            }

            // Применяем правила и агрегируем результат
            double[] aggregatedMemberships = new double[rules.Length];
            Dictionary<string, Term> termsDictionary = inputVariable.Terms.ToDictionary(t => t.Name);

            for (int i = 0; i < rules.Length; i++)
            {
                double maxMembership = memberships[0]; // Инициализация с минимальным значением
                for (int j = 0; j < rules[i].Antecedents.Length; j++)
                {
                    maxMembership = Math.Max(maxMembership, termsDictionary[rules[i].Antecedents[j]].MembershipFunction.CalculateMembership(inputValue));
                }
                aggregatedMemberships[i] = maxMembership;
            }

            // Дефаззификация (центр тяжести)
            double numerator = 0;
            double denominator = 0;
            for (int i = 0; i < rules.Length; i++)
            {
                numerator += aggregatedMemberships[i] * outputVariable.Terms[i].MembershipFunction.Defuzzify();
                denominator += aggregatedMemberships[i];
            }

            // Добавляем проверку на деление на ноль
            return denominator != 0 ? numerator / denominator : 0;
        }
    }
   
}
