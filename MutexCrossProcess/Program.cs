using System.Security.Cryptography;

namespace MutexCrossProcess
{
    public class Program
    {
        public static Mutex _appMutex;
        public static bool _createdNew;
        static void Main(string[] args)
        {
            _appMutex = new Mutex(true,"Global\\MutexCrossProcessApp",out _createdNew);

            if(!_createdNew )
            {
                Console.WriteLine("another instance is already running. Exiting..");
                Console.ReadKey();
                return;
            }
            try
            {
                Console.WriteLine("application started - single instance");
                _appMutex.ReleaseMutex();
                var class1 = new Class1();
                var class2 = new Class2();

                var thread1 = new Thread(() => class1.DoWork("Class1"));
                var thread2 = new Thread(() => class2.DoWork("Class2"));

                thread1.Start();
                thread2.Start();

                thread1.Join();
                thread2.Join();

                Console.WriteLine("All work completed. Press any key to exit...");
            }
            finally
            {
                if (_createdNew)
                {
                    _appMutex.Dispose();
                }
            }

            Console.ReadKey();

        }
    }

    public class Class1
    {
        public void DoWork(string className)
        {
            Console.WriteLine($"{className} is waiting to do work...");

            Program._appMutex.WaitOne();

            try
            {
                Console.WriteLine($"{className} has enetered critical section");

                Thread.Sleep(2000);

                Console.WriteLine($"{className} has completed its work");
            }
            finally
            {
                Program._appMutex.ReleaseMutex();
                Console.WriteLine($"{className} released the mutex");
            }

        }
    }

    public class Class2
    {
        public void DoWork(string className)
        {
            Console.WriteLine($"{className} is waiting to do work...");

            if (Program._appMutex.WaitOne(3000))
            {
                try
                {
                    Console.WriteLine($"{className} has enetered critical section");

                    Thread.Sleep(2000);

                    Console.WriteLine($"{className} has completed its work");
                }
                finally
                {
                    Program._appMutex.ReleaseMutex();
                    Console.WriteLine($"{className} released the mutex");
                }
            }
            else
            {
                Console.WriteLine($"{className} couldn't get the mutex in time");
            }

        }
    }
}
