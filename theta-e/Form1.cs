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
            if (string.IsNullOrEmpty(textBox1.Text) 
                || string.IsNullOrEmpty(textBox2.Text)
                || string.IsNullOrEmpty(textBox3.Text)
                || string.IsNullOrEmpty(textBox10.Text)
                || string.IsNullOrEmpty(textBox14.Text)
                || string.IsNullOrEmpty(textBox15.Text)
                )
            {
                MessageBox.Show("Possibili campi vuoti.");
            } else {

                Double P = Double.Parse(textBox1.Text); // in hPa
                Double T = Double.Parse(textBox2.Text);
                Double T850 = Double.Parse(textBox14.Text);
                Double TK = T + 273.15;   // T in K
                Double TK850 = T850 + 273.15;   // T in K
                Double DP = Double.Parse(textBox3.Text);
                Double RH = Double.Parse(textBox10.Text);
                Double RH850 = Double.Parse(textBox15.Text);
                Double DPC = T - (100 - RH) / 5;    // DP calculated
                Double DPC850 = T - (100 - RH850) / 5;    // DP calculated at 850 hPa

                // Actual vapor pressure
                Double ep = 6.11 * Math.Pow(10, 7.5 * (DP / (237.7 + DP)));
                // Actual vapor pressure at 850 hPa
                Double ep850 = 6.11 * Math.Pow(10, 7.5 * (DPC850 / (237.7 + DPC850)));

                // Mixing ratio (M)
                Double w = 621.97 * (ep / (P - ep));
                // Mixing ratio (M) at 850 hPa
                Double w850 = 621.97 * (ep850 / (850 - ep850));

                // Saturated vapor pressure
                Double es = 6.11 * Math.Pow(10, 7.5 * (T / (237.7 + T)));

                // Saturation Mixing ratio (M)
                Double ws = 621.97 * (es / (P - es));

                // Theta-e in K
                Double thetae = TK * Math.Pow((1000 / P), 0.286) + 3 * w;   // Theta-e in K
                // Theta-e in K at 850 hPa
                Double thetae850K = TK850 * Math.Pow((1000 / 850), 0.286) + 3 * w850;   // Theta-e in K

                // Theta-e in C
                Double thetaeC = thetae - 273.15;

                // Theta-e in C at 850 hPa
                Double thetae850C = thetae850K - 273.5; // Theta-e in °K at 850 hPa

                // Theta-e in C at 850 hPa
                //Double te850C = te850 - 273.5;

                // Snow level
                Double sl = 10 * (thetae850C - 12) / 0.12;

                textBox5.Text = String.Format("{0:0.00}", ep).ToString();

                // String.Format("{0:0.00}", 123.4567)
                textBox11.Text = String.Format("{0:0.00}", w).ToString();
                textBox6.Text = String.Format("{0:0.00}", es).ToString();
                textBox12.Text = String.Format("{0:0.00}", ws).ToString();
                textBox13.Text = String.Format("{0:0.00}", DPC).ToString();
                textBox18.Text = String.Format("{0:0.00}", DPC850).ToString();
                textBox7.Text = String.Format("{0:0.00}", (w/ws)*100).ToString();

                textBox4.Text = String.Format("{0:0.00}", thetae850C).ToString();
                textBox8.Text = String.Format("{0:0.00}", thetae850K).ToString();

                textBox16.Text = String.Format("{0:0.00}", thetae).ToString();
                textBox17.Text = String.Format("{0:0.00}", thetaeC).ToString();
                textBox9.Text = String.Format("{0:0.00}", sl).ToString();
            }
        }
    }
}
