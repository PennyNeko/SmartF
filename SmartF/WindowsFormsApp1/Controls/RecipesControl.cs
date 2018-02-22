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
    public partial class RecipesControl : UserControl
    {
        public RecipesControl()
        {
            InitializeComponent();
        }

        private void listView1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (listView1.SelectedIndices.Count > 0)
            {
                checkedListBox1.Items.Clear();
                if (listView1.SelectedIndices[0] == 0)
                {
                    var items = checkedListBox1.Items;
                    items.Add("10 Bread Slices", true);
                    items.Add("1 Butter Pack", true);
                    items.Add("Salt");
                    items.Add("Pepper");
                    richTextBox1.Text = "Preheat the broiler.\nCut the bread into slices 1 to 2 inches thick.\n" +
                        "In a small bowl, mix butter, olive oil, garlic, oregano, salt and pepper.\nSpread the " +
                        "mixture evenly on the bread slices.\nOn a medium baking sheet, arrange the slices evenly " +
                        "and broil 5 minutes, or until slightly brown.\nCheck frequently so they do not burn.\nRemove " +
                        "from broiler.\nTop with cheese and return to broiler 2 to 3 minutes, until cheese is slightly " +
                        "brown and melted.\nServe at once.";
                }
                if (listView1.SelectedIndices[0] == 1)
                {
                    var items = checkedListBox1.Items;
                    items.Add("1 Sugar Pack");
                    items.Add("10 Bacon Slices");
                    items.Add("10 Chestnuts");
                    items.Add("Pepper");
                    richTextBox1.Text = "Preheat oven to 375 degrees F (190 degrees C).\nIn a medium - size mixing bowl," +
                        " combine brown sugar, Worcestershire sauce, and ketchup.\nCut bacon in half.Wrap one slice of bacon" +
                        " around each chestnut. Secure the bacon with a toothpick. Arrange the water chestnut wraps in a 9x13 " +
                        "inch baking dish.\nBake the water chestnut wraps for 10 to 15 minutes.\nRemove from water chestnut wraps" +
                        " from the oven and drain some of the grease out of the pan.Pour the sauce over the wraps.\nBake for 30 to 35 more minutes.";
                }
            }
        }

        private void simpleButton1_Click(object sender, EventArgs e)
        {
            string message = "Are you sure you wish to buy:\n";
            string caption = "Confirm payment";

            MessageBoxButtons buttons = MessageBoxButtons.YesNo;
            DialogResult result1;
            var items = checkedListBox1.Items;
            for (int i = 0; i < checkedListBox1.Items.Count; i++)
            {
                if (checkedListBox1.GetItemCheckState(i) != CheckState.Checked)
                {
                    message += checkedListBox1.Items[i] + "\n";
                }
            }
            result1 = MessageBox.Show(message, caption, buttons);
            if (result1 == DialogResult.Yes)
            {
                DialogResult result2 = MessageBox.Show("Items bought successfully", "Success");
                for (int i = 0; i < checkedListBox1.Items.Count; i++)
                {
                    if (checkedListBox1.GetItemCheckState(i) != CheckState.Checked)
                    {
                        checkedListBox1.SetItemCheckState(i, CheckState.Checked);
                    }
                }
            }
            else
            {
                DialogResult result2 = MessageBox.Show("Purchase canceled", "Canceled");
            }
        }
    }
}
