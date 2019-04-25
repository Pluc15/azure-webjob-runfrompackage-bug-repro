using System;
using System.Threading;
using System.Threading.Tasks;

namespace SomeConsoleApp
{
    class Program
    {
        static void Main(string[] args)
        {
            var running = true;
            var cts = new CancellationTokenSource();
            Console.CancelKeyPress += (s, e) =>
            {
                running = false;
                cts.Cancel();
            };
            while (running)
            {
                Console.WriteLine("Hello World!");
                Task.Delay(1000, cts.Token).GetAwaiter().GetResult();
            }
        }
    }
}
