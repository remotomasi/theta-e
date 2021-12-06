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
            textBox5.Text = ((int)V).ToString();

            Double Q = 0.0;
            Double X = V / (P - V) * C1;
            if (P > 0) {
                Q = Math.Pow((1000 / P), 0.29); 
            }else textBox4.Text = "Errore!";

            Double TE = 273.2 + T + 2480 * X / 1;
            Double THETAE = TE * Q;
            textBox4.Text = ((int)THETAE).ToString();
            Double THETAEC = THETAE - 273.15;
            textBox8.Text = ((int)THETAEC).ToString();

            Double S = Math.Exp(A - B / (T + C));
            textBox6.Text = ((int)S).ToString();

            Double XS = S / (P - S) * C1;
            Double TES = 273.2 + T + 2480 * XS / 1;
            Double THETAES = TES + Q;
            textBox7.Text = ((int)THETAES).ToString();

            Double T850 = T * 0.65;
            // Double D850 = (T850 - D) * 5 / 100;
            // Double V850 = Math.Exp(A - B / (D + C));
            Double X850 = V / (850 - V) * C1; 
            Double TE850 = 273.2 + T850 + 2480 * X850 / 1;
            Double Q850 = Math.Pow((1.177), 0.29);
            Double THETAE850 = TE850 * Q850;
            Double THETAE850C = THETAE850 - 273.15;
            Double QN = 10 * (THETAE850C - 12) / 0.12;
            textBox9.Text = ((int)QN).ToString();
        }
    }
}
