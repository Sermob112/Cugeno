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
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {

            chart1.Series.Clear();
            chart1.Series.Add("Аппроксимация");
            chart1.Series.Add("Оригинал");
            chart1.Series["Аппроксимация"].ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Line;

            // Установка типа линии для серии "Оригинал"
            chart1.Series["Оригинал"].ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Line;
            int left_side = int.Parse(textBox1.Text);
           int right_side = int.Parse(textBox2.Text);
            int num_fun = int.Parse(textBox3.Text);
            double razmah = double.Parse(textBox4.Text);
            List<double> xValues = GenerateXValues(0.1, 10.0, 0.1);  // Замените эту функцию на свою генерацию x
            Sugeno sugeno = new Sugeno(xValues, left_side, right_side, num_fun, razmah);

  
           sugeno.calc_y();


            sugeno.calc_a_i();


            sugeno.calc_alpha_i();

            sugeno.calc_c_i();

            // Аппроксимация функции log(x) методом Сугено
            List<double> approximatedValues = new List<double>();
            foreach (double x in xValues)
            {
                double C = sugeno.calc_C(xValues.IndexOf(x));
                approximatedValues.Add(C);
            }
      
           foreach (double x in xValues) { 
                double y = Math.Log(x);

                chart1.Series["Оригинал"].Points.AddXY(x, y);
            }

            foreach (double x in xValues)
            {
                double C = sugeno.calc_C(xValues.IndexOf(x));
                chart1.Series["Аппроксимация"].Points.AddXY(x,C);
            }

    

            
        }
        static List<double> GenerateXValues(double start, double end, double step)
        {
            List<double> xValues = new List<double>();
            for (double x = start; x <= end; x += step)
            {
                xValues.Add(x);
            }
            return xValues;
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            MamdaniForm mamdani = new MamdaniForm();
            mamdani.Show();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            CukomotoForm cukomotoForm = new CukomotoForm();
            cukomotoForm.Show();

        }

        private void button4_Click(object sender, EventArgs e)
        {
            LarsenForm larsenForm = new LarsenForm();
            larsenForm.Show();
        }
    }
}
