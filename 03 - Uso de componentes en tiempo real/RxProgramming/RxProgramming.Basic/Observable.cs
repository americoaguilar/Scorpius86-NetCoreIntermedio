using System;
using System.Collections.Generic;
using System.Text;

namespace RxProgramming.Basic
{
    public class Observable<T> : IObservable<T>
    {
        private readonly List<IObserver<T>> observers;
        public Observable()
        {
            this.observers = new List<IObserver<T>>();
        }
        public IDisposable Subscribe(IObserver<T> observer)
        {
            if (!observers.Contains(observer))
            {
                observers.Add(observer);
            }

            return new Unsubscriber<T>(observers, observer);
        }

        public void OnNext(T value)
        {
            foreach (var observer in observers)
            {
                observer.OnNext(value);
            }
        }

        public void OnError(Exception error)
        {
            foreach (var observer in observers)
            {
                observer.OnError(error);
            }
        }

        public void OnCompleted()
        {
            foreach (var observer in observers)
            {
                observer.OnCompleted();
            }
        }
    }
}
