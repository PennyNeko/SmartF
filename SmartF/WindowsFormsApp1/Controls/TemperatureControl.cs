using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp1
{
    public partial class TemperatureControl : UserControl
    {
        public TemperatureControl()
        {
            InitializeComponent();
        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void simpleButton1_Click(object sender, EventArgs e)
        {
            label3.Text = (Int32.Parse(label3.Text) + 1).ToString();
        }

        private void simpleButton2_Click(object sender, EventArgs e)
        {
            label3.Text = (Int32.Parse(label3.Text) - 1).ToString();
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void simpleButton4_Click(object sender, EventArgs e)
        {
            label2.Text = (Int32.Parse(label2.Text) + 1).ToString();
        }

        private void simpleButton3_Click(object sender, EventArgs e)
        {
            label2.Text = (Int32.Parse(label2.Text) - 1).ToString();
        }

        private void label6_Click(object sender, EventArgs e)
        {

        }
    }
}
