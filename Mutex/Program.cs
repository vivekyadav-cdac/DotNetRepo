namespace MutexExample
{
    internal class Program
    {
        private static int criticalSection = 0;
        private static Mutex mutex = new Mutex();
        static void Main(string[] args)
        {
           for(int i  = 0; i < 5; i++)
            {
                Thread thread = new Thread(DoWork);
                thread.Start();
            }
        }

        static void DoWork()
        {
            Console.WriteLine($"Thread {Thread.CurrentThread.ManagedThreadId} waiting...");
            
            mutex.WaitOne();

            Console.WriteLine($"Thread{Thread.CurrentThread.ManagedThreadId} entered critical section");

            for(int i = 0;i < 5;i++)
            {
                Thread.Sleep(1000);
                Console.WriteLine(criticalSection++);
            }

            mutex.ReleaseMutex();

            Console.WriteLine($"Thread{Thread.CurrentThread.ManagedThreadId} released Mutex.");
        }
    }
}
