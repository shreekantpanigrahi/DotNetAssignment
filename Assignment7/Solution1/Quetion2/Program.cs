using static System.Net.Mime.MediaTypeNames;
using System.Collections.Generic;
using System.Runtime.Intrinsics.X86;
using System.Xml.Linq;
using System.ComponentModel;

namespace Quetion2
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //You are working on an e-commerce application that has a list of products.
            //Each product has properties: ProductID, Name, Category, and Price. use
            //LINQ to find all products in the "Electronics" category that cost more
            //than Rs1000?

            #region  Question2

            List<Product> prod = new List<Product>
            {
                new Product { ProductID = 1, Name = "Laptop", Category = "Electronics", Price = 50000 },
                new Product { ProductID = 2, Name = "Smartphone", Category = "Electronics", Price = 15000 },
                new Product { ProductID = 3, Name = "T-Shirt", Category = "Clothing", Price = 800 },
                new Product { ProductID = 4, Name = "Tablet", Category = "Electronics", Price = 1200 },
                new Product { ProductID = 5, Name = "Headphones", Category = "Electronics", Price = 900 },
                new Product { ProductID = 6, Name = "Shoes", Category = "Footwear", Price = 2000 }
            };

            var expensiveElectronic = prod
                .Where(p => p.Category == "Electronics" && p.Price > 1000)
                .ToList();

            Console.WriteLine("Electronics Products costing more than Rs 1000:");
            foreach(var product in expensiveElectronic)
            {
                Console.WriteLine($"Product ID: {product.ProductID}, Name: {product.Name}, Price: {product.Price}");
            }
#endregion

            #region Question 3
            //3. How would you use LINQ to find the most expensive product in the list? 

            var maxPrice = prod.Max(p => p.Price); // retrieve most expensive product from the list onlty one product.
            var mostexpensive = prod.FirstOrDefault(p => p.Price == maxPrice);
            //Console.WriteLine($"The most expensive element in the List: {mostexpensive.Price}");
            if (mostexpensive != null)  // Check if a product exists
            {
                Console.WriteLine($"The most expensive product is:");
                Console.WriteLine($"Product ID: {mostexpensive.ProductID}, Name: {mostexpensive.Name}, Price: {mostexpensive.Price}");
            }
            else
            {
                Console.WriteLine("No products available.");
            }
            #endregion

        }
    }
}
