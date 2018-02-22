using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp1.Controls
{
    public partial class ProductsOnOfferControl : UserControl
    {
        public ProductsOnOfferControl()
        {
            InitializeComponent();
        }

        private void ProductsOnOfferControl_Load(object sender, EventArgs e)
        {
            for (int i = 0; i < 2; i++)
            {
                string[] offeredItem = { MainForm.products[i].Name, "50% off" };
                listView1.Items.Add(new ListViewItem(offeredItem, MainForm.products[i].ImageIndex));
            }

        }

        private void listView1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (listView1.SelectedIndices.Count > 0)
            {
                label11.Text = MainForm.products[listView1.SelectedIndices[0]].Name;
                label13.Text = MainForm.products[listView1.SelectedIndices[0]].Count.ToString();
                label12.Text = MainForm.products[listView1.SelectedIndices[0]].ExpirationDate.ToString();
                pictureBox1.Image = imageList1.Images[listView1.SelectedIndices[0]];

                label14.Text = "1";
                label16.Text = "2 €";
                label15.Text = DateTime.Today.AddDays(10).ToString("dd/MM/yyyy");
                label17.Text = (Int32.Parse(label14.Text) * 2).ToString()+ " €";

            }
        }
        

        private void simpleButton4_Click(object sender, EventArgs e)
        {
            label14.Text = (Int32.Parse(label14.Text) + 1).ToString();
            label17.Text = (Int32.Parse(label14.Text) * 2).ToString() + " €";
        }

        private void simpleButton3_Click(object sender, EventArgs e)
        {
            label14.Text = (Int32.Parse(label14.Text) - 1).ToString();
            label17.Text = (Int32.Parse(label14.Text) * 2).ToString() + " €";
        }

        private void simpleButton1_Click(object sender, EventArgs e)
        {
            if (listView1.SelectedIndices.Count > 0)
            {
                string message = "Are you sure you wish to buy:\n";
                message += label14.Text + " ";
                message += MainForm.products[listView1.SelectedIndices[0]].Name;
                message += " for " + (Int32.Parse(label14.Text) * 2).ToString() + "€";
                string caption = "Confirm payment";

                MessageBoxButtons buttons = MessageBoxButtons.YesNo;
                DialogResult result1;
                DialogResult result2;
                result1 = MessageBox.Show(message, caption, buttons);
                if (result1 == DialogResult.Yes)
                {

                    result2 = MessageBox.Show("Products bought!", "Success");

                }
                else
                {
                    result2 = MessageBox.Show("Purchase canceled!", "Canceled");
                }
            }
        }
    }
}
