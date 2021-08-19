using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Simulation_Lab2
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        decimal t, x0, y0, v0, cosa, sina;
        private void button1_Click(object sender, EventArgs e)
        {
            label4.Text = "Time: 0";
            if (!timer1.Enabled)
            {
                chart1.Series[0].Points.Clear();
                t = 0;
                x0 = 0;
                y0 = inputHeight.Value;
                v0 = inputSpeed.Value;

                double a = (double)inputAngle.Value * Math.PI / 180;
                cosa = (decimal)Math.Cos(a);
                sina = (decimal)Math.Sin(a);

                chart1.Series[0].Points.AddXY(x0, y0);
                timer1.Start();
            }
        }

        const decimal dt = 0.1M;
        const decimal g = 9.81M;
        private void timer1_Tick(object sender, EventArgs e)
        {
            t += dt;

            decimal x = x0 + v0 * cosa * t;
            decimal y = y0 + v0 * sina * t - g * t * t /  2;

            label4.Text = "Time: " + t;
            chart1.Series[0].Points.AddXY(x, y);
            if (y <= 0)
            {
                timer1.Stop();
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            timer1.Enabled = !timer1.Enabled;
        }
    }
}
