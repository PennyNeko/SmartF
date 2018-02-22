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
    public partial class ExpiringSoonControl : UserControl
    {
        public ExpiringSoonControl()
        {
            InitializeComponent();
        }
        string[,] productInformation = new string[MainForm.products.Count, 5];
        private void ExpiringSoonControl_Load(object sender, EventArgs e)
        {
            for (int i = 0; i < ((MainForm.products.Count<4)? MainForm.products.Count :4); i++)
            {
                productInformation[i, 0] = MainForm.products[i].Name;
                productInformation[i, 3] = MainForm.products[i].Count.ToString();
                if (MainForm.products[i].productMeasurement == Product.ProductMeasurement.Bottle)
                    productInformation[i, 3] += " Bottle(s)";
                if (MainForm.products[i].productMeasurement == Product.ProductMeasurement.Pack)
                    productInformation[i, 3] += " Pack(s)";
                if (MainForm.products[i].productMeasurement == Product.ProductMeasurement.Slice)
                    productInformation[i, 3] += " Slice(s)";
                productInformation[i, 2] = MainForm.products[i].ExpirationDate.Date.ToString();
                productInformation[i, 1] = ((MainForm.products[i].ExpirationDate.Date - DateTime.Now.Date).TotalDays).ToString() + " day(s) to expire!";
                string[] temp = { productInformation[i, 0], productInformation[i, 1], productInformation[i, 2], productInformation[0,3] };
                listView1.Items.Add(new ListViewItem(temp, MainForm.products[i].ImageIndex));
                productInformation[i, 4] = MainForm.products[i].ImageIndex.ToString();
            }
        }

        private void listView1_SelectedIndexChanged_1(object sender, EventArgs e)
        {
            if (listView1.SelectedIndices.Count > 0)
            {
                label7.Text = productInformation[listView1.SelectedIndices[0], 0];
                label6.Text = productInformation[listView1.SelectedIndices[0], 2];
                label8.Text = productInformation[listView1.SelectedIndices[0], 3];
                pictureBox1.Image = imageList1.Images[Int32.Parse(productInformation[listView1.SelectedIndices[0], 4])];
            }
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
