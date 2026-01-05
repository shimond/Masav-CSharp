using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ConsoleAppTest
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine(Thread.CurrentThread.ManagedThreadId);
            Console.WriteLine("Main started"); //1
            //var t = TestAsync();
            //t.ContinueWith(x=> {
            //    Console.WriteLine("ContinueWith Finished"); //9
            //});
            _ = TestAsync();
            TestAsync().Wait();
            Console.WriteLine("Main Finished"); //8
            Console.Read();

        }

        static async Task TestAsync()
        {
            Console.WriteLine(Thread.CurrentThread.ManagedThreadId);
            Console.WriteLine("TestAsync 1"); //2
            Console.WriteLine("TestAsync WOW"); //3
            await Task.Delay(1000);
            await DoTheLoop();
            Console.WriteLine("TestAsync WOW"); //6
            Console.WriteLine("TestAsync 2");//7
        }

        static async Task DoTheLoop()
        {

            for (int i = 0; i < 10; i++)
            {
                await Task.Delay(1000);
                Console.WriteLine("DoTheLoop:" + i); //4
            }
            DoTheLoopSync();
        }

        static void DoTheLoopSync() //5
        {

            Console.WriteLine("DoTheLoopSync!!");
        }


    }
}
