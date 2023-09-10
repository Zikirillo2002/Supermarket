using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SupermarketDBService
{
    internal class Program
    {
        static void Main(string[] args)
        {
            CategoryDBService db = new CategoryDBService();

            //db.CreateCategory("Bakery");
            //db.ReadAllCategory();
            //db.UpdateCategory(5, "Bakery products");
            //db.DeleteCategory(5);
            //db.GetCategoryById(1);
            //db.GetCategoryByName("Fruit");
            //db.GetByCountProducts(3);

            ProductDBService productDB = new ProductDBService();

            //productDB.CreateProduct("FLASH", 8000, 1);
            //productDB.ReadAllProducts();
            //productDB.UpdateProduct(21,"GORILLA",9000,1);
            //productDB.DeleteProduct(21);
            //productDB.GetProductById(15);
            productDB.GetProductByName("kanta");
            //productDB.GetProductByPrice(40000, '>');
            //productDB.GetProductByCategory_Id(4);
        }
    }
}
