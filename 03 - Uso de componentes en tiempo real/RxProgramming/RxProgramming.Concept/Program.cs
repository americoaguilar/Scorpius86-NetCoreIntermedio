using RxProgramming.Concept.ProtoRx;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;

namespace RxProgramming.Concept
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Without Rx");
            Console.WriteLine("======");

            var iterable = new List<int> { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 };
            foreach (var iterator in iterable)
            {
                if (iterator < 10)
                {
                    System.Console.WriteLine(iterator);
                }
            }

            
            Console.WriteLine("");
            Console.WriteLine("With LINQ");
            Console.WriteLine("======");
            var query = iterable.Where(iterator => iterator < 10).Select(iterator => { System.Console.WriteLine(iterator); return iterator; });
            query.ToList();


            Console.WriteLine("");
            Console.WriteLine("With ProtoRx");
            Console.WriteLine("======");

            var ApplesStock = new StockObservable { Name = "Apples stock" };
            var PearsStock = new StockObservable { Name = "Pears stock" };
            var CabinetsStock = new StockObservable { Name = "Cabinets stock" };

            var FruitStore = new StockObserver { Name = "Fruit store" };
            var Storage = new StockObserver { Name = "storage" };

            ApplesStock.Subscribe(FruitStore);
            ApplesStock.Subscribe(Storage);

            PearsStock.Subscribe(FruitStore);
            PearsStock.Subscribe(Storage);

            CabinetsStock.Subscribe(Storage);

            Console.WriteLine("");
            Console.WriteLine("Initialize apples and pears to 20 units");
            ApplesStock.Units = 20;
            PearsStock.Units = 20;

            Console.WriteLine("");
            for (int i = 0; i < 5; i++)
            {
                if (i % 2 == 0)
                {
                    Console.WriteLine("Rest an apple");
                    ApplesStock.Units--;
                }
                else
                {
                    Console.WriteLine("Rest a pear");
                    PearsStock.Units--;
                }

                Thread.Sleep(1000);
            }

            Console.WriteLine("");
            Console.WriteLine("Initialize cabinets to 3 units");
            CabinetsStock.Units = 3;

            Thread.Sleep(1000);

            Console.WriteLine("Add a cabinet");
            CabinetsStock.Units = 4;

            System.Console.ReadLine();
        }
    }
}
