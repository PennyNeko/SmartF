using DevExpress.XtraBars.Navigation;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WindowsFormsApp1.Controls;

namespace WindowsFormsApp1
{
    
    public partial class MainForm : DevExpress.XtraEditors.XtraForm
    {
        public static Dictionary<string, Control> existingControls = new Dictionary<string, Control>();
        public static List<Product> products = new List<Product>();
        bool wasMainHintShown = false;
        public static bool wasRecipeHintShown = false;
        public MainForm()
        {
            InitializeComponent();
            FormBorderStyle = FormBorderStyle.None;
            AddDummyProducts();
            AddControlsToList();
        }

        private void AddDummyProducts()
        {
            products.Add(new Product("Milk", 1, 0,DateTime.Today.Date ,Product.ProductMeasurement.Bottle));
            products.Add(new Product("Butter", 2, 1, DateTime.Today.AddDays(1).Date, Product.ProductMeasurement.Pack));
            products.Add(new Product("Cheese", 10, 2, DateTime.Today.AddDays(1).Date, Product.ProductMeasurement.Slice));
            products.Add(new Product("Egg", 5, 3, DateTime.Today.AddDays(2).Date, Product.ProductMeasurement.Pack));
            products.Add(new Product("Bread", 10, 4, DateTime.Today.AddDays(3).Date, Product.ProductMeasurement.Slice));
        }

        private void AddControlsToList()
        {
            existingControls.Add("browser", new BrowserControl());
            existingControls.Add("temperature", new TemperatureControl());
            existingControls.Add("weather", new WeatherControl());
            existingControls.Add("all_products", new AllProductsControl());
            existingControls.Add("fridge_camera", new FridgeCameraControl());
            existingControls.Add("expiring_soon", new ExpiringSoonControl());
            existingControls.Add("on_offer", new ProductsOnOfferControl());
            existingControls.Add("find_recipes", new RecipesControl());
        }

        private void listView2_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void mainPage1_Load(object sender, EventArgs e)
        {

        }
        
        private void simpleButton1_Click(object sender, EventArgs e)
        {
            foreach (Control c in existingControls.Values)
            {
                try
                {
                    Controls.Remove(c);
                }
                catch
                {

                }
            }
            simpleButton1.Visible = false;
        }

        private void tileItem1_ItemClick(object sender, DevExpress.XtraEditors.TileItemEventArgs e)
        {
            TemperatureControl tempCont= (TemperatureControl)existingControls["temperature"];
            Dock = DockStyle.Fill;
            Controls.Add(tempCont);
            tempCont.BringToFront();
            ShowButton();
        }

        private void browserTile_ItemClick(object sender, DevExpress.XtraEditors.TileItemEventArgs e)
        {
            BrowserControl brCont = (BrowserControl)existingControls["browser"];
            Dock = DockStyle.Fill;
            Controls.Add(brCont);
            brCont.BringToFront();
            ShowButton();
        }

        private void weatherTile_ItemClick(object sender, DevExpress.XtraEditors.TileItemEventArgs e)
        {
            WeatherControl weathCont = (WeatherControl)existingControls["weather"];
            Dock = DockStyle.Fill;
            Controls.Add(weathCont);
            weathCont.BringToFront();
            ShowButton();
        }

        private void allProductsTile_ItemClick(object sender, DevExpress.XtraEditors.TileItemEventArgs e)
        {
            AllProductsControl allProdCont = (AllProductsControl)existingControls["all_products"];
            Dock = DockStyle.Fill;
            Controls.Add(allProdCont);
            allProdCont.BringToFront();
            ShowButton();
        }
        private void fridgeCameraTile_ItemClick(object sender, DevExpress.XtraEditors.TileItemEventArgs e)
        {
            FridgeCameraControl fridgeCameraControl = (FridgeCameraControl)existingControls["fridge_camera"];
            Dock = DockStyle.Fill;
            Controls.Add(fridgeCameraControl);
            fridgeCameraControl.BringToFront();
            ShowButton();
        }

        private void expiringProductsTile_ItemClick(object sender, DevExpress.XtraEditors.TileItemEventArgs e)
        {
            ExpiringSoonControl expiringSoonControl = (ExpiringSoonControl)existingControls["expiring_soon"];
            Dock = DockStyle.Fill;
            Controls.Add(expiringSoonControl);
            expiringSoonControl.BringToFront();
            ShowButton();
        }
        private void ShowButton()
        {
            simpleButton1.Visible = true;
            simpleButton1.BringToFront();
        }

        private void productOffersTile_ItemClick(object sender, DevExpress.XtraEditors.TileItemEventArgs e)
        {
            ProductsOnOfferControl productsOnOffer = (ProductsOnOfferControl)existingControls["on_offer"];
            Dock = DockStyle.Fill;
            Controls.Add(productsOnOffer);
            productsOnOffer.BringToFront();
            ShowButton();
        }

        private void findRecipesTile_ItemClick(object sender, DevExpress.XtraEditors.TileItemEventArgs e)
        {
            RecipesControl recipesControl= (RecipesControl)existingControls["find_recipes"];
            Dock = DockStyle.Fill;
            Controls.Add(recipesControl);
            recipesControl.BringToFront();
            ShowButton();

            string message = "Press \"Buy Missing Ingredients\" to buy all the unchecked ingredients automatically";
            string caption = "Hint!";
            MessageBoxButtons buttons = MessageBoxButtons.OK;
            DialogResult result;

            // Displays the MessageBox.

            if (!wasRecipeHintShown)
            {
                result = MessageBox.Show(message, caption, buttons);
                if (result == DialogResult.OK)
                {
                    wasRecipeHintShown = true;

                }
            }
        }

        private void tileControl1_Click(object sender, EventArgs e)
        {

        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            
        }

        private void MainForm_Shown(object sender, EventArgs e)
        {
            string message = "Press any tile to get more information";
            string caption = "Hint!";
            MessageBoxButtons buttons = MessageBoxButtons.OK;
            DialogResult result;

            // Displays the MessageBox.

            if (!wasMainHintShown)
            {
                result = MessageBox.Show(message, caption, buttons);
                if (result == DialogResult.OK)
                {
                    wasMainHintShown = true;

                }
            }
        }
    }
}
