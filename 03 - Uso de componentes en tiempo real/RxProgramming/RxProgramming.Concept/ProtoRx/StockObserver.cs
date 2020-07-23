using System;
using System.Collections.Generic;
using System.Text;

namespace RxProgramming.Concept.ProtoRx
{
    public class StockObserver
    {
        public string Name { get; set; }
        public void Notify(StockObservable observable, int units)
        {
            Console.WriteLine("[{0}] The stock {1} has now {2} units", this.Name, observable.Name, units);
        }
    }
}
