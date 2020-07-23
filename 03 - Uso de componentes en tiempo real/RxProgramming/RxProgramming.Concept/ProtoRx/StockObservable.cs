using System;
using System.Collections.Generic;
using System.Text;

namespace RxProgramming.Concept.ProtoRx
{
    public class StockObservable
    {
        private readonly IList<StockObserver> _observers;

        private int _units;

        public StockObservable()
        {
            this._observers = new List<StockObserver>();
        }

        public string Name { get; set; }

        public int Units
        {
            get
            {
                return _units;
            }

            set
            {
                if (_units != value)
                {
                    _units = value;
                    NotifyObservers();
                }
            }
        }

        public void Subscribe(StockObserver observer)
        {
            Console.WriteLine(observer.Name + " is subscribed to " + Name);
            _observers.Add(observer);
        }

        public void Unsubscribe(StockObserver observer)
        {
            if (_observers.Contains(observer))
            {
                _observers.Remove(observer);
            }
        }

        private void NotifyObservers()
        {
            foreach (var observer in _observers)
            {
                observer.Notify(this, _units);
            }
        }
    }
}
