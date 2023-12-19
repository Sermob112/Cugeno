using CukamotoWF;
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
            var mamdani2 = new Mamdani2();
            chart1.Series.Clear();
            chart1.Series.Add("Аппроксимация");
            chart1.Series.Add("Оригинал");

            chart1.Series["Оригинал"].ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Line;
            chart1.Series["Аппроксимация"].ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Line;

            List<double> xValues = new List<double>();

            for (double x = 1; x <= 10; x+=1)
            {
                double y = Math.Log(x);
                chart1.Series["Оригинал"].Points.AddXY(x, y);
                xValues.Add(x);
            }

            foreach (double x in xValues)
            {
                double y = mamdani2.FuzzyLogApproximation(x);
                chart1.Series["Аппроксимация"].Points.AddXY(x, y);
            }
            /*   double currentTemperature = 22;

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
   *//*
               Console.WriteLine($"Текущая температура: {currentTemperature}°C");
               Console.WriteLine($"Выход системы отопления: {result}%");

               Console.ReadLine();*//*

               textBox1.Text = $"Текущая температура: {currentTemperature}°C" + " " + $" Выход системы отопления: { result}% ";*/
        }
    }
}
