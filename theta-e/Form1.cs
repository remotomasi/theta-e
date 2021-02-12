using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace theta_e
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Double P = Double.Parse(textBox1.Text);
            Double T = Double.Parse(textBox2.Text);
            Double D = Double.Parse(textBox3.Text);
            Double A = 19.0785;
            Double B = 4098.025;
            Double C = 237.3;
            Double C1 = 18 / 28.96;

            Double V = Math.Exp(A - B / (D + C));
            textBox5.Text = V.ToString();

            Double Q = 0.0;
            Double X = V / (P - V) * C1;
            if (P > 0) {
                Q = Math.Pow((1000 / P), 0.29); 
            }else textBox4.Text = "Errore!";

            Double TE = 273.2 + T + 2480 * X / 1;
            Double THETAE = TE * Q;
            textBox4.Text = THETAE.ToString();
            Double THETAEC = THETAE - 273.15;
            textBox8.Text = THETAEC.ToString();

            Double S = Math.Exp(A - B / (T + C));
            textBox6.Text = S.ToString();

            Double XS = S / (P - S) * C1;
            Double TES = 273.2 + T + 2480 * XS / 1;
            Double THETAES = TES + Q;
            textBox7.Text = THETAES.ToString();
        }
    }
}
