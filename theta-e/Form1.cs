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
            Double P = Double.Parse(textBox1.Text); // in hPa
            Double T = Double.Parse(textBox2.Text);
            Double TK = T + 273.15;   // T in K
            Double DP = Double.Parse(textBox3.Text);
            Double RH = Double.Parse(textBox10.Text);
            Double DPC = T - (100 - RH) / 5;    // DP calculated

            // Actual vapor pressure
            Double ep = 6.11 * Math.Pow(10, 7.5 * (DP / (237.7 + DP)));

            // Mixing ratio (M)
            Double w = 621.97 * (ep / (P - ep));

            // Saturated vapor pressure
            Double es = 6.11 * Math.Pow(10, 7.5 * (T / (237.7 + T)));

            // Saturation Mixing ratio (M)
            Double ws = 621.97 * (es / (P - es));

            // Theta-e in K
            Double thetae = TK * Math.Pow((1000 / P), 0.286) + 3 * w;   // Theta-e in K
            Double te850 = thetae - 9.1;  // Theta-e at 850 hPa in K

            // Theta-e in C
            Double thetaeC = thetae - 273.15;

            // Theta-e in C at 850 hPa
            Double te850C = te850 - 273.5;

            // Snow level
            Double sl = 10 * (te850C - 12) / 0.12;

            textBox5.Text = String.Format("{0:0.00}", ep).ToString();

            // String.Format("{0:0.00}", 123.4567)
            textBox11.Text = String.Format("{0:0.00}", w).ToString();
            textBox6.Text = String.Format("{0:0.00}", es).ToString();
            textBox12.Text = String.Format("{0:0.00}", ws).ToString();
            textBox13.Text = String.Format("{0:0.00}", DPC).ToString();
            textBox7.Text = String.Format("{0:0.00}", (w/ws)*100).ToString();

            textBox4.Text = String.Format("{0:0.00}", te850).ToString();
            textBox8.Text = String.Format("{0:0.00}", te850C).ToString();
            textBox9.Text = String.Format("{0:0.00}", sl).ToString();
        }

    }
}
