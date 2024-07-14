using Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.EmployeeServices
{
    public class ProductService
    {
        private readonly IProduct datasource;
        public ProductService(IProduct datasource)
        {
            this.datasource = datasource;
        }

        public void CreateProduct(Product product)
        {
            datasource.CreateProduct(product);
        }

        public void DeleteProduct(int id)
        {
            datasource.DeleteProduct(id);
        }

        public Product GetProduct(int id)
        {
            return datasource.GetProduct(id);
        }

        public void UpdateProduct(Product product)
        {
            datasource.UpdateProduct(product);
        }

        public List<Product> ViewActiveProduct()
        {
            return datasource.ViewActiveProduct();
        }

        public List<Product> ViewAllProduct()
        {
            return datasource.ViewAllProduct();
        }

        public List<string> GetCategories()
        {
            return datasource.GetCategories();
        }
    }
}
