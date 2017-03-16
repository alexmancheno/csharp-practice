using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace testingTPL
{
    class Program
    {
        static void Main(string[] args)
        {
            Dictionary<CancellationToken, Task> tasks = new Dictionary<CancellationToken, Task>();
            var ts = new CancellationTokenSource();
            CancellationToken ct = ts.Token;
            //var ts = new CancellationTokenSource().Token;
            tasks.Add(ct, Task.Factory.StartNew(() =>
            {
                int i = 0;
                while (!ts.IsCancellationRequested)
                {
                    Thread.Sleep(1000);
                    Console.Write(i);
                    i++;
                }
            }, ct));

            //ts.Cancel();
            
            Console.WriteLine("Press any key");
            Console.ReadKey();
        }

        
    }
}
