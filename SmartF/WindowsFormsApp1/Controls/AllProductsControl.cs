using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WindowsFormsApp1.Controls;

namespace WindowsFormsApp1
{
    public partial class AllProductsControl : UserControl
    {
        string[,] productInformation = new string[MainForm.products.Count, 4];
        public AllProductsControl()
        {
            InitializeComponent();
            for (int i = 0; i< MainForm.products.Count; i++)
            {
                productInformation[i,0] = MainForm.products[i].Name;
                productInformation[i,1] = MainForm.products[i].Count.ToString();
                if (MainForm.products[i].productMeasurement == Product.ProductMeasurement.Bottle)
                    productInformation[i,1] += " Bottle(s)";
                if (MainForm.products[i].productMeasurement == Product.ProductMeasurement.Pack)
                    productInformation[i,1] += " Pack(s)";
                if (MainForm.products[i].productMeasurement == Product.ProductMeasurement.Slice)
                    productInformation[i,1] += " Slice(s)";
                productInformation[i,2] = MainForm.products[i].ExpirationDate.Date.ToString();
                string[] temp = { productInformation[i,0], productInformation[i, 1], productInformation[i, 2] }; 
                listView1.Items.Add(new ListViewItem(temp, MainForm.products[i].ImageIndex));
                productInformation[i, 3] = MainForm.products[i].ImageIndex.ToString();
            }
        }

        private void listView1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (listView1.SelectedIndices.Count > 0)
            {
                label6.Text = productInformation[listView1.SelectedIndices[0], 2];
                label7.Text = productInformation[listView1.SelectedIndices[0], 0];
                label8.Text = productInformation[listView1.SelectedIndices[0], 1];
                pictureBox1.Image = imageList1.Images[Int32.Parse(productInformation[listView1.SelectedIndices[0], 3])];
            }
        }

        private void AllProductsControl_Load(object sender, EventArgs e)
        {

        }

        private void simpleButton1_Click(object sender, EventArgs e)
        {
            RecipesControl recipesControl = (RecipesControl)MainForm.existingControls["find_recipes"];
            Dock = DockStyle.Fill;
            Controls.Add(recipesControl);
            recipesControl.BringToFront();

            string message = "Press \"Buy Missing Ingredients\" to buy all the unchecked ingredients automatically";
            string caption = "Hint!";
            MessageBoxButtons buttons = MessageBoxButtons.OK;
            DialogResult result;

            // Displays the MessageBox.

            if (!MainForm.wasRecipeHintShown)
            {
                result = MessageBox.Show(message, caption, buttons);
                if (result == DialogResult.OK)
                {
                    MainForm.wasRecipeHintShown = true;

                }
            }
        }
    }
}
