using System;
using System.Collections.Generic;
using System.Globalization;
using ExercicioEtiquetas.Entities;

namespace ExercicioEtiquetas
{
    class Program
    {
        static void Main(string[] args)
        {
            List<Product> products = new List<Product>();
            Console.Write("Enter the number of products: ");
            int n = int.Parse(Console.ReadLine());

            for (int i = 1; i <= n; i++)
            {
                Console.WriteLine($"\nProduct #{i} data:");
                Console.Write("Common, Used or Imported (c/u/i)? ");
                char op = char.Parse(Console.ReadLine());
                Console.Write("Name: ");
                string name = Console.ReadLine();
                Console.Write("Price: ");
                double price = double.Parse(Console.ReadLine(), CultureInfo.InvariantCulture);

                switch (op)
                {
                    case 'c':
                        products.Add(new Product(name, price));
                        break;
                    case 'i':
                        Console.Write("Customs fee: ");
                        double customsFee = double.Parse(Console.ReadLine(), CultureInfo.InvariantCulture);

                        products.Add(new ImportedProduct(name, price, customsFee));
                        break;
                    case 'u':
                        Console.Write("Manufacture date (DD/MM/YYYY): ");
                        DateTime manufactureDate = DateTime.Parse(Console.ReadLine());


                        products.Add(new UsedProduct(name, price, manufactureDate));
                        break;
                    default:
                        break;
                }
            }

            Console.WriteLine("\n\nPRICE TAGS: ");
            foreach (var item in products)
            {
                Console.WriteLine(item.PriceTag());
            }
        }
    }
}
