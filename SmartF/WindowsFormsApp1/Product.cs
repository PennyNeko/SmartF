using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApp1
{
    public class Product
    {
        public Product(string name, int count, int imageIndex, DateTime expirationDate, ProductMeasurement productMeasurement)
        {
            Name = name;
            Count = count;
            ImageIndex = imageIndex;
            ExpirationDate = expirationDate;
            this.productMeasurement = productMeasurement;
        }

        public enum ProductMeasurement { Bottle, Slice, Pack }
        public string Name { set;get; }
        public int Count { set; get; }
        public int ImageIndex { set; get; }
        public DateTime ExpirationDate { set; get; }
        public ProductMeasurement productMeasurement { set; get; }
    }
}
