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
    public partial class LarsenForm : Form
    {
        public LarsenForm()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            var larsen = new Larsen2();
            var serviceRating = double.Parse(textBox2.Text);
            var foodQualityRating = double.Parse(textBox3.Text);

            double overallRating = larsen.CalculateOverallRating(serviceRating, foodQualityRating);
            double tipAmount = larsen.CalculateTipAmount(overallRating);
            textBox1.Text = $"Количество чаевых: {tipAmount}";


            /*  FuzzyLogicEngine fuzzyEngine = new FuzzyLogicEngine();

              // Ввод данных от пользователя (ваш способ ввода данных)

              int redIntensity =33 ;


              int greenIntensity = 0;


              int blueIntensity = 0;

              // Создание объекта RGBColor на основе введенных данных
              RGBColor userColor = new RGBColor((Intensity)redIntensity, (Intensity)greenIntensity, (Intensity)blueIntensity);

              // Определение оттенка с использованием движка нечеткой логики
              Shade resultShade = fuzzyEngine.DetermineShade(userColor, GetRules());

              // Вывод результата
           textBox1.Text = $"Определенный оттенок: {resultShade}";*/



        }

        static List<RuleLarsen> GetRules()
        {
            // Создание и возвращение списка правил
            return new List<RuleLarsen>
        {
            // Здесь вы можете добавить ваши собственные правила
            new RuleLarsen(Intensity.Low, Intensity.Low, Intensity.Low, Shade.Dark),
            new RuleLarsen(Intensity.Medium, Intensity.Medium, Intensity.Medium, Shade.Medium),
            new RuleLarsen(Intensity.High, Intensity.High, Intensity.High, Shade.Light)
        };
        }

    }


}
