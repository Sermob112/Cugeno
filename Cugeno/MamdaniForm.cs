using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Cugeno
{
    public partial class MamdaniForm : Form
    {
        public MamdaniForm()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            double currentTemperature = 22;

            // Определяем лингвистические переменные
            LinguisticVariable temperature = new LinguisticVariable("Температура", 15, 30);
            LinguisticVariable heatingOutput = new LinguisticVariable("Выход системы отопления", 0, 100);

            // Задаем лингвистические термы для температуры
            temperature.AddTerm("Холодно", new TriangularMembershipFunction(15, 18, 21));
            temperature.AddTerm("Нормально", new TriangularMembershipFunction(20, 22.5, 25));
            temperature.AddTerm("Жарко", new TriangularMembershipFunction(23, 27, 30));

            // Задаем лингвистические термы для выхода системы отопления
            heatingOutput.AddTerm("Выключено", new TriangularMembershipFunction(0, 0, 50));
            heatingOutput.AddTerm("Включено", new TriangularMembershipFunction(50, 80, 100));
            heatingOutput.AddTerm("Неизвестно", new TriangularMembershipFunction(10, 10, 10));
            // Определяем правила
            Rule[] rules = new Rule[]
            {
                new Rule(new string[] { "Холодно" }, "Включено"),
                new Rule(new string[] { "Нормально" }, "Выключено"),
                new Rule(new string[] { "Жарко" }, "Выключено"),
            };

            // Запускаем вывод
            FuzzySystem fuzzySystem = new FuzzySystem(temperature, heatingOutput, rules);
            double result = fuzzySystem.Evaluate(currentTemperature);
/*
            Console.WriteLine($"Текущая температура: {currentTemperature}°C");
            Console.WriteLine($"Выход системы отопления: {result}%");

            Console.ReadLine();*/

            textBox1.Text = $"Текущая температура: {currentTemperature}°C" + " " + $" Выход системы отопления: { result}% ";
        }
    }
}
