
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;


namespace Cugeno
{
    public partial class CukomotoForm : Form
    {
        public CukomotoForm()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            var Cukomoto = new Cukomoto();
            var serviceRating = double.Parse(textBox2.Text);
            var foodQualityRating = double.Parse(textBox3.Text);
            var t = Cukomoto.CalculateTips(serviceRating, foodQualityRating);
            textBox1.Text = t.ToString();
        }
    }
}
