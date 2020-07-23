using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Reactive.Linq;
using System.Reactive.Subjects;
using System.Threading;

namespace RxProgramming.Linq
{
    class Program
    {
        static string urlEmployeesApi = "https://localhost:44333/api/Employees";
        static void Main(string[] args)
        {
            Console.WriteLine("Linq, ToObservable");
            Console.WriteLine("====================");

            var enumerable = new List<int> { 1, 2, 3 };
            var observable = enumerable.ToObservable();

            observable
                .Where(i => i < 3)
                .Sum()
                .Subscribe(Console.WriteLine);

            Console.WriteLine("");
            Console.WriteLine("Observable.Never, Automatic end Task");
            Console.WriteLine("==========================================");

            var neverObservable = Observable.Never<int>();
            //Same
            var subjectNever = new Subject<int>();

            Console.WriteLine("");
            Console.WriteLine("Observable.Empty, Manual end Task");
            Console.WriteLine("==========================================");

            var emptyObservable = Observable.Empty<int>();
            //Same
            var subjectEmpty = new Subject<int>();
            subjectEmpty.OnCompleted();

            Console.WriteLine("");
            Console.WriteLine("Observable.Return, Automatic Return and end Task");
            Console.WriteLine("=======================================================");
            var returnObservable = Observable.Return(1);
            returnObservable.Subscribe(iterator => Console.WriteLine("Observable.Return Iterator : " + iterator));
            //Same
            var subjectReturn = new ReplaySubject<int>();
            subjectReturn.OnNext(1);
            subjectReturn.OnCompleted();
            returnObservable.Subscribe(iterator => Console.WriteLine("Same subjectReturn Iterator : " + iterator));

            Console.WriteLine("");
            Console.WriteLine("Observable.Throw, return Error");
            Console.WriteLine("=======================================================");
            var throwObservable = Observable.Throw<int>(new Exception("throwObservable"));
            //throwObservable.Subscribe(iterator => Console.WriteLine(iterator));
            //Same
            var subjectThrow = new ReplaySubject<int>();
            subjectThrow.OnError(new Exception("subjectThrow"));
            //subjectThrow.Subscribe(iterator => Console.WriteLine(iterator));



            Console.WriteLine("");
            Console.WriteLine("Create");
            Console.WriteLine("=======================================================");
            // Subject
            var subject = new ReplaySubject<int>();
            subject.OnNext(1);
            subject.OnNext(2);
            subject.OnCompleted();

            // Same
            var enumerableCreate = new List<int> { 1, 2 };
            var observableEnumeration = enumerableCreate.ToObservable();
            observableEnumeration.Subscribe(iterator => Console.WriteLine("ToObservable Iterator : " + iterator));

            // Same
            var created = Observable.Create<int>(observable =>
            {
                observable.OnNext(1);
                observable.OnNext(2);
                observable.OnCompleted();

                return () => { };
            });
            created.Subscribe(iterator => Console.WriteLine("Observable.Create Iterator : " + iterator));


            Console.WriteLine("");
            Console.WriteLine("Range");
            Console.WriteLine("=======================================================");
            var rangeObservable = Observable.Range(0, 10);
            rangeObservable.Subscribe(iterator => Console.WriteLine("Observable.Range Iterator : " + iterator));
            //Same
            var createObservable = Observable.Create<int>(observable =>
            {
                for (var i = 0; i < 10; i++)
                {
                    observable.OnNext(i);
                }

                observable.OnCompleted();
                return () => { };
            });
            createObservable.Subscribe(iterator => Console.WriteLine("Observable.Create Iterator : " + iterator));
            //Same
            var forObservable = Observable.Generate(0, i => i < 10, i => i + 1, i => i);
            forObservable.Subscribe(iterator => Console.WriteLine("Observable.Generate Iterator : " + iterator));


            Console.WriteLine("");
            Console.WriteLine("Time");
            Console.WriteLine("=======================================================");
            var timeObserver = Observable.Interval(TimeSpan.FromSeconds(1));
            //timeObserver.Subscribe(iterator => Console.WriteLine("Observable.Interval Iterator : " + iterator));
            //Same
            var timerObserver = Observable.Timer(TimeSpan.FromSeconds(2), TimeSpan.FromSeconds(1));
            //timerObserver.Subscribe(iterator => Console.WriteLine("Observable.Timer Iterator : " + iterator));


            Console.WriteLine("");
            Console.WriteLine("Async");
            Console.WriteLine("=======================================================");

            var asyncObservable = Observable.ToAsync<string,int, string>(FunctionThatTakesALongTime)("ToAsync", 2);
            asyncObservable.Subscribe(r => Console.WriteLine("Observable.ToAsync Result : " + r));

            var asyncObservable2 = Observable.ToAsync<string, int, string>(FunctionThatTakesALongTime)("ToAsync", 10);
            asyncObservable2.Subscribe(r => Console.WriteLine("Observable.ToAsync Result2 : " + r));

            WebRequest request = WebRequest.Create(urlEmployeesApi);
            var responseObservable = Observable.ToAsync<WebResponse>(request.GetResponse)();
            responseObservable.Subscribe(response => {
                using (Stream dataStream = response.GetResponseStream())
                {
                    StreamReader reader = new StreamReader(dataStream);
                    string responseFromServer = reader.ReadToEnd();
                    Console.WriteLine("responseObservable : " + responseFromServer);
                }
            },(err)=>{
                Console.WriteLine("responseObservable : " + err.Message);
            });

            Console.ReadLine();
        }

        public static string FunctionThatTakesALongTime(string param1,int param2)
        {
            Thread.Sleep(param2*1000);
            return "End Task" + param1;
        }
    }
}
