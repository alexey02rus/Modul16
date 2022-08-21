using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.Encodings.Web;
using System.Text.Json;
using System.Text.Unicode;
using System.Threading.Tasks;

namespace Task1
{
    class Program
    {
        static void Main(string[] args)
        {
            const int n = 5;
            Product[] products = new Product[n];
            int code;
            bool beCode;
            double price;
            bool bePrice;
            string name;
            for (int i = 0; i < n; i++)
            {
                Console.WriteLine($"Введите код {i+1} товара");
                do
                {
                    beCode = int.TryParse(Console.ReadLine(), out code);
                    if (!beCode)
                    {
                        Console.WriteLine("Ошибка! Неверный формат данных. Попробуйте ещё раз.");
                    }
                } while (!beCode);
                Console.WriteLine($"Введите наименование {i + 1} товара");
                name = Console.ReadLine();
                Console.WriteLine($"Введите цену {i + 1} товара");
                do
                {
                    bePrice = double.TryParse(Console.ReadLine(), out price);
                    if (!bePrice)
                    {
                        Console.WriteLine("Ошибка! Неверный формат данных. Попробуйте ещё раз.");
                    }
                } while (!bePrice);
                Console.WriteLine();
                products[i] = new Product() { Code = code, Name = name, Price = price };
            }
            JsonSerializerOptions options = new JsonSerializerOptions
            {
                Encoder = JavaScriptEncoder.Create(UnicodeRanges.BasicLatin, UnicodeRanges.Cyrillic),
                WriteIndented = true
            };
            string jsonString = JsonSerializer.Serialize(products, options);

            using (StreamWriter sw = new StreamWriter("../../../Products.json"))
            {
                sw.WriteLine(jsonString);
            }
        }
    }
}
