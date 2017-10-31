using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ConsoleApp1ASync
{
    class Program
    {
        static void Main(string[] args)
        {
            Task<int> res = SlowMethod();

            for (int i = 0; i < 10; i++)
            {
                Console.WriteLine(i);
            }
            Console.WriteLine(res.Result);
            Console.WriteLine("Thread main end=> " + Thread.CurrentThread.ManagedThreadId);

            Console.ReadKey();
        }

        public static async Task<int> SlowMethod()
        {
            Console.WriteLine("Thread slow method start=> "+Thread.CurrentThread.ManagedThreadId);

            await Task.Delay(3000);

            Console.WriteLine("Thread  slow method end=> " + Thread.CurrentThread.ManagedThreadId);

            return 123;
        }

    }
}
