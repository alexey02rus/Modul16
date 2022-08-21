using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace Task2
{
    class Program
    {
        static void Main(string[] args)
        {
            string jsonString = string.Empty;
            using(StreamReader sr = new StreamReader("../../../Products.json"))
            {
                jsonString = sr.ReadToEnd();
            }
            Product[] products = JsonSerializer.Deserialize<Product[]>(jsonString);
            Product maxProduct = products[0];
            foreach  (Product p in products)
            {
                if (p.Price > maxProduct.Price)
                    maxProduct = p;
            }
            Console.WriteLine($"Самый дорогой товар: {maxProduct.Name}\nКод товара: {maxProduct.Code}\nЦена: {maxProduct.Price}");
            Console.ReadKey();
        }
    }
}
