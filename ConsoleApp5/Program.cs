using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ConsoleApp5
{
    class Program
    {
        public static void Main(string[] args)
        {

            doJob().Wait();
            simpledo();

            MyTask myTask = new MyTask();
            myTask.dotheJob().Wait();

            Console.ReadKey();

        }

        private static async Task doJob()
        {
            await Task.Run(() =>
            {
                for (int i = 0; i < 10; i++)
                {
                    Thread.Sleep(1000);
                    Console.WriteLine("\n Method do the job");

                    Task.Delay(1000).Wait();
                }

            });
        }

        private static void simpledo()
        {
            for (int i = 0; i < 5; i++)
            {
                Thread.Sleep(1000);
                Console.WriteLine("\n Method simple do");

                Task.Delay(1000).Wait();
            }
        }



        class MyTask
        {


            public async Task dotheJob()
            {
                int a = await doSomethingAsync(10);
                return;
            }

            private async Task<int> doSomethingAsync(int v)
            {
                return await Task.Run(() =>
                {

                    Thread.Sleep(1000);
                    Console.WriteLine("\n doSomethingAsync");
                    Console.Write("\n " + (v * 2));
                    return v * 2;

                });
            }
        }

    }


}