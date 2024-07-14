using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Interfaces
{
    public interface IProduct
    {
        void CreateProduct(Product product);
        void UpdateProduct(Product product);
        void DeleteProduct(int id);
        Product GetProduct(int id);
        List<Product> ViewAllProduct();
        List<Product> ViewActiveProduct();
        List<string> GetCategories();
    }
}
