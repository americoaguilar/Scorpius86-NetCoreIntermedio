using System;
using System.Reactive.Subjects;
using System.Threading;

namespace RxProgramming.Basic
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Subject! (Without Memory)");
            Console.WriteLine("====================");

            var subject = new Subject<int>();
            subject.OnNext(1);
            subject.Subscribe(iterator => Console.WriteLine("Iterator: " + iterator));
            subject.OnNext(2);
            subject.OnNext(3);
            subject.Subscribe(iterator => Console.WriteLine("Other Subscriber Iterator: " + iterator));

            Console.WriteLine("");
            Console.WriteLine("ReplaySubject! (With Memory)");
            Console.WriteLine("============================");

            var replaySubject = new ReplaySubject<int>();
            replaySubject.OnNext(1);
            replaySubject.OnNext(2);
            replaySubject.Subscribe(iterator => Console.WriteLine("Iterator: " + iterator));
            replaySubject.OnNext(3);
            replaySubject.Subscribe(iterator => Console.WriteLine("Other Subscriber Iterator: " + iterator));

            Console.WriteLine("");
            Console.WriteLine("BehaviorSubject! (Last Memory)");
            Console.WriteLine("==============================");

            var behaviorSubject = new BehaviorSubject<int>(0);
            behaviorSubject.OnNext(1);
            behaviorSubject.OnNext(2);
            behaviorSubject.Subscribe(iterator => Console.WriteLine("Iterator: " + iterator));
            behaviorSubject.OnNext(3);
            behaviorSubject.Subscribe(iterator => Console.WriteLine("Other Subscriber Iterator: " + iterator));

            Console.WriteLine("");
            Console.WriteLine("AsyncSubject! (Notify only Completed, Last Memory)");
            Console.WriteLine("==================================================");

            var asyncSubject = new AsyncSubject<int>();
            asyncSubject.Subscribe(iterator => Console.WriteLine("Iterator: " + iterator));
            asyncSubject.OnNext(1);
            asyncSubject.OnNext(2);
            asyncSubject.OnNext(3);
            Console.WriteLine("Apply Completed");
            asyncSubject.OnCompleted();
            asyncSubject.Subscribe(iterator => Console.WriteLine("Other Subscriber Iterator: " + iterator));
        }
    }
}
