using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Transactions;

namespace Domain
{
    public class Product
    {
        public int productId { get; set; }
        public string name { get; set; }
        public string brand { get; set; }
        public decimal price { get; set; }
        public string description { get; set; }
        public string category { get; set; }
        public int height { get; set; }
        public int width { get; set;}
        public int length { get; set; }
        public int weight { get; set; }
        public int stock { get; set; }
        public bool shown { get; set; }

        public Product(int productId, string name, string brand, decimal price, string description, string category, int height, int width, int length, int weight, int stock, bool shown)
        {
            this.productId = productId;
            this.name = name;
            this.brand = brand;
            this.price = price;
            this.description = description;
            this.category = category;
            this.height = height;
            this.width = width;
            this.length = length;
            this.weight = weight;
            this.stock = stock;
            this.shown = shown;
        }
    }
}
