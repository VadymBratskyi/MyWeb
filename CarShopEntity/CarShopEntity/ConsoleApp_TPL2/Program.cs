using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ConsoleApp_TPL2
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Thread main method start=> " + Thread.CurrentThread.ManagedThreadId);

            Task<int> task = Task.Factory.StartNew(SlowOperation);

            for (int i = 0; i < 10; i++)
            {
                Console.WriteLine(i);
            }

            Console.WriteLine(task.Result);
            Console.WriteLine("Thread main method end=> "+Thread.CurrentThread.ManagedThreadId);

            Console.ReadKey();
        }

        private static int SlowOperation()
        {
            Console.WriteLine("Thread slow method start=>" + Thread.CurrentThread.ManagedThreadId);

            Thread.Sleep(3000);

            Console.WriteLine("Thread slow method end=>" + Thread.CurrentThread.ManagedThreadId);

            return 123;
        }
    }
}
