using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ConsoleApp1TPL
{
    class Program
    {
        static void Main(string[] args)
        {
            //synhron
            var res = SlowOperation();

            for (int i = 0; i < 10; i++)
            {
                Console.WriteLine(i);
            }

            Console.WriteLine(res);
            Console.WriteLine("Thread=>"+Thread.CurrentThread.ManagedThreadId);

            Console.ReadKey();
        }


        private static int SlowOperation()
        {
            Console.WriteLine("Thread=>" + Thread.CurrentThread.ManagedThreadId);

            Thread.Sleep(3000);

            Console.WriteLine("Thread=>" + Thread.CurrentThread.ManagedThreadId);

            return 123;
        }
    }
}
